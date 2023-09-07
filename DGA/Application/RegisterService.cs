using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class RegisterService
{
    public static void ConfigureApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
        services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}