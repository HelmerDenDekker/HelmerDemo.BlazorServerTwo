using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using HelmerDemo.BlazorServerTwo.Application.Features.Users;

namespace HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs.NotifyChanged;

// TODO: Remove or comment out the code that does not work and add remarks why it does not work.
/// <summary>
/// I tried to create an EditBox that shows the same (typed) message in all the views open to the user. This is quite impossible however! You will get into a loop, since you do NEVER know what viewmodel is "THE" source of truth. A better way to do this, may be to have a warning or something
/// </summary>
public class EditMessageBoxViewModel : IEditMessageBoxViewModel
{
    private readonly IMessageBoxStore _store;
    private readonly IUserStateService _userStateProvider;
    private MessageBoxState? _state;
    private IDisposable _stateSubscription;
    private IDisposable? _userStateSubscription;

    public EditMessageBoxViewModel(IUserStateService userStateProvider, IMessageBoxStore store)
    {
        _userStateProvider = userStateProvider;
        _store = store;
    }

    public void Dispose()
    {
        _state?.PropertyChanged -= OnStatePropertyChangedHandler;
        _userStateSubscription?.Dispose();
        _stateSubscription?.Dispose();
    }

    public ViewModelStateEnum ViewModelState { get; private set; } = ViewModelStateEnum.Loading;
    public string ErrorMessage { get; private set; } = string.Empty;

    public void Initialize()
    {
        _userStateSubscription = _userStateProvider.WhenStateChanged().Where(u => u.State == ViewModelStateEnum.Ready)
            .Subscribe(_ => InitializeState());
    }

    // blazor view updates this field automatically => means user is typing. It can also mean auto-update (by listening to MessageBoxState). TODO This will cause conflict! I can keep EditMode or UpdateMode and make it switch?
    public string MessageFormText { get;
        set => SetField(ref field, value);
    } = string.Empty;

    public void Submit()
    {
        if (_state.IsValid(_state))
        {
            _state.Submit();
            return;
        }
        
        // TODO: Data annotations validation in form
        ErrorMessage = _state.Results.FirstOrDefault()?.ErrorMessage ?? "An error occurred while submitting the message.";
        ViewModelState = ViewModelStateEnum.Error;
    }

    public bool Validate()
    {
        return _state.IsValid(_state);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void InitializeState()
    {
        // get State
        _state = _store.FindById(_userStateProvider.UserId);

        if (_state == null)
        {
            ViewModelState = ViewModelStateEnum.Error;
            ErrorMessage = "Could not retrieve state for user session.";
            return;
        }

        _state.PropertyChanged += OnStatePropertyChangedHandler;

        MessageFormText = _state.MessageFormText;
        ViewModelState = ViewModelStateEnum.Ready;
    }

    private void OnStatePropertyChangedHandler(object? sender, PropertyChangedEventArgs e)
    {
        // TODO: all these string comparisons are very expensive!
        if (e.PropertyName == nameof(MessageBoxState.MessageFormText))
        {
            MessageFormText = _state.MessageFormText;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MessageFormText)));
        }
    }
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Is continuously checking for equality too expensive?
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);

        return true;
    }
}

public interface IEditMessageBoxViewModel : INotifyPropertyChanged, IDisposable
{
    public ViewModelStateEnum ViewModelState { get; }
    string ErrorMessage { get; }

    public string MessageFormText { get; set; }
    void Initialize();
    void Submit();
    bool Validate();
}