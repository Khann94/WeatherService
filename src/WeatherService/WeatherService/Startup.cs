#region Usings

using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;
using WeatherService.Api.Config;
using WeatherService.Common.Mvc.Extensions;
using WeatherService.Database.Context;
using WeatherService.Services.Mapping;

#endregion

namespace WeatherService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterModulesServices();

            // Automapper
            var automapperAssemblies = new List<Assembly>()
            {
                typeof(Startup).Assembly,
                typeof(WeatherSeviceProfile).Assembly,
            };

            services.AddAutoMapper(automapperAssemblies);
            services.AddSwaggerConfiguration();

            services.AddDbContext<WeatherContext>();
            services.AddEntityFrameworkInMemoryDatabase();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.DocExpansion(DocExpansion.None);
                options.SwaggerEndpoint($"v1/swagger.json", $"Weather service API");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
