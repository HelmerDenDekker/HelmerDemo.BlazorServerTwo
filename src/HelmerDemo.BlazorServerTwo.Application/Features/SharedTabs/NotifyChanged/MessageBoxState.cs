using System.ComponentModel;
using System.Runtime.CompilerServices;
using HelmerDemo.BlazorServerTwo.Shared.Validation;

namespace HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs.NotifyChanged;

/// <summary>
///     There is one state per user session.
///     When creating a state, I need the user session Id.
/// </summary>
public class MessageBoxState : BaseValidator<MessageBoxState>, INotifyPropertyChanged
{
    public List<Message> Messages
    {
        get;
    } = new();

    //[Required(AllowEmptyStrings = false, ErrorMessage = "Message form text is required.")]
    //[MaxLength(1000, ErrorMessage = "Message form text cannot exceed 1000 characters.")]
    public string MessageFormText
    {
        get;
        private set => SetField(ref field, value);
    } = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    // TODO: Behavior like Add etc.

    public void Submit()
    {
        // TODO Validation?
        Messages.Add(new Message(MessageFormText));
        MessageFormText = string.Empty;
        OnPropertyChanged(nameof(Messages));
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Is continuously checking for equality too expensive?
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);

        return true;
    }

    public void UpdateMessageFormText(string messageFormText)
    {
        MessageFormText = messageFormText;
    }
}