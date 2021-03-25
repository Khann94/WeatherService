#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherService.Common.Consts;
using WeatherService.Database.Context;
using WeatherService.Database.Entity;
using WeatherService.Services.Services.Interfaces;

#endregion

namespace WeatherService.Services.Initializer
{
    public class Initializer
    {
        #region Private field(s)

        private readonly WeatherContext Context;
        private readonly IIntergrationService IntergrationService;

        #endregion

        #region Constructor

        public Initializer(
            WeatherContext context,
            IIntergrationService intergrationService)
        {
            Context = context ?? throw new ArgumentNullException("Missing context for initializer");
            IntergrationService = intergrationService ?? throw new ArgumentNullException("Missing integration service initializer");
        }

        #endregion

        #region Public method(s)

        public async Task InitializeAsync()
        {
            var citiesExist = await Context.Cities.AnyAsync();
            if (!citiesExist)
            {
                var city = new City()
                {
                    ExternalId = SeedExternalIds.WarsawExternalId,
                    Latitude = Coordinate.Warsaw.Latitude,
                    Longitude = Coordinate.Warsaw.Longitude,
                    Name = Names.Warsaw,
                };

                await Context.Cities.AddAsync(city);
                await Context.SaveChangesAsync();
            }

            var cities = await Context.Cities.ToListAsync();

            foreach (var city in cities)
            {
                // TODO Add logic to get data from the integration service
            }

            await Context.SaveChangesAsync();
        }

        #endregion
    }
}
