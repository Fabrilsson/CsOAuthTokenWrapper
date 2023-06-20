using Newtonsoft.Json;

namespace CsOAuthTokenWrapper.Data.Requests
{
    internal sealed class OAuthTokenRequest
    {
        public string? client_id { get; }

        public string? client_secret { get; }

        public string? scope { get; }

        public string? grant_type { get; }

        internal OAuthTokenRequest(
            string? clientID,
            string? clientSecret,
            string? scope,
            string? grantType)
        {
            this.client_id = clientID;
            this.client_secret = clientSecret;
            this.scope = scope;
            this.grant_type = grantType;
        }
    }
}
