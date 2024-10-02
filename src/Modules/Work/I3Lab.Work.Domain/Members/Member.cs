using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.Members.Events;
using System.Text.Json.Serialization;

namespace I3Lab.Treatments.Domain.Members
{
    public class Member : Entity, IAggregateRoot
    {
        public ClinicId ClinicId { get; private set; }
        public MemberId Id { get; private set; }
       // public MemberRole MemberRole { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private Member() { } // For EF Core

     
        private Member(
            MemberId memberId,
            string email)
        {
            Id = memberId;
            Email = email;
        }

        public static Member CreateNew(
            MemberId memberId, string email)
        {
            return new Member(memberId, email);
        }

        //public Result ChangeRole(string newRoleValue)
        //{
        //    var result = MemberRole.Create(newRoleValue);
        //    if (result.IsFailed)
        //        return Result.Fail(result.Errors);

        //    MemberRole = result.Value;
        //    AddDomainEvent(new MemberRoleChengetDomainEvent(Id, result.Value));
        //    return Result.Ok();
        //}
    }
}

