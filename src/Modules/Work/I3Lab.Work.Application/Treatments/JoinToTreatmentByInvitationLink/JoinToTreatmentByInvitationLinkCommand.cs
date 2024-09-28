using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Treatments.JoinToTreatmentByInvitationLink
{
    public class JoinToTreatmentByInvitationLinkCommand : IRequest<Result>
    {
        public string Token {  get; set; }

        public Guid MemberId { get; set; }    

        public JoinToTreatmentByInvitationLinkCommand()
        {
            
        }
        public JoinToTreatmentByInvitationLinkCommand(
            string token, 
            Guid memberId)
        {
            Token = token;
            MemberId = memberId;    
        }
    }
}
