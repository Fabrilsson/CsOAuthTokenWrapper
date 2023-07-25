using CsOAuthTokenWrapper.Data.Client;
using CsOAuthTokenWrapper.Data.Context;
using CsOAuthTokenWrapper.Data.Extensions;
using CsOAuthTokenWrapper.Data.Provider;
using CsOAuthTokenWrapper.Wrapper;
using Microsoft.Extensions.DependencyInjection;

namespace CsOAuthTokenWrapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOAuthTokenWrapper<T>(this IServiceCollection services, Func<IAuthenticationOptionsBuilder, IAuthenticationOptions> builder) where T: class
        {
            services.AddDataDependencies(builder.Invoke(new AuthenticationOptionsBuilder()));
            services.AddScoped(sp =>
            {
                return new OAuthTokenProviderWrapper<T>(
                    new AuthTokenProvider(
                        new AuthContext(
                            sp.GetRequiredService<IAuthNetworkClient>(),
                            builder.Invoke(new AuthenticationOptionsBuilder()
                            )
                        )
                    )
                );
            });

            return services;
        }
    }
}
