using BepInEx.Configuration;
using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Molluscans
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Molluscan(config);
            DeepMolluscan(config);

            if ((bool)config[PluginConfig.DefDeepMolluscan].BoxedValue || (bool)config[PluginConfig.DefMolluscan].BoxedValue)
            {
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "Molluscan_ragdoll");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "DeepSeaMolluscan_ragdoll");
                new Item("dybassets", "TrophyMolluscan").Configurable = Configurability.Disabled;
                new Item("dybassets", "TrophyDeepSeaMolluscan").Configurable = Configurability.Disabled;
                new Item("dybassets", "Molluscan_attack").Configurable = Configurability.Disabled;
                new Item("dybassets", "Molluscan_attack2").Configurable = Configurability.Disabled;
                new Item("dybassets", "Molluscan_attack3").Configurable = Configurability.Disabled;
                new Item("dybassets", "Molluscan_taunt").Configurable = Configurability.Disabled;
                new Item("dybassets", "MolluscanLand_attack").Configurable = Configurability.Disabled;
                new Item("dybassets", "MolluscanLand_attack2").Configurable = Configurability.Disabled;
                new Item("dybassets", "MolluscanLand_attack3").Configurable = Configurability.Disabled;
                new Item("dybassets", "MolluscanLand_taunt").Configurable = Configurability.Disabled;
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_alert");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_attack");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_death");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_hit");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_idle");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_taunt");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_alert");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_attack");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_death");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_hit");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_idle");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_taunt");
            }
        }

        private static void Molluscan(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefMolluscan].BoxedValue) return;

            Creature creature2;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature2 = new Creature("dybassets", "MolluscanLand")
                {
                    Biome = Heightmap.Biome.None
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(742)
                            .SetPrefabName("MolluscanLand")
                            .SetConditionBiomes(Heightmap.Biome.BlackForest | Heightmap.Biome.Swamp)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature2 = new Creature("dybassets", "MolluscanLand")
                {
                    Biome = Heightmap.Biome.BlackForest,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredOceanDepth = new Range(1f, 2f),
                    RequiredAltitude = new Range(-1f, 10f),
                    RequiredWeather = (Weather.LightRain | Weather.Rain | Weather.ThunderStorm),
                    CheckSpawnInterval = 450,
                    SpawnChance = 25f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 2,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            
            creature2.Drops["TrophyMolluscan"].Amount = new Range(1f, 1f);
            creature2.Drops["TrophyMolluscan"].DropChance = 10f;
            creature2.Drops["TrophyMolluscan"].DropOnePerPlayer = false;
            creature2.Drops["TrophyMolluscan"].MultiplyDropByLevel = false;
            creature2.Drops["Chitin"].Amount = new Range(1f, 1f);
            creature2.Drops["Chitin"].DropChance = 100f;
            creature2.Drops["Chitin"].DropOnePerPlayer = false;
            creature2.Drops["Chitin"].MultiplyDropByLevel = true;
        }

        private static void DeepMolluscan(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefDeepMolluscan].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "Molluscan")
                {
                    Biome = Heightmap.Biome.None
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(743)
                            .SetPrefabName("Molluscan")
                            .SetConditionBiomes(Heightmap.Biome.Ocean)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "Molluscan")
                {
                    Biome = Heightmap.Biome.Ocean,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(-1000f, -10f),
                    RequiredOceanDepth = new Range(15f, 30f),
                    CheckSpawnInterval = 450,
                    SpawnChance = 15f,
                    GroupSize = new Range(1f, 2f),
                    Maximum = 4,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            
            creature.Drops["TrophyDeepSeaMolluscan"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyDeepSeaMolluscan"].DropChance = 10f;
            creature.Drops["TrophyDeepSeaMolluscan"].DropOnePerPlayer = false;
            creature.Drops["TrophyDeepSeaMolluscan"].MultiplyDropByLevel = false;
            creature.Drops["Chitin"].Amount = new Range(2f, 3f);
            creature.Drops["Chitin"].DropChance = 100f;
            creature.Drops["Chitin"].DropOnePerPlayer = false;
            creature.Drops["Chitin"].MultiplyDropByLevel = true;
        }
    }
}
