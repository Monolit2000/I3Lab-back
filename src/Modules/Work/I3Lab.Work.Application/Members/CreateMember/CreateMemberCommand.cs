using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace I3Lab.Treatments.Application.Members.CreateMember
{
    public class CreateMemberCommand : IRequest<Result<MemberDto>>
    {
        public string Email { get; }

        public Guid UserId { get; }

        public CreateMemberCommand(
           Guid userId, string email)
        {
            Email = email;
            UserId = userId;
        }
    }
}
