using HeladeriaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HeladeriaAPI.Data
{
    public class HeladeriaDbContextFactory : IDesignTimeDbContextFactory<HeladeriaDbContext>
    {
        public HeladeriaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HeladeriaDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-7GAJBF6;Database=HeladeriaDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");

            return new HeladeriaDbContext(optionsBuilder.Options);
        }
    }
}
