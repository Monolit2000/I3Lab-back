using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentById
{
    public class TreatmentDto
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid PatientId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid TreatmentPreview { get; set; }
        public List<TreatmentStageDto> TreatmentStages { get; set; } = new List<TreatmentStageDto>();
    }
}
