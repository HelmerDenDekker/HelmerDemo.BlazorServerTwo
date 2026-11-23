using System.ComponentModel.DataAnnotations;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Blazor;

/// <summary>
/// This holds the State of the View. So this is tied to the Blazor, Frontend project. It is aenemic. 
/// </summary>
public class ExampleFormViewState
{
    public List<PersonSummaryViewState> People { get; set; } = new();
    public AddPersonViewState AddPersonViewState { get; set; } = new();
}

/// <summary>
/// Models only to be user in Blazor
/// </summary>
public class PersonSummaryViewState
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = string.Empty;
}

/// <summary>
/// Models only to be user in Blazor
/// </summary>
public class AddPersonViewState
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
}
