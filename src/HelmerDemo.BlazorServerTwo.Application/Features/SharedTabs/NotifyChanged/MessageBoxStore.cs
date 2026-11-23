using System.Collections.Concurrent;
using Serilog;

namespace HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs.NotifyChanged;

public class MessageBoxStore : NotifyChanged.IMessageBoxStore
{
    private ConcurrentDictionary<Guid, MessageBoxState> UserMessageBoxStates { get; } = new();
    
    public MessageBoxState? FindById(Guid userId)
    {
        var isRetrieved = UserMessageBoxStates.TryGetValue(userId, out var model);
        return isRetrieved ? model : null;
    }

    public void Add(Guid userId, MessageBoxState boxState)
    {
        if (!UserMessageBoxStates.TryAdd(userId, boxState))
            Log.Error($"Adding key {userId} to dictionary failed: key already exists");
    }

    public void RemoveById(Guid id)
    {
        if (!UserMessageBoxStates.TryRemove(id, out _))
            Log.Error($"Removal of key {id} in dictionary failed: key not found");
    }
}