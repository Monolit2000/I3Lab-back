using Bogus;
using I3Lab.Treatments.Application.TreatmentInvites.CreateTreatmentInvite;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.TreatmentInvites;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace I3lab.Works.IntegrationTests.Abstraction
{
    public class BaseIntegrationTest : IClassFixture< IntegrationTestWebAppFactory>, IDisposable
    {

        protected readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly TreatmentContext DbContext;
        protected Faker Faker;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            DbContext = _scope.ServiceProvider.GetRequiredService<TreatmentContext>();
            Faker = new Faker();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            DbContext?.Dispose();
        }

        internal async Task<TreatmentStage> CreateTreatmentStageAsync(TreatmentId newTreatmentId = default)
        {
            var creator = await CreateMemberAsync();

            var treatmentId = newTreatmentId ?? await CreateTreatmentAsync(creator);

            var stage = TreatmentStage.CreateBasedOnTreatment(
                creator,
                treatmentId,
                TreatmentStageTitel.Create(Guid.NewGuid().ToString())).Value;

            await DbContext.TreatmentStages.AddAsync(stage);
            await DbContext.SaveChangesAsync();
            return stage;
        }

        internal async Task<TreatmentId> CreateTreatmentAsync(Member newMember = default)
        {
            var member = newMember ?? await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var command = new CreateTreatmentCommand
            {
                CreatorId = member.Id.Value,
                PatientId = patient.Id.Value,
                TreatmentTitel = Guid.NewGuid().ToString()
            };

            var result = await Sender.Send(command);
            return new TreatmentId(result.Value.TreatmentId);
        }


        internal async Task<Treatment> CreateTreatmentDbAsync (Member newMember = default, Member creator = default, Member patient = default)
        {
            var treatment = Treatment.CreateNew(
                creator ?? await CreateMemberAsync(),
                patient ?? await CreateMemberAsync(),
                TreatmentTitel.Create(Faker.Commerce.ProductName()));

            treatment.AddToTreatmentMembers(newMember ?? await CreateMemberAsync());

            await DbContext.Treatments.AddAsync(treatment);
            await DbContext.SaveChangesAsync();

            return treatment;
        }


        internal async Task<Member> CreateMemberAsync()
        {
            var member = Member.Create(new MemberId(Guid.NewGuid()), Faker.Internet.Email());
            await DbContext.Members.AddAsync(member);
            await DbContext.SaveChangesAsync();
            return member;
        }

        internal async Task<TreatmentInvite> CreateTreatmentInviteAsync(MemberId creator, MemberId invitee)
        {
            var treatment = await CreateTreatmentDbAsync();

            var treatmentId = treatment.Id; 

            var command = new CreateTreatmentInviteCommand
            {
                TreatmentId = treatmentId.Value,
                MemberToInviteId = invitee.Value,
                InviterId = creator.Value
            };
            var inviteResult = await Sender.Send(command);

            return await DbContext.TreatmentInvites
                .Where(ti => ti.Treatment.Id == treatmentId)
                .FirstOrDefaultAsync();
        }

    }
}


//var createTreatmentcommand = new CreateTreatmentCommand
//{
//    CreatorId = creator.Value,
//    PatientId = invitee.Value,
//    TreatmentTitel = Faker.Name.JobTitle()
//};

//var result = await Sender.Send(createTreatmentcommand);


//new TreatmentId(result.Value.TreatmentId);