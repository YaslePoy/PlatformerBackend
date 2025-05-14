using Microsoft.EntityFrameworkCore;

namespace PlatformerBackend.Models
{
    public class PlatformerContext : DbContext
    {
        public static readonly PlatformerContext Instance = new PlatformerContext();
        public PlatformerContext()
        {
        
        }
        public PlatformerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=tcp:95.105.78.72,1433\\SQLEXPRESS;Initial Catalog=platformer;User ID=remote;Password=pass;Trust Server Certificate=True");
            }
        }

        public DbSet<Player> Players { get; set; }
    }
}