using FluentResults;
using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Treatments.Domain.TreatmentStages
{
    public class TreatmentStageStatus : ValueObject
    {
        public static TreatmentStageStatus Pending => new TreatmentStageStatus(nameof(Pending));
        public static TreatmentStageStatus Active => new TreatmentStageStatus(nameof(Active));
        public static TreatmentStageStatus Completed => new TreatmentStageStatus(nameof(Completed));
        public static TreatmentStageStatus Closed => new TreatmentStageStatus(nameof(Closed));

        public string Value { get; }

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Pending),
            nameof(Active),
            nameof(Completed)
        };

        private TreatmentStageStatus(string value)
        {
            Value = value;
        }

        public static Result<TreatmentStageStatus> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid treatment stage status value: {value}");

            return new TreatmentStageStatus(value);
        }

        public bool IsActive => Value == nameof(Active);
        public bool IsCompleted => Value == nameof(Completed);
        public bool IsClosed => Value == nameof(Closed);
        public bool IsPending => Value == nameof(Pending);
    }
}
