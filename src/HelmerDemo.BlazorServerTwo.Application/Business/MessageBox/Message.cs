namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

public class Message
{
    public Message(string content)
    {
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    public string Content { get; }
    public DateTime CreatedAt { get; }
}