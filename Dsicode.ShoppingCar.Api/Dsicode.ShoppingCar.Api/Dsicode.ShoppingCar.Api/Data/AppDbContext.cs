using Dsicode.ShoppingCart.Api.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // Añadir

namespace Dsicode.ShoppingCart.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones específicas para MySQL
            modelBuilder.Entity<CartHeader>(entity =>
            {
                entity.Property(e => e.CartHeaderId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.CartHeaderId);
            });

            modelBuilder.Entity<CartDetails>(entity =>
            {
                entity.Property(e => e.CartDetailsId).ValueGeneratedOnAdd();
                entity.HasKey(e => e.CartDetailsId);

                entity.HasOne(d => d.CartHeader)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartHeaderId)
                    .OnDelete(DeleteBehavior.Cascade); // Importante para MySQL
            });
        }
    }
}