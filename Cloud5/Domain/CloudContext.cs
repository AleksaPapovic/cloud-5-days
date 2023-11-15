using Cloud5.Domain.Player;
using Microsoft.EntityFrameworkCore;

namespace Cloud5.Domain
{

    public class CloudDbContext : DbContext
    {
        public CloudDbContext(DbContextOptions<CloudDbContext> options) : base(options) { }

        public DbSet<PlayerStats> PlayerStats { get; set; }

    }

}
