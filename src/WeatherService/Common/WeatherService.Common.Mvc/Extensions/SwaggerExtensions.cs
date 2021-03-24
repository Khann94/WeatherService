#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#endregion

namespace WeatherService.Common.Mvc.Extensions
{
    public static class SwaggerExtensions
    {
        #region Public Methods

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = $"Weather Service", Version = "v1" });
                options.DescribeAllParametersInCamelCase();
                options.EnableAnnotations();
            });

            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        #endregion
    }
}
