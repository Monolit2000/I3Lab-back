using I3Lab.Treatments.Application.Contract;
using System.Reflection;

namespace I3Lab.Treatments.Infrastructure
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(WorkModule).Assembly;
    }
}
