using FluentAssertions;
using FluentResults;
using I3Lab.Clinics.Domain.DoctorCreationProposals;
using I3Lab.Clinics.Domain.DoctorCreationProposals.Errors;
using I3Lab.Clinics.Application.DoctorCreationProposals.RejectDoctorCreationProposal;
using NSubstitute;
using I3Lab.Clinics.Domain.ClinicCreationProposals;
using I3Lab.Clinics.Application.DoctorCreationProposals;

namespace I3Lab.Clinics.UnitTests.DoctorCreationProposals
{
    public class RejectDoctorCreationProposalCommandHandlerTests : ClinicTestsBase
    {
        private readonly IDoctorCreationProposalRepository _doctorCreationProposalRepository;
        private readonly RejectDoctorCreationProposalCommandHandler _handler;

        public RejectDoctorCreationProposalCommandHandlerTests()
        {
            _doctorCreationProposalRepository = Substitute.For<IDoctorCreationProposalRepository>();
            _handler = new RejectDoctorCreationProposalCommandHandler(_doctorCreationProposalRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenProposalDoesNotExist()
        {
            // Arrange
            var command = new RejectDoctorCreationProposalCommand(Guid.NewGuid());

            _doctorCreationProposalRepository
                .GetByIdAsync(Arg.Any<DoctorCreationProposalId>(), Arg.Any<CancellationToken>())
                .Returns((DoctorCreationProposal)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == DoctorCreationProposalApplicationErrors.ProposalNotExist);
        }

        [Fact]
        public async Task Handle_ShouldRejectProposal_WhenProposalExists()
        {
            // Arrange
            var testData = CreateClinicTestData();
            var command = new RejectDoctorCreationProposalCommand(testData.Proposal.Id.Value);

            _doctorCreationProposalRepository
                .GetByIdAsync(Arg.Any<DoctorCreationProposalId>(), Arg.Any<CancellationToken>())
                .Returns(testData.Proposal);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            testData.Proposal.ConfirmationStatus.Value.Should().Be(ConfirmationStatus.Rejected.Value);
            await _doctorCreationProposalRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenRejectFails()
        {
            // Arrange
            var testData = CreateClinicTestData();
            var proposal = testData.Proposal;
            proposal.Reject();

            var command = new RejectDoctorCreationProposalCommand(Guid.NewGuid());

            _doctorCreationProposalRepository
                .GetByIdAsync(Arg.Any<DoctorCreationProposalId>(), Arg.Any<CancellationToken>())
                .Returns(proposal);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == DoctorCreationProposalsDomainErrors.ProposalCannotBeRejected);
            await _doctorCreationProposalRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }
    }
}
