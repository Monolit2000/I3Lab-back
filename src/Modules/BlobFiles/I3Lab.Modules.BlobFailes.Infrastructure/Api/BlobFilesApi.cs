using MediatR;
using FluentResults;
using I3Lab.Modules.BlobFailes.Api;
using static I3Lab.Modules.BlobFailes.Api.IBlobFilesApi;
using I3Lab.Modules.BlobFailes.Application.BlobFiles.CreateBlobFile;

namespace I3Lab.Modules.BlobFailes.Infrastructure.Api
{
    public class BlobFilesApi(IMediator mediator) : IBlobFilesApi
    {
        public async Task<TResult> ExecuteRequestAsync<TResult>(IRequest<TResult> request)
        {
            return await mediator.Send(request);
        }

        public async Task ExecuteRequestAsync(IRequest request)
        {
            await mediator.Send(request);
        }

        public async Task<Result<BlobFileDto>> UploadAsync(string FileName, Stream stream, string contentType, CancellationToken cancellationToken = default)
        { 
            var result = await mediator.Send(new CreateBlobFileCommand
            {
                FileName = FileName,
                Stream = stream,
                ContentType = contentType
            });

            if (result.IsFailed)
                return Result.Fail("Upload fail");

            return new BlobFileDto(result.Value.Id, result.Value.Uri);
        }
    }
}
