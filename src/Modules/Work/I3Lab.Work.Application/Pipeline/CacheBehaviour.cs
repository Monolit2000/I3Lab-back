using MediatR;
using I3Lab.Treatments.Application.Contract;
using I3Lab.BuildingBlocks.Application.Cache;
using I3Lab.BuildingBlocks.Infrastructure.Cache;

namespace I3Lab.Treatments.Application.Pipeline
{
    public class CacheBehaviour<TRequest, TResponse>(
        IInMemoryCacheService _cacheService) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICacheableRequest
    {
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

      