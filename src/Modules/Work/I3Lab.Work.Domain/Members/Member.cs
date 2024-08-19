using I3Lab.BuildingBlocks.Domain;
using System.ComponentModel;

namespace I3Lab.Works.Domain.Members
{
    public class Member : Entity, IAggregateRoot
    {
        public ClinicId ClinicId { get; private set; }

        public MemberId Id { get; private set; }

        public MemberRole MemberRole { get; private set; }

        public string Login { get; private set; }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        private Member()
        {
            // For EF Core
        }

        private Member(
            MemberId id,
            string login,
            string email, 
            string firstName,
            string lastName)
        {
            Id = id;
            Login = login;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public static Member CreateNew(
            MemberId id,
            string login,
            string email,
            string firstName,
            string lastName)
        {
            return new Member(
                id, 
                login, 
                email, 
                firstName, 
                lastName);
        }


    }

}

