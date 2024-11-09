using Bogus;
using I3Lab.Users.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I3Lab.Users.Application.Contract;
using I3Lab.Treatments.Infrastructure.Persistence;

namespace I3lab.Users.IntegrationTests.Abstraction
{
    public class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
    {

        protected readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly UserContext DbContext;
        protected readonly TreatmentContext TreatmentDbContext;

        protected Faker Faker;
        protected readonly IPasswordHasher _passwordHasher;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            DbContext = _scope.ServiceProvider.GetRequiredService<UserContext>();
            TreatmentDbContext = _scope.ServiceProvider.GetRequiredService<TreatmentContext>();
            Faker = new Faker();

            _passwordHasher = _scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            DbContext?.Dispose();
        }
    }
}
