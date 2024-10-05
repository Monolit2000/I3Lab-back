using MediatR;
using FluentResults;

namespace I3Lab.Treatments.Application.TreatmentFiles.CreateTreatmentFile
{
    public class CreateTreatmentFileCommand : IRequest<Result<TreatmentFileDto>>
    {
        public Guid WorkId { get; set; }    
        public string FileName { get; set; }
        public string ContentType { get; set; }

        public Stream Stream { get; set; }

        public CreateTreatmentFileCommand(
            Guid workId,
            string fileName)
        {
            FileName = fileName;
            WorkId = workId;
        }
    }
}
