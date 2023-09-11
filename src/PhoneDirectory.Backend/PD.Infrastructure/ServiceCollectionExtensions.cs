using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneDirectory.Backend.Infrastructure.Configs;

namespace PhoneDirectory.Backend.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureSettingsOptions(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AuthConfig>(config.GetSection(AuthConfig.Key));
        services.Configure<DatabaseConfig>(config.GetSection(DatabaseConfig.Key));

        return services;
    }
}