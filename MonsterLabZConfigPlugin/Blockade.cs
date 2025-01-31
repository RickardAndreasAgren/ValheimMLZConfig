using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace MonsterLabZ
{
    [BepInPlugin("MonsterLabZ", "MonsterLabZ", "3.0.11")]
    public class MonsterLabZ : BaseUnityPlugin
    {
        public const string ModGUID = "MonsterLabZ";

        public const string ModName = "MonsterLabZ";

        public const string ModVersion = "3.0.11";

        public static ManualLogSource Log;

        public readonly Harmony harmony = new Harmony("MonsterLabZ");

        public static readonly ManualLogSource PatcherLogger =
            BepInEx.Logging.Logger.CreateLogSource("MLZCP");

        public void Awake()
        {
            PatcherLogger.LogWarning("BLOCKED");
            /*
            var infos = BepInEx.Bootstrap.Chainloader.PluginInfos;
            foreach (var info in infos)
            {
                PatcherLogger.LogWarning($"MLZCP: Comparing pluginInfos {info.Key}");
            }*/
            return;
        }
        public static string Greet()
        {
            return "Hi";
        }
    }
}
