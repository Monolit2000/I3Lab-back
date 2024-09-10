using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;

namespace I3Lab.Works.Domain.TreatmentInvites.Errors
{
    public static class TreatmentInviteErrors
    {
        public static Error InviteAlreadyExists(Member memberToInvite, Treatment treatment)
        {
            return new Error($"An invite already exists for member {memberToInvite.Id} to the treatment {treatment.Id}.")
                .WithMetadata("MemberId", memberToInvite.Id.ToString())
                .WithMetadata("TreatmentId", treatment.Id.ToString());
        }

        public static Error InvalidInviteStatus()
        {
            return new Error("Invalid invite status. Only pending invites can be accepted or rejected.");
        }

        public static Error MemberNotAuthorized(Member inviter)
        {
            return new Error($"Member {inviter.Id} is not authorized to invite other members to this treatment.")
                .WithMetadata("InviterId", inviter.Id.ToString());
        }

        public static Error InviteNotFound(TreatmentInviteId inviteId)
        {
            return new Error($"The invite with ID {inviteId} was not found.")
                .WithMetadata("InviteId", inviteId.ToString());
        }

        public static Error TreatmentNotFound(Treatment treatment)
        {
            return new Error($"The treatment with ID {treatment.Id} was not found.")
                .WithMetadata("TreatmentId", treatment.Id.ToString());
        }

        public static Error InviteCannotBeProcessed(TreatmentInvite invite)
        {
            return new Error("This invite cannot be processed due to its current status.")
                .WithMetadata("InviteId", invite.Id.ToString())
                .WithMetadata("Status", invite.TreatmentInviteStatus.ToString());
        }
    }
}
