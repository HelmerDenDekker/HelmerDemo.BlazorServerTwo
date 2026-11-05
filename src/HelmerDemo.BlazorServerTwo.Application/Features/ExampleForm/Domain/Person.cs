namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;

/// <summary>
/// There can be all kinds of stuff in here that is relevant to the domain model.
/// </summary>
public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}