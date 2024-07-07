using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.WorkComments;
using I3Lab.Works.Domain.WorkComments.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = I3Lab.Works.Domain.BlobFiles.BlobFile;

namespace I3Lab.Works.Domain.WorkCatalogs
{
    public class PinedFile : Entity
    {
        public WorkCommentId WorkCommentId { get; private set; }
        public BlobFileId FileId { get; private set; }

        public PinedFile() { } // For EF Core 

        private PinedFile(
            WorkCommentId workCommentId,
            BlobFileId fileId)
        {
            WorkCommentId = workCommentId;
            FileId = fileId;

            AddDomainEvent(new FilePinedDomainEvent());
        }

        public static PinedFile CreatePinedFile(
            WorkCommentId workCommentId, 
            BlobFileId fileId)
        {
            return new PinedFile(
                workCommentId, 
                fileId);
        }
    }
}
