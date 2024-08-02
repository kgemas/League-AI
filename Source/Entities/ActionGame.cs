namespace LeagueAI.Libraries.Entities
{
    public sealed class ActionGame
    {
        public int? actorCellId { get; set; }
        public int? championId { get; set; }
        public bool? completed { get; set; }
        public int? id { get; set; }
        public bool? isAllyAction { get; set; }
        public bool? isInProgress { get; set; }
        public double? pickTurn { get; set; }
        public string type { get; set; }
    }
}
