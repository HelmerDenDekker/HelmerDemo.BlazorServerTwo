using System.Collections.Concurrent;
using Serilog;

namespace HelmerDemo.BlazorServerTwo.Application.Features.Users;

// In memory store that persists the state of users
public class UserStateStore : IUserStateStore
{
    private ConcurrentDictionary<Guid, UserState> UserStates { get; } = new();

    public UserState? FindById(Guid userId)
    {
        var isRetrieved = UserStates.TryGetValue(userId, out var model);
        return isRetrieved ? model : null;
    }
    
    public void Add(UserState userState)
    {
        if (!UserStates.TryAdd(userState.Id, userState))
            Log.Error("Adding key {id} to dictionary failed: key already exists", userState.Id);
    }
    
    public void RemoveById(Guid id)
    {
        if (!UserStates.TryRemove(id, out _))
            Log.Error("Removal of key {id} in dictionary failed: key not found", id);
    }
}

public interface IUserStateStore
{
    public UserState? FindById(Guid userId);
    public void Add(UserState userState);

    public void RemoveById(Guid id);
}