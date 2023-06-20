using CsOAuthTokenWrapper.Data.Client;
using CsOAuthTokenWrapper.Data.Context;
using CsOAuthTokenWrapper.Data.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace CsOAuthTokenWrapper.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services, IAuthenticationOptions authenticationOptions)
        {
            services.AddSingleton<HttpClient>();
            services.AddScoped<IAuthNetworkClient, AuthNetworkClient>();
            services.AddSingleton(authenticationOptions);
            services.AddScoped<IAuthContext, AuthContext>();
            services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();

            return services;
        }
    }
}