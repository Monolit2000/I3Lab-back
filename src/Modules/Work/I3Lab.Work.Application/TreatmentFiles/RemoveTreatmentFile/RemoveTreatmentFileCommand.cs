using FluentResults;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentFiles.RemoveTreatmentFile
{
    public class RemoveTreatmentFileCommand : IRequest<Result>
    {
        public Guid BlobFileId { get; set; }

        public RemoveTreatmentFileCommand(Guid blobFileId)
        {
            BlobFileId = blobFileId;
        }
    }
}
