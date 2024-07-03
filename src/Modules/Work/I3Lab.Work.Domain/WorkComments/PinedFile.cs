using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Files;
using I3Lab.Works.Domain.WorkComments;
using I3Lab.Works.Domain.WorkComments.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = I3Lab.Works.Domain.Files.File;

namespace I3Lab.Works.Domain.WorkCatalogs
{
    public class PinedFile : Entity
    {
        public WorkCommentId WorkCommentId { get; private set; }
        public FileId FileId { get; private set; }

        public PinedFile() { } // For EF Core 

        private PinedFile(
            WorkCommentId workCommentId,
            FileId fileId)
        {
            WorkCommentId = workCommentId;
            FileId = fileId;

            AddDomainEvent(new FilePinedDomainEvent());
        }

        public static PinedFile CreatePinedFile(
            WorkCommentId workCommentId, 
            FileId fileId)
        {
            return new PinedFile(
                workCommentId, 
                fileId);
        }
    }
}
