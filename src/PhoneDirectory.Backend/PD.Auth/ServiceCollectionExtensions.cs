using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhoneDirectory.Backend.Infrastructure.Configs;

namespace PD.Auth;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        var authConfigModel = configuration.GetSection(AuthConfig.Key).Get<AuthConfig>();
        if (authConfigModel is null)
        {
            return services;
        }

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
            {
                x.ClaimsIssuer = authConfigModel.Issuer;
                x.Audience = authConfigModel.Audience;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authConfigModel.Issuer,
                    ValidAudience = authConfigModel.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.ASCII.GetBytes(authConfigModel.SecretKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddAuthorization();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}