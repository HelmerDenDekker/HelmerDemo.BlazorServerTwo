namespace HelmerDemo.BlazorServerTwo.Application.Business.Counter.MVU;

// Use records in C# for concise, immutable Models.
// Avoid mutating state directly; instead, use the Update function to create new instances.
// Include validation or constraints within the Model to ensure the state remains valid.

public record CounterModel(int Count);