using AutoFixture;
using FluentAssertions;
using I3Lab.Treatments.Application.Treatments.ApplicationErrors;
using I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsReadOnly;
using I3Lab.Treatments.Application.Treatments.SetTreatmentMemberAccessibilityTypeAsEdit;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.UnitTests.Treatments
{
    public class SetTreatmentMemberAccessibilityTypeAsReadOnlyCommandHandlerTests : TreatmentTestsBase
    {
        private readonly Fixture _fixture;
        private readonly IMemberRepository _memberRepository;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly SetTreatmentMemberAccessibilityTypeAsReadOnlyCommandHandler _handler;

        public SetTreatmentMemberAccessibilityTypeAsReadOnlyCommandHandlerTests()
        {
            _fixture = new Fixture();
            _memberRepository = Substitute.For<IMemberRepository>();
            _treatmentRepository = Substitute.For<ITreatmentRepository>();
            _handler = new SetTreatmentMemberAccessibilityTypeAsReadOnlyCommandHandler(_memberRepository, _treatmentRepository);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenTreatmentNotFound()
        {
            // Arrange
            var command = _fixture.Create<SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand>();
            _treatmentRepository.GetByIdAsync(new TreatmentId(command.TreatmentId))
                .Returns((Treatment)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.TreatmentNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenMemberNotFound()
        {
            // Arrange
            var command = _fixture.Create<SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand>();

            var treatment = CreateTreatmentTestData(new TreatmentTestDataOptions()).Treatment;

            _treatmentRepository.GetByIdAsync(new TreatmentId(command.TreatmentId))
                .Returns(treatment);
            _memberRepository.GetAsync(new MemberId(command.TreatmentMemberId))
                .Returns((Member)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentsErrors.MemberNotFound);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenAccessibilityTypeIsSet()
        {
            // Arrange
            var command = _fixture.Create<SetTreatmentMemberAccessibilityTypeAsReadOnlyCommand>();

            var newMember = CreateMember();

            var testData = CreateTreatmentTestData(new TreatmentTestDataOptions());

            var treatment = testData.Treatment;

            treatment.AddToTreatmentMembers(newMember);

            _treatmentRepository.GetByIdAsync(new TreatmentId(command.TreatmentId))
                .Returns(treatment);
            _memberRepository.GetAsync(new MemberId(command.TreatmentMemberId))
                .Returns(newMember);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
            await _treatmentRepository.Received(1).SaveChangesAsync();
        }

        //[Fact]
        //public async Task Handle_ShouldReturnError_WhenSettingAccessibilityTypeFails()
        //{
        //    // Arrange
        //    var command = _fixture.Create<SetTreatmentMemberAccessibilityTypeAsEditCommand>();

        //    var newMember = CreateMember();

        //    var testData = CreateTreatmentTestData(new TreatmentTestDataOptions());

        //    var treatment = testData.Treatment;

        //    treatment.AddToTreatmentMembers(newMember);

        //    _treatmentRepository.GetByIdAsync(new TreatmentId(command.TreatmentId))
        //        .Returns(treatment);
        //    _memberRepository.GetAsync(new MemberId(command.TreatmentMemberId))
        //        .Returns(newMember);

        //    // Act
        //    var result = await _handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    result.IsFailed.Should().BeTrue("the setting of accessibility type should fail");
        //    await _treatmentRepository.DidNotReceive().SaveChangesAsync();
        //}
    }
}
