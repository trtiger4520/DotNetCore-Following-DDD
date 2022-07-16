using System.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Application.Common.Interfaces.Authentication;
using System.Application.Common.Interfaces.Services;
using System.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace System.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}