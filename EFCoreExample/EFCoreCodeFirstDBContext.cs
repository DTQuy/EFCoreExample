using EFCoreExample.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample
{
    public class EFCoreCodeFirstDBContext : DbContext
    {
        private readonly string _ConnectionString = "Host=ep-jolly-scene-a15563c4.ap-southeast-1.aws.neon.tech;Database=Assignment1;Username=dquy1514;Password=I4U5QbdvWHnL";
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<UserOrderProduct> UserOrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql(_ConnectionString);
        }

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
