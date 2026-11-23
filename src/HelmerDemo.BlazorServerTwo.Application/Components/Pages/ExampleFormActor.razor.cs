using HelmerDemo.BlazorServerTwo.Application.Features;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Actor;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class ExampleFormActor : ComponentBase
{
    public IExampleFormActor Actor { get; set; } = default!;

    private ViewState State { get; set; } = ViewState.Loading;
    private string ErrorMessage { get; set; } = string.Empty;
    
    private List<PersonSummaryVso> People { get; set; } = new();
    private AddPersonVso AddPersonModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        // retrieve the actor from an Actorservice.
        // I want a memcache. default. I want a combo of Usersession and ActorId to get me the right actor. Custom DI.
        // It should be a dictionary of userSessionKey, that has a dictionary of Actors. There needs to be an order.
        // TODO: Pick it up from here, another day, including subscriptions, initialization etc.
    }

    private Task AddPersonAsync()
    {
        throw new NotImplementedException();
    }
}

internal class PersonSummaryVso
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = string.Empty;
}

internal class AddPersonVso
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Other;
}