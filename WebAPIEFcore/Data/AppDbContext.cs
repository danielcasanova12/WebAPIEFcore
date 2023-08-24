using Microsoft.EntityFrameworkCore;
using WebAPIEFcore.Models;

namespace WebAPIEFcore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Banco.db");
        }
    }
}

