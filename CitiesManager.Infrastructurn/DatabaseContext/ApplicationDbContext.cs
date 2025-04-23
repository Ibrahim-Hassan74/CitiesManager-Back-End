using CitiesManager.Core.Identity;
using CitiesManager.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(
                new City { CityID = Guid.Parse("49815A7D-83CA-4BAA-83D3-464607D513B6"), CityName = "New York" },
                new City { CityID = Guid.Parse("3CFC9DF2-64E2-4C15-9580-E8F71906533E"), CityName = "Antwerp"},
                new City { CityID = Guid.Parse("DA9E0BF9-C403-4109-8044-478F7C8A9766"), CityName = "Paris" }
            );
        }

    }
}
