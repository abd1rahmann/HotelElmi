using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AbdiHotelConsole.Data
{
    public class Application
    {
        public void Run()
        {
            // 4: Create json builder (boiler plate code)
            // Makes it possible to connect to appsettings.json
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            // 6: Create DBContext(boiler plate code).
            // Create options & connectionstring variables(boiler plate code).
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            //var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer("Server=localhost;Database=AbdiHotel;Trusted_Connection=True;TrustServerCertificate=true;");

            // 7a: Kör i console add-migration "Initial migration"
            // 7b: Migrate DbSets to SQL tabeller
            // Om inte databasen redan finns... så skapas den nu.
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitiaizer = new DataInitializer();
                dataInitiaizer.MigrateAndSeed(dbContext);
            }
        }
    }
}
