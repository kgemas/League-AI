using LeagueAI.Libraries.Api;
using LeagueAI.Libraries.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LeagueAI.Libraries.Helper
{
    public sealed class PatternsUlti
    {
        private static readonly Dictionary<string, Type> Scripts = new Dictionary<string, Type>();
        public static List<string> ScriptsPattern => Scripts.Keys.ToList();

        public static void Initialize()
        {
            Type baseType = typeof(BasePatternScript);
            Assembly assembly = Assembly.GetAssembly(baseType);

            // Lấy tất cả các Type của assembly
            Type[] types = assembly.GetTypes();

            // Lọc các Type của class kế thừa từ class cha
            IEnumerable<Type> derivedTypes = types.Where(t => t.IsSubclassOf(baseType));

            foreach (Type type in derivedTypes)
            {
                Scripts.Add(type.Name, type);
            }
        }
        public static bool Contains(string name) => Scripts.ContainsKey(name);

        public static void Execute(string name)
        {
            if (!Scripts.ContainsKey(name))
            {
                Logger.WriteLine(string.Format(DEFINE.PatternErrorLog, name));
                return;
            }

            BasePatternScript script = null;
            try
            {
                script = Activator.CreateInstance(Scripts[name]) as BasePatternScript;
                script.bot = new BotApi();
                script.client = new ClientApi();
                script.game = new GameApi();
                script.Execute();
            }
            catch (Exception ex) { Logger.WriteLine(ex); }
        }
        public static new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Type> script in Scripts)
            {
                sb.AppendLine("-" + script.Key);
            }
            return sb.ToString();
        }
    }
}
