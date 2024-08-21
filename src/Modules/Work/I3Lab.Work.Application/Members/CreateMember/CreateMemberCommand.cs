using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace I3Lab.Works.Application.Members.CreateMember
{
    public class CreateMemberCommand : IRequest<Result<MemberDto>>
    {
        public string Email { get; set; }

        public CreateMemberCommand()
        {
                
        }

        public CreateMemberCommand(
           string email)
        {
            Email = email;
        }

    }
}
