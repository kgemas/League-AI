namespace LeagueAI.Libraries.Entities
{
    public sealed class Availability
    {
        public bool? isAvailable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>InGameFlow</example>
        public string state { get; set; }
    }
}
