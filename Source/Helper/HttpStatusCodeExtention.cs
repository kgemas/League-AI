using Leaf.xNet;

namespace LeagueAI.Libraries.Helper
{
    public static class HttpStatusCodeExtention
    {
        public static bool IsSuccess(this HttpStatusCode httpStatusCode)
        {
            var code = (int)httpStatusCode;
            return 200 <= code && code < 300;
        }
    }
}
