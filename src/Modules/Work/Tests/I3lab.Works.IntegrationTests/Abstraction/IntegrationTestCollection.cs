
namespace I3lab.Works.IntegrationTests.Abstraction
{
    [CollectionDefinition(nameof(IntegrationTestCollection))]
    public class IntegrationTestCollection : ICollectionFixture<IntegrationTestWebAppFactory>;
}
