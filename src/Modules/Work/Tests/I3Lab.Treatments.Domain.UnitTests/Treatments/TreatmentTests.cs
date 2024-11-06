using FluentAssertions;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.Treatments.Events;
using I3Lab.Treatments.Domain.Treatments.Errors;
using I3Lab.Treatments.Domain.WorkAccebilitys;


namespace I3Lab.Treatments.UnitTests.Domain.Treatments
{
    public class TreatmentTests
    {
        private readonly Member _creator = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");
        private readonly Member _patient = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");
        private readonly TreatmentTitel _titel = TreatmentTitel.Create("Initial Treatment");

        [Fact]
        public void CreateNew_ShouldInitializeTreatmentWithGivenProperties()
        {
            // Act
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);

            // Assert
            treatment.Creator.Should().Be(_creator);
            treatment.Patient.Should().Be(_patient);
            treatment.Titel.Should().Be(_titel);
            treatment.Status.Should().Be(TreatmentStatus.Active);
            treatment.TreatmentMembers.Should().HaveCount(2); // Creator and Patient
            treatment.DomainEvents.Should().ContainSingle(e => e is TreatmentCreatedDomainEvent);
        }

        [Fact]
        public void Invite_ShouldCreateTreatmentInviteSuccessfully()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);
            var newMember = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");

            // Act
            var invite = treatment.Invite(newMember, _creator);

            // Assert
            invite.InvitedMember.Id.Should().Be(newMember.Id);
            invite.InviterMember.Id.Should().Be(_creator.Id);
        }

        [Fact]
        public void AddToTreatmentMembers_ShouldAddNewMember_WhenNotAlreadyInTreatment()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);
            var newMember = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");

            // Act
            var result = treatment.AddToTreatmentMembers(newMember);

            // Assert
            result.IsSuccess.Should().BeTrue();
            treatment.TreatmentMembers.Should().ContainSingle(m => m.Member.Id == newMember.Id);
        }

        [Fact]
        public void AddToTreatmentMembers_ShouldReturnFailure_WhenMemberAlreadyInTreatment()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);

            // Act
            var result = treatment.AddToTreatmentMembers(_creator);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.MemberAlreadyAdded);
        }

        [Fact]
        public void RemoveTreatmentMember_ShouldRemoveMemberSuccessfully()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);

            // Act
            var result = treatment.RemoveTreatmentMember(_creator.Id, _creator.Id);

            // Assert
            result.IsSuccess.Should().BeTrue();
            treatment.TreatmentMembers.Should().NotContain(m => m.Member.Id == _creator.Id);
            treatment.DomainEvents.Should().ContainSingle(e => e is MemberRemovedFromTreatmentDomainEvent);
        }

        [Fact]
        public void RemoveTreatmentMember_ShouldReturnError_WhenMemberNotFound()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);
            var nonExistentMemberId = new MemberId(Guid.NewGuid());

            // Act
            var result = treatment.RemoveTreatmentMember(nonExistentMemberId, _creator.Id);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.MemberNotFound);
        }

        [Fact]
        public void ValidateInviteToken_ShouldReturnSuccess_WhenTokenIsValid()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);
            var token = treatment.InvitationToken.Token;

            // Act
            var result = treatment.ValidateInviteToken(token);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Cancel_ShouldSetStatusToCanceledAndAddDomainEvent()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);

            // Act
            var result = treatment.Cancel();

            // Assert
            result.IsSuccess.Should().BeTrue();
            treatment.Status.Should().Be(TreatmentStatus.Canceled);
            treatment.DomainEvents.Should().ContainSingle(e => e is TreatmentCanceledDomainEvent);
        }

        [Fact]
        public void Finish_ShouldSetStatusToFinishedAndAddDomainEvent()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);

            // Act
            var result = treatment.Finish();

            // Assert
            result.IsSuccess.Should().BeTrue();
            treatment.Status.Should().Be(TreatmentStatus.Finished);
            treatment.DomainEvents.Should().ContainSingle(e => e is TreatmentFinishedDomainEvent);
        }


        [Fact]
        public void SetAccessibilityTypeAsEdit_ShouldSetAccessibilityTypeToEdit()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);
            var member = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");

            // Добавляем участника к лечению
            treatment.AddToTreatmentMembers(member);

            // Act
            var result = treatment.SetAccessibilityTypeAsEdit(member.Id);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var updatedMember = treatment.TreatmentMembers.SingleOrDefault(m => m.Member.Id == member.Id);
            updatedMember.Should().NotBeNull();
            updatedMember.AccessibilityType.Value.Should().Be(AccessibilityType.Edit.Value);
        }  
        
        
        [Fact]
        public void SetAccessibilityTypeAsEdit_ShouldSetAccessibilityTypeToReadOnly()
        {
            // Arrange
            var treatment = Treatment.CreateNew(_creator, _patient, _titel);
            var member = Member.Create(new MemberId(Guid.NewGuid()), "testEmail@gmail.com");

            // Добавляем участника к лечению
            treatment.AddToTreatmentMembers(member);

            // Act
            var result = treatment.SetAccessibilityTypeAsReadOnly(member.Id);

            // Assert
            result.IsSuccess.Should().BeTrue();
            var updatedMember = treatment.TreatmentMembers.SingleOrDefault(m => m.Member.Id == member.Id);
            updatedMember.Should().NotBeNull();
            updatedMember.AccessibilityType.Value.Should().Be(AccessibilityType.ReadOnly.Value);
        }

        //[Fact]
        //public void AddPreview_ShouldSetTreatmentPreviewSuccessfully()
        //{
        //    // Arrange
        //    var treatment = Treatment.Create(_creator, _patient, _titel);
        //    var fileId = TreatmentFile.CreateBaseOnTreatmentStage(Guid.NewGuid());

        //    // Act
        //    treatment.AddPreview(fileId);

        //    // Assert
        //    treatment.TreatmentPreview.Should().Be(fileId);
        //}
    }
}
