using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using MediatR;


namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.RemoveBlobFile
{
    public class RemoveBlobFileCommandHandler(
        IBlobService blobService,
        IBlobFileRepository blobFileRepository) : IRequestHandler<RemoveBlobFileCommand, Result>
    {
        public async Task<Result> Handle(RemoveBlobFileCommand request, CancellationToken cancellationToken)
        {
            await blobService.DeleteAsync(request.BlobFileId, cancellationToken);

            await blobFileRepository.DeleteAsync(new BlobFileId(request.BlobFileId), cancellationToken);

            await blobFileRepository.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
