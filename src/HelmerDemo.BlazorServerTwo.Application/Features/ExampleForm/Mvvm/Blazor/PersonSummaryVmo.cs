namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvvm.Blazor;

public class PersonSummaryVmo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = string.Empty;
}