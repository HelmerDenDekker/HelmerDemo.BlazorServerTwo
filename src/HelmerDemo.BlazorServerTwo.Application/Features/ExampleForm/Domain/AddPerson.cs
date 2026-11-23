namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;

public class AddPerson
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
}