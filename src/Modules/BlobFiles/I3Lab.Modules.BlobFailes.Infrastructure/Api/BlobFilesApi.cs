using FluentResults;
using I3Lab.Modules.BlobFailes.Api;
using I3Lab.Modules.BlobFailes.Infrastructure.Processing;
using MediatR;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Api
{
    public class BlobFilesApi(IMediator mediator) : IBlobFailesApi
    {
        public async Task<TResult> ExecuteRequestAsync<TResult>(IRequest<TResult> request)
        {
            return await mediator.Send(request);
        }

        public async Task ExecuteRequestAsync(IRequest request)
        {
            await mediator.Send(request);
        }
    }
}
