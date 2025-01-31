using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class GreydwarfTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple_Shroom");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple_ragdoll");
        }
    }
}
