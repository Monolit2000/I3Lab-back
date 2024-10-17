using MediatR;
using I3Lab.Clinics.Application.Doctors.CreateDoctor;
using I3Lab.Clinics.Domain.DoctorCreationProposals.Events;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal
{
    public class DoctorCreationProposalConfirmedDomainEventHandler(
        ISender sender) : INotificationHandler<DoctorCreationProposalConfirmedDomainEvent>
    {
        public async Task Handle(DoctorCreationProposalConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            await sender.Send(new CreateDoctorCommand(notification.DoctorCreationProposalId));
        }
    }
}
