﻿using I3Lab.BuildingBlocks.Domain;
using FluentResults;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class ConfirmationStatus : ValueObject
    {

        public static ConfirmationStatus Confirmed = new ConfirmationStatus(nameof(Confirmed));

        public static ConfirmationStatus Validation = new ConfirmationStatus(nameof(Validation));

        public static ConfirmationStatus Rejected = new ConfirmationStatus(nameof(Rejected));

        private string Value { get; }


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
                return Result.Fail($"Invalid status value: {value}");

            return new ConfirmationStatus(value);
        }

    }
}