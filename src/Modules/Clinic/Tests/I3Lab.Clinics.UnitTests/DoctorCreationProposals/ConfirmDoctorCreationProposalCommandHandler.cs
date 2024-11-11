using FluentAssertions;
using FluentResults;
using I3Lab.Clinics.Application.DoctorCreationProposals;
using I3Lab.Clinics.Domain.ClinicCreationProposals;
using I3Lab.Clinics.Domain.DoctorCreationProposals;
using I3Lab.Clinics.Domain.DoctorCreationProposals.Errors;
using I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal;
using NSubstitute;

namespace I3Lab.Clinics.UnitTests.DoctorCreationProposals
{
    public class ConfirmDoctorCreationProposalCommandHandlerTests : ClinicTestsBase
    {
        private readonly IDoctorCreationProposalRepository _doctorCreationProposalRepository;
        private readonly ConfirmDoctorCreationProposalCommandHandler _handler;

        public ConfirmDoctorCreationProposalCommandHandlerTests()
        {
            _doctorCreationProposalRepository = Substitute.For<IDoctorCreationProposalRepository>();
            _handler = new ConfirmDoctorCreationProposalCommandHandler(_doctorCreationProposalRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenProposalDoesNotExist()
        {
            // Arrange
            var command = new ConfirmDoctorCreationProposalCommand(Guid.NewGuid());

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
        public async Task Handle_ShouldConfirmProposal_WhenProposalExists()
        {
            // Arrange
            var testData = CreateClinicTestData();
            var command = new ConfirmDoctorCreationProposalCommand(testData.Proposal.Id.Value);

            _doctorCreationProposalRepository
                .GetByIdAsync(Arg.Any<DoctorCreationProposalId>(), Arg.Any<CancellationToken>())
                .Returns(testData.Proposal);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            testData.Proposal.ConfirmationStatus.Value.Should().Be(ConfirmationStatus.Confirmed.Value);
            await _doctorCreationProposalRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenConfirmFails()
        {
            // Arrange
            var testData = CreateClinicTestData();
            var proposal = testData.Proposal;
            proposal.Confirm();

            var command = new ConfirmDoctorCreationProposalCommand(Guid.NewGuid());

            _doctorCreationProposalRepository
                .GetByIdAsync(Arg.Any<DoctorCreationProposalId>(), Arg.Any<CancellationToken>())
                .Returns(proposal);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == DoctorCreationProposalsDomainErrors.ProposalCannotBeApproved);
            await _doctorCreationProposalRepository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        }
    }
}
