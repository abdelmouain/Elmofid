﻿using Elmofid.Application.Common.Interfaces.Authentication;
using Elmofid.Application.Common.Interfaces.Persistence;
using Elmofid.Application.Common.Interfaces.Services;
using Elmofid.Infrastructure.Authentication;
using Elmofid.Infrastructure.Persistence.Authentication;
using Elmofid.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elmofid.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
