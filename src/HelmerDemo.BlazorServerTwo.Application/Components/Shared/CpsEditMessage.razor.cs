using HelmerDemo.BlazorServerTwo.Application.Business.CascadingPageState;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Shared;

public partial class CpsEditMessage : ComponentBase, IPageState
{
    [CascadingParameter]
    public CascadingPageState PageState { get; set; }
    
    private void MessageTextKeyUpEventHandler(KeyboardEventArgs obj)
    {
        if (obj.Key == "Enter" || obj.Key == "NumpadEnter")
            Submit(_editContext);
    }

    private void Submit(EditContext editContext)
    {
        PageState.Message = Message;
        Message = string.Empty;
    }
    
    protected EditContext _editContext;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(Message);
        
    }
    public string Message { get; set; } = string.Empty;
}