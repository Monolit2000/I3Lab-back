using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using BlobFile = I3Lab.Works.Domain.BlobFiles.BlobFile;

namespace I3Lab.Works.Domain.WorkDirectorys
{
    public class WorkDirectory : Entity, IAggregateRoot
    {
        public WorkDirectoryId Id { get; private set; }

        public readonly List<BlobFile> Files3Ds = [];

        public readonly List<BlobFile> OtherFiles = [];

        public string BlobName { get; private set; }

        public string BlobCatalogName {  get; private set; }    

        public string BlobCatalogPath { get; private set; }

        private WorkDirectory()
        {
                
        }

        private WorkDirectory(string blobName, string blobCatalogName, string blobCatalogPath)
        {
            Id = new WorkDirectoryId(Guid.NewGuid());
            BlobName = blobName;
            BlobCatalogName = blobCatalogName;
            BlobCatalogPath = blobCatalogPath;  
        }

        internal static WorkDirectory CreateNew(string blobName, string blobCatalogName, string blobCatalogPath)
        {
            return new WorkDirectory(blobName, blobCatalogPath, blobCatalogName);
        }


        public void AddFile3D(BlobFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Add(file);
        }

        public void AddFile(BlobFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Add(file);
        }

        public void RemoveFile3D(BlobFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Remove(file);
        }

        public void AddOtherFile(BlobFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            OtherFiles.Add(file);
        }

        public void RemoveOtherFile(BlobFile file)
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

        //public BlobFile? FindFile3DById(BlobFile fileId)
        //{
        //    return Files3Ds.FirstOrDefault(f => f.Id == fileId);
        //}

        //public BlobFile? FindOtherFileById(BlobFile fileId)
        //{
        //    return OtherFiles.FirstOrDefault(f => f.Id == fileId);
        //}
    }
}
