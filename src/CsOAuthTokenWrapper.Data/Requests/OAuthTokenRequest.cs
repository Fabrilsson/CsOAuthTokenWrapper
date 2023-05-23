using Newtonsoft.Json;

namespace CsOAuthTokenWrapper.Data.Requests
{
    internal class OAuthTokenRequest
    {
        [JsonProperty("client_id")]
        public string? ClientID { get; }

        [JsonProperty("client_secret")]
        public string? ClientSecret { get; }

        [JsonProperty("scope")]
        public string? Scope { get; }

        [JsonProperty("grant_type")]
        public string? GrantType { get; }

        public OAuthTokenRequest(
            string? clientID,
            string? clientSecret,
            string? scope,
            string? grantType)
        {
            ClientID = clientID;
            ClientSecret = clientSecret;
            Scope = scope;
            GrantType = grantType;
        }
    }
}
