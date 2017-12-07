namespace RaceDay.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RaceDayContext : DbContext
    {
        public RaceDayContext()
            : base("name=RaceDayConnection")
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Horse> Horses { get; set; }
        public virtual DbSet<Race> Races { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bets)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horse>()
                .Property(e => e.Odds)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Horse>()
                .HasMany(e => e.Bets)
                .WithRequired(e => e.Horse)
                .HasForeignKey(e => e.HorseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horse>()
                .HasMany(e => e.Races)
                .WithMany(e => e.Horses)
                .Map(m => m.ToTable("RaceHorses").MapLeftKey("HorseID").MapRightKey("RaceId"));

            modelBuilder.Entity<Race>()
                .HasMany(e => e.Bets)
                .WithRequired(e => e.Race)
                .WillCascadeOnDelete(false);
        }
    }
}
