namespace I3Lab.API.Modules.Treatments.TreatmentStageChats.Hubs
{
    public interface ITreatmentChatClient
    {
        public Task ReceiveMessage(string userName, string message);
    }
}
