namespace HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs.NotifyChanged;

public interface IMessageBoxStore
{
    public MessageBoxState? FindById(Guid userId);
    public void Add(Guid userId, MessageBoxState boxState);

    public void RemoveById(Guid id);
}