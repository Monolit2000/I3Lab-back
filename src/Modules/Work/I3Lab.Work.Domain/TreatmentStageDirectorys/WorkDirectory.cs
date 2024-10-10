using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentFiles;
using TreatmentFile = I3Lab.Treatments.Domain.TreatmentFiles.TreatmentFile;

namespace I3Lab.Treatments.Domain.WorkDirectorys
{
    public class WorkDirectory : Entity, IAggregateRoot
    {
        public WorkDirectoryId Id { get; private set; }

        public readonly List<TreatmentFile> Files3Ds = [];

        public readonly List<TreatmentFile> OtherFiles = [];

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


        public void AddFile3D(TreatmentFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Add(file);
        }

        public void AddFile(TreatmentFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Add(file);
        }

        public void RemoveFile3D(TreatmentFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Files3Ds.Remove(file);
        }

        public void AddOtherFile(TreatmentFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            OtherFiles.Add(file);
        }

        public void RemoveOtherFile(TreatmentFile file)
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

        //public TreatmentFile? FindFile3DById(TreatmentFile fileId)
        //{
        //    return Files3Ds.FirstOrDefault(f => f.Id == fileId);
        //}

        //public TreatmentFile? FindOtherFileById(TreatmentFile fileId)
        //{
        //    return OtherFiles.FirstOrDefault(f => f.Id == fileId);
        //}
    }
}
