using Bogus;
using I3Lab.Treatments.Application.Treatments.CreateTreatment;
using I3Lab.Treatments.Application.TreatmentStages.CloseTreatmentStage;
using I3Lab.Treatments.Domain.Members;
using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Infrastructure.Persistence;
using I3Lab.Users.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3lab.Works.IntegrationTests.Abstraction
{
    public class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
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

        internal async Task<TreatmentStage> CreateTreatmentStageAsync()
        {
            var creator = await CreateMemberAsync();

            var treatmentId = await CreateTreatmentAsync(creator);

            var stage = TreatmentStage.CreateBasedOnTreatment(
                creator,
                treatmentId,
                TreatmentStageTitel.Create(Guid.NewGuid().ToString())).Value;

            await DbContext.TreatmentStages.AddAsync(stage);
            await DbContext.SaveChangesAsync();
            return stage;
        }

        internal async Task<TreatmentId> CreateTreatmentAsync(Member creator = default)
        {
            var creatord = creator ?? await CreateMemberAsync();
            var patient = await CreateMemberAsync();
            var command = new CreateTreatmentCommand
            {
                CreatorId = creatord.Id.Value,
                PatientId = patient.Id.Value,
                TreatmentTitel = Faker.Commerce.ProductName()
            };

            var result = await Sender.Send(command);
            return new TreatmentId(result.Value.TreatmentId);
        }

        internal async Task<Member> CreateMemberAsync()
        {
            var member = Member.Create(new MemberId(Guid.NewGuid()), Faker.Internet.Email());
            await DbContext.Members.AddAsync(member);
            await DbContext.SaveChangesAsync();
            return member;
        }

    }
}
