using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentInvites.Events
{
    public class TreatmentInviteCreatedDomainEvent : DomainEventBase
    {
        public Treatment Treatment { get; set; }
        public Member MemberToInvite { get; set; }
        public Member Inviter { get; set; }

        public TreatmentInviteCreatedDomainEvent(
            Treatment treatment, 
            Member memberToInvite,
            Member inviter)
        {
            Treatment = treatment;
            MemberToInvite = memberToInvite;
            Inviter = inviter;
        }
    }
}
