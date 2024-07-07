using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkDirectorys
{
    public class WorkDirectoryFile : Entity
    {
        public WorkDirectoryId WorkCatalogId { get; private set; }

        public BlobFileId FileId { get; private set; }

        public WorkDirectoryFile() { } // For EF Core

        public WorkDirectoryFile(
            WorkDirectoryId workCatalogId,
            BlobFileId fileId)
        {
            WorkCatalogId = workCatalogId; 
            FileId = fileId;    
        }

        internal static WorkDirectoryFile CreateNew(
            WorkDirectoryId workCatalogId,
            BlobFileId fileId)
        {
            return new WorkDirectoryFile(
                workCatalogId, 
                fileId);  
        }
    }
}
