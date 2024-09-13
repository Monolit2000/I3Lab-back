using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.BuildingBlocks.Infrastructure
{
    public static class ServiceFactory
    {
        private static IServiceProvider _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }


        public static T GetScopedService<T>()
        {
            var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<T>();
            return service;
        }
    }
}
