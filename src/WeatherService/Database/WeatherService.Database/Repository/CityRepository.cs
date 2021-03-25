#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherService.Database.Context;
using WeatherService.Database.Entity;
using WeatherService.Database.Repository.Interface;

#endregion

namespace WeatherService.Database.Repository
{
    public class CityRepository : ICityRepository
    {
        #region Public properties

        public CityRepository(WeatherContext context)
        {
            Context = context;
        }

        #endregion

        #region Private properties

        private WeatherContext Context { get; set; }

        #endregion

        #region Public method(s)

        public async Task<List<City>> GetAllCitiesWithWeathers()
        {
            var cities = await Context
                .Cities
                .Include(x => x.Weathers)
                .ToListAsync();

            return cities;
        }

        public async Task<City> GetByExternalIdOrNull(Guid externalId)
        {
            var city = await Context
                .Cities
                .Include(x => x.Weathers)
                .FirstOrDefaultAsync(x => x.ExternalId == externalId);

            return city;
        }

        public async Task Update(List<City> cities)
        {
            Context.UpdateRange(cities);
            await Context.SaveChangesAsync();
        }

        public async Task Update(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException("Missing city to update");
            }

            Context.UpdateRange(city);
            await Context.SaveChangesAsync();
        }

        #endregion
    }
}
