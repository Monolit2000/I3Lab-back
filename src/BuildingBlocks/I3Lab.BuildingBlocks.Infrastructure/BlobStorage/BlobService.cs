using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.BlobStorage
{
    public class BlobService : IBlobService
    {
        public BlobServiceClient _blobServiceClient;

        private const string ContainerName = "files";

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
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

        public async Task DeleateAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
        }


    }
}
