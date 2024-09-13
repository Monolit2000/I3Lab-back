using I3Lab.Works.Application.Contract;
using System.Reflection;

namespace I3Lab.Works.Infrastructure
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(WorkModule).Assembly;
    }
}
