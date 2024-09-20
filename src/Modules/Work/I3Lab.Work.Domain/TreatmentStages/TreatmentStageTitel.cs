using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageTitel : ValueObject
    {
        public string Value { get; }

        private TreatmentStageTitel(string value)
        {
            Value = value;
        }

        public static TreatmentStageTitel Create(string value)
        {
            return new TreatmentStageTitel(value);
        }
    }
}
