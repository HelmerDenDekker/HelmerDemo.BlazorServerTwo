using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;
using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Actor;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExampleFormActorApplication(this IServiceCollection services)
    {
        services.AddSingleton<PersonsDomainModel>();
        
        return services;
    }
}