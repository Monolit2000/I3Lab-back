using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFileById;
using MediatR;


namespace I3Lab.Modules.BlobFailes.Api
{
    public interface IBlobFilesApi
    {
        Task<TResult> ExecuteRequestAsync<TResult>(IRequest<TResult> request);

        Task ExecuteRequestAsync(IRequest request);

        Task<Result<BlobFileDto>> UploadAsync(string FileName, Stream stream, string contentType, CancellationToken cancellationToken = default);
        public record BlobFileDto(Guid FileId, string Uri);

        //Task<TResult> ExecuteQueryAsync<TResult>(IRequest<TResult> query);
    }
}
