using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lolapitestwpf
{
    class CurrentGame
    {

        public class Rootobject
        {
            public int GameId { get; set; }
            public int MapId { get; set; }
            public string GameMode { get; set; }
            public string GameType { get; set; }
            public Participant[] Participants { get; set; }
            public Observers Observers { get; set; }
            public string PlatformId { get; set; }
            public object[] BannedChampions { get; set; }
            public int GameStartTime { get; set; }
            public int GameLength { get; set; }
        }

        public class Observers
        {
            public string EncryptionKey { get; set; }
        }

        public class Participant
        {
            public int TeamId { get; set; }
            public int Spell1Id { get; set; }
            public int Spell2Id { get; set; }
            public int ChampionId { get; set; }
            public int ProfileIconId { get; set; }
            public string SummonerName { get; set; }
            public bool Bot { get; set; }
            public int SummonerId { get; set; }
            public Rune[] Runes { get; set; }
            public Mastery[] Masteries { get; set; }
        }

        public class Rune
        {
            public int Count { get; set; }
            public int RuneId { get; set; }
        }

        public class Mastery
        {
            public int Rank { get; set; }
            public int MasteryId { get; set; }
        }

    }
}
