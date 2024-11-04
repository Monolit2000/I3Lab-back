using Bogus;
using I3Lab.Treatments.Infrastructure.Persistence;
using I3Lab.Users.Infrastructure.Persistence;
using MediatR;
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
    }
}
