namespace BS_Proj
{
    using Microsoft.EntityFrameworkCore;
    public class PlayerDB : DbContext
    {
        public PlayerDB(DbContextOptions<PlayerDB> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Players");
        }
    }
}
