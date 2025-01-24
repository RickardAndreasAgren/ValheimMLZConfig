extern alias MonsterLabZN;
using MonsterLabZN::MonsterLabZ;

namespace MonsterLabZConfig.Loaders
{
    internal static class PatchedLoader
    {
        public static void LoadPrefix(ZNetScene __instance)
        {
            ShaderSwapper.GatherCustomShaders(__instance);
        }

        internal static void LoadPostfix()
        {
            ShaderSwapper.ReplaceCustomShaders();
            CommonResources.FindCommonResources();
        }
    }
}
