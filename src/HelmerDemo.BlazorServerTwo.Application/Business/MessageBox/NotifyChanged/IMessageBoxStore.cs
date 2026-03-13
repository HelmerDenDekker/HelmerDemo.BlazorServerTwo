namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox.NotifyChanged;

public interface IMessageBoxStore
{
    public MessageBoxState? FindById(Guid userId);
    public void Add(Guid userId, MessageBoxState boxState);

    public void RemoveById(Guid id);
}