using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Shadow
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 3) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_evilspirit_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_evilshadow_attack");
            new Item("dybassets", "evilshadow_attack").Configurable = Configurability.Disabled;

            Creature creature = new Creature("dybassets", "EvilShadow")
            {
                Biome = Heightmap.Biome.None,
                CanSpawn = false
            };

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
            {
                MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(709)
                        .SetTemplateName("GenEvilShadow")
                        .SetPrefabName("EvilShadow")
                        .SetConditionBiomes(Heightmap.Biome.Swamp)
                        .SetMinLevel(1)
                        .SetMaxLevel(3);
                });
            }
        }
    }
}
