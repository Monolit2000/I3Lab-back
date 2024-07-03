using FluentResults;
using I3Lab.Work.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Application.Works.AddWorkMember
{
    public class AddWorkMemberCommand : IRequest<Result<WorkMemberDto>> 
    {
    }
}
