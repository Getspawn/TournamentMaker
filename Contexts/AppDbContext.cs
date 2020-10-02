using Microsoft.EntityFrameworkCore;
using TournamentMaker.Entities;

namespace TournamentMaker.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Player { get; set; }
    }
}
