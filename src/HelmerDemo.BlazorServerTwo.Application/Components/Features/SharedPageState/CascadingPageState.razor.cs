using System.Text.Json;
using HelmerDemo.BlazorServerTwo.Application.Features.SharedPageState;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Features.SharedPageState;

public partial class CascadingPageState : ComponentBase, IPageState
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    
    // Used for tracking changes
    public IPageState GetCopy()
    {
        var state = (IPageState)this;
        var json = JsonSerializer.Serialize(state);
        var copy = JsonSerializer.Deserialize<PageState>(json);
        return copy;
    }
    
    private string message = "";
    public string Message
    {
        get => message;
        set
        {
            message = value;
            // Force a re-render
            StateHasChanged();
        }
    }
    
    protected override void OnInitialized()
    {
        Message = "Initial Message";
    }
}