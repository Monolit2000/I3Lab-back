using FluentResults;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentFiles.RemoveTreatmentFile
{
    public class RemoveTreatmentFileCommand : IRequest<Result>
    {
        public Guid TreatmentFileId { get; set; }

        public RemoveTreatmentFileCommand(Guid blobFileId)
        {
            TreatmentFileId = blobFileId;
        }
    }
}
