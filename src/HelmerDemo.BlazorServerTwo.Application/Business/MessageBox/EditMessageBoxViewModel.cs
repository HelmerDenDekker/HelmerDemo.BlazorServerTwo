using System.Reactive.Linq;
using HelmerDemo.BlazorServerTwo.Application.Business.Users;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

public class EditMessageBoxViewModel : IEditMessageBoxViewModel, IDisposable
{
    private readonly IUserStateProvider _userStateProvider;
    private readonly IMessageBoxStore _store;
    private IDisposable? _userStateSubscription;

    public EditMessageBoxViewModel(IUserStateProvider userStateProvider, IMessageBoxStore store)
    {
        _userStateProvider = userStateProvider;
        _store = store;
    }

    public ViewModelStateEnum ViewModelState { get; private set; } = ViewModelStateEnum.Loading;
    public string ErrorMessage { get; private set; } = string.Empty;

    public void Initialize()
    {
        _userStateSubscription = _userStateProvider.WhenStateChanged().Where(u=>u.State == ViewModelStateEnum.Ready).Subscribe(_ => InitializeState());
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

    public void Dispose()
    {
        _userStateSubscription?.Dispose();
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