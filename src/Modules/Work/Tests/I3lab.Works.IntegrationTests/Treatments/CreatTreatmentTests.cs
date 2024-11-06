using FluentAssertions;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.Members.CreateMember;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using Microsoft.EntityFrameworkCore;


namespace I3lab.Works.IntegrationTests.Treatments
{
    public class CreateTreatmentTests : BaseIntegrationTest
    {
        public CreateTreatmentTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_CreateTreatment_WhenCommandIsValid()
        {
            // Arrange
            var creatorId = await CreateMemberAsync();
            var patientId = await CreateMemberAsync();
            var command = new CreateTreatmentCommand
            {
                CreatorId = creatorId.Value,
                PatientId = patientId.Value,
                TreatmentTitel = Faker.Name.JobTitle()
            };

            // Act
            var result = await Sender.Send(command);

            var defaultTreatmentStages = await DbContext.TreatmentStages
                .Where(x => x.TreatmentId == new TreatmentId(result.Value.TreatmentId))
                .ToListAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.InviteToken.Should().NotBeNullOrEmpty();

            defaultTreatmentStages.Should().NotBeEmpty();
            defaultTreatmentStages.Should().HaveCount(4);
        }

        [Fact]
        public async Task Handle_Should_AddTreatmentToDatabase_WhenCommandIsValid()
        {
            // Arrange
            var creatorId = await CreateMemberAsync();
            var patientId = await CreateMemberAsync();
            var command = new CreateTreatmentCommand
            {
                CreatorId = creatorId.Value,
                PatientId = patientId.Value,
                TreatmentTitel = Faker.Lorem.Sentence(3)
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            var treatment = await DbContext.Treatments.FirstOrDefaultAsync(t => t.Id == new TreatmentId(result.Value.TreatmentId));
            treatment.Should().NotBeNull();
            treatment.Titel.Value.Should().Be(command.TreatmentTitel);
            treatment.Creator.Id.Value.Should().Be(creatorId.Value);
            treatment.Patient.Id.Value.Should().Be(patientId.Value);
        }

        [Fact]
        public async Task Handle_Should_ReturnNotUniqueError_WhenTreatmentTitleIsNotUnique()
        {
            // Arrange
            var creatorId = await CreateMemberAsync();
            var patientId = await CreateMemberAsync();
            var existingTitle = "Existing Treatment";

            // First, create a treatment with the existing title
            await Sender.Send(new CreateTreatmentCommand
            {
                CreatorId = creatorId.Value,
                PatientId = patientId.Value,
                TreatmentTitel = existingTitle
            });

            // Now try to create another treatment with the same title
            var command = new CreateTreatmentCommand
            {
                CreatorId = creatorId.Value,
                PatientId = patientId.Value,
                TreatmentTitel = existingTitle
            };

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message.Contains("not unique"));
        }

        private async Task<MemberId> CreateMemberAsync()
        {
            var command = new CreateMemberCommand(Guid.NewGuid(), Faker.Internet.Email());
            var result = await Sender.Send(command);
            return new MemberId(result.Value.Id);
        }
    }
}
