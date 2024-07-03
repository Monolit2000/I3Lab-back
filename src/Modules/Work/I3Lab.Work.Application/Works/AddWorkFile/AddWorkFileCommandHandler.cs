using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.AddWorkFile
{
    public class AddWorkFileCommandHandler : IRequestHandler<AddWorkFileCommand, Result<WorkFileDto>>
    {

        public Task<Result<WorkFileDto>> Handle(AddWorkFileCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
