using I3Lab.BuildingBlocks.Domain;
using I3Lab.Work.Domain.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.Member
{
    public class WorkMember : Entity, IAggregateRoot
    {
        public WorkMemberId Id { get; private set; }

        public string Login { get; private set; }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }




        private WorkMember()
        {
            // For EF Core
        }

        private WorkMember(
            WorkMemberId id,
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

        public static 

    }

}

