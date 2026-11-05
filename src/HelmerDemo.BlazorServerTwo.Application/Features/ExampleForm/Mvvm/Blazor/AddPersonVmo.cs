using System.ComponentModel.DataAnnotations;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Shared.Domain;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvvm.Blazor;

public class AddPersonVmo
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
}