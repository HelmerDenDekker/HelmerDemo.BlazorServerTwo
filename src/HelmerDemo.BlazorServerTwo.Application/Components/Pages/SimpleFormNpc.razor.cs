using System.ComponentModel;
using HelmerDemo.BlazorServerTwo.Application.Features.SimpleForm.Npc;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class SimpleFormNpc : ComponentBase, IDisposable
{
    private EditContext? _editContext { get; set; }
    private InputTextArea _inputTextReference;
    private MessageNpcViewModel Model { get; set; } = new MessageNpcViewModel();
    public string EnteredContent { get; set; } = string.Empty;
    
    protected override void OnInitialized()
    {
        Model.PropertyChanged += UpdateEnteredContent;
        _editContext = new EditContext(Model.Content);
    }

    private void UpdateEnteredContent(object? sender, PropertyChangedEventArgs e)
    {
        EnteredContent = Model.Content;
    }

    public void Dispose()
    {
        Model.PropertyChanged -= UpdateEnteredContent;
    }
}