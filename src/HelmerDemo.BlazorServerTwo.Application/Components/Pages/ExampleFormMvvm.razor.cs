using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvvm.Blazor;
using Microsoft.AspNetCore.Components;

namespace HelmerDemo.BlazorServerTwo.Application.Components.Pages;

public partial class ExampleFormMvvm : ComponentBase
{
    [Inject]
    public IPersonsViewModel ViewModel { get; set; } = default!;
    
    protected override async Task OnInitializedAsync()
    {
        await ViewModel.InitializeAsync();
    }
}