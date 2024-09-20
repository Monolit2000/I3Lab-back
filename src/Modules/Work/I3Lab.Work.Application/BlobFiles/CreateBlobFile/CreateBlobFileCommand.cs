using FluentResults;
using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.WorkDirectorys;
using MediatR;
using System.Text.Json.Serialization;

namespace I3Lab.Treatments.Application.BlobFiles.AddBlobFile
{
    public class CreateBlobFileCommand : IRequest<Result<BlobFileDto>>
    {
        public Guid WorkId { get; set; }    
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Stream Stream { get; set; }

        public CreateBlobFileCommand(
            Guid workId,
            string fileName)
        {
            FileName = fileName;
            WorkId = workId;
        }
    }
}
