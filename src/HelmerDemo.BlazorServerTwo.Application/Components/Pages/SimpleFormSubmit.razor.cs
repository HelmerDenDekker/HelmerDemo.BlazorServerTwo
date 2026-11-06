using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class SimpleFormSubmit : ComponentBase
{
    
    [Required(AllowEmptyStrings = false)]
    [MaxLength(1000)]
    public string Content { get; set; } = string.Empty;
    
    public string SubmittedContent { get; set; } = string.Empty;
    
    private EditContext? _editContext { get; set; }
    private InputTextArea _inputTextReference;
    
    protected override void OnInitialized()
    {
        _editContext = new EditContext(Content);
    }
    
    private void ValidSubmitEventHandler(EditContext obj)
    {
        SubmittedContent = Content;
        Content = string.Empty;
        
        InvokeAsync(StateHasChanged);
    }
}