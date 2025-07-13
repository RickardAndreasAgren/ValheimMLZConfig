using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class TrollGiant
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefTrollGiant].BoxedValue) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "TrollGiant_Ragdoll");
            new Item("dybassets", "trollgiant_slam").Configurable = Configurability.Disabled;
            new Item("dybassets", "trollgiant_stomp").Configurable = Configurability.Disabled;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "TrollGiant")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(728)
                            .SetTemplateName("GenTrollGiant")
                            .SetPrefabName("TrollGiant")
                            .SetConditionBiomes(Heightmap.Biome.DeepNorth)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "TrollGiant")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
        }
    }
}
