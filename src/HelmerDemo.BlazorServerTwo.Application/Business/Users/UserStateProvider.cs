using System.Reactive.Subjects;

namespace HelmerDemo.BlazorServerTwo.Application.Business.Users;

/// <summary>
///     This class provides the <see cref="UserState" /> to viewmodels in a stateless way. Its lifetime is scoped. It
///     fetches stuff from the UserState the ViewModel needs.
/// </summary>
public class UserStateProvider : IUserStateProvider, IDisposable
{
    private readonly IUserStateStore _userStateStore;

    private readonly BehaviorSubject<UserStateDto> _userStateSubject;

    public UserStateProvider(IUserStateStore userStateStore)
    {
        _userStateStore = userStateStore;
        _userStateSubject = new BehaviorSubject<UserStateDto>(this.ToDto());
    }
    
    public bool IsLoading { get; private set; } = true;

    public IObservable<UserStateDto> WhenStateChanged()
    {
        return _userStateSubject;
    }

    public Guid UserId { get; private set; }

    public UserDto Create()
    {
        var state = new UserState();
        _userStateStore.Add(state);
        UserId = state.Id;
        IsLoading = false;
        _userStateSubject.OnNext(this.ToDto());

        return new UserDto(state.Id);
    }

    public void Rehydrate(UserDto user)
    {
        var userState = _userStateStore.FindById(user.Id);

        // UserState exists in browser, not in memory.
        if (userState == null)
        {
            userState = new UserState(user.Id);
            _userStateStore.Add(userState);
        }

        UserId = userState.Id;
        IsLoading = false;
        _userStateSubject.OnNext(this.ToDto());
    }

    public void Dispose()
    {
        _userStateSubject.Dispose();
    }
}

public interface IUserStateProvider
{
    public Guid UserId { get; }

    public bool IsLoading { get; }

    public UserDto Create();

    public void Rehydrate(UserDto resultValue);

    public IObservable<UserStateDto> WhenStateChanged();
}