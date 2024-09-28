using MediatR;
using FluentResults;

namespace I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentIInviteByLink
{
    public class AcceptTreatmentIInviteByLinkCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }

        public string Token { get; set; }

        public AcceptTreatmentIInviteByLinkCommand()
        {
                
        }
        public AcceptTreatmentIInviteByLinkCommand(
            Guid userId, 
            string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}
