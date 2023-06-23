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
        public double ExpiresInSeconds { get; }

        public readonly DateTime ReceivalDate;

        public readonly DateTime ExpiresOn;

        public AuthResult(
            string? accessTokenType,
            string? accessToken,
            double expiresInSeconds,
            int expirationOffsetInSeconds = 300)
        {
            AccessTokenType = accessTokenType;
            AccessToken = accessToken;
            ExpiresInSeconds = expiresInSeconds;

            var dateTime = DateTime.UtcNow;

            ExpiresOn = dateTime.AddSeconds(ExpiresInSeconds - expirationOffsetInSeconds);
            ReceivalDate = dateTime;
        }
    }
}
