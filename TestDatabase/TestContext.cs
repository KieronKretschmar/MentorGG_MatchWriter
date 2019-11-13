using System;
using TestEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDatabase
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BombDefused> BombDefused { get; set; }
        public virtual DbSet<MatchStats> MatchStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;userid=matchdbuser;password=passwort;database=matchdb;persistsecurityinfo=True");

                // We could use an InMemoryDB  
                //optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BombDefused>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_BombDefused_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_BombDefused_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_BombDefused_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_BombDefused_PlayerRoundStats");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.BombDefused);
                    //.HasForeignKey(d => d.MatchId)
                    //.HasConstraintName("FK_BombExplosion_MatchStats");
            });

            modelBuilder.Entity<MatchStats>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.HasIndex(e => e.DemoId)
                    .HasName("IX_FK_MatchStats_DemoStats");

                entity.Property(e => e.Avgrank).HasColumnName("AVGRank");

                entity.Property(e => e.AvgroundTime).HasColumnName("AVGRoundTime");

                entity.Property(e => e.Event)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Map)
                    .IsRequired()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MatchDate).HasColumnType("datetime");

                entity.Property(e => e.NumRoundsCt1).HasColumnName("NumRoundsCT1");

                entity.Property(e => e.NumRoundsCt2).HasColumnName("NumRoundsCT2");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasDefaultValueSql("('')");
            });

        }
    }
}
