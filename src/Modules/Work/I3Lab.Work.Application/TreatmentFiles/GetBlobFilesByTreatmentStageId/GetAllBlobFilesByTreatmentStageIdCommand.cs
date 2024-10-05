using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetBlobFilesByWorkId
{
    public class GetAllBlobFilesByTreatmentStageIdCommand : IRequest<Result<List<BlobFileDto>>>
    {
        public Guid WorkId { get; set; }

        public GetAllBlobFilesByTreatmentStageIdCommand()
        {
                
        }

        public GetAllBlobFilesByTreatmentStageIdCommand(Guid workId)
        {
            WorkId = workId;
        }
    }
}
