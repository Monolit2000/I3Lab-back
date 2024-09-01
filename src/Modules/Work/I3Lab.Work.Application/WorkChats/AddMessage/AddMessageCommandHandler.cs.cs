using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.WorkChats.AddMessage
{
    public class AddMessageCommandHendler : IRequestHandler<AddMessageCommand, Result>
    {
        public Task<Result> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
