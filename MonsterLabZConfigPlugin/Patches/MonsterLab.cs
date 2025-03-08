using HarmonyLib;

namespace MonsterLabZConfig
{
    [HarmonyPatch(typeof(FejdStartup))]
    static class FejdStartupPatch
    {
        internal const string harmonyId = "MonsterLabZ";

        [HarmonyPatch(nameof(FejdStartup.Awake))]
        [HarmonyPriority(Priority.Last)]
        static void Awake()
        {
            if (Harmony.HasAnyPatches(harmonyId)) UnpatchIfPatched();
        }

        static void UnpatchIfPatched()
        {
            Harmony.UnpatchID(harmonyId);
            ZLog.Log($"Unpatching all '{harmonyId}' patches");
        }
    }
}
