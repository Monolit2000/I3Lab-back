using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentInvites.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentInvites.Rule
{
    class TreatmentInviteStatusMustByPending : IBusinessRule
    {
        private readonly TreatmentInviteStatus _currentStatus;

        public TreatmentInviteStatusMustByPending( TreatmentInviteStatus newStatus)
        {
            _currentStatus = newStatus;
        }

        public bool IsBroken() => _currentStatus != TreatmentInviteStatus.Pending;

        public string Message => TreatmentInviteErrors.InvalidInviteStatus();
    }
}
