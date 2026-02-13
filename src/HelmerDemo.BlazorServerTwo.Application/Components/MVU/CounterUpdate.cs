using Serilog;

namespace HelmerDemo.BlazorServerTwo.Application.Components.MVU;

public static class CounterUpdate
{
    // functional and immutable, so always create a new model.
    public static CounterModel Update(CounterModel model, CounterMessageEnum message)
    {
        return message switch
        {
            CounterMessageEnum.Increment => new CounterModel(model.Count + 1),
            _ => model
        };
    }
    
    // any additional operations, such as fetching or logging should be handled in the update layer, or delegated to an external service
    public static CounterModel UpdateWithLogging(CounterModel model, CounterMessageEnum message)
    {
        Log.Information("Received message: {Message}", message);
        return Update(model, message);
    }
}