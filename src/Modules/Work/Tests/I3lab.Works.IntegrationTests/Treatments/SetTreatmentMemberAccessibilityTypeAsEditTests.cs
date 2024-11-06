using FluentAssertions;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsEdit;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.WorkAccebilitys;
using Microsoft.EntityFrameworkCore;


namespace I3lab.Treatments.IntegrationTests.Treatments
{
    public class SetTreatmentMemberAccessibilityTypeAsEditTests : BaseIntegrationTest
    {
        public SetTreatmentMemberAccessibilityTypeAsEditTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_SetAccessibilityTypeAsEdit_WhenCommandIsValid()
        {
            // Arrange
            var treatmentMember = await CreateMemberAsync();

            var treatmentId = await CreateTreatmentAsync(treatmentMember);

            var command = new SetTreatmentMemberAccessibilityTypeAsEditCommand(treatmentId.Value, treatmentMember.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert

            var updatedTreatment = await DbContext.Treatments
            .Include(t => t.TreatmentMembers)
            .FirstOrDefaultAsync(t => t.Id == treatmentId);

            result.IsSuccess.Should().BeTrue();

            var updatedMember = updatedTreatment.TreatmentMembers
                .Single(m => m.Member.Id == treatmentMember.Id);

            updatedMember.AccessibilityType.Value.Should().Be(AccessibilityType.Edit.Value);
        }



        [Fact]
        public async Task Handle_Should_SetAccessibilityTypeAsEdit_WhenCommandIsValidV2()
        {
            // Arrange
            var member = await CreateMemberAsync();
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();

            // Create a treatment with an invitation token
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(Faker.Lorem.Word()));
            treatment.AddToTreatmentMembers(member);
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            var command = new SetTreatmentMemberAccessibilityTypeAsEditCommand(treatment.Id.Value, member.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert

            result.IsSuccess.Should().BeTrue();

            var updatedMember = treatment.TreatmentMembers
                .Single(m => m.Member.Id == member.Id);

            updatedMember.AccessibilityType.Value.Should().Be(AccessibilityType.Edit.Value);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenMemberNotFound()
        {
            // Arrange
            var treatmentId = await CreateTreatmentAsync();
            var nonExistentMemberId = Guid.NewGuid();

            var command = new SetTreatmentMemberAccessibilityTypeAsEditCommand(treatmentId.Value, nonExistentMemberId);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.MemberNotFound);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var nonExistentTreatmentId = Guid.NewGuid();
            var member = await CreateMemberAsync();

            var command = new SetTreatmentMemberAccessibilityTypeAsEditCommand(nonExistentTreatmentId, member.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.TreatmentNotFound);
        }
    }
}
