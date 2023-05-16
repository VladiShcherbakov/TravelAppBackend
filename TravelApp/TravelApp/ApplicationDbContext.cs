using Microsoft.EntityFrameworkCore;
using TravelApp.TravelApp.Models;

namespace TravelApp.TravelApp
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TravelPlanModel> TravelPlans { get; set; }
        public DbSet<TravelInfoModel> TravelInfos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TravelPlanModel>().HasMany(x => x.TravelInfos).WithOne(x => x.PlanModel);
        }
    }
}
