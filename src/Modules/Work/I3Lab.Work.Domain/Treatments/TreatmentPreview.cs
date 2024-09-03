using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Treatments.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Treatments
{
    public class TreatmentPreview : Entity
    {
        public TreatmentId TreatmentId { get; private set; }
        public BlobFile FileId { get; private set; }

        private TreatmentPreview() { } // For EF Core 

        private TreatmentPreview(TreatmentId treatmentId, BlobFile fileId)
        {
            TreatmentId = treatmentId;
            FileId = fileId;

            AddDomainEvent(new TreatmentPreviewAddedDomainEvent());
        }

        internal static TreatmentPreview CreateNew(
            TreatmentId treatmentId, 
            BlobFile fileId)
        {
            return new TreatmentPreview(
                treatmentId, 
                fileId);
        }

    }
}
