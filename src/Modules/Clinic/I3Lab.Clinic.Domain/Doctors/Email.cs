using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.Doctors
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
            => Value = value;

        public static Email Create(string value)
            => new Email(value);
    }
}
