using I3Lab.BuildingBlocks.Domain;
using FluentResults;

namespace I3Lab.Treatments.Domain.TreatmentInvites
{
    public class InviteToken : ValueObject
    {
        public string Token { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        private InviteToken(
            string token, 
            DateTime expiryDate)
        {
            Token = token;
            ExpiryDate = expiryDate;
        }

        public static InviteToken Generate(TimeSpan tokenLifetime)
        {
            var token = Guid.NewGuid().ToString();
            var expiryDate = DateTime.UtcNow.Add(tokenLifetime);
            return new InviteToken(token, expiryDate);
        }

        public Result<InviteToken> Refresh(TimeSpan tokenLifetime)
        {
            if (!IsExpired())
                return Result.Fail<InviteToken>("Cannot refresh a token that has not expired.");

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

        public static Result<InviteToken> Create(string token, DateTime expiryDate)
        {
            if (expiryDate <= DateTime.UtcNow)
                return Result.Fail<InviteToken>("Token expiry date must be in the future.");

            return new InviteToken(token, expiryDate);
        }
    }
}
