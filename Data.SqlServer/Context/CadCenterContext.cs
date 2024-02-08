using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.Context
{
    public class CadCenterContext : DbContext
    {
        public CadCenterContext(DbContextOptions<CadCenterContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
