namespace CsOAuthTokenWrapper.Data.Context
{
    public interface IAuthenticationOptions
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string Scope { get; }
        string GrantType { get; }
        string OAuthTokenEndPoint { get; }
    }
}