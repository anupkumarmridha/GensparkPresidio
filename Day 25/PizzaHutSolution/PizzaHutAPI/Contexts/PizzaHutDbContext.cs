using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Contexts
{
    public class PizzaHutDbContext : DbContext
    {
        public PizzaHutDbContext(DbContextOptions<PizzaHutDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne()
                .HasForeignKey<User>(u => u.CustomerId) // Foreign key is CustomerId
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Pizza)
                .WithOne()
                .HasForeignKey<Stock>(s => s.PizzaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Pizza)
                .WithMany()
                .HasForeignKey(od => od.PizzaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Pizza)
                .WithMany()
                .HasForeignKey(ci => ci.PizzaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
