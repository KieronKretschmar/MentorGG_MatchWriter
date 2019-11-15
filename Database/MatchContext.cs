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
        public virtual DbSet<Kill> Kills { get; set; }
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
                    .IsRequired(); // Makes sure each BombDefused has a MatchStats

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.BombDefused)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                // One to zero/one relation
                // Every BombDefused has a RoundStats, but not every RoundStats has a BombDefused
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

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.BombExplosion)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithOne(p => p.BombExplosion)
                    .HasForeignKey<BombExplosion>(d => new { d.MatchId, d.Round })
                    .IsRequired();
            });

            modelBuilder.Entity<BombPlant>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.BombPlant)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.BombPlant)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithOne(p => p.BombPlant)
                    .HasForeignKey<BombPlant>(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.BombPlant)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });


            modelBuilder.Entity<BotTakeOver>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.BotTakeOverId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.BotTakeOver)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<ConnectDisconnect>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ConnectDisconnectId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.ConnectDisconnect)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ConnectDisconnect)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ConnectDisconnect)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();
            });

            modelBuilder.Entity<Damage>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.DamageId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.DecoyId });

                entity.HasIndex(e => new { e.MatchId, e.FireNadeId });

                entity.HasIndex(e => new { e.MatchId, e.HeGrenadeId });

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.VictimId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.WeaponFiredId });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.VictimId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.Decoy)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.DecoyId });

                entity.HasOne(d => d.FireNade)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.FireNadeId });

                entity.HasOne(d => d.He)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.HeGrenadeId });

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Damages)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();                

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.VictimMatchStats)
                    .WithMany(p => p.DamagesReceived)
                    .HasForeignKey(d => new { d.MatchId, d.VictimId })
                    .IsRequired();

                entity.HasOne(d => d.WeaponFired)
                    .WithMany(p => p.Damage)
                    .HasForeignKey(d => new { d.MatchId, d.WeaponFiredId });

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Damages)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.VictimRoundStats)
                    .WithMany(p => p.DamagesReceived)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.VictimId })
                    .IsRequired();
            });

            modelBuilder.Entity<Decoy>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Decoy)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<FireNade>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.FireNade)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<Flash>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                // TODO: What happens when I remove this?
                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => d.MatchId);

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Flash)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<Flashed>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId, e.VictimId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.AssistedKillId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.VictimId });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.VictimId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();
                
                // optional relationship (zero/one to zero/one)
                // a Kill may/may not have an AssistingFlash assist, and a Flashed may/may not have an AssistedKill
                // optionality comes from AssistedKillId being nullable
                entity.HasOne(d => d.AssistedKill)
                    .WithOne(p => p.AssistingFlash)
                    .HasForeignKey<Flashed>(d => new { d.MatchId, d.AssistedKillId });

                entity.HasOne(d => d.Flash)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.GrenadeId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.VictimId })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Flashed)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.VictimId })
                    .IsRequired();
            });

            modelBuilder.Entity<He>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.He)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<HostageDrop>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.HostageDrop)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<HostagePickUp>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostagePickUp_RoundStats");

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.HostagePickUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<HostageRescue>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.HostageRescue)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<ItemDropped>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ItemDroppedId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.ItemDropped)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<ItemPickedUp>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ItemPickedUpId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.ItemDroppedId });

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.ItemDropped)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.ItemDroppedId });

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.ItemPickedUp)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<ItemSaved>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.ItemSavedId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.ItemSaved)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<Kill>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.KillId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.DamageId });

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.Damage)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => new { d.MatchId, d.DamageId })
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.VictimMatchStats)
                    .WithMany(p => p.Deaths)
                    .HasForeignKey(d => new { d.MatchId, d.VictimId })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Kills)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.VictimRoundStats)
                    .WithMany(p => p.Deaths)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.VictimId })
                    .IsRequired();
            });

            modelBuilder.Entity<MatchStats>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.HasIndex(e => e.DemoId);

                entity.Property(e => e.Map)
                    .IsRequired();
            });

            modelBuilder.Entity<OverTimeStats>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.HasIndex(e => e.MatchId);

                // 1 to 0/1 relationship
                // Every OverTimeStats has a MatchStats, but not every MatchStats has a OverTimeStats
                entity.HasOne(d => d.MatchStats)
                    .WithOne(p => p.OverTimeStats)
                    .HasForeignKey<OverTimeStats>(d => d.MatchId)
                    .IsRequired();
            });

            modelBuilder.Entity<PlayerMatchStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.SteamId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => e.SteamId);

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.PlayerMatchStats)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();
            });

            modelBuilder.Entity<PlayerPosition>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId, e.Time });

                entity.HasIndex(e => e.MatchId);

                // As we PlayerPosition is rarely queried, but contains many rows to update/delete,
                // one index on MatchId might be enough

                //entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                //entity.HasIndex(e => new { e.MatchId, e.Round });

                //entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => d.MatchId);

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.PlayerPosition)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<PlayerRoundStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => e.PlayerId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.PlayerRoundStats)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.PlayerRoundStats)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.PlayerRoundStats)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();
            });

            modelBuilder.Entity<Refrag>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.KillId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.KillId });

                entity.HasIndex(e => new { e.MatchId, e.RefraggedKillId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Refrag)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.Kill)
                    .WithOne(p => p.Refrag)
                    .HasForeignKey<Refrag>(d => new { d.MatchId, d.KillId })
                    .IsRequired();

                entity.HasOne(d => d.RefraggedKill)
                    .WithMany(p => p.RefraggedBy)
                    .HasForeignKey(d => new { d.MatchId, d.RefraggedKillId })
                    .IsRequired();
            });

            modelBuilder.Entity<RoundItem>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.RoundItemId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.RoundItem)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.RoundItem)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.RoundItem)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.RoundItem)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<RoundStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => e.MatchId);

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.RoundStats)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();
            });

            modelBuilder.Entity<Smoke>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GrenadeId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.Property(e => e.Trajectory).IsRequired();

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.Smoke)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<WeaponFired>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.WeaponFiredId });

                entity.HasIndex(e => e.MatchId);

                // As we WeaponFired is rarely queried, but contains many rows to update/delete,
                // one index on MatchId might be enough

                //entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                //entity.HasIndex(e => new { e.MatchId, e.Round });

                //entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.WeaponFired)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });

            modelBuilder.Entity<WeaponReload>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.WeaponReloadId });

                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => new { e.MatchId, e.PlayerId });

                entity.HasIndex(e => new { e.MatchId, e.Round });

                entity.HasIndex(e => new { e.MatchId, e.Round, e.PlayerId });

                entity.HasOne(d => d.MatchStats)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => d.MatchId)
                    .IsRequired();

                entity.HasOne(d => d.PlayerMatchStats)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => new { d.MatchId, d.PlayerId })
                    .IsRequired();

                entity.HasOne(d => d.RoundStats)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => new { d.MatchId, d.Round })
                    .IsRequired();

                entity.HasOne(d => d.PlayerRoundStats)
                    .WithMany(p => p.WeaponReload)
                    .HasForeignKey(d => new { d.MatchId, d.Round, d.PlayerId })
                    .IsRequired();
            });
        }
    }
}
