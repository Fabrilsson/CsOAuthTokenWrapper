using CsOAuthTokenWrapper.Data.Result;

namespace CsOAuthTokenWrapper.Data.Context
{
    public interface IAuthContext
    {
        Task<AuthResult> AcquireTokenAsync();

        string ContextId { get; }
    }
}