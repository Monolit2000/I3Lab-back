using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments
{
    public class TreatmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime TreatmentDate { get; set; }
        public Guid CreatorId { get; set; }
        public Guid PatientId { get; set; }
    }
}
