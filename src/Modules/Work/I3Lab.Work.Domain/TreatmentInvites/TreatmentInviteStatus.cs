using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace I3Lab.Works.Domain.TreatmentInvites
{
    public class TreatmentInviteStatus : ValueObject
    {
        public string Value{ get; }


        public static TreatmentInviteStatus Rejected = new TreatmentInviteStatus(nameof(Rejected));

        public static TreatmentInviteStatus Accepted = new TreatmentInviteStatus(nameof(Accepted));

        public static TreatmentInviteStatus Pending = new TreatmentInviteStatus(nameof(Pending));

        

        private TreatmentInviteStatus( string value) 
            => Value = value;

        private static readonly HashSet<string> ValidStatuses = new HashSet<string>
        {
            nameof(Rejected),
            nameof(Accepted),
            nameof(Pending)
        };

        public static Result<TreatmentInviteStatus> Create(string value)
        {
            if (!ValidStatuses.Contains(value))
                return Result.Fail($"Invalid status value: {value}");

            return new TreatmentInviteStatus(value);
        }


    }
}
