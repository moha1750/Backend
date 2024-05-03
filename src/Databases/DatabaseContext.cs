using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Databases
{
    public class DatabaseContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderStock> OrderStock { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<Category> Category { get; set; }


        private IConfiguration _config;
        public DatabaseContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseNpgsql(_config["DB"]).UseSnakeCaseNamingConvention();
    }
}
// Host=aws-0-eu-central-1.pooler.supabase.com;Username=postgres.xjkkxefgmmzwkgxpypui;Password=L326tuCH3RwWAUPJ;Database=postgres