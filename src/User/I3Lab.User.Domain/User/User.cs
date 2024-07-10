using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.User.Domain.User
{
    public class User : Entity, IAggregateRoot
    {

        public UserId Id { get; set; }
        public string AvatarImage { get; set; }

        public string Name { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }       
        public string PasswordHase { get; set; }
        
        public DateTime RegisterDate { get; set; }
    }
}
