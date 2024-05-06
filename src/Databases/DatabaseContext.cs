using BackendTeamwork.Entities;
using BackendTeamwork.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(_config["DB"]);
            dataSourceBuilder.MapEnum<Role>();
            var dataSource = dataSourceBuilder.Build();
            optionsBuilder.UseNpgsql(dataSource).UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Role>();

            modelBuilder.HasPostgresExtension("pgcrypto");

            modelBuilder.Entity<OrderStock>()
                        .Property(orderStock => orderStock.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<User>()
                        .Property(user => user.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Address>()
                        .Property(address => address.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Category>()
                        .Property(category => category.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Order>()
                        .Property(order => order.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Order>()
                        .Property(order => order.Date)
                        .HasDefaultValueSql("CURRENT_DATE");

            // modelBuilder.Entity<Order>()
            //             .Property(order => order.Status)
            //             .HasDefaultValueSql("Pending");

            modelBuilder.Entity<Payment>()
                        .Property(payment => payment.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Payment>()
                        .Property(payment => payment.Date)
                        .HasDefaultValueSql("CURRENT_DATE");

            modelBuilder.Entity<Product>()
                        .Property(product => product.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Product>()
                        .HasIndex(product => product.Name)
                        .IsUnique();

            modelBuilder.Entity<Review>()
                        .Property(review => review.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<Stock>()
                        .Property(stock => stock.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<User>()
                        .Property(user => user.Id)
                        .HasDefaultValueSql("gen_random_uuid()");

            modelBuilder.Entity<User>()
                        .HasIndex(user => user.Email)
                        .IsUnique();

            modelBuilder.Entity<Wishlist>()
                        .Property(wishlist => wishlist.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
