using Microsoft.EntityFrameworkCore;
using wep_api_CSharp_SuperHero.Controllers.Entities;

namespace wep_api_CSharp_SuperHero.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}
