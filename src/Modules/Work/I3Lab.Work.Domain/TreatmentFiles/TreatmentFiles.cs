using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Domain.WorkCatalogs.Events;

namespace I3Lab.Works.Domain.TreatmentFiles
{
    public class TreatmentFiles : Entity, IAggregateRoot
    {
        public TreatmentId TreatmentId { get; private set; }
        public TreatmentStageId TreatmentStageId { get; private set; }

        public TreatmentFilesId Id {  get; }   
        public FilePreview FilePreview { get; private set; } 
        public BlobFileType BlobFileType { get; private set; }
        public double MbSize { get; private set; }

        //public TreatmentFiles()
        //{

        //}

        private TreatmentFiles(
            TreatmentId treatmentId,
            FilePreview filePreview,
            BlobFileType blobFileType)
        {
            Id = new TreatmentFilesId(Guid.NewGuid());
            FilePreview = filePreview;
            BlobFileType = blobFileType;
            TreatmentId = treatmentId;
        }

    }
}
