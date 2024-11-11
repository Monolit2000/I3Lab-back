using FluentAssertions;
using FluentResults;
using I3Lab.Clinics.Application.Doctors;
using I3Lab.Clinics.Application.Doctors.CreateDoctor;
using I3Lab.Clinics.Domain.DoctorCreationProposals;
using I3Lab.Clinics.Domain.Doctors;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace I3Lab.Clinics.UnitTests.Doctors
{
    public class CreateDoctorCommandHandlerTests : ClinicTestsBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorCreationProposalRepository _doctorCreationProposalRepository;
        private readonly CreateDoctorCommandHandler _handler;

        public CreateDoctorCommandHandlerTests()
        {
            _doctorRepository = Substitute.For<IDoctorRepository>();
            _doctorCreationProposalRepository = Substitute.For<IDoctorCreationProposalRepository>();
            _handler = new CreateDoctorCommandHandler(_doctorRepository, _doctorCreationProposalRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailure_WhenProposalDoesNotExist()
        {
            // Arrange
            var command = new CreateDoctorCommand(new DoctorCreationProposalId(Guid.NewGuid()));

            _doctorCreationProposalRepository
                .GetByIdAsync(Arg.Any<DoctorCreationProposalId>())
                .Returns((DoctorCreationProposal)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == DoctorApplicationErrors.DoctorCreationProposalNotFound);
        }

        [Fact]
        public async Task Handle_ShouldCreateDoctor_WhenProposalExists()
        {
            // Arrange
            var testData = CreateClinicTestData();
            var proposal = testData.Proposal;
            var command = new CreateDoctorCommand(proposal.Id);

            _doctorCreationProposalRepository
                .GetByIdAsync(Arg.Any<DoctorCreationProposalId>())
                .Returns(proposal);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _doctorRepository.Received(1).AddAsync(Arg.Is<Doctor>(d => d.Email == testData.Doctor.Email));
        }

        //[Fact]
        //public async Task Handle_ShouldReturnFailure_WhenAddingDoctorFails()
        //{
        //    // Arrange
        //    var testData = CreateClinicTestData();
        //    var proposal = testData.Proposal;
        //    var command = new CreateDoctorCommand(proposal.Id);

        //    _doctorCreationProposalRepository
        //        .GetByIdAsync(Arg.Any<DoctorCreationProposalId>())
        //        .Returns(proposal);

        //    //_doctorRepository
        //    //    .When(repo => repo.AddAsync(Arg.Any<Doctor>()))
        //    //    .Do(_ => throw new Exception("Database error"));

        //    // Act
        //    var result = await _handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    result.IsFailed.Should().BeTrue();
        //    //result.Errors.Should().ContainSingle(e => e.Message == "Database error");
        //}
    }
}
