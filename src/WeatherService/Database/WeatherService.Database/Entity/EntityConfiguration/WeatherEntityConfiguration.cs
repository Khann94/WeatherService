#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace WeatherService.Database.Entity.EntityConfiguration
{
    public class WeatherEntityConfiguration : BaseEntityConfiguration<Weather>
    {
        #region Public properties

        public override void Configure(EntityTypeBuilder<Weather> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Weathers)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion
    }
}
