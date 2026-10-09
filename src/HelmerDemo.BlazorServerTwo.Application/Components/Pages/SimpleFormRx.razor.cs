using HelmerDemo.BlazorServerTwo.Application.Features.SimpleForm.Rx;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class SimpleFormRx : ComponentBase, IDisposable
{
    public MessageRxViewModel Model { get; set; } = new MessageRxViewModel();
    
    public string EnteredContent { get; set; } = string.Empty;
    
    private EditContext _editContext { get; set; }
    private InputTextArea _inputTextReference;
    private IDisposable? _subscription;

    protected override void OnInitialized()
    {
        _subscription = Model.WhenMessageChanged().Subscribe(message =>
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