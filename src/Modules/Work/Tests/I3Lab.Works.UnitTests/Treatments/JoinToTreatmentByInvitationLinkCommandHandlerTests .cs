using AutoFixture;
using NSubstitute;
using FluentAssertions;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Application.Treatments.JoinToTreatmentByInvitationLink;

namespace I3Lab.Treatments.UnitTests.Treatments
{
    public class JoinToTreatmentByInvitationLinkCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly IMemberRepository _memberRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly JoinToTreatmentByInvitationLinkCommandHandler _handler;

        public JoinToTreatmentByInvitationLinkCommandHandlerTests()
        {
            _fixture = new Fixture();
            _memberRepository = Substitute.For<IMemberRepository>();
            _treatmentRepository = Substitute.For<ITreatmentRepository>();
            _handler = new JoinToTreatmentByInvitationLinkCommandHandler(_memberRepository, _treatmentRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var command = _fixture.Create<JoinToTreatmentByInvitationLinkCommand>();
            _treatmentRepository.GetByTokenAsync(command.Token).Returns((Treatment)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == "Invalid invite link");
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTokenValidationFails()
        {
            // Arrange
            var command = _fixture.Create<JoinToTreatmentByInvitationLinkCommand>();

            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;

            _treatmentRepository.GetByTokenAsync(command.Token).Returns(treatment);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            await _treatmentRepository.DidNotReceive().SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldAddMemberToTreatment_WhenInviteIsValid()
        {
            // Arrange
            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;

            var command = _fixture.Build<JoinToTreatmentByInvitationLinkCommand>()
                .With(x => x.Token, treatment.InvitationToken.Token)
                .Create();

            var member = _fixture.Create<Member>();

            _treatmentRepository.GetByTokenAsync(command.Token).Returns(treatment);

            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.MemberId)))
                .Returns(member);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentRepository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenAddingMemberFails()
        {
            // Arrange
            var command = _fixture.Create<JoinToTreatmentByInvitationLinkCommand>();

            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;
            var member = _fixture.Create<Member>();

            _treatmentRepository.GetByTokenAsync(command.Token).Returns(treatment);

            _memberRepository.GetAsync(Arg.Is<MemberId>(id => id == new MemberId(command.MemberId)))
                .Returns((Member)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            await _treatmentRepository.DidNotReceive().SaveChangesAsync();
        }
    }
}
