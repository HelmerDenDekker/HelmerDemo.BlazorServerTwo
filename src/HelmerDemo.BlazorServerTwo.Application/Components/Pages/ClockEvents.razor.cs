using System.Timers;
using HelmerDemo.BlazorServerTwo.Application.Features.Clock;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

/// <summary>
/// Real simple example of the clock with the Timer.
/// This is a more classic Blazor example with all logic in the code-behind.
/// There are much simpler ways to do this, but this is to demonstrate the use of events and timers in Blazor.
/// </summary>
public partial class ClockEvents : ComponentBase, IDisposable
{
    /// <summary>
    /// The digital time in the frontend
    /// </summary>
    private DigitalTime CurrentTime = new(DateTime.Now);

    private System.Timers.Timer? _timer;

    /// <summary>
    /// overrides <see cref="OnAfterRender"/> event to subscribe to the listener and start the timer  
    /// </summary>
    /// <param name="firstRender"></param>
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            // Subscribe to the listener
            _timer.Elapsed += OnTimeUpdated;
            _timer.AutoReset = true;
            // Start the timer
            _timer.Enabled = true;
        }
        base.OnAfterRender(firstRender);
    }
		
    /// <summary>
    /// During prerender, this component is rendered without calling OnAfterRender and then immediately disposed this means timer will be null so we have to check for null or use the Null-conditional operator ? 
    /// </summary>
    public void Dispose()
    {
        if (_timer != null)
        {
            _timer.Elapsed -= OnTimeUpdated;
        }
        _timer?.Dispose();
    }
	
    /// <summary>
    /// The event listener, listening to an external event
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    private void OnTimeUpdated(object source, ElapsedEventArgs e)
    {
        CurrentTime = CurrentTime.AddSecond();
        InvokeAsync(StateHasChanged);
    }
}