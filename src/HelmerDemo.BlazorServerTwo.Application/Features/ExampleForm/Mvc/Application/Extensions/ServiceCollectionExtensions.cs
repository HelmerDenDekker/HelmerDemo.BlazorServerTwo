using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Domain;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.Mvc.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExampleFormMvcApplication(this IServiceCollection services)
    {
        services.AddSingleton<PersonsDomainModel>();
        services.AddScoped<ICommitPersonsService, CommitPersonsService>();
        return services;
    }
}