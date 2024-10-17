using FluentResults;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;

namespace I3Lab.Treatments.Domain.TreatmentInvites.Errors
{
    public static class TreatmentInviteErrors
    {
        public static string InviteAlreadyExists(Member memberToInvite, Treatment treatment)
            => $"An invite already exists for member {memberToInvite.Id} to the treatment {treatment.Id}.";
        
        public static string InvalidInviteStatus()
            => "Invalid invite status. Only pending invites can be accepted or rejected.";

        public static string MemberNotAuthorized(Member inviter)
            => $"Member {inviter.Id} is not authorized to invite other members to this treatment.";

        public static string InviteNotFound(TreatmentInviteId inviteId)
            => $"The invite with ID {inviteId} was not found.";

        public static string TreatmentNotFound(Treatment treatment)
            => $"The treatment with ID {treatment.Id} was not found.";

        public static string InviteCannotBeProcessed(TreatmentInvite invite)
            => $"This invite cannot be processed due to its current status. Invite ID: {invite.Id}, Status: {invite.TreatmentInviteStatus}.";
    }
}
