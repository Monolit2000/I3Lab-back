using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Application.ConfirmDoctorCreationPropos
{
    public class ConfirmDoctorCreationProposCommandHandler : IRequestHandler<ConfirmDoctorCreationProposCommand, Result<DoctorCreationProposDto>>
    {
        public Task<Result<DoctorCreationProposDto>> Handle(ConfirmDoctorCreationProposCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
