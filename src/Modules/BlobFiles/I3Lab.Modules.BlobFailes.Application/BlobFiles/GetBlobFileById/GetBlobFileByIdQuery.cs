using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFileById
{
    public class GetBlobFileByIdQuery : IRequest<Result<BlobFileStreamDto>>
    {
        public Guid BlobFileId { get; set; }

        public GetBlobFileByIdQuery()
        {

        }
      
        public GetBlobFileByIdQuery(Guid blobFileId)
        {
            BlobFileId = blobFileId;
        }
    }
}
