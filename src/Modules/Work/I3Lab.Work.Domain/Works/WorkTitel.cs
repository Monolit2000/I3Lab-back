using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Works
{
    public class WorkTitel : ValueObject
    {
        public string Value { get; }

        private WorkTitel(string value)
        {
            Value = value;
        }

        public static WorkTitel Create(string value)
        {
            return new WorkTitel(value);
        }
    }
}
