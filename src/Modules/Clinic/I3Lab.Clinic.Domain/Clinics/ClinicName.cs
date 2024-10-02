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
        public string Name { get; set; }

        private ClinicName(string name)
            => Name = name;

        public static ClinicName Create(string name)
        {
            return new ClinicName(name);
        }
    }
}
