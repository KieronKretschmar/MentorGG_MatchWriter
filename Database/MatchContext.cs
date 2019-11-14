using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database
{
    public partial class MatchContext : DbContext
    {
        public MatchContext()
        {
        }

        public MatchContext(DbContextOptions<MatchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BombDefused> BombDefused { get; set; }
        public virtual DbSet<BombExplosion> BombExplosion { get; set; }
        public virtual DbSet<BombPlant> BombPlant { get; set; }
        public virtual DbSet<BotTakeOver> BotTakeOver { get; set; }
        public virtual DbSet<ConnectDisconnect> ConnectDisconnect { get; set; }
        public virtual DbSet<Damage> Damage { get; set; }
        public virtual DbSet<Decoy> Decoy { get; set; }
        public virtual DbSet<FireNade> FireNade { get; set; }
        public virtual DbSet<Flash> Flash { get; set; }
        public virtual DbSet<Flashed> Flashed { get; set; }
        public virtual DbSet<He> He { get; set; }
        public virtual DbSet<HostageDrop> HostageDrop { get; set; }
        public virtual DbSet<HostagePickUp> HostagePickUp { get; set; }
        public virtual DbSet<HostageRescue> HostageRescue { get; set; }
        public virtual DbSet<ItemDropped> ItemDropped { get; set; }
        public virtual DbSet<ItemPickedUp> ItemPickedUp { get; set; }
        public virtual DbSet<ItemSaved> ItemSaved { get; set; }
        public virtual DbSet<Kills> Kills { get; set; }
        public virtual DbSet<MatchStats> MatchStats { get; set; }
        public virtual DbSet<OverTimeStats> OverTimeStats { get; set; }
        public virtual DbSet<PlayerMatchStats> PlayerMatchStats { get; set; }
        public virtual DbSet<PlayerPosition> PlayerPosition { get; set; }
        public virtual DbSet<PlayerRoundStats> PlayerRoundStats { get; set; }
        public virtual DbSet<Refrag> Refrag { get; set; }
        public virtual DbSet<RoundItem> RoundItem { get; set; }
        public virtual DbSet<RoundStats> RoundStats { get; set; }
        public virtual DbSet<Smoke> Smoke { get; set; }
        public virtual DbSet<WeaponFired> WeaponFired { get; set; }
        public virtual DbSet<WeaponReload> WeaponReload { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;userid=matchdbuser;password=passwort;database=matchdb;persistsecurityinfo=True");

                //We could use an InMemoryDB or other DB providers here
                //optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BombDefused>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.BombDefused)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.BombDefused)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithOne(p => p.BombDefused)
                    .HasForeignKey<BombDefused>(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.BombDefused)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<BombExplosion>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.BombExplosion)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithOne(p => p.BombExplosion)
                    .HasForeignKey<BombExplosion>(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BombExplosion_RoundStats");
            });

            modelBuilder.Entity<BombPlant>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_BombPlant_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_BombPlant_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_BombPlant_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_BombPlant_PlayerRoundStats");

                entity.Property(e => e.PlantZone).HasDefaultValueSql("((-1))");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.BombPlant)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_BombPlant_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.BombPlant)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BombPlant_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithOne(p => p.BombPlant)
                    .HasForeignKey<BombPlant>(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BombPlant_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.BombPlant)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BombPlant_PlayerRoundStats");
            });


            modelBuilder.Entity<BotTakeOver>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.BotTakeOverId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_BotTakeOver_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_BotTakeOver_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_BotTakeOver_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_BotTakeOver_PlayerRoundStats");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_BotTakeOver_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BotTakeOver_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BotTakeOver_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BotTakeOver_PlayerRoundStats");
            });

            modelBuilder.Entity<ConnectDisconnect>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ConnectDisconnectId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_ConnectDisconnect_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_ConnectDisconnect_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_ConnectDisconnect_RoundStats");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.ConnectDisconnect)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_ConnectDisconnect_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ConnectDisconnect)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectDisconnect_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ConnectDisconnect)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectDisconnect_RoundStats");
            });

            modelBuilder.Entity<Damage>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.DamageId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_Damage_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.DecoyId })
                    .HasName("IX_FK_Damage_Decoy");

                entity.HasIndex(e => new { e.MatchId, e.FireNadeId })
                    .HasName("IX_FK_Damage_FireNade");

                entity.HasIndex(e => new { e.MatchId, e.HegrenadeId })
                    .HasName("IX_FK_Damage_HE");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_Damage_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_Damage_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.WeaponFiredId })
                    .HasName("IX_FK_Damage_WeaponFired");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_Damage_PlayerRoundStats");

                entity.Property(e => e.HegrenadeId).HasColumnName("HEGrenadeId");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Damage_MatchStats");

                entity.HasOne(d => d.Decoy)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.DecoyId })
                    .HasConstraintName("FK_Damage_Decoy");

                entity.HasOne(d => d.FireNade)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.FireNadeId })
                    .HasConstraintName("FK_Damage_FireNade");

                entity.HasOne(d => d.He)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.HegrenadeId })
                    .HasConstraintName("FK_Damage_HE");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.DamagePlayerMatchStats)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Damage_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Damage_RoundStats");

                entity.HasOne(d => d.PlayerMatchStatsNavigation)
                    .WithMany(p => p.DamagePlayerMatchStatsNavigation)
                    .HasForeignKey(d => new { d.MatchId, d.VictimId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Damage_PlayerMatchStats_Victim");

                entity.HasOne(d => d.WeaponFired)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.WeaponFiredId })
                    .HasConstraintName("FK_Damage_WeaponFired");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.DamagePlayerRoundStats)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Damage_PlayerRoundStats");

                entity.HasOne(d => d.PlayerRoundStatsNavigation)
                    .WithMany(p => p.DamagePlayerRoundStatsNavigation)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.VictimId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Damage_PlayerRoundStats_Victim");
            });

            modelBuilder.Entity<Decoy>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_Decoy_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_Decoy_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_Decoy_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_Decoy_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Decoy_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Decoy_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Decoy_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Decoy_PlayerRoundStats");
            });

            modelBuilder.Entity<FireNade>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_FireNade_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_FireNade_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_FireNade_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_FireNade_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_FireNade_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FireNade_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FireNade_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FireNade_PlayerRoundStats");
            });

            modelBuilder.Entity<Flash>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_Flash_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_Flash_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_Flash_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_Flash_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Flash_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flash_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flash_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flash_PlayerRoundStats");
            });

            modelBuilder.Entity<Flashed>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId, e.VictimId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_Flashed_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.AssistedKillId })
                    .HasName("IX_FK_Flashed_Kills");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_Flashed_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.VictimId })
                    .HasName("IX_FK_Flashed_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.VictimId })
                    .HasName("IX_FK_Flashed_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Flashed_MatchStats");

                entity.HasOne(d => d.Kills)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.AssistedKillId })
                    .HasConstraintName("FK_Flashed_Kills");

                entity.HasOne(d => d.Flash)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.GrenadeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flashed_Flash");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flashed_RoundStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.VictimId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flashed_PlayerMatchStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.VictimId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flashed_PlayerRoundStats");
            });

            modelBuilder.Entity<He>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.ToTable("HE");

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_HE_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_HE_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_HE_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_HE_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_HE_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HE_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HE_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HE_PlayerRoundStats");
            });

            modelBuilder.Entity<HostageDrop>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_HostageDrop_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_HostageDrop_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_HostageDrop_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_HostageDrop_PlayerRoundStats");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_HostageDrop_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostageDrop_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostageDrop_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostageDrop_PlayerRoundStats");
            });

            modelBuilder.Entity<HostagePickUp>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_HostagePickUp_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_HostagePickUp_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_HostagePickUp_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_HostagePickUp_PlayerRoundStats");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_HostagePickUp_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostagePickUp_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostagePickUp_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostagePickUp_PlayerRoundStats");
            });

            modelBuilder.Entity<HostageRescue>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_HostageRescue_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_HostageRescue_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_HostageRescue_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_HostageRescue_PlayerRoundStats");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_HostageRescue_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostageRescue_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostageRescue_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostageRescue_PlayerRoundStats");
            });

            modelBuilder.Entity<ItemDropped>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ItemDroppedId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_ItemDropped_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_ItemDropped_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_ItemDropped_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_ItemDropped_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_ItemDropped_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemDropped_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemDropped_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemDropped_PlayerRoundStats");
            });

            modelBuilder.Entity<ItemPickedUp>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ItemPickedUpId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_ItemPickedUp_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.ItemDroppedId })
                    .HasName("IX_FK_ItemPickedUp_ItemDropped");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_ItemPickedUp_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_ItemPickedUp_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_ItemPickedUp_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_ItemPickedUp_MatchStats");

                entity.HasOne(d => d.ItemDropped)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.ItemDroppedId })
                    .HasConstraintName("FK_ItemPickedUp_ItemDropped");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPickedUp_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPickedUp_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPickedUp_PlayerRoundStats");
            });

            modelBuilder.Entity<ItemSaved>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ItemSavedId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_ItemSaved_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_ItemSaved_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_ItemSaved_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_ItemSaved_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_ItemSaved_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemSaved_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemSaved_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemSaved_PlayerRoundStats");
            });

            modelBuilder.Entity<Kills>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.KillId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_Kills_MatchStats"); // Remove these lines as we don't care about customizing the Indexes names

                entity.HasIndex(e => new { e.MatchId, e.DamageId })
                    .HasName("IX_FK_Kills_Damage");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_Kills_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_Kills_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_Kills_PlayerRoundStats");

                // We want to have an Index for each ForeignKey. We are missing those Indexes referencing VictimId


                // We don't need to specify different names in DB vs Model, so remove these lines

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Kills_MatchStats");

                entity.HasOne(d => d.Damage)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => new { d.MatchId, d.DamageId })
                    .HasConstraintName("FK_Kills_Damage");

                entity.HasOne(d => d.PlayerMatchStats)// This was originally KillsPlayerMatchStats, but it should be identical to the name of the table it references.
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull) // Not sure what exactly this does. Cascading could be better => Research
                    .HasConstraintName("FK_Kills_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kills_RoundStats");

                entity.HasOne(d => d.VictimMatchStats) // When a victim is involved, change PlayerXXX to VictimXXX. Otherwise same as above
                    .WithMany(p => p.Deaths)
                    .HasForeignKey(d => new { d.MatchId, d.VictimId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kills_PlayerMatchStats_Victim");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.KillsPlayerRoundStats)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kills_PlayerRoundStats");

                entity.HasOne(d => d.PlayerRoundStatsNavigation)
                    .WithMany(p => p.KillsPlayerRoundStatsNavigation)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.VictimId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kills_PlayerRoundStats_Victim");
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

            modelBuilder.Entity<OverTimeStats>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_OverTimeStats_MatchStats");

                entity.Property(e => e.MatchId).ValueGeneratedNever();

                entity.Property(e => e.StartCt).HasColumnName("StartCT");

                entity.HasOne(d => d.Match)
                    .WithOne(p => p.OverTimeStats)
                    .HasForeignKey<OverTimeStats>(d => d.MatchId)
                    .HasConstraintName("FK_OverTimeStats_MatchStats");
            });

            modelBuilder.Entity<PlayerMatchStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.SteamId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_PlayerMatchStats_MatchStats");

                entity.HasIndex(e => e.SteamId)
                    .HasName("IX_FK_PlayerMatchStats_PlayerStats");

                entity.Property(e => e.AvgtimeAlive).HasColumnName("AVGTimeAlive");

                entity.Property(e => e.HesDamage).HasColumnName("HEsDamage");

                entity.Property(e => e.HesDamageVictim).HasColumnName("HEsDamageVictim");

                entity.Property(e => e.HesUsed).HasColumnName("HEsUsed");

                entity.Property(e => e.Hltvrating1).HasColumnName("HLTVRating1");

                entity.Property(e => e.Hltvrating2).HasColumnName("HLTVRating2");

                entity.Property(e => e.Hs).HasColumnName("HS");

                entity.Property(e => e.Hsdeaths).HasColumnName("HSDeaths");

                entity.Property(e => e.Hskills).HasColumnName("HSKills");

                entity.Property(e => e.Hsvictim).HasColumnName("HSVictim");

                entity.Property(e => e.Mvps).HasColumnName("MVPs");

                entity.Property(e => e.RealMvps).HasColumnName("RealMVPs");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerMatchStats)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_PlayerMatchStats_MatchStats");
            });

            modelBuilder.Entity<PlayerPosition>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_PlayerPosition_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_PlayerPosition_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_PlayerPosition_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_PlayerPosition_PlayerRoundStats");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_PlayerPosition_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerPosition_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerPosition_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerPosition_PlayerRoundStats");
            });

            modelBuilder.Entity<PlayerRoundStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_PlayerRoundStats_MatchStats");

                entity.HasIndex(e => e.PlayerId)
                    .HasName("IX_FK_PlayerRoundStats_PlayerStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_PlayerRoundStats_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_PlayerRoundStats_RoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.Property(e => e.RoundStartMvps).HasColumnName("RoundStartMVPs");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerRoundStats)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_PlayerRoundStats_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.PlayerRoundStats)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerRoundStats_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.PlayerRoundStats)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerRoundStats_RoundStats");
            });

            modelBuilder.Entity<Refrag>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.KillId });

                entity.ToTable("_Refrag");

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK__Refrag_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.KillId })
                    .HasName("IX_FK__Refrag_Kill");

                entity.HasIndex(e => new { e.MatchId, e.RefraggedKillId })
                    .HasName("IX_FK__Refrag_Kill_Refragged");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Refrag)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Refrag_MatchStats");

                entity.HasOne(d => d.Kills)
                    .WithOne(p => p.RefragKills)
                    .HasForeignKey<Refrag>(d => new { d.MatchId, d.KillId })
                    .HasConstraintName("FK__Refrag_Kill");

                entity.HasOne(d => d.KillsNavigation)
                    .WithMany(p => p.RefragKillsNavigation)
                    .HasForeignKey(d => new { d.MatchId, d.RefraggedKillId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Refrag_Kill_Refragged");
            });

            modelBuilder.Entity<RoundItem>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.RoundItemId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_RoundItem_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_RoundItem_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_RoundItem_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_RoundItem_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.RoundItem)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_RoundItem_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.RoundItem)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoundItem_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.RoundItem)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoundItem_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.RoundItem)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoundItem_PlayerRoundStats");
            });

            modelBuilder.Entity<RoundStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_RoundStats_MatchStats");

                entity.Property(e => e.CtBuyStrat).HasColumnName("_CtBuyStrat");

                entity.Property(e => e.TbuyStrat).HasColumnName("_TBuyStrat");

                entity.Property(e => e.TplayedValue).HasColumnName("TPlayedValue");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.RoundStats)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_RoundStats_MatchStats");
            });

            modelBuilder.Entity<Smoke>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_Smoke_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_Smoke_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_Smoke_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_Smoke_PlayerRoundStats");

                entity.Property(e => e.Category).HasColumnName("_Category");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.Property(e => e.Result).HasColumnName("_Result");

                entity.Property(e => e.Target).HasColumnName("_Target");

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_Smoke_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Smoke_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Smoke_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Smoke_PlayerRoundStats");
            });

            modelBuilder.Entity<WeaponFired>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.WeaponFiredId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_WeaponFired_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_WeaponFired_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_WeaponFired_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_WeaponFired_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_WeaponFired_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponFired_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponFired_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponFired_PlayerRoundStats");
            });

            modelBuilder.Entity<WeaponReload>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.WeaponReloadId });

                entity.HasIndex(e => e.MatchId)
                    .HasName("IX_FK_WeaponReload_MatchStats");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId })
                    .HasName("IX_FK_WeaponReload_PlayerMatchStats");

                entity.HasIndex(e => new { e.MatchId, e.Round })
                    .HasName("IX_FK_WeaponReload_RoundStats");

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId })
                    .HasName("IX_FK_WeaponReload_PlayerRoundStats");

                entity.Property(e => e.IsCt).HasColumnName("IsCT");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK_WeaponReload_MatchStats");

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponReload_PlayerMatchStats");

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponReload_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponReload_PlayerRoundStats");
            });
        }
    }
}
