namespace HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs;

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