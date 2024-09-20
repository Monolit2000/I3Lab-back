using FluentResults;
using MediatR;

namespace I3Lab.Treatments.Application.BlobFiles.RemoveBlobFile
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
