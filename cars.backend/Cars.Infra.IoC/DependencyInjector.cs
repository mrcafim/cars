using Microsoft.Extensions.DependencyInjection;

namespace Cars.Infra.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Modules
            RegisterModules(services);
        }

        private static void RegisterModules(IServiceCollection services)
        {
            CarDependencyInjector.Register(services);
        }
    }
}
