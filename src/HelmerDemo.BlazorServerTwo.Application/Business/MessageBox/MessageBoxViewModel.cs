using HelmerDemo.BlazorServerTwo.Application.Business.Users;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

/// <summary>
///     Binds the MessageBoxState to the view. It follows the lifetime of the view (circuit).
///     When creating a ViewModel I need the UserSessionId from somewhere.
///     How do I know which user I am dealing with? As CascadingParameter? I DO think that will work for Blazor.
/// </summary>
public class MessageBoxViewModel : IMessageBoxViewModel
{
    private readonly IMessageBoxStore _store;
    private readonly IUserStateProvider _userStateProvider;

    public MessageBoxViewModel(IUserStateProvider userStateProvider, IMessageBoxStore store)
    {
        _userStateProvider = userStateProvider;
        _store = store;
    }

    // properties for view binding
    public ViewModelStateEnum ViewModelState { get; private set; } = ViewModelStateEnum.Loading;
    public string ErrorMessage { get; private set; } = string.Empty;
    public List<MessageDto> Messages { get; private set; } = new();
    
    public void Initialize()
    {
        // TODO some stupid and way to complex logic because UserProvider filling is async. For now, ask for reload.
        if(_userStateProvider.IsLoading)
        {
            ViewModelState = ViewModelStateEnum.Error;
            ErrorMessage = "User not loaded yet, please refresh later.";
            return;
        }
        InitializeState();
    }

    private void InitializeState()
    {
        // get State
        var state = _store.FindById(_userStateProvider.UserId);

        if (state == null)
        {
            ViewModelState = ViewModelStateEnum.Error;
            ErrorMessage = "Could not retrieve state for user session.";
            return;
        }

        Messages = state.Messages.ToDto();
        ViewModelState = ViewModelStateEnum.Ready;
    }
}

public interface IMessageBoxViewModel
{
    public ViewModelStateEnum ViewModelState { get; }
    string ErrorMessage { get; }

    public List<MessageDto> Messages { get; }

    //public IObservable<Message> WhenMessageChanged { get; }
    void Initialize();
}