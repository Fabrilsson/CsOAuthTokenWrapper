namespace CsOAuthTokenWrapper.Data.Context
{
    public class AuthenticationOptionsBuilder : IAuthenticationOptionsBuilder
    {
        private string _clientId;
        private string _clientSecret;
        private string _scope;
        private string _grantType;
        private string _authority;

        public void SetAuthority(string authority)
            => _authority = authority;        

        public void SetClientId(string clientId)
            => _clientId = clientId;

        public void SetClientSecret(string clientSecret)
            => _clientSecret = clientSecret;

        public void SetGrantType(string grantType)
            => _grantType = grantType;

        public void SetScope(string scope)
            => _scope = scope;

        public IAuthenticationOptions Build()
        {
            if (string.IsNullOrEmpty(_authority))
                throw new ArgumentNullException(nameof(_authority));

            if (string.IsNullOrEmpty(_clientId))
                throw new ArgumentNullException(nameof(_clientId));

            if (string.IsNullOrEmpty(_clientSecret))
                throw new ArgumentNullException(nameof(_clientSecret));

            if (string.IsNullOrEmpty(_grantType))
                throw new ArgumentNullException(nameof(_grantType));

            if (string.IsNullOrEmpty(_scope))
                throw new ArgumentNullException(nameof(_scope));

            return new AuthenticationOptions(
                _clientId,
                _clientSecret,
                _scope,
                _grantType,
                _authority
            );
        }
    }
}