using I3Lab.Treatments.Domain.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public interface IMemberContext
    {
        MemberId MemberId { get; }
    }
}
