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
        public virtual DbSet<Kills> Kills { get; set; }
        public virtual DbSet<MatchStats> MatchStats { get; set; }
        public virtual DbSet<PlayerMatchStats> PlayerMatchStats { get; set; }

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

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.BombDefused)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BombDefused_PlayerMatchStats");
            });

            modelBuilder.Entity<Kills>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kills>>)(entity =>
            {
                entity.HasKey(e => (new { e.MatchId, e.KillId }));

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_Kills_MatchStats"); // Remove these lines as we don't care about customizing the Indexes names

                entity.HasIndex(e => (new { e.MatchId, e.DamageId }))
                    .HasName("IX_FK_Kills_Damage");

                entity.HasIndex(e => (new { e.MatchId, e.PlayerId }))
                    .HasName("IX_FK_Kills_PlayerMatchStats");

                entity.HasIndex(e => (new { e.MatchId, e.Round }))
                    .HasName("IX_FK_Kills_RoundStats");

                entity.HasIndex(e => (new { e.MatchId, e.Round, e.PlayerId }))
                    .HasName("IX_FK_Kills_PlayerRoundStats");

                // We want to have an Index for each ForeignKey. We are missing those Indexes referencing VictimId


                // We don't need to specify different names in DB vs Model, so remove these lines
                entity.Property(e => e.IsCt).HasColumnName("IsCT"); 

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => d.MatchId);


                entity.HasOne(d => d.PlayerMatchStats) // This was originally KillsPlayerMatchStats, but I already renamed it to PlayerMatchStats
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => (new { d.MatchId, d.PlayerId }))
                    .OnDelete(DeleteBehavior.ClientSetNull); // Not sure what exactly this does. Cascading could be better => Research

                entity.HasOne(d => d.VictimMatchStats) // Same rename as above, but with Victim
                    .WithMany(p => p.Deaths)
                    .HasForeignKey(d => (new { d.MatchId, d.VictimId }))
                    .OnDelete(DeleteBehavior.ClientSetNull);

                // FYI: This is how the above lines looked right after scaffold. 
                //entity.HasOne(d => d.PlayerMatchStats)
                //    .WithMany(p => p.KillsPlayerMatchStats)
                //    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Kills_PlayerMatchStats");


                //entity.HasOne(d => d.PlayerMatchStatsNavigation)
                //    .WithMany(p => p.KillsPlayerMatchStatsNavigation)
                //    .HasForeignKey(d => new { d.MatchId, d.VictimId })
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Kills_PlayerMatchStats_Victim");
            }));

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
