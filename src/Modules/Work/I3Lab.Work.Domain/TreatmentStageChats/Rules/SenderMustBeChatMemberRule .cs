
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentStageChats.Errors;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Rules
{
    public class SenderMustBeChatMemberRule : IBusinessRule
    {
        private readonly List<ChatMember> _chatMembers;
        private readonly MemberId _senderId;

        public SenderMustBeChatMemberRule(List<ChatMember> chatMembers, MemberId senderId)
        {
            _chatMembers = chatMembers;
            _senderId = senderId;
        }

        public bool IsBroken()
        {
            return _chatMembers.All(m => m.MemberId != _senderId);
        }

        public string Message => TreatmentStageChatsDomainErrors.SenderNotInChat;
    }
}
