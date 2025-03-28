using TestKotas.Model;
using Microsoft.EntityFrameworkCore;

namespace TestKotas.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }

        // Registered DB Model in ApplicationDbContext file
        public DbSet<PokemonCaptured> PokemonCaptured { get; set; }
        public DbSet<PokemonMaster> PokemonMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}