using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFils;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentFiles.RemoveTreatmentFile
{
    public class RemoveTreatmentFileCommandHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<RemoveTreatmentFileCommand, Result>
    {
        public async Task<Result> Handle(RemoveTreatmentFileCommand request, CancellationToken cancellationToken)
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