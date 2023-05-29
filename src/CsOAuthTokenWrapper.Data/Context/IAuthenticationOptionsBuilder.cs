namespace CsOAuthTokenWrapper.Data.Context
{
    public interface IAuthenticationOptionsBuilder
    {
        void SetClientId(string clientId);
        void SetClientSecret(string clientSecret);
        void SetScope(string scope);
        void SetGrantType(string grantType);
        void SetAuthority(string authority);
        IAuthenticationOptions Build();
    }
}