using FluentResults;
using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Clinics.Domain.ClinicCreationProposals
{
    public class ConfirmationStatus : ValueObject
    {
        public static ConfirmationStatus Confirmed = new ConfirmationStatus(nameof(Confirmed));

        public static ConfirmationStatus Validation = new ConfirmationStatus(nameof(Validation));

        public static ConfirmationStatus Rejected = new ConfirmationStatus(nameof(Rejected));

        public string Value { get; }

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Confirmed),
            nameof(Validation),
            nameof(Rejected)
        };

        private ConfirmationStatus(string value)
            => Value = value;

        public static Result<ConfirmationStatus> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid status Id: {value}");

            return new ConfirmationStatus(value);
        }
    }
}
