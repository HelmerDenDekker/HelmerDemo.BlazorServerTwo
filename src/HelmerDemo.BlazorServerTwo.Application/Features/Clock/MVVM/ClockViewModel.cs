using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace HelmerDemo.BlazorServerTwo.Application.Features.Clock.MVVM;

public class ClockViewModel : IClockViewModel, IDisposable
{
    private readonly Subject<ClockModel> _clockSubject = new();
    private readonly IDisposable _subscription;

    public ClockViewModel()
    {
        Model = new ClockModel(DateTime.Now);
        // Source:
        var ticks = Observable.Timer(
            TimeSpan.Zero,
            TimeSpan.FromSeconds(1));
        // Subscribe
        _subscription = ticks.Subscribe(_ =>
        {
            Model = Model.AddSecond();
            _clockSubject.OnNext(Model);
        },
        e => OnError(e.Message)
        );
    }

    public ClockModel Model { get; private set; }
    public IObservable<ClockModel> WhenTimeChanged => _clockSubject;


    public void Dispose()
    {
        _subscription.Dispose();
        _clockSubject.Dispose();
    }
    
    private void OnError(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; private set; } = string.Empty;
}

// for blazor, we can inject the interface. For a Maui application, newing up performs better.
public interface IClockViewModel : IDisposable
{
    public ClockModel Model { get; }
    public IObservable<ClockModel> WhenTimeChanged { get; }

    public string ErrorMessage { get; }
}