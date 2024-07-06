using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Files;
using I3Lab.Works.Domain.WorkDirectorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = I3Lab.Works.Domain.Files.File;

namespace I3Lab.Works.Domain.Works
{
    public class WorkDirectory : Entity
    {
        public WorkId WorkId { get; private set; }

        public readonly List<File> Files3Ds = [];

        public readonly List<File> OtherFiles = [];

        public string BlobName { get; private set; }

        public string BlobContainerName { get; private set; }

        public string BlobCatalogName { get; private set; }

        public string BlobCatalogPath { get; private set; }

        private WorkDirectory() { }// For EF CORE
       
        private WorkDirectory(
            WorkId workId, 
            string blobName, 
            string blobCatalogName, 
            string blobCatalogPath)
        {
            WorkId = workId;
            BlobName = blobName;
            BlobCatalogName = blobCatalogName;
            BlobCatalogPath = blobCatalogPath;
        }

        internal static WorkDirectory CreateNew(
            WorkId workId, 
            string blobName, 
            string blobCatalogName, 
            string blobCatalogPath)
        {
            return new WorkDirectory(
                workId, 
                blobName, 
                blobCatalogPath, 
                blobCatalogName);
        }


        public void AddFile3D(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Add(file);
        }

        public void AddFile(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Add(file);
        }

        public void RemoveFile3D(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Remove(file);
        }

        public void AddOtherFile(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            OtherFiles.Add(file);
        }

        public void RemoveOtherFile(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            OtherFiles.Remove(file);
        }

        public void UpdateBlobName(string newBlobName)
        {
            if (string.IsNullOrWhiteSpace(newBlobName))
                throw new ArgumentException("Blob name cannot be empty.", nameof(newBlobName));

            BlobName = newBlobName;
        }

        public void UpdateBlobCatalogName(string newBlobCatalogName)
        {
            if (string.IsNullOrWhiteSpace(newBlobCatalogName))
                throw new ArgumentException("Catalog name cannot be empty.", nameof(newBlobCatalogName));

            BlobCatalogName = newBlobCatalogName;
        }

        public void UpdateBlobCatalogPath(string newBlobCatalogPath)
        {
            if (string.IsNullOrWhiteSpace(newBlobCatalogPath))
                throw new ArgumentException("Catalog path cannot be empty.", nameof(newBlobCatalogPath));

            BlobCatalogPath = newBlobCatalogPath;
        }

        public File? FindFile3DById(FileId fileId)
        {
            return Files3Ds.FirstOrDefault(f => f.Id == fileId);
        }

        public File? FindOtherFileById(FileId fileId)
        {
            return OtherFiles.FirstOrDefault(f => f.Id == fileId);
        }

    }
}
