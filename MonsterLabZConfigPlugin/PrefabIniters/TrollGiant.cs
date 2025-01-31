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

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "TrollGiant")
                {
                    Biome = Heightmap.Biome.None
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(728)
                            .SetPrefabName("TrollGiant")
                            .SetBiomeArea((Heightmap.BiomeArea?)Heightmap.Biome.DeepNorth)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "TrollGiant")
                {
                    Biome = Heightmap.Biome.None
                };
            }
            
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "TrollGiant_Ragdoll");
            new Item("dybassets", "trollgiant_slam").Configurable = Configurability.Disabled;
            new Item("dybassets", "trollgiant_stomp").Configurable = Configurability.Disabled;
        }
    }
}
