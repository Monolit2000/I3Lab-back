﻿using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.BlobFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.WorkDirectorys
{
    public class WorkDirectoryFile : Entity
    {
        public WorkDirectoryId WorkCatalogId { get; private set; }

        public BlobFile FileId { get; private set; }

        public WorkDirectoryFile() { } // For EF Core

        public WorkDirectoryFile(
            WorkDirectoryId workCatalogId,
            BlobFile fileId)
        {
            WorkCatalogId = workCatalogId; 
            FileId = fileId;    
        }

        internal static WorkDirectoryFile CreateNew(
            WorkDirectoryId workCatalogId,
            BlobFile fileId)
        {
            return new WorkDirectoryFile(
                workCatalogId, 
                fileId);  
        }
    }
}