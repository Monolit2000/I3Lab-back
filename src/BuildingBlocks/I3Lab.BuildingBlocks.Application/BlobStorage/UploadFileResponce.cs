using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Application.BlobStorage
{
    public record UploadFileResponce(string Conteiner, Guid FileId, string Uri, string Directory = default);
}
