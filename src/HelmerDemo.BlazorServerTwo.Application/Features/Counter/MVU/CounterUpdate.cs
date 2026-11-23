using Serilog;

namespace HelmerDemo.BlazorServerTwo.Application.Features.Counter.MVU;

public static class CounterUpdate
{
    // functional and immutable, so always create a new model.
    public static CounterModel Update(CounterModel model, CounterMessage message)
    {
        return message switch
        {
            CounterMessage.Increment => new CounterModel(model.Count + 1),
            _ => model
        };
    }
    
    // any additional operations, such as fetching or logging should be handled in the update layer, or delegated to an external service
    public static CounterModel UpdateWithLogging(CounterModel model, CounterMessage message)
    {
        Log.Information("Received message: {Message}", message);
        return Update(model, message);
    }
}