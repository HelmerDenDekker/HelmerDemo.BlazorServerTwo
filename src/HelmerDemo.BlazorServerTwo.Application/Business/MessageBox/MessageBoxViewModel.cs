namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

public class MessageBoxViewModel : IMessageBoxViewModel
{
    
}

public interface IMessageBoxViewModel
{
    public IObservable<Message> WhenMessageChanged { get; }
}