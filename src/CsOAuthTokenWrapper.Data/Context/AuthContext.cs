using CsOAuthTokenWrapper.Data.Client;
using CsOAuthTokenWrapper.Data.Requests;
using CsOAuthTokenWrapper.Data.Resources;
using CsOAuthTokenWrapper.Data.Result;

namespace CsOAuthTokenWrapper.Data.Context
{
    public sealed class AuthContext : IAuthContext
    {
        private readonly IAuthNetworkClient _authNetworkClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _scope;
        private readonly string _grantType;
        private readonly string _oAuthTokenEndPoint;

        public string ContextId { get; }

        public AuthContext(
            IAuthNetworkClient authNetworkClient,
            IAuthenticationOptions authenticationOptions)
        {
            _authNetworkClient = authNetworkClient;
            _clientId = authenticationOptions.ClientId;
            _clientSecret = authenticationOptions.ClientSecret;
            _scope = authenticationOptions.Scope;
            _grantType = authenticationOptions.GrantType;
            _oAuthTokenEndPoint = authenticationOptions.OAuthTokenEndPoint;

            ContextId = authenticationOptions.ClientId;
        }

        public async Task<AuthResult> AcquireTokenAsync()
        {
            var request = new OAuthTokenRequest(_clientId, _clientSecret, _scope, _grantType);

            var resource = new OAuthTokenResource(request, _oAuthTokenEndPoint);

            var response = await _authNetworkClient.RemoteCallAsync<AuthResult>(resource);

            return response;
        }
    }
}
