using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class LavaRoots
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_LavaRoot_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_lavaroot_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_lavaroot_hit");
            new Item("dybassets", "lavaroot_attack").Configurable = Configurability.Disabled;

            new Creature("dybassets", "ML_LavaRoot")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
        }
    }
}
