using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Domain.DoctorCreationProposals
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        => Value = value;


        private Email()
        {
            
        }

        public static Email Create(string value)
        {
            return new Email(value);
        }
    }
}
