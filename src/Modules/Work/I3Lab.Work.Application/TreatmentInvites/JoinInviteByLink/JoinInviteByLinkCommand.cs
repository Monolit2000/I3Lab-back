using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.TreatmentInvites.JoinInviteByLink
{
    public class JoinInviteByLinkCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }

        public string Token { get; set; }

        public JoinInviteByLinkCommand()
        {
                
        }
        public JoinInviteByLinkCommand(
            Guid userId, 
            string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}
