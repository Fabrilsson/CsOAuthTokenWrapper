using CsOAuthTokenWrapper.Data.Client;
using CsOAuthTokenWrapper.Data.Context;
using CsOAuthTokenWrapper.Data.Provider;
using CsOAuthTokenWrapper.Data.Serializer;
using Microsoft.Extensions.DependencyInjection;

namespace CsOAuthTokenWrapper.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddScoped<IAuthNetworkClient, AuthNetworkClient>();
            services.AddScoped<IJsonSerializer, JsonSerializer>();
            services.AddScoped<IAuthContext, AuthContext>();
            services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();

            return services;
        }
    }
}