using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentFils;
using I3Lab.Treatments.Domain.Treatments.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class TreatmentPreview : Entity
    {
        public TreatmentId TreatmentId { get; private set; }
        public TreatmentFile FileId { get; private set; }

        private TreatmentPreview() { } // For EF Core 

        private TreatmentPreview(TreatmentId treatmentId, TreatmentFile fileId)
        {
            TreatmentId = treatmentId;
            FileId = fileId;

            AddDomainEvent(new TreatmentPreviewAddedDomainEvent());
        }

        internal static TreatmentPreview CreateNew(
            TreatmentId treatmentId, 
            TreatmentFile fileId)
        {
            return new TreatmentPreview(
                treatmentId, 
                fileId);
        }

    }
}
