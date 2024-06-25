using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Application.Outbox
{
    public sealed class OutboxMessage
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public string Content { get; set; }

        public DateTime OccurredOnUtc { get; set; }

        public DateTime? ProcessedOnUtc { get; set; }

        public string? Error { get; set; }
    }
}
