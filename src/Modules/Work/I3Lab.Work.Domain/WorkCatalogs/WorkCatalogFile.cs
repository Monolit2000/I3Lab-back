using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.WorkCatalogs
{
    public class WorkCatalogFile : Entity
    {
        public WorkCatalogId WorkCatalogId { get; private set; }

        public FileId FileId { get; private set; }

        public WorkCatalogFile() { } // For EF Core

        public WorkCatalogFile(
            WorkCatalogId workCatalogId,
            FileId fileId)
        {
            WorkCatalogId = workCatalogId; 
            FileId = fileId;    
        }

        internal static WorkCatalogFile CreateNew(
            WorkCatalogId workCatalogId,
            FileId fileId)
        {
            return new WorkCatalogFile(
                workCatalogId, 
                fileId);  
        }
    }
}
