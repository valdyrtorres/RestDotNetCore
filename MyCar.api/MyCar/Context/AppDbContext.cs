using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCar.Models;
using System.IO;

namespace MyCar.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Tirando do hard code
            //optionsBuilder.UseSqlServer(
            //    @"Server=PREDATORVALDIR\\SQLEXPRESS;Database=MyCar;Trusted_Connection=True;MultipleActiveResultSets=true");

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
