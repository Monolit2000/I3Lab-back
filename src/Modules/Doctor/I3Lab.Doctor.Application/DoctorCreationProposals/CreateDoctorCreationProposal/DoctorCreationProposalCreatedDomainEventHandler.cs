using I3Lab.Doctors.Domain.DoctorCreationProposals.Events;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal
{
    public class DoctorCreationProposalCreatedDomainEventHandler(
        IPublishEndpoint publishEndpoint) : INotificationHandler<DoctorCreationProposalCreatedDomainEvent>
    {
        public Task Handle(DoctorCreationProposalCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
