using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.CreateWork
{
    public class CreateWorkCommand : IRequest<Result<WorkDto>>
    {
        public Guid TreatmentId {  get; set; }

        public Guid CreatorId { get; set; }
    }
}
