using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Files;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = I3Lab.Work.Domain.Files.File;

namespace I3Lab.Work.Domain.WorkCatalogs
{
    public class WorkCatalog : Entity, IAggregateRoot
    {
        public WorkCatalogId Id { get; private set; }

        public readonly List<File> Files3Ds = [];

        public readonly List<File> OtherFiles = [];

        public string BlobName { get; private set; }

        public string BlobCatalogName {  get; private set; }    

        public string BlobCatalogPath { get; private set; }

        private WorkCatalog()
        {
                
        }

        private WorkCatalog(string blobCatalogPath, string blobName)
        {
            Id = new WorkCatalogId(Guid.NewGuid());
            BlobName = blobName;
            BlobCatalogPath = blobCatalogPath;  
        }

        internal static WorkCatalog CreateNew(string blobCatalogPath, string blobName)
        {
            return new WorkCatalog(blobCatalogPath, blobName);
        }

    }
}
