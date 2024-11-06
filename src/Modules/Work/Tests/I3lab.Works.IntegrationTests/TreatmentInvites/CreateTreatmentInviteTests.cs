using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Domain.Treatments.Errors;
using I3Lab.Treatments.Application.TreatmentInvites;
using I3Lab.Treatments.Application.TreatmentInvites.CreateTreatmentInvite;

namespace I3lab.Treatments.IntegrationTests.TreatmentInvites
{
    public class CreateTreatmentInviteTests : BaseIntegrationTest
    {
        public CreateTreatmentInviteTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_CreateTreatmentInvite_WhenCommandIsValid()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var invitee = await CreateMemberAsync();
            var treatmentId = await CreateTreatmentAsync();

            var command = new CreateTreatmentInviteCommand
            {
                TreatmentId = treatmentId.Value,
                MemberToInviteId = invitee.Id.Value,
                InviterId = creator.Id.Value
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            var treatmentInvite = await DbContext.TreatmentInvites
                .Where(ti => ti.Treatment.Id == treatmentId)
                .ToListAsync();
            treatmentInvite.Should().HaveCount(1);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var invitee = await CreateMemberAsync();

            var command = new CreateTreatmentInviteCommand
            {
                TreatmentId = Guid.NewGuid(),  // Invalid treatment ID
                MemberToInviteId = invitee.Id.Value,
                InviterId = creator.Id.Value
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.TreatmentNotFound);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenInviteeNotFound()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var treatmentId = await CreateTreatmentAsync();

            var command = new CreateTreatmentInviteCommand
            {
                TreatmentId = treatmentId.Value,
                MemberToInviteId = Guid.NewGuid(),  // Invalid invitee ID
                InviterId = creator.Id.Value
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentInviteApplicationErrors.InviteeNotFound);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenInviterNotFound()
        {
            // Arrange
            var invitee = await CreateMemberAsync();
            var inviter = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var treatmentId = await CreateTreatmentAsync();

            var command = new CreateTreatmentInviteCommand
            {
                TreatmentId = treatmentId.Value,
                MemberToInviteId = invitee.Id.Value,
                InviterId = Guid.NewGuid()  // Invalid inviter ID
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentInviteApplicationErrors.InviterNotFound);
        }

        [Fact]
        public async Task Handle_Should_AddTreatmentInviteToDatabase_WhenCommandIsValid()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var invitee = await CreateMemberAsync();
            var treatmentId = await CreateTreatmentAsync();

            var command = new CreateTreatmentInviteCommand
            {
                TreatmentId = treatmentId.Value,
                MemberToInviteId = invitee.Id.Value,
                InviterId = creator.Id.Value
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var treatmentInvite = await DbContext.TreatmentInvites
                .Where(ti => ti.Treatment.Id == treatmentId)
                .FirstOrDefaultAsync();

            treatmentInvite.Should().NotBeNull();
            treatmentInvite.InvitedMember.Id.Should().Be(invitee.Id);
            treatmentInvite.InviterMember.Id.Should().Be(creator.Id);
        }
    }
}
