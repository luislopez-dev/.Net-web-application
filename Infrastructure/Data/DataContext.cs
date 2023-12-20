using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceProduct> InvoiceProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InvoiceProduct>()
            .HasOne(o => o.Invoice)
            .WithMany(i => i.InvoiceProducts)
            .HasForeignKey(o => o.InvoiceId);

        modelBuilder.Entity<InvoiceProduct>()
            .HasOne(o => o.Product)
            .WithMany(p => p.InvoiceProducts)
            .HasForeignKey(o => o.ProductId);
    }
}