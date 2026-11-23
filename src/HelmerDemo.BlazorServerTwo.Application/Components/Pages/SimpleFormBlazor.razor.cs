using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class SimpleFormBlazor : ComponentBase
{
    [Required(AllowEmptyStrings = false)]
    [MaxLength(1000)]
    public string Content { get; set; } = string.Empty;
    
    public string EnteredContent { get; set; } = string.Empty;
    
    private EditContext? _editContext { get; set; }
    private InputTextArea _inputTextReference;
    
    protected override void OnInitialized()
    {
        _editContext = new EditContext(Content);
    }

    private void MessageTextInputEventHandler(ChangeEventArgs obj)
    {
        EnteredContent = Content;
    }
}