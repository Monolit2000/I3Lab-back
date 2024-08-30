using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Administration.Domain.DoctorCreationProposals
{
    public class DoctorCreationProposalStatus : ValueObject
    {

        public static DoctorCreationProposalStatus Confirmed = new DoctorCreationProposalStatus(nameof(Confirmed));

        public static DoctorCreationProposalStatus Validation = new DoctorCreationProposalStatus(nameof(Validation));

        public static DoctorCreationProposalStatus Rejected = new DoctorCreationProposalStatus(nameof(Rejected));

        private string Value { get; }


        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Confirmed),
            nameof(Validation),
            nameof(Rejected)
        };

        private DoctorCreationProposalStatus(string value)
            => Value = value;

        public static Result<DoctorCreationProposalStatus> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid status value: {value}");

            return new DoctorCreationProposalStatus(value);
        }

    }
}
