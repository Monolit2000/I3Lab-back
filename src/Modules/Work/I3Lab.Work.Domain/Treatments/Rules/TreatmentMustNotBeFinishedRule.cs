using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Rules
{
    public class TreatmentMustNotBeFinishedRule : IBusinessRule
    {
        private readonly TreatmentStatus _status;

        public TreatmentMustNotBeFinishedRule(TreatmentStatus status)
        {
            _status = status;
        }

        public bool IsBroken() => _status.IsFinished;

        public string Message => "Cannot cancel or modify a treatment that has already been finished.";
    }

}
