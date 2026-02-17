using HelmerDemo.BlazorServerTwo.Application.Business.Clock.MVVM;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

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