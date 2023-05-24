using CsOAuthTokenWrapper.Data.Provider;
using CsOAuthTokenWrapper.Data.Result;

namespace CsOAuthTokenWrapper
{
    public class OAuthTokenProviderWrapper
    {
        private readonly IAuthTokenProvider _authTokenProvider;

        public OAuthTokenProviderWrapper(IAuthTokenProvider authTokenProvider)
        {
            _authTokenProvider = authTokenProvider;
        }

        public AuthResult AcquireToken(int timeoutBudget = 30)
            => _authTokenProvider.GetAccessToken(timeoutBudget);

        public async Task<AuthResult> AcquireTokenAsync(int timeoutBudget = 30)
            => await _authTokenProvider.GetAccessTokenAsync(timeoutBudget);
    }
}