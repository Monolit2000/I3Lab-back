using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.IntegrationEvents
{
    public class DoctorCreationProposalRejectedIntegrationEvent
    {
        public Guid DoctorCreationProposalId { get; }

        public DoctorCreationProposalRejectedIntegrationEvent(Guid doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
