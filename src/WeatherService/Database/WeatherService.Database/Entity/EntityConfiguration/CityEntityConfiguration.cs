#region Usings

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace WeatherService.Database.Entity.EntityConfiguration
{
    public class CityEntityConfiguration : BaseEntityConfiguration<City>
    {
        #region Configure

        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasMany(x => x.Weathers)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion
    }
}
