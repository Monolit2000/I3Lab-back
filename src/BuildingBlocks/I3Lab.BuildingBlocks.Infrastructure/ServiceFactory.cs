using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace I3Lab.BuildingBlocks.Infrastructure
{
    public static class ServiceFactory
    {
        //private static WebApplication _app;
        private static IServiceProvider _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public static T GetService<T>()
        {
            var scope = _serviceProvider.CreateScope();
            return _serviceProvider.GetRequiredService<T>();
        }


        public static IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }


        public static T GetScopedService<T>()
        {
            var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<T>();
            return service;
        }

        //public static void Configure(Microsoft.AspNetCore.Builder.WebApplication app)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
