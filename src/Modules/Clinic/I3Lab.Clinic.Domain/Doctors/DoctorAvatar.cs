using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.Doctors
{
    public class DoctorAvatar : ValueObject
    {
        public string Url { get; }

        private DoctorAvatar(string url)
         => Url = url;

        public static DoctorAvatar Create(string url)
        {
            return new DoctorAvatar(url);
        }
    }
}
