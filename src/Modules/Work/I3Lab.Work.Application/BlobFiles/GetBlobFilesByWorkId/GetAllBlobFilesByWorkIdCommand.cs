using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.BlobFiles.GetBlobFilesByWorkId
{
    public class GetAllBlobFilesByWorkIdCommand : IRequest<Result<List<BlobFileDto>>>
    {
        public Guid WorkId { get; set; }

        public GetAllBlobFilesByWorkIdCommand()
        {
                
        }

        public GetAllBlobFilesByWorkIdCommand(Guid workId)
        {
            WorkId = workId;
        }
    }
}
