using Bogus;
using FluentAssertions;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Application.Treatments.FinishTreatment;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.Treatments.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace I3lab.Works.IntegrationTests.Treatments
{
    public class FinishTreatmentTests : BaseIntegrationTest
    {
        public FinishTreatmentTests(IntegrationTestWebAppFactory factory)
            : base(factory) { }

        [Fact]
        public async Task Handle_Should_FinishTreatment_WhenTreatmentIsActive()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();

            // Create an active treatment
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(Faker.Lorem.Word()));
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            var command = new FinishTreatmentCommand(creator.Id.Value, treatment.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue();

            // Verify that the treatment status is updated to "Finished"
            var updatedTreatment = await DbContext.Treatments
                .FirstOrDefaultAsync(t => t.Id == treatment.Id);

            updatedTreatment.Should().NotBeNull();
            updatedTreatment.Status.Should().Be(TreatmentStatus.Finished);
            //updatedTreatment.TreatmentDate.TreatmentFinished.Should().NotBeOnOrBefore(DateTime.UtcNow);
        }

        [Fact]
        public async Task Handle_Should_ReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();

            // Create an active treatment
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(Faker.Lorem.Word()));
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            var command = new FinishTreatmentCommand(creator.Id.Value, Guid.NewGuid());

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.TreatmentNotFound);
        }

        [Fact]
        public async Task Handle_Should_Fail_WhenTreatmentIsAlreadyCanceled()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();

            // Create and cancel a treatment
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(Faker.Lorem.Word()));
            treatment.Cancel();
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            var command = new FinishTreatmentCommand(creator.Id.Value, treatment.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            //result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.TreatmentAlreadyCanceled);
        }
    }
}
