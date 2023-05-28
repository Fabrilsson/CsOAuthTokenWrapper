using CsOAuthTokenWrapper.Data.Extensions;
using CsOAuthTokenWrapper.Wrapper;
using Microsoft.Extensions.DependencyInjection;

namespace CsOAuthTokenWrapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOAuthTokenWrapper(this IServiceCollection services)
        {
            services.AddDataDependencies();
            services.AddScoped<IOAuthTokenProviderWrapper, OAuthTokenProviderWrapper>();

            return services;
        }
    }
}
