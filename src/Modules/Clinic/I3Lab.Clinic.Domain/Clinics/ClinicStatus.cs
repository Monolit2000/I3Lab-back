using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Clinics.Domain.Clinics
{
    public class ClinicStatus : ValueObject
    {
        // Predefined Clinic Statuses
        public static ClinicStatus Active => new ClinicStatus(nameof(Active));
        public static ClinicStatus Canceled => new ClinicStatus(nameof(Canceled));
        public static ClinicStatus Finished => new ClinicStatus(nameof(Finished));
        public static ClinicStatus Pending => new ClinicStatus(nameof(Pending));

        public string Value { get; }

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Active),
            nameof(Canceled),
            nameof(Finished),
            nameof(Pending)
        };

        private ClinicStatus(string value)
        {
            Value = value;
        }

        // Method to create a ClinicStatus dynamically
        public static Result<ClinicStatus> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid treatment status value: {value}");

            return new ClinicStatus(value);
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
