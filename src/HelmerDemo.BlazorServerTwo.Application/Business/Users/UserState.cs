namespace HelmerDemo.BlazorServerTwo.Application.Business.Users;

/// <summary>
///     Holds the user state and domain logic. Has a custom lifetime. // TODO, it is NOT about the session. It is Shared
///     state.
/// </summary>
public class UserState
{
    public UserState()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; }

    public bool LoggedIn { get; private set; }

    // Behavior
    public void Login()
    {
        LoggedIn = true;
    }

    public void Logout()
    {
        LoggedIn = false;
    }
}