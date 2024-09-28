using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentStageChats.Rules
{
    public class MessageMustExistRule : IBusinessRule
    {
        private readonly Message _message;

        public MessageMustExistRule(Message message)
        {
            _message = message;
        }

        public bool IsBroken() => _message == null;

        public string Message => "Message not found.";
    }
}
