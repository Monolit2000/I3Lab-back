using AutoFixture;
using FluentAssertions;
using NSubstitute;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;

namespace I3Lab.Treatments.UnitTests.Treatments
{
    public class CreateTreatmentCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly IMemberRepository _memberRepositoryMock;
        private readonly ITreatmentRepository _treatmentRepositoryMock;
        private readonly CreateTreatmentCommandHandler _handler;

        public CreateTreatmentCommandHandlerTests()
        {
            _fixture = new Fixture();
            _memberRepositoryMock = Substitute.For<IMemberRepository>();
            _treatmentRepositoryMock = Substitute.For<ITreatmentRepository>();
            _handler = new CreateTreatmentCommandHandler(_memberRepositoryMock, _treatmentRepositoryMock);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentNameIsNotUnique()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentCommand>();
            _treatmentRepositoryMock.IsNameUniqueAsync(command.TreatmentTitel).Returns(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.NotUniqueName);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenCreatorIsNull()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentCommand>();
            _treatmentRepositoryMock.IsNameUniqueAsync(command.TreatmentTitel).Returns(true);
            _memberRepositoryMock.GetAsync(Arg.Any<MemberId>()).Returns((Member)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.CreatorIsNull);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenPatientIsNull()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentCommand>();
            var creator = _fixture.Create<Member>();
            _treatmentRepositoryMock.IsNameUniqueAsync(command.TreatmentTitel).Returns(true);
            _memberRepositoryMock.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.CreatorId))).Returns(creator);
            _memberRepositoryMock.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.PatientId))).Returns((Member)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.PatientIsNull);
        }

        [Fact]
        public async Task Handle_ShouldReturnTreatmentDto_WhenCommandIsValid()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentCommand>();
            var creator = _fixture.Create<Member>();
            var patient = _fixture.Create<Member>();

            _treatmentRepositoryMock.IsNameUniqueAsync(command.TreatmentTitel).Returns(true);
            _memberRepositoryMock.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.CreatorId))).Returns(creator);
            _memberRepositoryMock.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.PatientId))).Returns(patient);

            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(command.TreatmentTitel));
            _treatmentRepositoryMock.AddAsync(treatment).Returns(Task.CompletedTask);
            _treatmentRepositoryMock.SaveChangesAsync().Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Id.Should().NotBeEmpty();
            result.Value.IvniteToken.Should().NotBeNullOrWhiteSpace();
        }
    }

}