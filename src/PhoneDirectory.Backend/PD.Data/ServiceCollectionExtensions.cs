using Microsoft.Extensions.DependencyInjection;
using PhoneDirectory.Backend.Data.Contexts;

namespace PhoneDirectory.Backend.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureData(this IServiceCollection services)
    {
        services.AddDbContext<PhoneDirectoryContext>();
        return services;
    }
}