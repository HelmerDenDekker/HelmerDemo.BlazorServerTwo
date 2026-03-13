using System.ComponentModel;
using HelmerDemo.BlazorServerTwo.Application.Business.MessageBox.NotifyChanged;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Shared;

/// <summary>
///     In web, it is possible to have multiple tabs open, having the same content.
///     In n tabs, I want to show the same message box with the same content.
/// </summary>
public partial class EditMessageBox : ComponentBase, IDisposable
{
    protected EditContext _editContext;
    private InputTextArea _inputTextReference;

    [Inject] private IEditMessageBoxViewModel ViewModel { get; set; }

    public void Dispose()
    {
        ViewModel.PropertyChanged -= NotifyFieldChangedHandler;
    }

    protected override void OnInitialized()
    {
        ViewModel.Initialize();
        _editContext = new EditContext(ViewModel.MessageFormText);
        ViewModel.PropertyChanged += NotifyFieldChangedHandler;
    }

    private void NotifyFieldChangedHandler(object? sender, PropertyChangedEventArgs e)
    {
        StateHasChanged();
    }

    private void Submit(EditContext obj)
    {
        var isValid = ViewModel.Validate();

        if (isValid)
            ViewModel.Submit();
    }

    private void MessageTextInputEventHandler(ChangeEventArgs obj)
    {
        // TODO: Think about it. Blazor already couples the input to the ViewModel.
        // There can only be one ViewModel in EditMode.
        // We can take the advantage of streams to process, and subscribe
    }

    private void MessageTextKeyUpEventHandler(KeyboardEventArgs obj)
    {
        if (obj.Key == "Enter" || obj.Key == "NumpadEnter") Submit(_editContext);
    }
}