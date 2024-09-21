using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFilesByType
{
    public class GetBlobFilesByTypeQuery : IRequest<Result<BlobFileDto>>
    {
        public Guid WorkId { get; set; }

        public string Type { get; set; }

        public GetBlobFilesByTypeQuery(
            Guid workId, 
            string type)
        {
            WorkId = workId;
            Type = type;
        }
    }
}
