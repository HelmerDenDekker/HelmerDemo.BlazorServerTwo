namespace HelmerDemo.BlazorServerTwo.Application.Business.Users;

/// <summary>
///     This class provides the <see cref="UserState" /> to viewmodels in a stateless way. Its lifetime is scoped. It
///     fetches stuff from the UserState the ViewModel needs.
/// </summary>
public class UserStateProvider(IUserStateStore userStateStore) : IUserStateProvider
{
    public bool IsLoading { get; private set; } = true;
    // TODO: The UserStateProvider can be in a Loading state. => Before requesting the Guid, check the state. Maybe come back for it? WhenLoaded?

    public Guid UserId { get; private set; }

    public UserDto Create()
    {
        var state = new UserState();
        userStateStore.Add(state);
        UserId = state.Id;
        IsLoading = false;

        return new UserDto(state.Id);
    }

    public void Rehydrate(UserDto user)
    {
        var userState = userStateStore.FindById(user.Id);
        if (userState == null)
            // TODO, something clearly went wrong. Implement clean exception handling here. For now, we just throw an exception.
            throw new Exception($"UserState with id {user.Id} not found");

        UserId = userState.Id;
        IsLoading = false;
    }
}

public interface IUserStateProvider
{
    public Guid UserId { get; }

    public UserDto Create();

    public void Rehydrate(UserDto resultValue);
}