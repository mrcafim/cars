using Cars.Domain.Interfaces.Repositories;
using Cars.Domain.Interfaces.Services;
using Cars.Infra.Data.Repository;
using Cars.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Cars.Infra.IoC
{
    public static class CarDependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Services
            services.AddScoped<ICarService, CarService>();

            // Repositories
            services.AddScoped<ICarRepository, CarRepository>();
        }
    }
}
