using I3Lab.BuildingBlocks.Application.Cache;
using I3Lab.Treatments.Application.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace I3Lab.Treatments.Application.Pipeline
{
    public class CacheInvalidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : ICacheInvalidatorRequest
    {
        private readonly IInMemoryCacheService _cache;
        private readonly ILogger<CacheInvalidationBehaviour<TRequest, TResponse>> _logger;

        public CacheInvalidationBehaviour(
            IInMemoryCacheService cache,
            ILogger<CacheInvalidationBehaviour<TRequest, TResponse>> logger
        )
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            _logger.LogTrace("Handling request of type {RequestType} with details {@Request}", nameof(request), request);
            var response = await next().ConfigureAwait(false);
            if (!string.IsNullOrEmpty(request.CacheKey))
            {
                await _cache.RemoveAsync(request.CacheKey);
                _logger.LogTrace("Cache key {CacheKey} removed from cache", request.CacheKey);
            }
            return response;
        }
    }
}
