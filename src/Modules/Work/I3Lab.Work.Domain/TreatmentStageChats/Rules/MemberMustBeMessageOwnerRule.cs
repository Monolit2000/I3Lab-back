using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Rules
{
    public class MemberMustBeMessageOwnerRule : IBusinessRule
    {
        private readonly Message _message;

        private readonly MemberId _memberId;    

        public MemberMustBeMessageOwnerRule(Message message, MemberId memberId)
        {
            _message = message;
            _memberId = memberId;
        }

        public bool IsBroken() => _message.SenderId != _memberId;


        public string Message => TreatmentStageChatsDomainErrors.MemberMustBeMessageOwner;
    }
}
