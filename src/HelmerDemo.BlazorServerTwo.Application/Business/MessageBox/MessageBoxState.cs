using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System.Reactive.Subjects;
using HelmerDemo.BlazorServerTwo.Shared.Validation;
using R3;

namespace HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;

/// <summary>
///     There is one state per user session.
///     When creating a state, I need the user session Id.
/// </summary>
public class MessageBoxState : BaseValidator<MessageBoxState>
{

    public ReactiveProperty<List<Message>> Messages { get; private set; } = new(new());
    
    //[Required(AllowEmptyStrings = false, ErrorMessage = "Message form text is required.")]
    //[MaxLength(1000, ErrorMessage = "Message form text cannot exceed 1000 characters.")]
    public ReactiveProperty<string> MessageFormText { get; private set; } = new(string.Empty);

    // TODO: Behavior like Add etc.
    
    public void Submit()
    {
        // TODO Validation?
        Messages.Value.Add(new Message(MessageFormText.Value));
        MessageFormText.Value = string.Empty;
    }
}