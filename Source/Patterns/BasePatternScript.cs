using LeagueAI.Libraries.Api;

namespace LeagueAI.Libraries.Patterns
{
    public abstract class BasePatternScript
    {
        public BotApi bot { protected get; set; }
        public GameApi game { protected get; set; }
        public ClientApi client { protected get; set; }

        public abstract void Execute();

        public virtual void Dispose() { }
    }
}
