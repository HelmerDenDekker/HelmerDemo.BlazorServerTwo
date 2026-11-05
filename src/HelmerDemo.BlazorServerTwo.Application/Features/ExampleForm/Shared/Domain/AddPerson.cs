namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Shared.Domain;

public class AddPerson
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
}