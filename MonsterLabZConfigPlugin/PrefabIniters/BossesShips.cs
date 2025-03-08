using BepInEx.Configuration;
using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossesShips
    {
        public static short wildSetting { get; set; }
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            wildSetting = (short)config[PluginConfig.DefWildBosses].BoxedValue;
            if (wildSetting < 1) return;

            LoadFulingShip(config);
            LoadDraugrShip(config);
        }

        private static void LoadFulingShip(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefFulingShip].BoxedValue || wildSetting == 0) return;

            Creature creature;
            if (wildSetting > 1)
            {
                creature = new Creature("dybassets", "ML_GoblinShip")
                {
                    Biome = Heightmap.Biome.Plains,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Edge,
                    RequiredAltitude = new Range(-1000f, 0f),
                    SpawnAltitude = 20f,
                    RequiredOceanDepth = new Range(15f, 20f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 10f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Day,
                    RequiredWeather = Weather.MeadowsClearSkies,
                    RequiredGlobalKey = GlobalKey.KilledModer
                };
            }
            else
            {
                creature = new Creature("dybassets", "ML_GoblinShip")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(750)
                            .SetTemplateName("GenML_GoblinShip")
                            .SetPrefabName("ML_GoblinShip")
                            .SetConditionBiomes(Heightmap.Biome.Plains)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }

            creature.Drops["DeerHide"].Amount = new Range(1f, 2f);
            creature.Drops["DeerHide"].DropChance = 100f;
            creature.Drops["DeerHide"].DropOnePerPlayer = false;
            creature.Drops["DeerHide"].MultiplyDropByLevel = true;
            creature.Drops["ElderBark"].Amount = new Range(1f, 2f);
            creature.Drops["ElderBark"].DropChance = 100f;
            creature.Drops["ElderBark"].DropOnePerPlayer = false;
            creature.Drops["ElderBark"].MultiplyDropByLevel = true;
            creature.Drops["FineWood"].Amount = new Range(1f, 2f);
            creature.Drops["FineWood"].DropChance = 100f;
            creature.Drops["FineWood"].DropOnePerPlayer = false;
            creature.Drops["FineWood"].MultiplyDropByLevel = true;
            creature.Drops["DwarfGoblin_NoAttack"].Amount = new Range(3f, 5f);
            creature.Drops["DwarfGoblin_NoAttack"].DropChance = 100f;
            creature.Drops["DwarfGoblin_NoAttack"].DropOnePerPlayer = false;
            creature.Drops["DwarfGoblin_NoAttack"].MultiplyDropByLevel = false;
            creature.Drops["ML_GoblinShip_Cargo"].Amount = new Range(3f, 5f);
            creature.Drops["ML_GoblinShip_Cargo"].DropChance = 100f;
            creature.Drops["ML_GoblinShip_Cargo"].DropOnePerPlayer = false;
            creature.Drops["ML_GoblinShip_Cargo"].MultiplyDropByLevel = false;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_Boat");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinShaman_Boat");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_NoAttack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_Spawn");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_GoblinShip_Cargo");
            new Item("dybassets", "ml_aiship_move").Configurable = Configurability.Disabled;
            new Item("dybassets", "ml_goblinship_spawn").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_shipwater_surface");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ship_move_slow");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ship_move_fast");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ml_goblinship_spawn_projectile");
        }

        private static void LoadDraugrShip(ConfigFile config)
        {
            Creature creature;
            if (!(bool)config[PluginConfig.DefDraugrShip].BoxedValue || wildSetting == 0) return;
            if (wildSetting > 1)
            {
                creature = new Creature("dybassets", "ML_DraugrShip")
                {
                    Biome = Heightmap.Biome.BlackForest,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Edge,
                    RequiredAltitude = new Range(-1000f, 0f),
                    SpawnAltitude = 20f,
                    RequiredOceanDepth = new Range(15f, 20f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 10f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Night,
                    RequiredWeather = Weather.Fog,
                    RequiredGlobalKey = GlobalKey.KilledBonemass
                };
            }
            else
            {
                creature = new Creature("dybassets", "ML_DraugrShip")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(751)
                            .SetTemplateName("GenML_DraugrShip")
                            .SetPrefabName("ML_DraugrShip")
                            .SetConditionBiomes(Heightmap.Biome.Swamp)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }
                
            creature.Drops["DeerHide"].Amount = new Range(1f, 2f);
            creature.Drops["DeerHide"].DropChance = 100f;
            creature.Drops["DeerHide"].DropOnePerPlayer = false;
            creature.Drops["DeerHide"].MultiplyDropByLevel = true;
            creature.Drops["ElderBark"].Amount = new Range(1f, 2f);
            creature.Drops["ElderBark"].DropChance = 100f;
            creature.Drops["ElderBark"].DropOnePerPlayer = false;
            creature.Drops["ElderBark"].MultiplyDropByLevel = true;
            creature.Drops["FineWood"].Amount = new Range(1f, 2f);
            creature.Drops["FineWood"].DropChance = 100f;
            creature.Drops["FineWood"].DropOnePerPlayer = false;
            creature.Drops["FineWood"].MultiplyDropByLevel = true;
            creature.Drops["ML_DraugrShip_Cargo"].Amount = new Range(3f, 5f);
            creature.Drops["ML_DraugrShip_Cargo"].DropChance = 100f;
            creature.Drops["ML_DraugrShip_Cargo"].DropOnePerPlayer = false;
            creature.Drops["ML_DraugrShip_Cargo"].MultiplyDropByLevel = false;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Draugr_Boat");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_DraugrBomber_Boat");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Draugr_Spawn");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Draugr_ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_DraugrShip_Cargo");
            new Item("dybassets", "ml_draugrship_spawn").Configurable = Configurability.Disabled;
            new Item("dybassets", "Draugr_OozeBomb").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Draugr_Bow").Configurable = Configurability.Disabled;
            new Item("dybassets", "draugrboat_axe").Configurable = Configurability.Disabled;
            new Item("dybassets", "draugrboat_sword").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ml_draugrship_spawn_projectile");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "draugr_oozebomb_projectile");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "draugr_oozebomb_explosion");
        }
    }
}
