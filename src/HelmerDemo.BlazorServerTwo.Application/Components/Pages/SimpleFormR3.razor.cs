using HelmerDemo.BlazorServerTwo.Application.Features.SimpleForm.R3;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using R3;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class SimpleFormR3 : ComponentBase, IDisposable
{
    public MessageR3ViewModel Model { get; set; } = new MessageR3ViewModel();
    
    public string EnteredContent { get; set; } = string.Empty;
    
    private EditContext _editContext { get; set; }
    private InputTextArea _inputTextReference;
    private IDisposable? _subscription;

    protected override void OnInitialized()
    {
        _subscription = Model.Content.Subscribe(message =>
        {
            EnteredContent = message;
            InvokeAsync(StateHasChanged);
        });
        _editContext = new EditContext(Model.Content);
    }
    
    public void Dispose()
    {
        Model.Dispose();
        _subscription?.Dispose();
    }
}