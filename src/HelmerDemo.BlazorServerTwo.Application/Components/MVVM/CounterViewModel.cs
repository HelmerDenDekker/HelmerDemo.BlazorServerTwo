namespace HelmerDemo.BlazorServerTwo.Application.Components.MVVM;

// The ViewModel in MVVM binds the Model to the View. It contains properties and commands that the View can bind to.
public class CounterViewModel
{
    public CounterViewModel()
    {
        Model = new CounterModel(0);
    }

    public CounterModel Model { get; }

    public void IncrementCount()
    {
        // Add any side effects or application-type logic here. Domain logic belongs in the model!
        Model.Increment();
    }
}