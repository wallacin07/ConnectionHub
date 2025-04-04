using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Repositories;
using Genesis.Core.Repositories;

namespace Api.Configuration;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureRepositoriesEntities(this IServiceCollection services)
    {
        services.AddScoped<BaseRepository<User>, UserRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}