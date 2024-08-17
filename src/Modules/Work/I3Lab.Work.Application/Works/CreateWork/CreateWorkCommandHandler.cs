using FluentResults;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.CreateWork
{
    public class CreateWorkCommandHandler(
        IWorkRepository workRepository,
        IMemberContext memberContext) : IRequestHandler<CreateWorkCommand, Result<WorkDto>>
    {
        public Task<Result<WorkDto>> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
        {

            

            throw new NotImplementedException();
        }
    }
}
