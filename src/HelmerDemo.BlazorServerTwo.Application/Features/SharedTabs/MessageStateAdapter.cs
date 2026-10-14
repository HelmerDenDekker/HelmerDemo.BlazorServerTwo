namespace HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs;

public static class MessageStateAdapter
{
    public static MessageDto ToDto(this Message message)
    {
        return new MessageDto
        {
            Content = message.Content,
            TimeStamp = message.CreatedAt.ToString("HH:mm")
        };
    }

    public static List<MessageDto> ToDto(this List<Message> messages)
    {
        return messages.Select(m => m.ToDto()).ToList();
    }
}