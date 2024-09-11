using FluentResults;
using I3Lab.Works.Domain.BlobFiles;
using MediatR;

namespace I3Lab.Works.Application.BlobFiles.RemoveBlobFile
{
    public class RemoveBlobFileCommandHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<RemoveBlobFileCommand, Result>
    {
        public async Task<Result> Handle(RemoveBlobFileCommand request, CancellationToken cancellationToken)
        {
            await blobFileRepository.DeleteAsync(new BlobFileId(request.BlobFileId));
            return Result.Ok();
        }
    }
}
//var blobFile = await blobFileRepository.GetByIdAsync(new BlobFileId(request.BlobFileId));

//if (blobFile == null)
//    return Result.Fail("sad");