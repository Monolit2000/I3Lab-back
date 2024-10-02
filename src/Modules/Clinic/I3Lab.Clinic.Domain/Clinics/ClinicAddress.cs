using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class ClinicAddress : ValueObject
    {
        public string Value { get; set; }

        private ClinicAddress(string value)
            => Value = value;

        public static ClinicAddress Create(string address)
        {
            return new ClinicAddress(address);
        }
    }
}
