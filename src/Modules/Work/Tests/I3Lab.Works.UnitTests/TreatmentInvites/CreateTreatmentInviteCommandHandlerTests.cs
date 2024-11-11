using AutoFixture;
using NSubstitute;
using FluentAssertions;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Application.TreatmentInvites;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Application.TreatmentInvites.CreateTreatmentInvite;

namespace I3Lab.Treatments.UnitTests.TreatmentInvites
{
    public class CreateTreatmentInviteCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly IMemberRepository _memberRepositoryMock;
        private readonly ITreatmentRepository _treatmentRepositoryMock;
        private readonly ITreatmentInviteRepository _treatmentInviteRepositoryMock;
        private readonly CreateTreatmentInviteCommandHandler _handler;

        public CreateTreatmentInviteCommandHandlerTests()
        {
            _fixture = new Fixture();
            _memberRepositoryMock = Substitute.For<IMemberRepository>();
            _treatmentRepositoryMock = Substitute.For<ITreatmentRepository>();
            _treatmentInviteRepositoryMock = Substitute.For<ITreatmentInviteRepository>();
            _handler = new CreateTreatmentInviteCommandHandler(
                _memberRepositoryMock,
                _treatmentRepositoryMock,
                _treatmentInviteRepositoryMock);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentDoesNotExist()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentInviteCommand>();

            _treatmentRepositoryMock
                .GetByIdAsync(Arg.Any<TreatmentId>(), Arg.Any<CancellationToken>())
                .Returns((Treatment)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentApplicationErrors.TreatmentNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenMemberToInviteDoesNotExist()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentInviteCommand>();

            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;

            _treatmentRepositoryMock
                .GetByIdAsync(new TreatmentId(command.TreatmentId), Arg.Any<CancellationToken>())
                .Returns(treatment);

            _memberRepositoryMock
                .GetAsync(new MemberId(command.MemberToInviteId))
                .Returns((Member)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentInviteApplicationErrors.InviteeNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenInviterDoesNotExist()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentInviteCommand>();

            var testData = CreateTreatmentTestData(new TreatmentTestDataOptions());

            var treatment = testData.Treatment;

            var memberToInvite = CreateMember();

            _treatmentRepositoryMock
                .GetByIdAsync(new TreatmentId(command.TreatmentId), Arg.Any<CancellationToken>())
                .Returns(treatment);
            _memberRepositoryMock
                .GetAsync(new MemberId(command.MemberToInviteId))
                .Returns(memberToInvite);
            _memberRepositoryMock
                .GetAsync(new MemberId(command.InviterId))
                .Returns((Member)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentInviteApplicationErrors.InviterNotFound);
        }

        [Fact]
        public async Task Handle_ShouldCreateTreatmentInvite_WhenCommandIsValid()
        {
            // Arrange
            var command = _fixture.Create<CreateTreatmentInviteCommand>();
            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;
            var memberToInvite = CreateMember();
            var inviter = CreateMember();

            _treatmentRepositoryMock
                .GetByIdAsync(new TreatmentId(command.TreatmentId), Arg.Any<CancellationToken>())
                .Returns(treatment);
            _memberRepositoryMock
                .GetAsync(new MemberId(command.MemberToInviteId))
                .Returns(memberToInvite);
            _memberRepositoryMock
                .GetAsync(new MemberId(command.InviterId))
                .Returns(inviter);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentInviteRepositoryMock
                .Received(1)
                .AddAsync(Arg.Is<TreatmentInvite>(invite => invite.InvitedMember == memberToInvite && invite.InviterMember == inviter));
        }
    }
}
