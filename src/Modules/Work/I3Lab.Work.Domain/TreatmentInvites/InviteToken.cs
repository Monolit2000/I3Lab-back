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

        // Method to generate a new token with an expiration date
        public static InviteToken Generate(TimeSpan tokenLifetime)
        {
            var token = Guid.NewGuid().ToString();
            var expiryDate = DateTime.UtcNow.Add(tokenLifetime);
            return new InviteToken(token, expiryDate);
        }


         // Method to refresh the token, regenerating a new token and setting a new expiry date
        public Result<InviteToken> Refresh(TimeSpan tokenLifetime)
        {
            if (!IsExpired())
                return Result.Fail<InviteToken>("Cannot refresh a token that has not expired.");

            var inviteToken = Generate(tokenLifetime);

            return Result.Ok(inviteToken);
        }

        // Method to check if the token has expired
        public bool IsExpired() => DateTime.UtcNow > ExpiryDate;

        // Method to validate if the token is correct and valid (not expired)
        public Result Validate(string token)
        {
            if (Token != token)
                return Result.Fail("Invalid token.");

            if (IsExpired())
                return Result.Fail("Token has expired.");

            return Result.Ok();
        }

        // Static method to recreate an existing token (for database retrieval)
        public static Result<InviteToken> Create(string token, DateTime expiryDate)
        {
            if (expiryDate <= DateTime.UtcNow)
                return Result.Fail<InviteToken>("Token expiry date must be in the future.");

            return Result.Ok(new InviteToken(token, expiryDate));
        }
    }
}
