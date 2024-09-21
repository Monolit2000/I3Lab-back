using FluentResults;
using I3Lab.Treatments.Domain.BlobFiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFilesByType
{
    public class GetBlobFilesByTypeQueryHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<GetBlobFilesByTypeQuery, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(GetBlobFilesByTypeQuery request, CancellationToken cancellationToken)
        {

            //var filers = await blobFileRepository.GetAllTypeAndTreatmentStageIdAsync(BlobFileType.C);

            throw new NotImplementedException();
        }
    }
}
