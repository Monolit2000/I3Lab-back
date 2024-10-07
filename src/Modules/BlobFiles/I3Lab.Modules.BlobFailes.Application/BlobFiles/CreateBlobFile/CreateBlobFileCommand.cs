using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFileById;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.CreateBlobFile
{
    public class CreateBlobFileCommand : IRequest<Result<BlobFileDto>>
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }

        public Stream Stream { get; set; }

        public CreateBlobFileCommand(
            Guid workId,
            string fileName)
        {
            FileName = fileName;
        }
    }
}
