using HeladeriaAPI.Models.Envase;
using HeladeriaAPI.Models.Helado;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HeladeriaAPI.Data
{
    public class HeladeriaDbContext : DbContext
    {
        public HeladeriaDbContext(DbContextOptions<HeladeriaDbContext> options) : base(options) { }

        public DbSet<Envase> Envases { get; set; }
        public DbSet<Helado> Helados { get; set; }
    }
}
