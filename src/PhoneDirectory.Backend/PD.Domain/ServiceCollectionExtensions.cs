using Microsoft.Extensions.DependencyInjection;
using PhoneDirectory.Backend.Domain.Interfaces.Services;
using PhoneDirectory.Backend.Domain.Services;

namespace PhoneDirectory.Backend.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IPhoneService, PhoneService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}