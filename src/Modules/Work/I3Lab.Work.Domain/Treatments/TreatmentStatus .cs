using FluentResults;
using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class TreatmentStatus : ValueObject
    {
        // Predefined Treatment Statuses
        internal static TreatmentStatus Active => new TreatmentStatus(nameof(Active));
        internal static TreatmentStatus Canceled => new TreatmentStatus(nameof(Canceled));
        internal static TreatmentStatus Finished => new TreatmentStatus(nameof(Finished));
        internal static TreatmentStatus Pending => new TreatmentStatus(nameof(Pending));

        public string Value { get; }

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Active),
            nameof(Canceled),
            nameof(Finished),
            nameof(Pending)
        };

        private TreatmentStatus(string value)
        {
            Value = value;
        }

        // Method to create a TreatmentStatus dynamically
        public static Result<TreatmentStatus> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid treatment status value: {value}");

            return new TreatmentStatus(value);
        }

        // Method to check if the status is valid
        public static bool IsValid(string value) => ValidStatuses.Contains(value);

        // Status checks
        public bool IsActive => Value == nameof(Active);
        public bool IsCanceled => Value == nameof(Canceled);
        public bool IsFinished => Value == nameof(Finished);
        public bool IsPending => Value == nameof(Pending);
    }
}
