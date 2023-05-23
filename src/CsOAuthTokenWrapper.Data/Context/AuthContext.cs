using CsOAuthTokenWrapper.Data.Client;
using CsOAuthTokenWrapper.Data.Requests;
using CsOAuthTokenWrapper.Data.Resources;
using CsOAuthTokenWrapper.Data.Result;
using CsOAuthTokenWrapper.Data.Serializer;

namespace CsOAuthTokenWrapper.Data.Context
{
    internal class AuthContext
    {
        private readonly IAuthNetworkClient _authNetworkClient;
        private readonly IJsonSerializer _serializer;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _scope;
        private readonly string _grantType;
        private readonly string _authority;

        internal AuthContext(
            IAuthNetworkClient authNetworkClient,
            IJsonSerializer jsonSerializer,
            string clientId,
            string clientSecret,
            string scope,
            string grantType,
            string authority)
        {
            _authNetworkClient = authNetworkClient;
            _serializer = jsonSerializer;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scope = scope;
            _grantType = grantType;
            _authority = authority;
        }

        internal async Task<AuthResult> AcquireTokenAsync()
        {
            var request = new OAuthTokenRequest(_clientId, _clientSecret, _scope, _grantType);

            using var resource = new OAuthTokenResource(_serializer, request);

            var response = await _authNetworkClient.RemoteCallAsync<AuthResult>(resource);

            return response;
        }
    }
}
