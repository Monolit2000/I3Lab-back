using I3Lab.Doctors.Domain.DoctorCreationProposals;
using I3Lab.Doctors.Domain.DoctorCreationProposals.Events;
using MediatR;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal
{
    public class DoctorCreationProposalConfirmedDomainEventHandler(
        ISender sender) : INotificationHandler<DoctorCreationProposalConfirmedDomainEvent>
    {
        public Task Handle(DoctorCreationProposalConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
