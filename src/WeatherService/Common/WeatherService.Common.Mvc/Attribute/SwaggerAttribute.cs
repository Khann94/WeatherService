#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

#endregion

namespace WeatherService.Common.Mvc.Attribute
{
    public class SwaggerAttribute : SwaggerResponseAttribute
    {
        public SwaggerAttribute(HttpStatusCode statusCode = HttpStatusCode.OK, Type type = null, string description = null)
            : base((int)statusCode, description, type)
        {
        }
    }
}
