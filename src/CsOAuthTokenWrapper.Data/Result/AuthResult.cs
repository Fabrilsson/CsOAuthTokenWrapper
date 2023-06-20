using Newtonsoft.Json;

namespace CsOAuthTokenWrapper.Data.Result
{
    public sealed class AuthResult
    {
        [JsonProperty("token_type")]
        public string? AccessTokenType { get; }

        [JsonProperty("access_token")]
        public string? AccessToken { get; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; }

        public AuthResult(
            string? accessTokenType,
            string? accessToken,
            double expiresIn)
        {
            AccessTokenType = accessTokenType;
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }
    }
}
