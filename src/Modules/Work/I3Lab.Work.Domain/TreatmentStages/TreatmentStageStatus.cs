using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageStatus : ValueObject
    {
        public string Value { get; }

        internal static TreatmentStageStatus Pending => new TreatmentStageStatus(nameof(Pending));
        internal static TreatmentStageStatus Active => new TreatmentStageStatus(nameof(Active));
        internal static TreatmentStageStatus Completed => new TreatmentStageStatus(nameof(Completed));

        public TreatmentStageStatus(string value)
        {
            Value = value;
        }
    }
}
