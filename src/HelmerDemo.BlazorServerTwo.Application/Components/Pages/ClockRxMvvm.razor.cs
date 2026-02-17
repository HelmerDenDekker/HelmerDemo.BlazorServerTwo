using HelmerDemo.BlazorServerTwo.Application.Business.Clock.MVVM;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

/// <summary>
/// Clock component using MVVM and Rx.NET. The ViewModel is injected and the component subscribes to the time changes.
/// The ViewModel is responsible for the logic.
/// The ViewModel is responsible for changing state
/// The Model is responsible for the properties and domain logic.
/// The component is responsible for rendering the UI and subscribing to changes.
/// </summary>
public partial class ClockRxMvvm : ComponentBase, IDisposable
{
    private IDisposable? _subscription;
    
    [Inject]
    private IClockViewModel? ClockViewModel { get; set; }
    
    protected override void OnInitialized()
    {
        // Subscribe
        _subscription = ClockViewModel.WhenTimeChanged.Subscribe(
            time =>
            {
                InvokeAsync(StateHasChanged);
            }
            );
    }

    public void Dispose()
    {
        ClockViewModel?.Dispose();
        _subscription?.Dispose();
    }
}