using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Treatments
{
    public class TreatmentDate
    {
        public DateTime TreatmentStarted { get; set; }

        public DateTime TreatmentFinished { get; set; }

        private TreatmentDate(
            DateTime treatmentStarted)
        {
            TreatmentStarted = treatmentStarted;
            TreatmentFinished = default;
        }

        public static TreatmentDate Start()
        {
            return new TreatmentDate(DateTime.UtcNow);
        }

        public void End()
        {
            TreatmentFinished = DateTime.UtcNow;
        }
    }
}
