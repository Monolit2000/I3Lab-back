using AutoFixture;
using FluentAssertions;
using FluentResults;
using NSubstitute;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.AddTreatmentMember;
using I3Lab.Treatments.Domain.Treatments.Errors;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;

namespace I3Lab.Treatments.UnitTests.Treatments
{

    public class AddTreatmentMemberCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly IMemberRepository _memberRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly AddTreatmentMemberCommandHandler _handler;

        public AddTreatmentMemberCommandHandlerTests()
        {
            _fixture = new Fixture();
            _memberRepository = Substitute.For<IMemberRepository>();
            _treatmentRepository = Substitute.For<ITreatmentRepository>();
            _handler = new AddTreatmentMemberCommandHandler(_memberRepository, _treatmentRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var command = _fixture.Create<AddTreatmentMemberCommand>();
            _treatmentRepository.GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>()).Returns((Treatment)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Treatment not found");
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenMemberNotFound()
        {
            // Arrange
            var command = _fixture.Create<AddTreatmentMemberCommand>();

            // Create a real instance of Treatment to avoid mocking issues
            var treatment = Treatment.CreateNew(
                _fixture.Create<Member>(),
                _fixture.Create<Member>(),
                TreatmentTitel.Create("Sample Treatment")
            );

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new MemberId(command.TreatmentId)), Arg.Any<CancellationToken>())
                .Returns(treatment);
            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.MemberId))).Returns((Member)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentApplicationErrors.MemberNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenAddToTreatmentMembersFails()
        {
            // Arrange
            var command = _fixture.Create<AddTreatmentMemberCommand>();

            // Create a real instance of Treatment to avoid mocking issues
            var treatment = Treatment.CreateNew(
                _fixture.Create<Member>(),
                _fixture.Create<Member>(),
                TreatmentTitel.Create("Sample Treatment")
            );

            var member = _fixture.Create<Member>();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new MemberId(command.TreatmentId)), Arg.Any<CancellationToken>())
                .Returns(treatment);
            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.MemberId))).Returns(member);

            // Simulate failure in AddToTreatmentMembers by adding the member manually beforehand
            treatment.AddToTreatmentMembers(member);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.MemberAlreadyAdded);
        }


        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenMemberSuccessfullyAdded()
        {
            // Arrange
            var command = _fixture.Create<AddTreatmentMemberCommand>();

            // Create a real instance of Treatment to avoid mocking issues
            var treatment = Treatment.CreateNew(
                _fixture.Create<Member>(),
                _fixture.Create<Member>(),
                TreatmentTitel.Create("Sample Treatment"));

            var member = _fixture.Create<Member>();

            _treatmentRepository.GetByIdAsync(Arg.Is<TreatmentId>(id => id == new MemberId(command.TreatmentId)), Arg.Any<CancellationToken>())
                .Returns(treatment);
            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.MemberId))).Returns(member);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentRepository.Received(1).SaveChangesAsync();
        }
    }
}