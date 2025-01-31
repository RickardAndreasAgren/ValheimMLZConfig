using CreatureManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Jellies
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefJellyfish].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "ML_JellyFish0")
                {
                    Biome = Heightmap.Biome.Ocean
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(741)
                            .SetPrefabName("ML_JellyFish0")
                            .SetBiomeArea((Heightmap.BiomeArea?)(Heightmap.Biome.Ocean))
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "ML_JellyFish0")
                {
                    Biome = Heightmap.Biome.Ocean,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(-1000f, -10f),
                    RequiredOceanDepth = new Range(20f, 30f),
                    CheckSpawnInterval = 800,
                    SpawnAltitude = -10f,
                    SpawnChance = 55f,
                    GroupSize = new Range(1f, 3f),
                    Maximum = 6,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            creature.Drops["Guck"].Amount = new Range(1f, 2f);
            creature.Drops["Guck"].DropChance = 100f;
            creature.Drops["Guck"].DropOnePerPlayer = false;
            creature.Drops["Guck"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_jellyfish_death");
        }
    }
}
