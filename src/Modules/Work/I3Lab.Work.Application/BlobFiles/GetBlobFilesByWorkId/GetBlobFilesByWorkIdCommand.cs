using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFilesByWorkId
{
    public class GetBlobFilesByWorkIdCommand : IRequest<Result<List<BlobFileDto>>>
    {
        public Guid WorkId { get; }

        public GetBlobFilesByWorkIdCommand(Guid workId)
        {
            WorkId = workId;
        }
    }
}
