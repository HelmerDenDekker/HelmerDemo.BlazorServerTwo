using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application;

public class AddPersonDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
}