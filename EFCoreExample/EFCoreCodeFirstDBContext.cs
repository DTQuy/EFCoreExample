using EFCoreExample.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample
{
    public class EFCoreCodeFirstDBContext : DbContext
    {
        private readonly string _ConnectionString = "Host=ep-jolly-scene-a15563c4.ap-southeast-1.aws.neon.tech;Database=Assignment1;Username=dquy1514;Password=I4U5QbdvWHnL";
        public DbSet<User>? Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql(_ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = modelBuilder.Entity<User>()
                .HasOne(a => a.UserDetails)
                .WithOne(a => a.User)
                .HasForeignKey<UserDetails>(a => a.UserId);

            _ = modelBuilder.Entity<User>()
                .HasMany(u => u.UserOrders)
                .WithOne(uo => uo.User)
                .HasForeignKey(uo => uo.UserId);

            _ = modelBuilder.Entity<UserOrderProduct>()
                .HasKey(uop => new { uop.UserOrderId, uop.ProductId });

            _ = modelBuilder.Entity<UserOrderProduct>()
                .HasOne(uop => uop.UserOrder)
                .WithMany(uo => uo.UserOrderProducts)
                .HasForeignKey(uop => uop.UserOrderId);

            _ = modelBuilder.Entity<UserOrderProduct>()
                .HasOne(uop => uop.Product)
                .WithMany(p => p.UserOrderProducts)
                .HasForeignKey(uop => uop.ProductId);
        }
    }
}
