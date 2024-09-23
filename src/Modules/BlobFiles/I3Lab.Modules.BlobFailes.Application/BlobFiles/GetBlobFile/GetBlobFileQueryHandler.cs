using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using MediatR;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFile
{
    public class GetBlobFileQueryHandler(
        IBlobService blobService,
        IBlobFileRepository blobFileRepository) : IRequestHandler<GetBlobFileQuery, Result<BlobFileStreamDto>>
    {
        public async Task<Result<BlobFileStreamDto>> Handle(GetBlobFileQuery request, CancellationToken cancellationToken)
        {
            var blobFile = await blobFileRepository.GetByIdAsync(new BlobFileId(request.BlobFileId));

            if (blobFile is null)
                return Result.Fail("File not found");

            var fileResponce = await blobService.DownloadAsync(new Guid(blobFile.Path.FileName));

            return new BlobFileStreamDto(fileResponce.Stream, fileResponce.ContentType);
        }
    }
}
