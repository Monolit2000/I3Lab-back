using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.WorkDirectorys
{
    public class WorkCatalogFile : Entity
    {
        public WorkDirectoryId WorkCatalogId { get; private set; }

        public FileId FileId { get; private set; }

        public WorkCatalogFile() { } // For EF Core

        public WorkCatalogFile(
            WorkDirectoryId workCatalogId,
            FileId fileId)
        {
            WorkCatalogId = workCatalogId; 
            FileId = fileId;    
        }

        internal static WorkCatalogFile CreateNew(
            WorkDirectoryId workCatalogId,
            FileId fileId)
        {
            return new WorkCatalogFile(
                workCatalogId, 
                fileId);  
        }
    }
}
