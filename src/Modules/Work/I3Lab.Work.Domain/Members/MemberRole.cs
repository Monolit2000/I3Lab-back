using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Works.Domain.Works;
using System.Net;

namespace I3Lab.Works.Domain.Members
{
    public class MemberRole : ValueObject
    {
        public string Value { get; }

        internal static MemberRole Patient => new MemberRole(nameof(Patient));
        internal static MemberRole Artisan => new MemberRole(nameof(Artisan));
        internal static MemberRole Admin => new MemberRole(nameof(Admin));
        internal static MemberRole Doctor => new MemberRole(nameof(Doctor));

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Patient),
            nameof(Artisan),
            nameof(Admin),
            nameof(Doctor),
        };

        private MemberRole(string value)
        {
            Value = value;
        }

        public static Result<MemberRole> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid status value: {value}");

            return new MemberRole(value);
        }

    }
}
