using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Rules
{
    public class MemberMustNotBeAlreadyInChatRule : IBusinessRule
    {
        private readonly List<ChatMember> _chatMembers;
        private readonly MemberId _memberId;

        public MemberMustNotBeAlreadyInChatRule(List<ChatMember> chatMembers, MemberId memberId)
        {
            _chatMembers = chatMembers;
            _memberId = memberId;
        }

        public bool IsBroken() => _chatMembers.Any(m => m.MemberId == _memberId);

        public string Message => "Member is already in the chat.";
    }

}
