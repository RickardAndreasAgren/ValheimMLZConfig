using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class LavaRoots
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            new Creature("dybassets", "ML_LavaRoot")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
                
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_LavaRoot_Ragdoll");
            new Item("dybassets", "lavaroot_attack").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_lavaroot_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_lavaroot_hit");
        }
    }
}
