﻿using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Butterflies
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefButterflies].BoxedValue) return;

            Creature creature;
            Creature creature2;
            Creature creature3;

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "Rainbow_Butterfly")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                creature2 = new Creature("dybassets", "Green_Butterfly")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                }; ;
                creature3 = new Creature("dybassets", "Silkworm_Butterfly")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                }; ;


                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(733)
                            .SetTemplateName("GenRainbow_Butterfly")
                            .SetPrefabName("Rainbow_Butterfly")
                            .SetConditionBiomes(Heightmap.Biome.Meadows)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(734)
                            .SetTemplateName("GenGreen_Butterfly")
                            .SetPrefabName("Green_Butterfly")
                            .SetConditionBiomes(Heightmap.Biome.BlackForest)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(735)
                            .SetTemplateName("GenSilkworm_Butterfly")
                            .SetPrefabName("Silkworm_Butterfly")
                            .SetConditionBiomes(Heightmap.Biome.Mistlands)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            } else
            {
                creature = new Creature("dybassets", "Rainbow_Butterfly")
                {
                    Biome = Heightmap.Biome.Meadows,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    CheckSpawnInterval = 300,
                    RequiredWeather = (Weather.ClearSkies | Weather.MeadowsClearSkies),
                    ForestSpawn = Forest.No,
                    SpawnChance = 50f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 3,
                    CanHaveStars = false,
                    SpecificSpawnTime = SpawnTime.Day
                };
                creature2 = new Creature("dybassets", "Green_Butterfly")
                {
                    Biome = Heightmap.Biome.BlackForest,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    CheckSpawnInterval = 300,
                    RequiredWeather = (Weather.ClearSkies | Weather.MeadowsClearSkies | Weather.BlackForestFog),
                    SpawnChance = 50f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 3,
                    CanHaveStars = false,
                    SpecificSpawnTime = SpawnTime.Day
                };

                creature3 = new Creature("dybassets", "Silkworm_Butterfly")
                {
                    Biome = Heightmap.Biome.Mistlands,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    CheckSpawnInterval = 300,
                    RequiredWeather = Weather.MistlandsDark,
                    SpawnChance = 50f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 3,
                    CanHaveStars = false,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
                
            creature.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = false;

            creature2.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature2.Drops["Ooze"].DropChance = 100f;
            creature2.Drops["Ooze"].DropOnePerPlayer = false;
            creature2.Drops["Ooze"].MultiplyDropByLevel = false;

            creature3.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature3.Drops["Ooze"].DropChance = 100f;
            creature3.Drops["Ooze"].DropOnePerPlayer = false;
            creature3.Drops["Ooze"].MultiplyDropByLevel = false;
        }
    }
}
