using Microsoft.EntityFrameworkCore;
using Sefaz.Infraestrutura.DAL.EF.Models;

namespace Sefaz.Infraestrutura.DAL.EF
{
    public class SefazContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sefazDatabase.db");
        }

        public DbSet<Produto> Produto { get; set; }
    }
}