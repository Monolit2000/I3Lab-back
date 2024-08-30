using I3Lab.Doctors.Application.Doctor.CreateDoctor;
using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.DoctorCreationProposals.Events;
using MediatR;

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
