using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Svartalf
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 3) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Svartalfar0_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_taunt");

            Creature creature = new Creature("dybassets", "MLNPC_Svartalfar0")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            creature.Drops["Entrails"].Amount = new Range(1f, 1f);
            creature.Drops["Entrails"].DropChance = 100f;
            creature.Drops["Entrails"].DropOnePerPlayer = false;
            creature.Drops["Entrails"].MultiplyDropByLevel = true;
        }
    }
}
