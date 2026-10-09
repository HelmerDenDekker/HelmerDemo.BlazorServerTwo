using HelmerDemo.BlazorServerTwo.Application.Features.SharedPageState;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Features.SharedPageState;

public partial class CpsUser : ComponentBase
{
    [CascadingParameter]
    public CascadingPageState PageState { get; set; }

    // private copy of the AppState data
    IPageState state;

    protected override void OnInitialized()
    {
        state = PageState.GetCopy();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // Check for changes
        if (PageState.Message != state.Message)
        {
            // Message has changed
            state.Message = PageState.Message;
        }
    }
}