using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using HelmerDemo.BlazorServerTwo.Application.Business.Users;
using HelmerDemo.BlazorServerTwo.Shared.Validation;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

public class EditMessageBoxViewModel : IEditMessageBoxViewModel, IDisposable
{
    private readonly IUserStateProvider _userStateProvider;
    private readonly IMessageBoxStore _store;
    private IDisposable? _userStateSubscription;
    private readonly Subject<Unit> _stateChangedSubject;
    private MessageBoxState? _state;
    private IDisposable _stateSubscription;

    public EditMessageBoxViewModel(IUserStateProvider userStateProvider, IMessageBoxStore store)
    {
        _userStateProvider = userStateProvider;
        _store = store;
        _stateChangedSubject = new Subject<Unit>();
    }
    
    public IObservable<Unit> WhenStateChanged() => _stateChangedSubject;

    public ViewModelStateEnum ViewModelState { get; private set; } = ViewModelStateEnum.Loading;
    public string ErrorMessage { get; private set; } = string.Empty;

    public void Initialize()
    {
        _userStateSubscription = _userStateProvider.WhenStateChanged().Where(u=>u.State == ViewModelStateEnum.Ready).Subscribe(_ => InitializeState());
    }

    public string MessageFormText { get; set; } = string.Empty;
    
    public void Submit()
    {
        _state.Submit();
    }

    public bool Validate()
    {
        return _state.IsValid(_state);
    }

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

        _state.MessageFormText.Subscribe(s => )
        
        MessageFormText = _state.MessageFormText;
        ViewModelState = ViewModelStateEnum.Ready;
        
        // TODO couple changes to state and viewModel. (will this round-trip? Better to use PropertyChanged stuff here!)
        _stateSubscription = _state.WhenStateChanged().Subscribe(_ => _stateChangedSubject.OnNext(Unit.Default));
        
    }

    public void Dispose()
    {
        _userStateSubscription?.Dispose();
            _stateSubscription?.Dispose();
            _state?.Dispose();
            _stateChangedSubject.Dispose();
    }
}

public interface IEditMessageBoxViewModel
{
    public ViewModelStateEnum ViewModelState { get; }
    string ErrorMessage { get; }
    void Initialize();
    
    IObservable<Unit> WhenStateChanged();
    
    public string MessageFormText { get; set; }
    void Submit();
    bool Validate();
}