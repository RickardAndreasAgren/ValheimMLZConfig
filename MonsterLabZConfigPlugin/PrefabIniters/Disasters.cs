using BepInEx.Configuration;
using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;
using static Heightmap;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Disasters
    {
        internal static void init(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefDisasters].BoxedValue) return;

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                new Creature("dybassets", "ML_HailStorm")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                new Creature("dybassets", "ML_LightningStorm")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                new Creature("dybassets", "ML_MeteorShower")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(730)
                            .SetTemplateName("GenHailStorm")
                            .SetPrefabName("ML_HailStorm")
                            .SetConditionBiomes(Heightmap.Biome.Mountain | Heightmap.Biome.DeepNorth)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(731)
                            .SetTemplateName("GenLightningStorm")
                            .SetPrefabName("ML_LightningStorm")
                            .SetConditionBiomes(Heightmap.Biome.Meadows | Heightmap.Biome.Plains)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(732)
                            .SetTemplateName("GenMeteorShower")
                            .SetPrefabName("ML_MeteorShower")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            } else
            {
                new Creature("dybassets", "ML_HailStorm")
                {
                    Biome = (Heightmap.Biome.Mountain | Heightmap.Biome.DeepNorth),
                    SpecificSpawnArea = CreatureManager.SpawnArea.Center,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 5f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
                new Creature("dybassets", "ML_LightningStorm")
                {
                    Biome = (Heightmap.Biome.Meadows | Heightmap.Biome.Plains),
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 1000,
                    RequiredWeather = Weather.ThunderStorm,
                    SpawnChance = 5f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
                new Creature("dybassets", "ML_MeteorShower")
                {
                    Biome = Heightmap.Biome.AshLands,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Center,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 5f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            
            new Item("dybassets", "ML_MeteorShower_Start").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_HailStorm_Start").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_LightningStorm_Start").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_ml_hailstorm");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_hailstorm_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ml_meteorshower_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_HailStorm_Projectile");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_HailStorm_Spawn");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_LightningStorm_AOE");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_LightningStorm_Spawn");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_MeteorShower_AOE");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_MeteorShower_Spawn");
        }
    }
}