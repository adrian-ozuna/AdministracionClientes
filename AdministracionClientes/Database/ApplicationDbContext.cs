using AdministracionClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministracionClientes.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Addresses)
            .WithOne(e => e.Client)
            .HasForeignKey(e => e.ClientId);
    }
}