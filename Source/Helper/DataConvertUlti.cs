using Newtonsoft.Json;
using System.Drawing;

namespace LeagueAI.Libraries.Helper
{
    public static class DataConvertUlti
    {
        public static string SerializeJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T DeserializeJson<T>(string content) where T : class
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static Color? ToColorRGB(this int[] colorArr)
        {
            if (colorArr?.Length != 3) return null;
            return Color.FromArgb(colorArr[0], colorArr[1], colorArr[2]);
        }
    }
}
