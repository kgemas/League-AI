namespace LeagueAI.Libraries.Entities
{
    public sealed class Summoner
    {
        public long accountId { get; set; }

        public string displayName { get; set; }

        public string internalName { get; set; }

        public bool nameChangeFlag { get; set; }

        public byte percentCompleteForNextLevel { get; set; }

        public short profileIconId { get; set; }

        public string puuid { get; set; }

        public RerollPoints RerollPoints { get; set; }

        public long summonerId { get; set; }

        public short summonerLevel { get; set; }

        public bool unnamed { get; set; }

        public int xpSinceLastLevel { get; set; }

        public int xpUntilNextLevel { get; set; }

    }
}
