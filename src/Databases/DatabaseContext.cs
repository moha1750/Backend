using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Databases
{
    public class DatabaseContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStock> OrderStock { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Category> Categories { get; set; }


        private IConfiguration _config;
        public DatabaseContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseNpgsql(_config["DB"]);
    }
}
// Host=aws-0-eu-central-1.pooler.supabase.com;Username=postgres.xjkkxefgmmzwkgxpypui;Password=L326tuCH3RwWAUPJ;Database=postgres