using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Blazor;
using HelmerDemo.BlazorServerTwo.Shared.Extensions;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

/// <summary>
/// The razor page is like the view. This code-behind is like the javascript in the View, it takes care of the events and the state of the view. (ViewState)
/// </summary>
public partial class ExampleFormMvc : ComponentBase
{
    [Inject]
    private ICommitPersonsService CommitPersonsService { get; set; } = null!;
    
    private ExampleFormViewState ExampleFormViewState { get; } = new();

    protected override async Task OnInitializedAsync()
    {
        var result = await CommitPersonsService.GetAllPersonsAsync();
        ExampleFormViewState.People = result.Select(p => p.ToViewState()).ToList();
    }
    
    private string _validationErrorMessage = string.Empty;
    
    private async Task AddPersonFormSubmitAsync()
    {
        _validationErrorMessage = string.Empty;
        // validation
        if (ExampleFormViewState.AddPersonViewState.FirstName.IsNullOrWhiteSpace())
        {
            _validationErrorMessage = "First name is required.";
            return;
        }
        
        if (ExampleFormViewState.AddPersonViewState.LastName.IsNullOrWhiteSpace())
        {
            _validationErrorMessage = "Last name is required.";
            return;
        }
        
        var addPersonDto = ExampleFormViewState.AddPersonViewState.ToDto();
        var addResult = await CommitPersonsService.AddPersonAsync(addPersonDto);
        // TODO: handle addResult error, if any. For now, we assume it is successful.
        
        // reset form
        ExampleFormViewState.AddPersonViewState = new AddPersonViewState();
        // refresh list
        var result = await CommitPersonsService.GetAllPersonsAsync();
        ExampleFormViewState.People = result.Select(p => p.ToViewState()).ToList();
    }
}