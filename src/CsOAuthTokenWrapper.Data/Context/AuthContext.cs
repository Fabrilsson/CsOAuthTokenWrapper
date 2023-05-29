using CsOAuthTokenWrapper.Data.Client;
using CsOAuthTokenWrapper.Data.Requests;
using CsOAuthTokenWrapper.Data.Resources;
using CsOAuthTokenWrapper.Data.Result;
using CsOAuthTokenWrapper.Data.Serializer;

namespace CsOAuthTokenWrapper.Data.Context
{
    internal sealed class AuthContext : IAuthContext
    {
        private readonly IAuthNetworkClient _authNetworkClient;
        private readonly IJsonSerializer _serializer;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _scope;
        private readonly string _grantType;
        private readonly string _oAuthTokenEndPoint;

        public AuthContext(
            IAuthNetworkClient authNetworkClient,
            IJsonSerializer jsonSerializer,
            IAuthenticationOptions authenticationOptions)
        {
            _authNetworkClient = authNetworkClient;
            _serializer = jsonSerializer;
            _clientId = authenticationOptions.ClientId;
            _clientSecret = authenticationOptions.ClientSecret;
            _scope = authenticationOptions.Scope;
            _grantType = authenticationOptions.GrantType;
            _oAuthTokenEndPoint = authenticationOptions.OAuthTokenEndPoint;
        }

        public async Task<AuthResult> AcquireTokenAsync()
        {
            var request = new OAuthTokenRequest(_clientId, _clientSecret, _scope, _grantType);

            using var resource = new OAuthTokenResource(_serializer, request, _oAuthTokenEndPoint);

            var response = await _authNetworkClient.RemoteCallAsync<AuthResult>(resource);

            return response;
        }
    }
}
