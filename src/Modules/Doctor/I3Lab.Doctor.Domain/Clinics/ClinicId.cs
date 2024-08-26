using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Domain.Clinics
{
    public class ClinicId : TypedIdValueBase
    {
        public ClinicId(Guid value) 
            : base(value)
        {
        }
    }
}
