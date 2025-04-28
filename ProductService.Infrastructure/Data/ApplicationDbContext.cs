using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

        public DbSet<Product> Products => Set<Product>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Set default schema if you're not using 'public'
            modelBuilder.HasDefaultSchema("ecommerce_product");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(p => p.ProductId);

                entity.Property(p => p.ProductId)
                      .IsRequired();

                entity.Property(p => p.Name)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(p => p.Description)
                      .HasMaxLength(500);

                entity.Property(p => p.Price)
                      .HasColumnType("decimal(10,2)")
                      .IsRequired();

                entity.Property(p => p.Category)
                      .HasMaxLength(50);

                entity.Property(p => p.Stock)
                      .IsRequired();

                entity.Property(p => p.CreatedTime)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(p => p.UpdatedTime)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            base.OnModelCreating(modelBuilder);
        }




    }




}
