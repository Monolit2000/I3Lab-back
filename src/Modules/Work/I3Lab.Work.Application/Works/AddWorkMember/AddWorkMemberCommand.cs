using FluentResults;
using I3Lab.Works.Domain.Works;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.Works.AddWorkMember
{
    public class AddWorkMemberCommand : IRequest<Result<WorkMemberDto>> 
    {
        public Guid WorkId { get; set; }
        public Guid MemberId { get; set; }
        public Guid AddedByMemberId { get; set; }

        [JsonConstructor]
        public AddWorkMemberCommand(
            Guid workId, 
            Guid workMemberId,
            Guid addedByMemberId)
        {
            WorkId = workId;
            MemberId = workMemberId;
            AddedByMemberId = addedByMemberId;  
        }
    }
}
