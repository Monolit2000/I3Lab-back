using I3Lab.Work.Domain.File;
using I3Lab.Work.Domain.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace I3Lab.Work.Domain.Works
{
    public class WorkFile
    {
        public WorkId WorkId { get; private set; }
        public FileId FileId { get; private set; }
        public DateTime CreateDate { get; private set; }

        private WorkFile()
        {
        }

        private WorkFile(WorkId workId, FileId fileId)
        {
            WorkId = workId;    
            FileId = fileId;    

            CreateDate = DateTime.UtcNow;
        }

        internal static WorkFile CreateNew(WorkId workId, FileId fileId)
        {
            return new WorkFile(workId, fileId);
        }

    }
}
