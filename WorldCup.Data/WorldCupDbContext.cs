using System.Data.Entity;
using WorldCup.Data.Model;

namespace WorldCup.Data
{
    public class WorldCupDbContext : DbContext
    {
        public WorldCupDbContext() : base("WC2018DbModels")
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Match> Matches { get; set; }

        //EF Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasRequired<Team>(s => s.TeamA)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired<Team>(s => s.TeamB)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
