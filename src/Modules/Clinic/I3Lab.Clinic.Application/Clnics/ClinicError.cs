using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Application.Clnics
{
    public static class ClinicError
    {
        public static string ClinicAlreadyExist(string clinicName)
            => $"Clinic {clinicName} already exist";
    }
}
