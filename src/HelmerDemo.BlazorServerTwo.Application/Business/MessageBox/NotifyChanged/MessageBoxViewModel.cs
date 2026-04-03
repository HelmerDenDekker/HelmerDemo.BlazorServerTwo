using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using HelmerDemo.BlazorServerTwo.Application.Business.Users;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox.NotifyChanged;

/// <summary>
///     Binds the MessageBoxState to the view. It follows the lifetime of the view (circuit).
///     When creating a ViewModel I need the UserSessionId from somewhere.
///     How do I know which user I am dealing with? As CascadingParameter? I DO think that will work for Blazor.
/// </summary>
public class MessageBoxViewModel : IMessageBoxViewModel, IDisposable
{
    private readonly IMessageBoxStore _store;
    private readonly IUserStateService _userStateProvider;
    private readonly Subject<Unit> _stateChangedSubject;
    private IDisposable? _userStateSubscription;
    private MessageBoxState? _state;

    public MessageBoxViewModel(IUserStateService userStateProvider, IMessageBoxStore store)
    {
        _userStateProvider = userStateProvider;
        _store = store;
        _stateChangedSubject = new Subject<Unit>();
    }

    public void Dispose()
    {
        _state?.PropertyChanged -= OnStatePropertyChangedHandler;
        _userStateSubscription?.Dispose();
        _stateChangedSubject.Dispose();
    }

    // properties for view binding
    public ViewModelStateEnum ViewModelState { get;
        set => SetField(ref field, value);
    } = ViewModelStateEnum.Loading;
    public string ErrorMessage { get; } = string.Empty;

    // Overkill? Or nicely decoupled messages?
    public List<MessageDto> Messages { get; private set; } = new();

    public IObservable<Unit> WhenStateChanged() => _stateChangedSubject;

    public void Initialize()
    {
        _userStateSubscription = _userStateProvider.WhenStateChanged().Where(u => u.State == ViewModelStateEnum.Ready)
            .Subscribe(_ => InitializeState());
    }

    private void InitializeState()
    {
        // try to rehydrate State
        _state = _store.FindById(_userStateProvider.UserId);
        
        // when new user
        if (_state == null)
        {
            _state = new MessageBoxState();
            _store.Add(_userStateProvider.UserId, _state);
        }
        
        _state.PropertyChanged += OnStatePropertyChangedHandler;
        ViewModelState = ViewModelStateEnum.Ready;
        _stateChangedSubject.OnNext(Unit.Default);
    }

    private void OnStatePropertyChangedHandler(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MessageBoxState.Messages))
        {
            Messages = _state.Messages.ToDto();
            _stateChangedSubject.OnNext(Unit.Default);
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}

public interface IMessageBoxViewModel : INotifyPropertyChanged
{
    public ViewModelStateEnum ViewModelState { get; }
    string ErrorMessage { get; }

    public List<MessageDto> Messages { get; }
    IObservable<Unit> WhenStateChanged();

    void Initialize();
}