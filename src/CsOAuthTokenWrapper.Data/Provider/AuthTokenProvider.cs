using CsOAuthTokenWrapper.Data.Context;
using CsOAuthTokenWrapper.Data.Result;
using Polly;
using Polly.Timeout;

namespace CsOAuthTokenWrapper.Data.Provider
{
    public sealed class AuthTokenProvider : IAuthTokenProvider
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private static ICollection<AuthResult?> _authResults = new HashSet<AuthResult?>();
        private readonly IAuthContext _authContext;

        public AuthTokenProvider(IAuthContext authContext)
        {
            _authContext = authContext;
        }

        public AuthResult GetAccessToken(int timeoutBudget = 30)
        {
            if (_authResults != null && _authResults.Any(r => r?.ClientId == _authContext.ContextId))
            {
                var result = _authResults.First(r => r?.ClientId == _authContext.ContextId);

                if (result?.ExpiresOn > DateTimeOffset.UtcNow)
                    return result;
            }
            else
            {
                _semaphore.Wait(TimeSpan.FromMinutes(1));

                if (_authResults != null && _authResults.Any(r => r?.ClientId == _authContext.ContextId))
                {
                    var result = _authResults.First(r => r?.ClientId == _authContext.ContextId);

                    if (result?.ExpiresOn > DateTimeOffset.UtcNow)
                    {
                        _semaphore.Release();
                        return result;
                    }
                }

                try
                {
                    var timeout = Policy.Timeout(TimeSpan.FromSeconds(timeoutBudget), TimeoutStrategy.Pessimistic);

                    var retry = Policy.Handle<Exception>().WaitAndRetryForever(i => TimeSpan.FromSeconds(10));

                    var retryTimeout = timeout.Wrap(retry);

                    var result = retryTimeout.Execute(() =>
                        _authContext.AcquireTokenAsync().GetAwaiter().GetResult());

                    _authResults.Add(
                        new AuthResult(result.AccessTokenType, result.AccessToken, result.ExpiresInSeconds, _authContext.ContextId)
                    );
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            return _authResults.FirstOrDefault(r => r.ClientId == _authContext.ContextId);
        }

        public async Task<AuthResult> GetAccessTokenAsync(int timeoutBudget = 30)
        {
            if (_authResults != null && _authResults.Any(r => r?.ClientId == _authContext.ContextId))
            {
                var result = _authResults.First(r => r?.ClientId == _authContext.ContextId);

                if (result?.ExpiresOn > DateTimeOffset.UtcNow)
                    return result;
            }
            else
            {
                _semaphore.Wait(TimeSpan.FromMinutes(1));

                if (_authResults != null && _authResults.Any(r => r?.ClientId == _authContext.ContextId))
                {
                    var result = _authResults.First(r => r?.ClientId == _authContext.ContextId);

                    if (result?.ExpiresOn > DateTimeOffset.UtcNow)
                    {
                        _semaphore.Release();
                        return result;
                    }
                }

                try
                {
                    var timeout = Policy.TimeoutAsync(TimeSpan.FromSeconds(timeoutBudget), TimeoutStrategy.Pessimistic);

                    var retry = Policy.Handle<Exception>().WaitAndRetryForeverAsync(i => TimeSpan.FromSeconds(10));

                    var retryTimeout = timeout.WrapAsync(retry);

                    var result = await retryTimeout.ExecuteAsync(() =>
                        _authContext.AcquireTokenAsync()
                    );

                    _authResults.Add(
                        new AuthResult(result.AccessTokenType, result.AccessToken, result.ExpiresInSeconds, _authContext.ContextId)
                    );
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            return _authResults.FirstOrDefault(r => r.ClientId == _authContext.ContextId);
        }
    }
}
