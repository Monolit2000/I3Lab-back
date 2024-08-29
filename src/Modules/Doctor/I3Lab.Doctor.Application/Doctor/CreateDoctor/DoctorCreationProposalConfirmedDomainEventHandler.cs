using I3Lab.Doctors.Domain.DoctorCreationProposals.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.Doctor.CreateDoctor
{
    public class DoctorCreationProposalConfirmedDomainEventHandler : INotificationHandler<DoctorCreationProposalConfirmedDomainEvent>
    {
        public Task Handle(DoctorCreationProposalConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
