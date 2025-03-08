using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Mistiles
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((bool)config[PluginConfig.DefMistileRedAggro].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_RedMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_RedMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(704)
                            .SetTemplateName("GenML_RedMistile_Aggressive")
                            .SetPrefabName("ML_RedMistile_Aggressive")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            if ((bool)config[PluginConfig.DefMistileRedPassive].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_RedMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_RedMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(705)
                            .SetTemplateName("GenML_RedMistile_Passive")
                            .SetPrefabName("ML_RedMistile_Passive")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }
            if ((bool)config[PluginConfig.DefMistileBlueAggro].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_BlueMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_BlueMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(706)
                            .SetTemplateName("GenML_BlueMistile_Aggressive")
                            .SetPrefabName("ML_BlueMistile_Aggressive")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            if ((bool)config[PluginConfig.DefMistileBluePassive].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_BlueMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_BlueMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                }

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(707)
                            .SetTemplateName("GenML_BlueMistile_Passive")
                            .SetPrefabName("ML_BlueMistile_Passive")
                            .SetConditionBiomes(Heightmap.Biome.Meadows | Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }

            if ((bool)config[PluginConfig.DefMistileBluePassive].BoxedValue || (bool)config[PluginConfig.DefMistileBlueAggro].BoxedValue)
            {
                new Item("dybassets", "ML_BlueMistile_kamikaze").Configurable = Configurability.Disabled;
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_BlueMistile_attack");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_BlueMistile_die");
            }
            if ((bool)config[PluginConfig.DefMistileRedPassive].BoxedValue || (bool)config[PluginConfig.DefMistileRedAggro].BoxedValue)
            {
                new Item("dybassets", "ML_RedMistile_kamikaze").Configurable = Configurability.Disabled;
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_RedMistile_attack");
                ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_RedMistile_die");
            }
        }
    }
}
