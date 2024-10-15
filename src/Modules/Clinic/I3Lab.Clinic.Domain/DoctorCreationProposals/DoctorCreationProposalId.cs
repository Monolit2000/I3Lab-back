using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalId : TypedIdValueBase
    {
        public DoctorCreationProposalId(Guid value)
            : base(value)
        {
        }
    }
}
