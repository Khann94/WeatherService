#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IIntegrationService IntergrationService;
        private readonly IMapper Mapper;

        #endregion

        #region Constructor

        public Initializer(
            WeatherContext context,
            IIntegrationService intergrationService,
            IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException("Missing context for in initializer");
            IntergrationService = intergrationService ?? throw new ArgumentNullException("Missing integration service initializer");
            Mapper = mapper ?? throw new ArgumentNullException("Missing mapper in initializer");
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
                var weatherFromApi = await IntergrationService.GetWeatherForCoordinates(city.Latitude, city.Longitude);
                city.Weathers.AddRange(Mapper.Map<List<Weather>>(weatherFromApi));
            }

            await Context.SaveChangesAsync();
        }

        #endregion
    }
}
