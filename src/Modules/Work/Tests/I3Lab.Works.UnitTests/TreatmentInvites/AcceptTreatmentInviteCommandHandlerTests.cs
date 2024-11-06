using NSubstitute;
using AutoFixture;
using FluentAssertions;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Application.TreatmentInvites;
using I3Lab.Treatments.Application.TreatmentInvites.AcceptTreatmentInvite;


namespace I3Lab.Treatments.UnitTests.TreatmentInvites
{
    public class AcceptTreatmentInviteCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentInviteRepository _treatmentInviteRepositoryMock;
        private readonly AcceptTreatmentInviteCommandHandler _handler;

        public AcceptTreatmentInviteCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentInviteRepositoryMock = Substitute.For<ITreatmentInviteRepository>();
            _handler = new AcceptTreatmentInviteCommandHandler(_treatmentInviteRepositoryMock);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentInviteDoesNotExist()
        {
            // Arrange
            var command = _fixture.Create<AcceptTreatmentInviteCommand>();

            _treatmentInviteRepositoryMock
                .GetByIdAsync(Arg.Any<TreatmentInviteId>())
                .Returns((TreatmentInvite)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentInviteApplicationErrors.TreatmentInviteNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenAcceptFails()
        {
            // Arrange
            var command = _fixture.Create<AcceptTreatmentInviteCommand>();
            var treatmentInvite = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentInvite;

            treatmentInvite.Accept();

            _treatmentInviteRepositoryMock
                .GetByIdAsync(Arg.Any<TreatmentInviteId>())
                .Returns(treatmentInvite);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            await _treatmentInviteRepositoryMock.DidNotReceive().SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldAcceptInviteAndSaveChanges_WhenInviteIsValid()
        {
            // Arrange
            var command = _fixture.Create<AcceptTreatmentInviteCommand>();
                  var treatmentInvite = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentInvite;

            _treatmentInviteRepositoryMock
                .GetByIdAsync(Arg.Any<TreatmentInviteId>())
                .Returns(treatmentInvite);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentInviteRepositoryMock.Received(1).SaveChangesAsync();
        }
    }
}
