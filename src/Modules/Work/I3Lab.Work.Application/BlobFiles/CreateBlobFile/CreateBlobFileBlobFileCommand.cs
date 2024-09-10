using FluentResults;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.WorkDirectorys;
using MediatR;

namespace I3Lab.Works.Application.BlobFiles.AddBlobFile
{
    public class CreateBlobFileBlobFileCommand : IRequest<Result<BlobFileDto>>
    {
        public Guid WorkId { get; set; }    
        public string FileName { get; set; }
        public BlobFileType Type { get; set; }
        public string BlobPath { get; set; }
        public WorkDirectoryId WorkDirectoryId { get; set; }

        public Stream Stream { get; set; }

        public CreateBlobFileBlobFileCommand(
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
