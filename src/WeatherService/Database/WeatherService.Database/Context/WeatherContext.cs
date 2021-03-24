#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherService.Database.Entity;

#endregion

namespace WeatherService.Database.Context
{
    public class WeatherContext : DbContext
    {
        #region Constructor(s)

        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        #endregion

        #region DbSets

        public DbSet<City> Cities { get; set; }

        public DbSet<Weather> Weathers { get; set; }

        #endregion

        #region SaveChanges Override

        public override int SaveChanges() => SaveChanges(acceptAllChangesOnSuccess: true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateBaseEntities();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateBaseEntities();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion

        #region Builder

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BaseEntity).Assembly);
        }

        #endregion

        #region Private Methods

        private void UpdateBaseEntities()
        {
            var modifiedEntries = ChangeTracker
                .Entries()
                .Where(entry => entry.State == EntityState.Added
                    || entry.State == EntityState.Modified);
            var utcNow = DateTime.UtcNow;

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is IDatedEntity baseEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            baseEntity.Created = utcNow;
                            baseEntity.Updated = utcNow;
                            break;

                        case EntityState.Modified:
                            baseEntity.Updated = utcNow;
                            break;
                    }
                }
            }
        }

        #endregion
    }
}
