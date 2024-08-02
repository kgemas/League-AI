namespace LeagueAI.Libraries.Entities
{
    public sealed class StatusInGame
    {
        /// <summary>
        /// Máu hiện tại
        /// </summary>
        public double currentHealth { get; set; }

        /// <summary>
        /// Tổng số máu
        /// </summary>
        public double maxHealth { get; set; }

        /// <summary>
        /// Mana hiện tại
        /// </summary>
        public double resourceValue { get; set; }

        /// <summary>
        /// Tổng số mana
        /// </summary>
        public double resourceMax { get; set; }
    }
}
