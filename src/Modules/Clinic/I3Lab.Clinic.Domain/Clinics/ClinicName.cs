using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class ClinicName : ValueObject
    {
        public string Value { get; private set; }

        private ClinicName(string value)
            => Value = value;

        public static ClinicName Create(string value)
        {
            return new ClinicName(value);
        }
    }
}
