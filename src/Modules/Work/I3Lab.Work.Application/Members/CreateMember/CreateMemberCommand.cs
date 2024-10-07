using FluentResults;
using I3Lab.Treatments.Application.Configuration.CaheKeys.Members;
using I3Lab.Treatments.Application.Configuration.Commands;
using I3Lab.Treatments.Application.Contract;

namespace I3Lab.Treatments.Application.Members.CreateMember
{
    public class CreateMemberCommand : InternalCommandBase<Result<MemberDto>>, ICacheInvalidatorRequest
    {
        public string Email { get; }

        public Guid UserId { get; }

        public string CacheKey => MembersCaheKeys.Members;

        public CreateMemberCommand(
           Guid userId, string email)
        {
            Email = email;
            UserId = userId;
        }
    }
}
