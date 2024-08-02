using LeagueAI.Libraries.Interfaces;

namespace LeagueAI.Libraries.Api
{
    public abstract class BaseApiMember<T> where T : IApi
    {
        protected T Api { get; private set; }


        public BaseApiMember(T api)
        {
            Api = api;
        }
    }
}
