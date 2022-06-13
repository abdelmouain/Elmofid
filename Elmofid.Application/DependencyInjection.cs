using Elmofid.Application.Services.Authenticaton;
using Microsoft.Extensions.DependencyInjection;

namespace Elmofid.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
