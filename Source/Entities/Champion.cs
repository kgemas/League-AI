using LeagueAI.Libraries.Interfaces;
using System.Drawing;

namespace LeagueAI.Libraries.Entities
{
    public sealed class Champion : IEntity
    {
        public bool Ally
        {
            get;
            private set;
        }
        public Point Position
        {
            get;
            private set;
        }

        public Champion(bool ally, Point position)
        {
            Ally = ally;
            Position = position;
        }

    }
}
