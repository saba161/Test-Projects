using System.Reflection;
using Application.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class RegisterService
{
    public static void ConfigureApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(typeof(MovieProfile));
    }
}