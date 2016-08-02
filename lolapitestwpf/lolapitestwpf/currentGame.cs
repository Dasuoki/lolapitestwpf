using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lolapitestwpf
{
    class currentGame
    {

        public class Rootobject
        {
            public int gameId { get; set; }
            public int mapId { get; set; }
            public string gameMode { get; set; }
            public string gameType { get; set; }
            public Participant[] participants { get; set; }
            public Observers observers { get; set; }
            public string platformId { get; set; }
            public object[] bannedChampions { get; set; }
            public int gameStartTime { get; set; }
            public int gameLength { get; set; }
        }

        public class Observers
        {
            public string encryptionKey { get; set; }
        }

        public class Participant
        {
            public int teamId { get; set; }
            public int spell1Id { get; set; }
            public int spell2Id { get; set; }
            public int championId { get; set; }
            public int profileIconId { get; set; }
            public string summonerName { get; set; }
            public bool bot { get; set; }
            public int summonerId { get; set; }
            public Rune[] runes { get; set; }
            public Mastery[] masteries { get; set; }
        }

        public class Rune
        {
            public int count { get; set; }
            public int runeId { get; set; }
        }

        public class Mastery
        {
            public int rank { get; set; }
            public int masteryId { get; set; }
        }

    }
}
