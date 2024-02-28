using EFCoreExample.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample
{
    /// <summary>
    /// Represents the DbContext for the EF Core Code First approach
    /// </summary>
    public class EFCoreCodeFirstDBContext : DbContext
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        private readonly string _ConnectionString = "Host=ep-jolly-scene-a15563c4.ap-southeast-1.aws.neon.tech;Database=Assignment1;Username=dquy1514;Password=I4U5QbdvWHnL";

        /// <summary>
        /// Gets or sets the DbSet for users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for user details
        /// </summary>
        public DbSet<UserDetails> UserDetails { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for user orders
        /// </summary>
        public DbSet<UserOrder> UserOrders { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for user order products
        /// </summary>
        public DbSet<UserOrderProduct> UserOrderProducts { get; set; }

        /// <summary>
        /// Configures the database connection and options
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql(_ConnectionString);
        }

        /// <summary>
        /// Configures the model relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.Entity<User>()
                .HasOne(u => u.UserDetails)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserDetails>(ud => ud.UserId);

            _ = modelBuilder.Entity<UserOrder>()
                .HasMany(uo => uo.OrderProducts)
                .WithOne(op => op.UserOrder)
                .HasForeignKey(op => op.OrderID);

            _ = modelBuilder.Entity<UserOrderProduct>()
                .HasKey(op => op.UserOrderProductID);
        }
    }
}
