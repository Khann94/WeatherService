#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace WeatherService.Common.Mvc.Utils
{
    public class LazyServiceProvider<T> : Lazy<T>
        where T : class
    {
        #region Constructor(s)

        public LazyServiceProvider(IServiceProvider provider)
            : base(() => provider.GetRequiredService<T>())
        {
        }

        #endregion
    }
}
