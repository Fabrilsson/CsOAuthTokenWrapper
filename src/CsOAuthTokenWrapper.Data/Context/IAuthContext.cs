using CsOAuthTokenWrapper.Data.Result;

namespace CsOAuthTokenWrapper.Data.Context
{
    internal interface IAuthContext
    {
        Task<AuthResult> AcquireTokenAsync();
    }
}