using I3Lab.Administration.IntegrationEvents;
using I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace I3Lab.Doctors.Application.DoctorCreationProposals
{
    public class DoctorCreationProposalConfirmedIntegrationEventHandler(
        ILogger<DoctorCreationProposalConfirmedIntegrationEventHandler> logger,
        ISender sender)
        : IConsumer<DoctorCreationProposalConfirmedIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<DoctorCreationProposalConfirmedIntegrationEvent> context)
        {
            logger.LogInformation("{Consumer} : {Message}",
          nameof(DoctorCreationProposalConfirmedIntegrationEventHandler), context.Message.DoctorCreationProposalId);

            //await sender.Send(new ConfirmDoctorCreationProposalCommand(
            //    context.Message.DoctorCreationProposalId));
        }
    }
}
