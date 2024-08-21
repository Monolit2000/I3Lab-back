using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using System.ComponentModel;

namespace I3Lab.Works.Domain.Members
{
    public class Member : Entity, IAggregateRoot
    {
        public ClinicId ClinicId { get; private set; }

        public MemberId Id { get; private set; }

        public MemberRole MemberRole { get; private set; }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        private Member()
        {
            // For EF Core
        }

        private Member(
            string email)
        {
            Id = new MemberId(Guid.NewGuid());
            Email = email;
            MemberRole = MemberRole.Doctor;
        }

        public static Member CreateNew(string email)
        {
            return new Member(email);
        }


        public Result ChangeRole(string newRoleValue)
        {
            var result = MemberRole.Create(newRoleValue);
            if (result.IsFailed)
                return Result.Fail(result.Errors);

            MemberRole = result.Value;
            return Result.Ok();
        }

    }

}

