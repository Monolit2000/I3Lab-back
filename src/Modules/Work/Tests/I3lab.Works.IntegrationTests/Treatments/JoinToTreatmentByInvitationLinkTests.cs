using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using I3Lab.Treatments.Domain.Treatments;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Domain.Treatments.Errors;
using I3Lab.Treatments.Application.Treatments.JoinToTreatmentByInvitationLink;

namespace I3lab.Works.IntegrationTests.Treatments
{
    public class JoinToTreatmentByInvitationLinkTests : BaseIntegrationTest
    {

        public JoinToTreatmentByInvitationLinkTests(IntegrationTestWebAppFactory factory)
        : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_AddMemberToTreatment_WhenTokenIsValid()
        {
            // Arrange
            var member = await CreateMemberAsync();
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();

            // Create a treatment with an invitation token
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(Faker.Lorem.Word()));
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            // Generate a valid invitation token
            var token = treatment.InvitationToken;

            var command = new JoinToTreatmentByInvitationLinkCommand(token.Token, member.Id.Value);
           
            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();

            // Verify that the member has been added to the treatment
            var updatedTreatment = await DbContext.Treatments
                .Include(t => t.TreatmentMembers)
                .FirstOrDefaultAsync(t => t.Id == treatment.Id);

            updatedTreatment.Should().NotBeNull();
            updatedTreatment.TreatmentMembers.Should().ContainSingle(m => m.Member.Id == member.Id);
        }

        [Fact]
        public async Task Handle_Should_Fail_WhenTokenIsInvalid()
        {
            // Arrange
            var member = await CreateMemberAsync();
            var invalidToken = Faker.Random.AlphaNumeric(20);

            var command = new JoinToTreatmentByInvitationLinkCommand
            {
                MemberId = member.Id.Value,
                Token = invalidToken
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.InvalidInviteLink);
        }

        [Fact]
        public async Task Handle_Should_Fail_WhenMemberIdIsInvalid()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();

            // Create a treatment with an invitation token
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(Faker.Lorem.Word()));
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            // Generate a valid invitation token
            var token = treatment.InvitationToken;

            // Use a random, non-existent member ID
            var invalidMemberId = Guid.NewGuid();

            var command = new JoinToTreatmentByInvitationLinkCommand
            {
                MemberId = invalidMemberId,
                Token = token.Token
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.MemberNotFound);
        }
    }
}
