using HelmerDemo.BlazorServerTwo.Shared;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;

/// <summary>
/// The domain is modeled as a singleton here, not as a good example, but as a quick domain representation. A domain can be scoped, or have its own lifetime.
/// </summary>
public class PersonsDomainModel
{
    public List<Person> Persons { get; set; } = new();
    
    public Result AddPerson(AddPerson addPerson)
    {
        if (string.IsNullOrWhiteSpace(addPerson.FirstName))
        {
            return Result.BadRequest;
        }
        
        if (string.IsNullOrWhiteSpace(addPerson.LastName))
        {
            return Result.BadRequest;
        }
        
        var person = new Person
        {
            FirstName = addPerson.FirstName,
            LastName = addPerson.LastName,
            Gender = addPerson.Gender
        };
        
        Persons.Add(person);
        
        return Result.Created;
    }
}