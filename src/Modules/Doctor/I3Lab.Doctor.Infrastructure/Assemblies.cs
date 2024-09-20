using I3Lab.Doctors.Application.Contract;
using I3Lab.Treatments.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Infrastructure
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(DoctorModule).Assembly;
    }
}
