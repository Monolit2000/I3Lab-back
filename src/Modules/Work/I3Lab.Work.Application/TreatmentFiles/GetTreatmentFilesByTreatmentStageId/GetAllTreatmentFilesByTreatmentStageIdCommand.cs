using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFilesByTreatmentStageId
{
    public class GetAllTreatmentFilesByTreatmentStageIdCommand : IRequest<Result<List<BlobFileDto>>>
    {
        public Guid WorkId { get; set; }

        public GetAllTreatmentFilesByTreatmentStageIdCommand()
        {
                
        }

        public GetAllTreatmentFilesByTreatmentStageIdCommand(Guid workId)
        {
            WorkId = workId;
        }
    }
}
