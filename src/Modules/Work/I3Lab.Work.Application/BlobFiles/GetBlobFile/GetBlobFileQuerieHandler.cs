using FluentResults;
using I3Lab.Works.Domain.BlobFiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFile
{
    public class GetBlobFileQuerieHandler(IBlobFileRepository blobFileRepository) : IRequestHandler<GetBlobFileQuerie, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(GetBlobFileQuerie request, CancellationToken cancellationToken)
        {
            var blobFile = await blobFileRepository.GetByIdAsync(new BlobFileId(request.BlobFileId));

            


        }
    }
}
