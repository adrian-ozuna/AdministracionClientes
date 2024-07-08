using Microsoft.EntityFrameworkCore;

namespace AdministracionClientes.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}