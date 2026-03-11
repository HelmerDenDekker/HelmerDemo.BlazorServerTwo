using R3;

namespace HelmerDemo.BlazorServerTwo.Application.Business.Counter.R3;

public class CounterViewModel : IDisposable
{
    private CompositeDisposable _disposables = new();
    public ReactiveProperty<int> Counter { get; }

    public ReactiveCommand IncrementCommand { get; }

    public CounterViewModel()
    {
        Counter = new ReactiveProperty<int>(0)
            .AddTo(_disposables);

        IncrementCommand = Counter.Select(x => x < 10)
            .ToReactiveCommand()
            .AddTo(_disposables);
        IncrementCommand.Subscribe(_ => Increment())
            .AddTo(_disposables);
    }

    private void Increment()
    {
        Counter.Value++;
    }

    public void Dispose() => _disposables.Dispose();
}