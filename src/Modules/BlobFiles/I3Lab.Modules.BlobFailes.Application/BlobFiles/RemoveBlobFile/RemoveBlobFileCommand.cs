using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.RemoveBlobFile
{
    public class RemoveBlobFileCommand : IRequest<Result>
    {
        public Guid BlobFileId { get; set; }

        public RemoveBlobFileCommand(Guid blobFileId)
        {
            BlobFileId = blobFileId;
        }
    }
}
