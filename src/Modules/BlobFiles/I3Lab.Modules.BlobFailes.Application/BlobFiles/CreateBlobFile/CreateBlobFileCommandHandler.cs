using MediatR;
using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFile;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.CreateBlobFile
{
    public class CreateBlobFileCommandHandler(
        IBlobFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<CreateBlobFileCommand, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(CreateBlobFileCommand request, CancellationToken cancellationToken)
        {
            var contentType = ContentType.Create(request.ContentType);

            var uploadFileResponce = await blobService.UploadAsync(request.Stream, request.ContentType);

            var url = BlobFileUrl.Create(uploadFileResponce.Uri);

            var newBlobFile = BlobFile.Create(
                BlobFileUrl.Create(uploadFileResponce.Uri), 
                contentType);

            await blobFileRepository.AddAsync(newBlobFile, cancellationToken);

            await blobFileRepository.SaveChangesAsync(cancellationToken);

            var blobFileDto = new BlobFileDto(
                newBlobFile.Id.Value,
                newBlobFile.Path.FileName,
                newBlobFile.CreateDate,
                newBlobFile.Accessibilitylevel.Value);

            return blobFileDto;
        }
    }
}
