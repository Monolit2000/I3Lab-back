using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace I3Lab.Work.Application.Members.CreateMember
{
    public class CreateMemberCommand : IRequest<Result<MemberDto>>
    {
        [JsonConstructor]
        public CreateMemberCommand(
           Guid memberId,
           string login,
           string email,
           string firstName,
           string lastName,
           string name)
        {
            Login = login;
            MemberId = memberId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Name = name;
        }

        internal Guid MemberId { get; }

        internal string Login { get; }

        internal string Email { get; }

        internal string FirstName { get; }

        internal string LastName { get; }

        internal string Name { get; }
    }
}
