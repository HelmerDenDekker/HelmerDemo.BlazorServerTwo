namespace HelmerDemo.BlazorServerTwo.Application.Components.MVVM;

// Model in MVVM contains the properties, state and logic (Domain logic!)
public class CounterModel
{
    public CounterModel(int count)
    {
        Count = count;
    }
    
    public int Count { get; private set; }

    // domain logic is in the domain model, not the viewModel
    public void Increment()
    {
        Count++;
    }
}