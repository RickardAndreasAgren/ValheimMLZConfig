using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Surtlings
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 3) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_alerted");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtling_spawn_death");
            new Item("dybassets", "ml_surtling_attack_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "ml_surtling_attack_claw").Configurable = Configurability.Disabled;

            Creature creature = new Creature("dybassets", "Surtling_Spawn")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            Creature creature2 = new Creature("dybassets", "ML_Surtling")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
        }
    }
}
