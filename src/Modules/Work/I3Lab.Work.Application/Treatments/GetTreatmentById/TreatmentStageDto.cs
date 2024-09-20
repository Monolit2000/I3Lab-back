using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.GetTreatmentById
{
    public class TreatmentStageDto
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
