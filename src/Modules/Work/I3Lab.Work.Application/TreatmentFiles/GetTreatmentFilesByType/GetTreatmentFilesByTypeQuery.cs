using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetBlobFilesByType
{
    public class GetTreatmentFilesByTypeQuery : IRequest<Result<TreatmentFilesDto>>
    {
        public Guid WorkId { get; set; }

        public string Type { get; set; }

        public GetTreatmentFilesByTypeQuery(
            Guid workId, 
            string type)
        {
            WorkId = workId;
            Type = type;
        }
    }
}
