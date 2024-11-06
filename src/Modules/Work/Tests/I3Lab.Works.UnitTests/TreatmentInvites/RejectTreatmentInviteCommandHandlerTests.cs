using NSubstitute;
using AutoFixture;
using FluentAssertions;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Application.TreatmentInvites;
using I3Lab.Treatments.Application.TreatmentInvites.RejectTreatmentInvite;

namespace I3Lab.Treatments.UnitTests.TreatmentInvites
{
    public class RejectTreatmentInviteCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly ITreatmentInviteRepository _treatmentInviteRepositoryMock;
        private readonly RejectTreatmentInviteCommandHandler _handler;

        public RejectTreatmentInviteCommandHandlerTests()
        {
            _fixture = new Fixture();
            _treatmentInviteRepositoryMock = Substitute.For<ITreatmentInviteRepository>();
            _handler = new RejectTreatmentInviteCommandHandler(_treatmentInviteRepositoryMock);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentInviteDoesNotExist()
        {
            // Arrange
            var command = _fixture.Create<RejectTreatmentInviteCommand>();

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
        public async Task Handle_ShouldReturnError_WhenRejectFails()
        {
            // Arrange
            var command = _fixture.Create<RejectTreatmentInviteCommand>();
            var treatmentInvite = CreateTreatmentTestData(new TreatmentTestDataOptions()).TreatmentInvite;

            treatmentInvite.Reject();

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
        public async Task Handle_ShouldRejectInviteAndSaveChanges_WhenInviteIsValid()
        {
            // Arrange
            var command = _fixture.Create<RejectTreatmentInviteCommand>();
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
