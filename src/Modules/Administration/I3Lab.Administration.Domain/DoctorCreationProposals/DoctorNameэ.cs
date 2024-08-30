using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Domain.DoctorCreationProposals
{
    public class DoctorName : ValueObject
    {

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        private DoctorName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static DoctorName Create(string firstName, string lastName)
        {
            return new DoctorName(firstName, lastName);
        }

    }
}
