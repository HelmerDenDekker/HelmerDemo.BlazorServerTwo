using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Shared.Domain;
using HelmerDemo.BlazorServerTwo.Shared;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application;

/// <summary>
/// This is like an API controller.
/// </summary>
public class CommitPersonsService : ICommitPersonsService
{
    private readonly PersonsDomainModel _personsDomainModel;

    public CommitPersonsService(PersonsDomainModel personsDomainModel)
    {
        _personsDomainModel = personsDomainModel;
    }
    
    /// <inheritdoc/>
    public async Task<List<PersonSummaryDto>> GetAllPersonsAsync()
    {
        return _personsDomainModel.Persons.Select(p => new PersonSummaryDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName
        }).ToList();
    }

    /// <inheritdoc/>
    public async Task<Result> AddPersonAsync(AddPersonDto addPersonDto)
    {
        // validation (again, like in the old days. Always do input validation...) OR, in this case, leave it up to the domain.
        
        // add to the domain
        var result = _personsDomainModel.AddPerson(new AddPerson
        {
            FirstName = addPersonDto.FirstName,
            LastName = addPersonDto.LastName,
            Gender = addPersonDto.Gender
        });
        
        // persist to the database here.
        
        return result;
    }
}

public interface ICommitPersonsService
{
    /// <summary>
    /// Query style!!
    /// </summary>
    /// <returns></returns>
    public Task <List<PersonSummaryDto>> GetAllPersonsAsync();
    
    /// <summary>
    /// Command style!!
    /// </summary>
    /// <param name="addPersonDto"></param>
    /// <returns></returns>
    public Task<Result> AddPersonAsync(AddPersonDto addPersonDto);
}