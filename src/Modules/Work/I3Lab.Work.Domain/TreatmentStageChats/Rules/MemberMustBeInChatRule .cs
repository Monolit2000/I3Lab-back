using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats.Errors;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Rules
{
    public class MemberMustBeInChatRule : IBusinessRule
    {
        private readonly List<ChatMember> _chatMembers;
        private readonly MemberId _memberId;

        public MemberMustBeInChatRule(List<ChatMember> chatMembers, MemberId memberId)
        {
            _chatMembers = chatMembers;
            _memberId = memberId;
        }

        public bool IsBroken() => _chatMembers.All(m => m.MemberId != _memberId);

        public string Message => TreatmentStageChatsDomainErrors.MemberNotInChat;
    }
}
