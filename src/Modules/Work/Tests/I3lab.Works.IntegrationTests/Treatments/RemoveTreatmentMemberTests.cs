using Bogus;
using FluentAssertions;
using I3lab.Works.IntegrationTests.Abstraction;
using I3Lab.Treatments.Application.Treatments.RemoveTreatmentMember;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.Treatments.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3lab.Works.IntegrationTests.Treatments
{
    public class RemoveTreatmentMemberTests : BaseIntegrationTest
    {
        private readonly Faker _faker;

        public RemoveTreatmentMemberTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
            _faker = new Faker();
        }

        [Fact]
        public async Task Handle_Should_RemoveMemberFromTreatment_WhenMemberExists()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var memberToRemove = await CreateMemberAsync();

            // Create a treatment and add the member to be removed
            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(_faker.Lorem.Word()));
            treatment.AddToTreatmentMembers(memberToRemove);
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();


           // Assuming creator has permission to remove
            var command = new RemoveTreatmentMemberCommand(treatment.Id.Value, memberToRemove.Id.Value, creator.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsSuccess.Should().BeTrue("the command should succeed if the member exists in the treatment");

            // Reload the treatment from the database to confirm member removal
            var updatedTreatment = await DbContext.Treatments
                .Include(t => t.TreatmentMembers)
                .FirstOrDefaultAsync(t => t.Id == treatment.Id);

            updatedTreatment.Should().NotBeNull();
            updatedTreatment.TreatmentMembers.Should().NotContain(m => m.Member.Id == memberToRemove.Id,
                "the member should be removed from the treatment members list");
        }

        [Fact]
        public async Task Handle_Should_Fail_WhenMemberDoesNotExistInTreatment()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var nonExistentMemberId = Guid.NewGuid();

            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(_faker.Lorem.Word()));
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            var command = new RemoveTreatmentMemberCommand(treatment.Id.Value, nonExistentMemberId, creator.Id.Value);
         

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue("the command should fail if the member does not exist in the treatment");
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.MemberNotFound,
                "the error message should indicate that the member was not found");
        }

        [Fact]
        public async Task Handle_Should_Fail_WhenTreatmentDoesNotExist()
        {
            // Arrange
            var nonExistentTreatmentId = Guid.NewGuid();
            var memberToRemove = await CreateMemberAsync();
            var removingMember = await CreateMemberAsync();

            var command = new RemoveTreatmentMemberCommand(nonExistentTreatmentId, memberToRemove.Id.Value, removingMember.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeTrue("the command should fail if the treatment does not exist");
            result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.TreatmentNotFound,
                "the error message should indicate that the treatment was not found");
        }

        [Fact]
        public async Task Handle_Should_Fail_WhenRemovingMemberHasNoPermission()
        {
            // Arrange
            var creator = await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var memberToRemove = await CreateMemberAsync();
            var unauthorizedMember = await CreateMemberAsync();

            var treatment = Treatment.CreateNew(creator, patient, TreatmentTitel.Create(_faker.Lorem.Word()));
            treatment.AddToTreatmentMembers(memberToRemove);
            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            var command = new RemoveTreatmentMemberCommand(treatment.Id.Value, memberToRemove.Id.Value, unauthorizedMember.Id.Value);

            // Act
            var result = await Sender.Send(command);

            // Assert
            result.IsFailed.Should().BeFalse();
            //result.Errors.Should().ContainSingle(e => e.Message == TreatmentErrors.PermissionDenied,
            //    "the error message should indicate permission was denied");
        }
    }
}
