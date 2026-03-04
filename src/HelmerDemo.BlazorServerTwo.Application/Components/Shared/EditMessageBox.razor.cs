using System.Reactive.Subjects;
using HelmerDemo.BlazorServerTwo.Application.Business.MessageBox;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Shared;

/// <summary>
/// In web, it is possible to have multiple tabs open, having the same content.
/// In n tabs, I want to show the same message box with the same content.
/// </summary>
public partial class EditMessageBox : ComponentBase
{
    protected EditContext _editContext;
    
    [Inject]
    private IEditMessageBoxViewModel ViewModel { get; set; }
    
    protected override void OnInitialized()
    {
        ViewModel.Initialize();
        _editContext = new EditContext(ViewModel.MessageFormText);
    }
    
    private void Submit(EditContext obj)
    {
        ViewModel.Submit();
    }
    
    private void MessageTextInputEventHandler(ChangeEventArgs obj)
    {
        _inputStream.OnNext(MessageInput.Content);
    }
	
    private void MessageTextKeyUpEventHandler(KeyboardEventArgs obj)
    {
        if (obj.Key == "Enter" || obj.Key == "NumpadEnter")
        {
            Submit(_editContext);
        }
    }
}