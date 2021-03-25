#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Database.Entity;

#endregion

namespace WeatherService.Database.Repository.Interface
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCitiesWithWeathers();

        Task<City> GetByExternalIdOrNull(Guid externalId);

        Task Update(List<City> cities);

        Task Update(City city);
    }
}
