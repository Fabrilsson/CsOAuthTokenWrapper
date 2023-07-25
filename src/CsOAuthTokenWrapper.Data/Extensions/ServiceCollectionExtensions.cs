using CsOAuthTokenWrapper.Data.Client;
using CsOAuthTokenWrapper.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CsOAuthTokenWrapper.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services, IAuthenticationOptions authenticationOptions)
        {
            services.AddSingleton<HttpClient>();
            services.AddSingleton<IAuthNetworkClient, AuthNetworkClient>();

            return services;
        }
    }
}