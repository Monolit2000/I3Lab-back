using MassTransit.Observables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.InternalCommands
{
    public class InternalCommand
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public string? Error { get; set; }

        public DateTime? EnqueueDate { get; set; }

        public DateTime? ProcessedDate { get; set; }
    }
}
