using CsOAuthTokenWrapper.Data.Context;
using CsOAuthTokenWrapper.Data.Result;
using Polly;
using Polly.Timeout;

namespace CsOAuthTokenWrapper.Data.Provider
{
    public sealed class AuthTokenProvider : IAuthTokenProvider
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static AuthResult? _authResult;
        private readonly IAuthContext _authContext;

        internal AuthTokenProvider(IAuthContext authContext)
        {
            _authContext = authContext;
        }

        public AuthResult GetAccessToken(int timeoutBudget = 30)
        {
            if (_authResult != null && _authResult.ExpiresOn > DateTimeOffset.UtcNow)
                return _authResult;
            else
            {
                _semaphore.Wait(TimeSpan.FromMinutes(1));

                if (_authResult != null && _authResult.ExpiresOn > DateTimeOffset.UtcNow)
                {
                    _semaphore.Release();
                    return _authResult;
                }

                try
                {
                    var timeout = Policy.Timeout(TimeSpan.FromSeconds(timeoutBudget), TimeoutStrategy.Pessimistic);

                    var retry = Policy.Handle<Exception>().WaitAndRetryForever(i => TimeSpan.FromSeconds(10));

                    var retryTimeout = timeout.Wrap(retry);

                    _authResult = retryTimeout.Execute(() =>
                        _authContext.AcquireTokenAsync().GetAwaiter().GetResult()
                    );
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            return _authResult;
        }

        public async Task<AuthResult> GetAccessTokenAsync(int timeoutBudget = 30)
        {
            if (_authResult != null && _authResult.ExpiresOn > DateTimeOffset.UtcNow)
                return _authResult;
            else
            {
                _semaphore.Wait(TimeSpan.FromMinutes(1));

                if (_authResult != null && _authResult.ExpiresOn > DateTimeOffset.UtcNow)
                {
                    _semaphore.Release();
                    return _authResult;
                }

                try
                {
                    var timeout = Policy.TimeoutAsync(TimeSpan.FromSeconds(timeoutBudget), TimeoutStrategy.Pessimistic);

                    var retry = Policy.Handle<Exception>().WaitAndRetryForeverAsync(i => TimeSpan.FromSeconds(10));

                    var retryTimeout = timeout.WrapAsync(retry);

                    _authResult = await retryTimeout.ExecuteAsync(() =>
                        _authContext.AcquireTokenAsync()
                    );
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            return _authResult;
        }
    }
}
