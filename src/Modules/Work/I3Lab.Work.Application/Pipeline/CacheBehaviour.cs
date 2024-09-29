using MediatR;
using I3Lab.Treatments.Application.Contract;
using I3Lab.BuildingBlocks.Application.Cache;
using I3Lab.BuildingBlocks.Infrastructure.Cache;

namespace I3Lab.Treatments.Application.Pipeline
{
    public class CacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheableRequest<TResponse>
 
    {
        private readonly IInMemoryCacheService _cacheService;

        public CacheBehaviour(IInMemoryCacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var response = await _cacheService.GetOrCreateAsync(
                request.CacheKey,
                async (cancellationToken) =>
                    await next())
                .ConfigureAwait(false);

            return response;
        }
    }
}

      