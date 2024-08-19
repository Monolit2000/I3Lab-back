using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace I3Lab.Works.Application.Members.CreateMember
{
    public class CreateMemberCommand : IRequest<Result<MemberDto>>
    {
        [JsonConstructor]
        public CreateMemberCommand(
           Guid memberId,
           string name,
           string email,
           string lastName)
        {
            MemberId = memberId;
            Name = name;
            Email = email;
            LastName = lastName;
        }

        internal Guid MemberId { get; }

        //internal string Login { get; }

        internal string Email { get; }

        //internal string FirstName { get; }

        internal string LastName { get; }

        internal string Name { get; }
    }
}
