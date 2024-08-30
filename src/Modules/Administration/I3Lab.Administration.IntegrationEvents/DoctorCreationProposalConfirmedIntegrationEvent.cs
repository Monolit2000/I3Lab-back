using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.IntegrationEvents
{
    public class DoctorCreationProposalConfirmedIntegrationEvent
    {
        public Guid DoctorCreationProposalId { get; }

        public DoctorCreationProposalConfirmedIntegrationEvent(Guid doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
