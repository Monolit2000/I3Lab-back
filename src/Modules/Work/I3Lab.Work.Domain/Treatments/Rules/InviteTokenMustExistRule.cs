using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentInvites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments.Rules
{
    public class InviteTokenMustExistRule : IBusinessRule
    {
        private readonly InvitationToken _inviteToken;

        public InviteTokenMustExistRule(InvitationToken inviteToken)
        {
            _inviteToken = inviteToken;
        }

        public bool IsBroken() => _inviteToken == null;

        public string Message => "No invite token exists.";
    }

}
