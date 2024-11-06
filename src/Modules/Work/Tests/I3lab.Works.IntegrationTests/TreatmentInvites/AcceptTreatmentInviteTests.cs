using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.TreatmentInvites;
using I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentInvite;

namespace I3lab.Treatments.IntegrationTests.TreatmentInvites
{
    public class AcceptTreatmentInviteTests : BaseIntegrationTest
    {
        public AcceptTreatmentInviteTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_AcceptTreatmentInvite_WhenCommandIsValid()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var invitee = await CreateMemberAsync();
            var treatmentInvite = await CreateTreatmentInviteAsync(creator.Id, invitee.Id);

            var command = new AcceptTreatmentInviteCommand(treatmentInvite.Id.Value);
           

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var acceptedInvite = await DbContext.TreatmentInvites
                .Where(ti => ti.Id == treatmentInvite.Id)
                .FirstOrDefaultAsync();

            acceptedInvite.Should().NotBeNull();
            acceptedInvite.IsAccepted().Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenTreatmentInviteNotFound()
        {
            // Arrange
            var command = new AcceptTreatmentInviteCommand(Guid.NewGuid());// Invalid invite ID

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentInviteApplicationErrors.TreatmentInviteNotFound);
        }

        [Fact]
        public async Task Handle_Should_AcceptTreatmentInvite_AndSaveChanges_WhenInviteIsValid()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var invitee = await CreateMemberAsync();
            var treatmentInvite = await CreateTreatmentInviteAsync(creator.Id, invitee.Id);

            var command = new AcceptTreatmentInviteCommand(treatmentInvite.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();

            var updatedInvite = await DbContext.TreatmentInvites
                .Where(ti => ti.Id == treatmentInvite.Id)
                .FirstOrDefaultAsync();

            updatedInvite.Should().NotBeNull();
            updatedInvite.IsAccepted().Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenAcceptFails()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var invitee = await CreateMemberAsync();
            var treatmentInvite = await CreateTreatmentInviteAsync(creator.Id, invitee.Id);

            treatmentInvite.Accept();
            await DbContext.SaveChangesAsync();

            var command = new AcceptTreatmentInviteCommand(treatmentInvite.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
        }
    }
}
