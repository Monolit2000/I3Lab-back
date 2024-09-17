using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Application.BlobStorage
{
    public interface IBlobService
    {
        Task<UploadFileResponce> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default);

        Task<FileResponce> DownloadAsync(Guid fileId, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid fileId, CancellationToken cancellationToken = default);

        Task<string> GetFileUrlAsync(Guid fileId, string directory = "", CancellationToken cancellationToken = default);
    }
}
