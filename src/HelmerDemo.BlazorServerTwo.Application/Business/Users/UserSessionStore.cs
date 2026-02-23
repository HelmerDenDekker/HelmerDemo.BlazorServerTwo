using System.Collections.Concurrent;
using Serilog;

namespace HelmerDemo.BlazorServerTwo.Application.Business.Users;

// In memory store that persists the state of users
public class UserSessionStore
{
    private ConcurrentDictionary<Guid, UserSessionState> UserSessionStates { get; } = new();

    public UserSessionState? FindById(Guid userId)
    {
        var isRetrieved = UserSessionStates.TryGetValue(userId, out var model);
        return isRetrieved ? model : null;
    }
    
    public void Add(Guid id, UserSessionState userState)
    {
        if (!UserSessionStates.TryAdd(id, userState))
            Log.Error("Adding key {id} to dictionary failed: key already exists", id);
    }
    
    public void RemoveById(Guid id)
    {
        if (!UserSessionStates.TryRemove(id, out _))
            Log.Error("Removal of key {id} in dictionary failed: key not found", id);
    }
}