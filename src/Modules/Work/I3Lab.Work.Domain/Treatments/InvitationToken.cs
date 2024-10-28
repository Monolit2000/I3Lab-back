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

        public static InvitationToken Generate(TimeSpan tokenLifetime = default)
        {
            //var token = Guid.NewGuid().ToString();
            var token = GenerateRandomToken(7);
            var expiryDate = DateTime.UtcNow.Add(tokenLifetime == default ? TimeSpan.FromHours(24) : tokenLifetime);
            return new InvitationToken(token, expiryDate);
        }

        private static string GenerateRandomToken(int length)
        {
            Random random = new Random();
            //string characters = Guid.NewGuid().ToString("N");
            string characters = $"{Guid.NewGuid()}ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var token = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                token.Append(characters[random.Next(characters.Length)]);
            }
            return token.ToString();
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
