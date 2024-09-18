using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Members.GetAllMembers
{
    public class GetAllMembersQuery : IRequest<Result<GetAllMembersQuery>>
    {
    }
}
