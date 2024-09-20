using I3Lab.Administration.IntegrationEvents;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.RejectDoctorCreationProposal
{
    public class DoctorCreationProposalRejectedIntegrationEventHandler : IConsumer<DoctorCreationProposalRejectedIntegrationEvent>
    {
        public Task Consume(ConsumeContext<DoctorCreationProposalRejectedIntegrationEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
