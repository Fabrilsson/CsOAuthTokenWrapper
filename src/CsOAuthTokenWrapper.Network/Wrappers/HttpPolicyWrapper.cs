using Polly;

namespace CsOAuthTokenWrapper.Network.Wrappers
{
    internal static class HttpPolicyWrapper
    {
        internal static AsyncPolicy GetAsyncPolicy()
        {
            return Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(10));
        }
    }
}
