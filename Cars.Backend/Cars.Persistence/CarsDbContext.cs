using Microsoft.EntityFrameworkCore;
using Cars.Application.Interfaces;
using Cars.Domain;
using Cars.Persistence.EntityTypeConfigurations;

namespace Cars.Persistence
{
    public class CarsDbContext : DbContext, ICarsDbContext
    {
        public DbSet<Car> Car { get; set; }

        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
