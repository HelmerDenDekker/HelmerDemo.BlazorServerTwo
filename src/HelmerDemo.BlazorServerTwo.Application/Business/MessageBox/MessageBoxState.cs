namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

/// <summary>
/// There is one state per user session.
/// When creating a state, I need the user session Id.
/// 
/// </summary>
public class MessageBoxState
{
    public List<Message> Messages { get; private set; } = new();
    
    public string MessageFormText { get; private set; } = string.Empty;
    
    // TODO: Behavior like Add etc.
}