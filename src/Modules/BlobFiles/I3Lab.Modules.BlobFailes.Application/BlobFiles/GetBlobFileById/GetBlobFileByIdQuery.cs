using MediatR;
using FluentResults;

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
