using FluentResults;
using I3Lab.BuildingBlocks.Domain;
using I3Lab.Treatments.Domain.TreatmentInvites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Domain.Treatments
{
    public class InvitationToken : ValueObject
    {
        public string Token { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        private InvitationToken(
            string token,
            DateTime expiryDate)
        {
            Token = token;
            ExpiryDate = expiryDate;
        }

        public static InvitationToken Generate(TimeSpan tokenLifetime)
        {
            var token = Guid.NewGuid().ToString();
            var expiryDate = DateTime.UtcNow.Add(tokenLifetime);
            return new InvitationToken(token, expiryDate);
        }

        public Result<InvitationToken> Refresh(TimeSpan tokenLifetime)
        {
            if (!IsExpired())
                return Result.Fail("Cannot refresh a token that has not expired.");

            // ExpiryDate = DateTime.UtcNow.Add(tokenLifetime);

            var inviteToken = Generate(tokenLifetime);

            return inviteToken;
        }

        public bool IsExpired() => DateTime.UtcNow > ExpiryDate;

        public Result Validate(string token)
        {
            if (Token != token)
                return Result.Fail("Invalid token.");

            if (IsExpired())
                return Result.Fail("Token has expired.");

            return Result.Ok();
        }

        public static Result<InvitationToken> Create(string token, DateTime expiryDate)
        {
            if (expiryDate <= DateTime.UtcNow)
                return Result.Fail("Token expiry date must be in the future.");

            return new InvitationToken(token, expiryDate);
        }
    }
}
