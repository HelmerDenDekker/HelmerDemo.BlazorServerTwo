namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application;

public class PersonSummaryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}