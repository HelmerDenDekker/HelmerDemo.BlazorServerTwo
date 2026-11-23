using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvvm.Blazor;

public static class PersonAdapter
{
    public static PersonSummaryVmo ToSummaryVmo(this Person person)
    {
        return new PersonSummaryVmo
        {
            Id = person.Id,
            FullName = person.FirstName + " " + person.LastName
        };
    }
}