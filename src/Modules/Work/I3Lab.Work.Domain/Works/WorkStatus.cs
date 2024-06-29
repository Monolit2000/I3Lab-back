using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Works
{
    public class WorkStatus : ValueObject
    {
        public string Value { get; }

        internal static WorkStatus Pending => new WorkStatus(nameof(Pending));
        internal static WorkStatus InProgress => new WorkStatus(nameof(InProgress));
        internal static WorkStatus Completed => new WorkStatus(nameof(Completed));

        public WorkStatus(string value)
        {
            Value = value;
        }
    }
}
