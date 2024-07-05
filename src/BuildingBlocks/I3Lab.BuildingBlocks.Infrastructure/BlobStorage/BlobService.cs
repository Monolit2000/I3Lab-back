using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using Microsoft.Extensions.Configuration;


namespace I3Lab.BuildingBlocks.Infrastructure.BlobStorage
{
    public class BlobService : IBlobService
    {
        public BlobServiceClient _blobServiceClient;

        public IConfiguration _configuration;

        private const string ContainerName = "files";

        public BlobService(
            BlobServiceClient blobServiceClient,
            IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }
        public async Task<Guid> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            var fileId = Guid.NewGuid();
            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.UploadAsync(
                stream,
                new BlobHttpHeaders { ContentType = contentType },
                cancellationToken: cancellationToken);

            return fileId;
        }

        public async Task<FileResponce> DownloadAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            BlobDownloadResult responce = await blobClient.DownloadContentAsync(cancellationToken: cancellationToken);

            return new FileResponce(responce.Content.ToStream(), responce.Details.ContentType);
        }

        public async Task DeleteAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        }

        public async Task SetAccessTierAsync(Guid fileId, AccessTier accessTier, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.SetAccessTierAsync(accessTier, cancellationToken: cancellationToken);
        }


    }
}
