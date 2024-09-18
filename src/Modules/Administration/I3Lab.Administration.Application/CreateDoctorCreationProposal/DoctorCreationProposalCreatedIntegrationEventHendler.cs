using MassTransit;
using I3Lab.Doctors.IntegrationEvents;
using MediatR;

namespace I3Lab.Administration.Application.CreateDoctorCreationProposal
{
    public class DoctorCreationProposalCreatedIntegrationEventHendler(
        ISender sender) : IConsumer<DoctorCreationProposalCreatedIntegrationEvent>
    {
        public async Task Consume(ConsumeContext<DoctorCreationProposalCreatedIntegrationEvent> context)
        {
            await sender.Send(new CreateDoctorCreationProposalCommand(
                context.Message.ProposalId,
                context.Message.FirstName,
                context.Message.LastName,
                context.Message.Email,
                context.Message.PhoneNumber,
                context.Message.DoctorAvatar));
        }
    }
}
