using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Domain.DoctorCreationProposals
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; }

        private PhoneNumber(string value)
        => Value = value;

        public static PhoneNumber Create(string value)
        {
            return new PhoneNumber(value);
        }

    }
}
