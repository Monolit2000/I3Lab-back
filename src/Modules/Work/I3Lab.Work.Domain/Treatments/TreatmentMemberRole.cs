using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using System.Collections.Generic;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class TreatmentMemberRole : ValueObject
    {
        public static TreatmentMemberRole Doctor => new TreatmentMemberRole(nameof(Doctor));
        public static TreatmentMemberRole Patient => new TreatmentMemberRole(nameof(Patient));
        public static TreatmentMemberRole Admin => new TreatmentMemberRole(nameof(Admin));

        public string Value { get; }

        private static readonly HashSet<string> ValidRoles = new HashSet<string>
        {
            nameof(Doctor),
            nameof(Admin)
        };

        private TreatmentMemberRole(string value)
        {
            Value = value;
        }

        public static Result<TreatmentMemberRole> Create(string value)
        {
            if (!ValidRoles.Contains(value))
                return Result.Fail($"Invalid treatment member role: {value}");

            return new TreatmentMemberRole(value);
        }
    }
}