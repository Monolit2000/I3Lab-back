using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetBlobFilesByType
{
    public class GetTreatmentFilesByTypeQueryHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<GetTreatmentFilesByTypeQuery, Result<TreatmentFilesDto>>
    {
        public async Task<Result<TreatmentFilesDto>> Handle(GetTreatmentFilesByTypeQuery request, CancellationToken cancellationToken)
        {

            //var filers = await blobFileRepository.GetAllTypeAndTreatmentStageIdAsync(FileType.C);

            throw new NotImplementedException();
        }
    }
}
