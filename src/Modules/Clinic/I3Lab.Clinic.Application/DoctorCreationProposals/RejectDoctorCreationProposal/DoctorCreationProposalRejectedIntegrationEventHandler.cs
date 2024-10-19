using MassTransit;
using I3Lab.Administration.IntegrationEvents;

namespace I3Lab.Clinics.Application.DoctorCreationProposals.RejectDoctorCreationProposal
{
    public class DoctorCreationProposalRejectedIntegrationEventHandler : IConsumer<DoctorCreationProposalRejectedIntegrationEvent>
    {
        public Task Consume(ConsumeContext<DoctorCreationProposalRejectedIntegrationEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
