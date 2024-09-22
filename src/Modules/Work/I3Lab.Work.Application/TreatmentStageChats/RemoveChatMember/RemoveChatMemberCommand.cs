using I3Lab.Treatments.Application.Configuration.Commands;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentStageChats.RemoveChatMember
{
    public class RemoveChatMemberCommand : IRequest
    {
        public Guid MemberId { get; }
        public Guid WorkId { get; }
        public Guid WrorkChatId { get; }

        public RemoveChatMemberCommand(
            Guid memberId,
            Guid workId)
        {
            MemberId = memberId;
            WorkId = workId;
        }
    }
}
