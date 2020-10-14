using Microsoft.EntityFrameworkCore;
using Sefaz.Infraestrutura.DAL.EF.Models;

namespace Sefaz.Infraestrutura.DAL.EF
{
    public class SefazContext
    {
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Sefaz.db");
        }

        public DbSet<Produto> Produto { get; set; }
    }
}