using FluentResults;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Domain.WorkChats.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Treatment.CreateTreatment
{
    public class CreateTreatmentCommandHandler(
        ITretmentRepository tretmentRepository) : IRequestHandler<CreateTreatmentCommand, Result<TreatmentDto>>
    {
        public Task<Result<TreatmentDto>> Handle(CreateTreatmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
