using I3Lab.Administration.Domain.DoctorCreationProposals.Events;
using MediatR;

namespace I3Lab.Administration.Application.ConfirmDoctorCreationPropos
{
    public class DoctorCreationProposalConfirmedDomainEventHandler : INotificationHandler<DoctorCreationProposalConfirmedDomainEvent>
    {
        public Task Handle(DoctorCreationProposalConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
  