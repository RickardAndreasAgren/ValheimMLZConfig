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

            Creature creature = new Creature("dybassets", "EvilShadow")
            {
                Biome = Heightmap.Biome.None
            };

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
            {
                MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(709)
                        .SetPrefabName("EvilShadow")
                        .SetConditionBiomes(Heightmap.Biome.Swamp)
                        .SetMinLevel(1)
                        .SetMaxLevel(3);
                });
            }
            new Item("dybassets", "evilshadow_attack").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_evilspirit_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_evilshadow_attack");
        }
    }
}
