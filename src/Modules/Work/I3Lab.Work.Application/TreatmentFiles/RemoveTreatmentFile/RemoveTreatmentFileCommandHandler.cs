using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFiles;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentFiles.RemoveTreatmentFile
{
    public class RemoveTreatmentFileCommandHandler(
        ITreatmentFileRepository blobFileRepository) : IRequestHandler<RemoveTreatmentFileCommand, Result>
    {
        public async Task<Result> Handle(RemoveTreatmentFileCommand request, CancellationToken cancellationToken)
        {
            await blobFileRepository.DeleteAsync(new TreatmentFileId(request.TreatmentFileId));
            await blobFileRepository.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
//var blobFile = await blobFileRepository.GetByIdAsync(new TreatmentFileId(request.TreatmentFileId));

//if (blobFile == null)
//    return Result.Fail("sad");