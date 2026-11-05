using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Shared.Domain;
using HelmerDemo.BlazorServerTwo.Shared.Extensions;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvvm.Blazor;

public class PersonsViewModel : IPersonsViewModel
{
    private readonly PersonsDomainModel _domainModel;

    public PersonsViewModel(PersonsDomainModel domainModel)
    {
        _domainModel = domainModel;
    }
    
    public ViewModelState State { get; private set; } = ViewModelState.Loading;
    
    public string ErrorMessage { get; private set; } = string.Empty;
    public List<PersonSummaryVmo> People { get; private set; } = new();

    public AddPersonVmo AddPersonModel { get; set; } = new();
    
    public async Task AddPersonAsync()
    {
        // you could block the frontEnd by showing loading, or not care about it. In that case, create some kind of queue.
        
        // validation - or let the domain do that.
        var addPerson = new AddPerson
        {
            FirstName = AddPersonModel.FirstName,
            LastName = AddPersonModel.LastName,
            Gender = AddPersonModel.Gender
        };
        
        var addResult = _domainModel.AddPerson(addPerson);
        
        if (!addResult.IsSuccess())
        {
            // TODO: This blocks the frontend, and makes it impossible for te user to correct. Better error handling.
            ErrorMessage = "Invalid input.";
            State = ViewModelState.Error;
            return;
        }
        
        // update list
        People = _domainModel.Persons.Select(p => p.ToSummaryVmo()).ToList();
        
        // reset the form
        AddPersonModel = new AddPersonVmo();
    }

    public async Task InitializeAsync()
    {
        // go to the db to get the data needed.
        
        // initialize the DomainModel if it does not exist yet.
        People = _domainModel.Persons.Select(p => p.ToSummaryVmo()).ToList();
        
        // on error set Error state.
        
        State = ViewModelState.Ready;
    }
}

public interface IPersonsViewModel
{
    public ViewModelState State { get; }

    public string ErrorMessage { get; }
    
    public List<PersonSummaryVmo> People { get; } 

    public Task AddPersonAsync();
    
    public Task InitializeAsync();
    
    public AddPersonVmo AddPersonModel { get; set; }
}