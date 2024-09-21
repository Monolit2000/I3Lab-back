using FluentResults;
using I3Lab.Treatments.Domain.BlobFiles;
using MediatR;

namespace I3Lab.Treatments.Application.BlobFiles.RemoveBlobFile
{
    public class RemoveBlobFileCommandHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<RemoveBlobFileCommand, Result>
    {
        public async Task<Result> Handle(RemoveBlobFileCommand request, CancellationToken cancellationToken)
        {
            await blobFileRepository.DeleteAsync(new BlobFileId(request.BlobFileId));
            await blobFileRepository.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
//var blobFile = await blobFileRepository.GetByIdAsync(new BlobFileId(request.BlobFileId));

//if (blobFile == null)
//    return Result.Fail("sad");