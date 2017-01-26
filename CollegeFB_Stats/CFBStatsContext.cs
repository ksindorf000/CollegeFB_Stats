using System.Data.Entity;
using CollegeFB_Stats.Models;

namespace CollegeFB_Stats
{
    class CFBStatsContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Stats> Stats { get; set; }
    }
}
