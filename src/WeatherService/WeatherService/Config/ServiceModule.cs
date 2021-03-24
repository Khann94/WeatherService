#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WeatherService.Common.Mvc.Utils;
using WeatherService.Database.Repository;
using WeatherService.Database.Repository.Interface;

#endregion

namespace WeatherService.Api.Config
{
    public static class ServiceModule
    {
        public static IServiceCollection RegisterModulesServices(this IServiceCollection services)
        {
            // Lazy service provider
            services.AddTransient(typeof(Lazy<>), typeof(LazyServiceProvider<>));

            // Services
            services.Scan(scan => scan
                .FromExecutingAssembly()
                .FromApplicationDependencies(a => a.FullName.Contains("WeatherService.Services"))
                .AddClasses(true)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation =>
                        implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime());

            services.AddTransient<IWeatherRepository, WeatherRepository>();

            return services;
        }
    }
}
