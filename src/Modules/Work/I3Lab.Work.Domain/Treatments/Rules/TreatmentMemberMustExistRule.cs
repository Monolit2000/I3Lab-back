using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Rules
{
    public class TreatmentMemberMustExistRule : IBusinessRule
    {
        private readonly TreatmentMember _treatmentMember;

        public TreatmentMemberMustExistRule(TreatmentMember treatmentMember)
        {
            _treatmentMember = treatmentMember;
        }

        public bool IsBroken() => _treatmentMember == null;

        public string Message => "Treatment member not found.";
    }

}
