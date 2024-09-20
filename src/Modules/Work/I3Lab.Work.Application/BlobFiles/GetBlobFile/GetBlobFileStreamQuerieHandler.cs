using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Treatments.Domain.BlobFiles;
using MediatR;

namespace I3Lab.Treatments.Application.BlobFiles.GetBlobFile
{
    public class GetBlobFileStreamQuerieHandler(
        IBlobFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<GetBlobFileStreamQuerie, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(GetBlobFileStreamQuerie request, CancellationToken cancellationToken)
        {
            var blobFile = await blobFileRepository.GetByIdAsync(new BlobFileId(request.BlobFileId));

            if (blobFile is null)
                return Result.Fail("File not found");

            var fileResponce = await blobService.DownloadAsync(new Guid(blobFile.FileName));

            return new BlobFileDto(fileResponce.Stream, fileResponce.ContentType);
        }
    }
}
