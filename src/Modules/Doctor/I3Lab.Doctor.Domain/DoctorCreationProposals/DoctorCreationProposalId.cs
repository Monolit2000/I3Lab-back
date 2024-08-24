using I3Lab.BuildingBlocks.Domain;
using I3Lab.BuildingBlocks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalId : TypedIdValueBase
    {
        public DoctorCreationProposalId(Guid value) 
            : base(value)
        {
        }
    }
}
