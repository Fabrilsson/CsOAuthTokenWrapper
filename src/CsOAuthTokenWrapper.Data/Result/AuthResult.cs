namespace CsOAuthTokenWrapper.Data.Result
{
    public class AuthResult
    {
        public string? AccessTokenType { get; }

        public string? AccessToken { get; }

        public DateTimeOffset ExpiresOn { get; }

        public bool ExtendedLifeTimeToken { get; }

        public string? TenantId { get; }

        public string? IdToken { get; }

        public string? Authority { get; }

        public AuthResult(
            string? accessTokenType,
            string? accessToken,
            DateTimeOffset expiresOn,
            bool extendedLifeTimeToken,
            string? tenantId,
            string? idToken,
            string? authority)
        {
            AccessTokenType = accessTokenType;
            AccessToken = accessToken;
            ExpiresOn = expiresOn;
            ExtendedLifeTimeToken = extendedLifeTimeToken;
            TenantId = tenantId;
            IdToken = idToken;
            Authority = authority;
        }
    }
}
