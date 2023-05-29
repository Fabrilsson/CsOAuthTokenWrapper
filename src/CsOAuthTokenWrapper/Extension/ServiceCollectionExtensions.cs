using CsOAuthTokenWrapper.Data.Context;
using CsOAuthTokenWrapper.Data.Extensions;
using CsOAuthTokenWrapper.Wrapper;
using Microsoft.Extensions.DependencyInjection;

namespace CsOAuthTokenWrapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOAuthTokenWrapper(this IServiceCollection services, Func<IAuthenticationOptionsBuilder, IAuthenticationOptions> builder)
        {
            services.AddDataDependencies(builder.Invoke(new AuthenticationOptionsBuilder()));
            services.AddScoped<IOAuthTokenProviderWrapper, OAuthTokenProviderWrapper>();

            return services;
        }
    }
}
