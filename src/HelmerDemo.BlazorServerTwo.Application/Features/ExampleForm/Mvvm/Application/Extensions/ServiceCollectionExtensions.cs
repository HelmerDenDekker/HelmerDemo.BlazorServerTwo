using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvvm.Blazor;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvvm.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExampleFormMvvmApplication(this IServiceCollection services)
    {
        services.AddSingleton<PersonsDomainModel>();
        services.AddSingleton<IPersonsViewModel, PersonsViewModel>();
        
        services.AddScoped<ICommitPersonsService, CommitPersonsService>();
        
        return services;
    }
}