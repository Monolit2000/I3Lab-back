using I3Lab.Doctors.Application.Contract;
using System.Reflection;

namespace I3Lab.Doctors.Infrastructure
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(DoctorModule).Assembly;
    }
}
