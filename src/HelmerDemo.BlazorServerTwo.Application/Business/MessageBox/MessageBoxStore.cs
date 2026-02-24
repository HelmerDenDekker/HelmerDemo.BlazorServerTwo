using System.Collections.Concurrent;
using Serilog;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

public class MessageBoxStore : IMessageBoxStore
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

public interface IMessageBoxStore
{
    public MessageBoxState? FindById(Guid userId);
    public void Add(Guid userId, MessageBoxState boxState);

    public void RemoveById(Guid id);
}