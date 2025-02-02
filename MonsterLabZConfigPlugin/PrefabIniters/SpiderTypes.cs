using BepInEx.Configuration;
using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class SpiderTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            SpidersBrown(config);
            SpidersForest(config);
            SpidersFrigid(config);
            SpidersFrost(config);
            SpidersGreen(config);
            SpidersTree(config);
            SpidersTan(config);

            if ((bool)config[PluginConfig.DefTreeSpider].BoxedValue 
                || (bool)config[PluginConfig.DefGreenSpider].BoxedValue
                || (bool)config[PluginConfig.DefFrostSpider].BoxedValue
                || (bool)config[PluginConfig.DefFrigidSpider].BoxedValue
                || (bool)config[PluginConfig.DefForestSpider].BoxedValue
                || (bool)config[PluginConfig.DefTanSpider].BoxedValue
                || (bool)config[PluginConfig.DefBrownSpider].BoxedValue)
            {
                new Item("dybassets", "SpiderFang").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_attack").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_attack_jump").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_jump").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_leftattack").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_rightattack").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_dodgeb").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_dodgel").Configurable = Configurability.Disabled;
                new Item("dybassets", "spider_dodger").Configurable = Configurability.Disabled;
                new Item("dybassets", "jumpingspider_spit").Configurable = Configurability.Disabled;
                new Item("dybassets", "treespider_leftattack").Configurable = Configurability.Disabled;
                new Item("dybassets", "treespider_rightattack").Configurable = Configurability.Disabled;
                new Item("dybassets", "cavespider_leftattack").Configurable = Configurability.Disabled;
                new Item("dybassets", "cavespider_rightattack").Configurable = Configurability.Disabled;
                new Item("dybassets", "web_attack").Configurable = Configurability.Disabled;
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_footstep_spider");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_alerted");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_death");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_hit");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_idle");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_jumpingspider_spit");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_web_hit");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_spider_death");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_spider_hit");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "swoop_trail");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_jumpingspider_spit");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "jumpingspider_poison_aoe");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "web_projectile");
            }
        }

        private static void SpidersTree(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefTreeSpider].BoxedValue) return;

            new Creature("dybassets", "TreeSpider")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "TreeSpider_Spawn")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(721)
                            .SetTemplateName("GenTreeSpider_Spawn")
                            .SetPrefabName("TreeSpider_Spawn")
                            .SetConditionBiomes(Heightmap.Biome.Meadows)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "TreeSpider_Spawn")
                {
                    Biome = Heightmap.Biome.Meadows,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Center,
                    SpawnAltitude = 10f,
                    CheckSpawnInterval = 600,
                    ForestSpawn = Forest.Yes,
                    SpawnChance = 10f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 3,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "TreeSpider_ragdoll");
        }

        private static void SpidersGreen(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefGreenSpider].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "GreenSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(722)
                            .SetTemplateName("GenGreenSpider")
                            .SetPrefabName("GreenSpider")
                            .SetConditionBiomes(Heightmap.Biome.Meadows)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "GreenSpider")
                {
                    Biome = Heightmap.Biome.Meadows,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    CheckSpawnInterval = 600,
                    ForestSpawn = Forest.No,
                    SpawnChance = 15f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 2,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "GreenSpider_ragdoll");
        }

        private static void SpidersFrost(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefFrostSpider].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "FrostSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(723)
                            .SetTemplateName("GenFrostSpider")
                            .SetPrefabName("FrostSpider")
                            .SetConditionBiomes(Heightmap.Biome.Mountain)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "FrostSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(2f, 3f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "FrostSpider_ragdoll");
        }

        private static void SpidersFrigid(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefFrigidSpider].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "FrigidSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(724)
                            .SetTemplateName("GenFrigidSpider")
                            .SetPrefabName("FrigidSpider")
                            .SetConditionBiomes(Heightmap.Biome.DeepNorth)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "FrigidSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(2f, 3f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "FrigidSpider_ragdoll");
        }

        private static void SpidersForest(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefForestSpider].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "ForestSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(725)
                            .SetTemplateName("GenForestSpider")
                            .SetPrefabName("ForestSpider")
                            .SetConditionBiomes(Heightmap.Biome.BlackForest)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "ForestSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(2f, 3f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ForestSpider_ragdoll");
        }

        private static void SpidersBrown(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefBrownSpider].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "BrownSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(726)
                            .SetTemplateName("GenBrownSpider")
                            .SetPrefabName("BrownSpider")
                            .SetConditionBiomes(Heightmap.Biome.Swamp)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "BrownSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            new Creature("dybassets", "BrownSpider_Spawn")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(2f, 3f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "BrownSpider_ragdoll");
        }
        private static void SpidersTan(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefTanSpider].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "TanSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(727)
                            .SetTemplateName("GenTanSpider")
                            .SetPrefabName("TanSpider")
                            .SetConditionBiomes(Heightmap.Biome.Plains)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "TanSpider")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(2f, 3f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "TanSpider_ragdoll");
        }
    }
}
