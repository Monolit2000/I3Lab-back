using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.CreateWorkChat
{
    public class CreateWorkChatCommand : IRequest
    {
        public Guid WorkId { get; }
        public Guid TreatmentId { get; }

        public CreateWorkChatCommand(
            Guid workId, 
            Guid treatmentId = default)
        {
            WorkId = workId;
            TreatmentId = treatmentId;
        }
    }
}
