using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PlayerRoundStats
    {
        public PlayerRoundStats()
        {
            BombDefused = new HashSet<BombDefused>();
            BombPlant = new HashSet<BombPlant>();
            BotTakeOver = new HashSet<BotTakeOver>();
            DamagePlayerRoundStats = new HashSet<Damage>();
            DamagePlayerRoundStatsNavigation = new HashSet<Damage>();
            Decoy = new HashSet<Decoy>();
            FireNade = new HashSet<FireNade>();
            Flash = new HashSet<Flash>();
            Flashed = new HashSet<Flashed>();
            He = new HashSet<He>();
            HostageDrop = new HashSet<HostageDrop>();
            HostagePickUp = new HashSet<HostagePickUp>();
            HostageRescue = new HashSet<HostageRescue>();
            ItemDropped = new HashSet<ItemDropped>();
            ItemPickedUp = new HashSet<ItemPickedUp>();
            ItemSaved = new HashSet<ItemSaved>();
            KillsPlayerRoundStats = new HashSet<Kills>();
            KillsPlayerRoundStatsNavigation = new HashSet<Kills>();
            PlayerPosition = new HashSet<PlayerPosition>();
            RoundItem = new HashSet<RoundItem>();
            Smoke = new HashSet<Smoke>();
            WeaponFired = new HashSet<WeaponFired>();
            WeaponReload = new HashSet<WeaponReload>();
        }

        public long MatchId { get; set; }
        public short Round { get; set; }
        public long PlayerId { get; set; }
        public int PlayedEquipmentValue { get; set; }
        public int MoneyInitial { get; set; }
        public int MoneySaved { get; set; }
        public int MoneyEarned { get; set; }
        public int MoneySpent { get; set; }
        public int MoneyLost { get; set; }
        public int GiftedValue { get; set; }
        public int ReceivedGiftValue { get; set; }
        public bool IsCt { get; set; }
        public short ArmorType { get; set; }
        public int PathId { get; set; }
        public short RoundStartKills { get; set; }
        public short RoundStartDeaths { get; set; }
        public short RoundStartAssists { get; set; }
        public short RoundStartScore { get; set; }
        public short RoundStartMvps { get; set; }
        public short RoundStartDamage { get; set; }

        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public RoundStats RoundStats { get; set; }
        public ICollection<BombDefused> BombDefused { get; set; }
        public ICollection<BombPlant> BombPlant { get; set; }
        public ICollection<BotTakeOver> BotTakeOver { get; set; }
        public ICollection<Damage> DamagePlayerRoundStats { get; set; }
        public ICollection<Damage> DamagePlayerRoundStatsNavigation { get; set; }
        public ICollection<Decoy> Decoy { get; set; }
        public ICollection<FireNade> FireNade { get; set; }
        public ICollection<Flash> Flash { get; set; }
        public ICollection<Flashed> Flashed { get; set; }
        public ICollection<He> He { get; set; }
        public ICollection<HostageDrop> HostageDrop { get; set; }
        public ICollection<HostagePickUp> HostagePickUp { get; set; }
        public ICollection<HostageRescue> HostageRescue { get; set; }
        public ICollection<ItemDropped> ItemDropped { get; set; }
        public ICollection<ItemPickedUp> ItemPickedUp { get; set; }
        public ICollection<ItemSaved> ItemSaved { get; set; }
        public ICollection<Kills> KillsPlayerRoundStats { get; set; }
        public ICollection<Kills> KillsPlayerRoundStatsNavigation { get; set; }
        public ICollection<PlayerPosition> PlayerPosition { get; set; }
        public ICollection<RoundItem> RoundItem { get; set; }
        public ICollection<Smoke> Smoke { get; set; }
        public ICollection<WeaponFired> WeaponFired { get; set; }
        public ICollection<WeaponReload> WeaponReload { get; set; }
    }
}
