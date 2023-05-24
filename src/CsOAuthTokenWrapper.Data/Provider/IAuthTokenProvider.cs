using CsOAuthTokenWrapper.Data.Result;

namespace CsOAuthTokenWrapper.Data.Provider
{
    public interface IAuthTokenProvider
    {
        AuthResult GetAccessToken(int timeoutBudget = 30);

        Task<AuthResult> GetAccessTokenAsync(int timeoutBudget = 30);
    }
}