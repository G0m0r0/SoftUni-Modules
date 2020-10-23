namespace BattleCards2.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions db)
            : base(db)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCard> UserCards { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BatlleCards2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCard>().HasKey(x => new { x.CardId, x.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
