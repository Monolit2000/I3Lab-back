using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFile
{
    public class GetBlobFileQuery : IRequest<Result<BlobFileStreamDto>>
    {
        public Guid BlobFileId { get; set; }

        public GetBlobFileQuery()
        {

        }
      
        public GetBlobFileQuery(Guid blobFileId)
        {
            BlobFileId = blobFileId;
        }
    }
}
