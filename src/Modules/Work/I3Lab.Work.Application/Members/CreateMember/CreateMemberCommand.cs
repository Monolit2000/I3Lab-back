using FluentResults;
using I3Lab.Treatments.Application.Configuration.Commands;

namespace I3Lab.Treatments.Application.Members.CreateMember
{
    public class CreateMemberCommand : InternalCommandBase<Result<MemberDto>>
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
