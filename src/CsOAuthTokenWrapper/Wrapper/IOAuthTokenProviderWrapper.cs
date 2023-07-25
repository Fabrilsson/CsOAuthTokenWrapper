using CsOAuthTokenWrapper.Data.Result;

namespace CsOAuthTokenWrapper.Wrapper
{
    public interface IOAuthTokenProviderWrapper<T>
    {
        AuthResult AcquireToken(int timeoutBudget = 30);

        Task<AuthResult> AcquireTokenAsync(int timeoutBudget = 30);
    }
}