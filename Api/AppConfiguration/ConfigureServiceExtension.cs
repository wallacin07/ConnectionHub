using System.Linq.Expressions;
using Api.Core.Services;
using Api.Domain.Services;

namespace Api.Configuration;

public static partial class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureEntitiesServices (this IServiceCollection services) 
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ICommentService, CommentService>();
        return services;
    }
}