using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using HelmerDemo.BlazorServerTwo.Application.Business.Users;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

/// <summary>
///     Binds the MessageBoxState to the view. It follows the lifetime of the view (circuit).
///     When creating a ViewModel I need the UserSessionId from somewhere.
///     How do I know which user I am dealing with? As CascadingParameter? I DO think that will work for Blazor.
/// </summary>
public class MessageBoxViewModel : IMessageBoxViewModel, IDisposable
{
    private readonly IMessageBoxStore _store;
    private readonly IUserStateProvider _userStateProvider;
    private readonly Subject<Unit> _stateChangedSubject;
    private IDisposable? _userStateSubscription;

    public MessageBoxViewModel(IUserStateProvider userStateProvider, IMessageBoxStore store)
    {
        _userStateProvider = userStateProvider;
        _store = store;
        _stateChangedSubject = new Subject<Unit>();
    }

    public void Dispose()
    {
        _userStateSubscription?.Dispose();
        _stateChangedSubject.Dispose();
    }

    // properties for view binding
    public ViewModelStateEnum ViewModelState { get; private set; } = ViewModelStateEnum.Loading;
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
        var state = _store.FindById(_userStateProvider.UserId);

        // new user
        if (state == null)
        {
            state = new MessageBoxState();
            _store.Add(_userStateProvider.UserId, state);
        }

        state.Messages.Subscribe(m => Messages = m.Value )
        ViewModelState = ViewModelStateEnum.Ready;
        _stateChangedSubject.OnNext(Unit.Default);
    }
}

public interface IMessageBoxViewModel
{
    public ViewModelStateEnum ViewModelState { get; }
    string ErrorMessage { get; }

    public List<MessageDto> Messages { get; }
    IObservable<Unit> WhenStateChanged();

    void Initialize();
}