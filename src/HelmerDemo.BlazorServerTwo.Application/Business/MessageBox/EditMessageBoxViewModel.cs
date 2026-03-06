using HelmerDemo.BlazorServerTwo.Application.Business.Users;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

public class EditMessageBoxViewModel : IEditMessageBoxViewModel
{
    private readonly IUserStateProvider _userStateProvider;
    private readonly IMessageBoxStore _store;

    public EditMessageBoxViewModel(IUserStateProvider userStateProvider, IMessageBoxStore store)
    {
        _userStateProvider = userStateProvider;
        _store = store;
    }

    public ViewModelStateEnum ViewModelState { get; private set; } = ViewModelStateEnum.Loading;
    public string ErrorMessage { get; private set; } = string.Empty;

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

    public string MessageFormText { get; set; } = string.Empty;
    public void Submit()
    {
        throw new NotImplementedException();
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

        MessageFormText = state.MessageFormText;
        ViewModelState = ViewModelStateEnum.Ready;
    }
}

public interface IEditMessageBoxViewModel
{
    public ViewModelStateEnum ViewModelState { get; }
    string ErrorMessage { get; }
    void Initialize();
    
    public string MessageFormText { get; set; }
    void Submit();
}