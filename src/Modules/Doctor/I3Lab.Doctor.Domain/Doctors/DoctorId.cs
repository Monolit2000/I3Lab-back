using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class DoctorId : TypedIdValueBase
    {
        public DoctorId(Guid value) 
            : base(value)
        {
        }
    }
}
