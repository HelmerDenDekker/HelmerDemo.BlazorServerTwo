namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

/// <summary>
/// Binds the MessageBoxState to the view. It follows the lifetime of the view (circuit).
/// When creating a ViewModel I need the UserSessionId from somewhere. How do I know which user I am dealing with? As CascadingParameter? I DO think that will work for Blazor.
/// </summary>
public class MessageBoxViewModel : IMessageBoxViewModel
{
    
}

public interface IMessageBoxViewModel
{
    //public IObservable<Message> WhenMessageChanged { get; }
}