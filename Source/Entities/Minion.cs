using LeagueAI.Libraries.Interfaces;
using System.Drawing;

namespace LeagueAI.Libraries.Entities
{
    public sealed class Minion : IEntity
    {
        public Point Position
        {
            get;
            private set;
        }

        public Minion(Point position)
        {
            Position = position;
        }
    }
}
