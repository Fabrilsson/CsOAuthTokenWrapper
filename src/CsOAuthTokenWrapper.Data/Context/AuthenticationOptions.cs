namespace CsOAuthTokenWrapper.Data.Context
{
    public class AuthenticationOptions : IAuthenticationOptions
    {
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string Scope { get; }
        public string GrantType { get; }
        public string OAuthTokenEndPoint { get; }

        public AuthenticationOptions(
            string clientId,
            string clientSecret,
            string scope,
            string grantType,
            string oAuthTokenEndPoint)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scope = scope;
            GrantType = grantType;
            OAuthTokenEndPoint = oAuthTokenEndPoint;
        }
    }
}