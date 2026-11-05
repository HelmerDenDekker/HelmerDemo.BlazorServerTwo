using HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.AsyncCommit.Application.Domain;

namespace HelmerDemo.BlazorServerTwo.Application.Features.ExampleForm.AsyncCommit.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExampleFormAsyncCommitApplication(this IServiceCollection services)
    {
        services.AddSingleton<PersonsDomainModel>();
        services.AddScoped<ICommitPersonsService, CommitPersonsService>();
        return services;
    }
}