using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Blazor;

public static class PersonViewStateAdapter
{
    public static AddPersonDto ToDto(this AddPersonViewState addPersonViewState)
    {
        return new AddPersonDto
        {
            FirstName = addPersonViewState.FirstName,
            LastName = addPersonViewState.LastName,
            Gender = addPersonViewState.Gender
        };
    }
    
    public static PersonSummaryViewState ToViewState(this PersonSummaryDto personSummaryDto)
    {
        return new PersonSummaryViewState
        {
            Id = personSummaryDto.Id,
            FullName = $"{personSummaryDto.FirstName} {personSummaryDto.LastName}"
        };
    }
}