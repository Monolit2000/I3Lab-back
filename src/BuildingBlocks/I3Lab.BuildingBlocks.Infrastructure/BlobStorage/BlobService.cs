using Azure.Storage;
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

        private const string ContainerName = "test";

        public BlobService(
            BlobServiceClient blobServiceClient,
            IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }

        #region none

        public async Task<UploadFileResponce> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            containerClient.CreateIfNotExists();

            var fileId = Guid.NewGuid();
            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType }, cancellationToken: cancellationToken);
           
            var uri = blobClient.Uri.ToString();
            return new UploadFileResponce(ContainerName, fileId, uri);
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

        public Task<string> GetFileUrlAsync(Guid fileId, string directory = "", CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            string blobName = string.IsNullOrEmpty(directory) ? fileId.ToString() : $"{directory}/{fileId}";

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            return Task.FromResult(blobClient.Uri.ToString());
        }

        #endregion

        #region directory 

        public async Task<Guid> UploadAsync(Stream stream, string contentType, string directory = "", CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            var fileId = Guid.NewGuid();
            string blobName = string.IsNullOrEmpty(directory) ? fileId.ToString() : $"{directory}/{fileId}";

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(
                stream,
                new BlobHttpHeaders { ContentType = contentType },
                cancellationToken: cancellationToken);

            return fileId;
        }

        public async Task<FileResponce> DownloadAsync(Guid fileId, string directory = "", CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            string blobName = string.IsNullOrEmpty(directory) ? fileId.ToString() : $"{directory}/{fileId}";

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            BlobDownloadResult responce = await blobClient.DownloadContentAsync(cancellationToken: cancellationToken);

            return new FileResponce(responce.Content.ToStream(), responce.Details.ContentType);
        }

        public async Task DeleteAsync(Guid fileId, string directory = "", CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            string blobName = string.IsNullOrEmpty(directory) ? fileId.ToString() : $"{directory}/{fileId}";

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        }

        public async Task SetAccessTierAsync(Guid fileId, AccessTier accessTier, string directory = "", CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            string blobName = string.IsNullOrEmpty(directory) ? fileId.ToString() : $"{directory}/{fileId}";

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.SetAccessTierAsync(accessTier, cancellationToken: cancellationToken);
        }

        #endregion

    }
}
