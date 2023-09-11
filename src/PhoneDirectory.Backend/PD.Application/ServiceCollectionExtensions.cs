using Microsoft.Extensions.DependencyInjection;
using PhoneDirectory.Backend.Application.Interfaces.Services;
using PhoneDirectory.Backend.Application.Services;

namespace PhoneDirectory.Backend.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IPhoneAppService, PhoneAppService>();
        services.AddScoped<IUserAppService, UserAppService>();

        return services;
    }
}