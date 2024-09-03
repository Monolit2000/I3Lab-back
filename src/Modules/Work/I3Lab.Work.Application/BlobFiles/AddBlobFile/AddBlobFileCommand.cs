using FluentResults;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.WorkDirectorys;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.AddBlobFile
{
    public class AddBlobFileCommand : IRequest<Result<BlobFileDto>>
    {
        public Guid WorkId { get; set; }    
        public string FileName { get; set; }
        public BlobFileType Type { get; set; }
        public string BlobPath { get; set; }
        public WorkDirectoryId WorkDirectoryId { get; set; }

        public Stream Stream { get; set; }

        public AddBlobFileCommand(
            string fileName,
            BlobFileType type,
            string blobPath,
            WorkDirectoryId workDirectoryId,
            Stream stream,
            Guid workId)
        {
            FileName = fileName;
            Type = type;
            BlobPath = blobPath;
            WorkDirectoryId = workDirectoryId;
            Stream = stream;
            WorkId = workId;
        }
    }
}
