using FluentResults;
using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Rules
{
    public class RepliedMessageMustExistRule : IBusinessRule
    {
        private readonly List<Message> _messages;
        private readonly MessageId _repliedToMessageId;

        public RepliedMessageMustExistRule(List<Message> messages, MessageId repliedToMessageId)
        {
            _messages = messages;
            _repliedToMessageId = repliedToMessageId;
        }

        public bool IsBroken()
        {
            return _messages.All(m => m.Id != _repliedToMessageId) && _repliedToMessageId != null;
        }

        public string Message => "Replied message not found.";
    }
}
