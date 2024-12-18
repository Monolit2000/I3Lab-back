﻿using MediatR;
using MassTransit;
using Microsoft.Extensions.Logging;
using I3Lab.Administration.IntegrationEvents;
using I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal;

namespace I3Lab.Clinics.Application.DoctorCreationProposals
{
    public class DoctorCreationProposalConfirmedIntegrationEventHandler(
        ILogger<DoctorCreationProposalConfirmedIntegrationEventHandler> logger,
        ISender sender): IConsumer<DoctorCreationProposalConfirmedIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<DoctorCreationProposalConfirmedIntegrationEvent> context)
        {
            logger.LogInformation("{Consumer} : {Message}",
          nameof(DoctorCreationProposalConfirmedIntegrationEventHandler), context.Message.DoctorCreationProposalId);

            await sender.Send(new ConfirmDoctorCreationProposalCommand(
                context.Message.DoctorCreationProposalId));
        }
    }
}
