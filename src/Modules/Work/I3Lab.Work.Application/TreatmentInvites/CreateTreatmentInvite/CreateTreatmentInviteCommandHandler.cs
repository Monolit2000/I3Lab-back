using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.TreatmentInvites.CreateTreatmentInvite
{
    public class CreateTreatmentInviteCommandHandler : IRequestHandler<CreateTreatmentInviteCommand, Result<TreatmentInviteDto>>
    {
        public Task<Result<TreatmentInviteDto>> Handle(CreateTreatmentInviteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
