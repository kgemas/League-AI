namespace LeagueAI.Libraries.Entities
{
    public sealed class RerollPoints
    {
        public int currentPoints { get; set; }

        public int maxRolls { get; set; }

        public int numberOfRolls { get; set; }

        public int pointsCostToRoll { get; set; }

        public int pointsToReroll { get; set; }
    }
}
