﻿using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using MonsterLabZConfig;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class DwarfGoblinTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature;
            Creature creature2;
            Creature creature3;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_die");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinSpear_projectile");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinSpearChitin_projectile");
            new Item("dybassets", "DwarfGoblinBow").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinPickAxe").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinClub").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSword").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinTorch").Configurable = Configurability.Disabled;
            //new Item("dybassets", "DwarfGoblinShieldBlackMetal").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShieldWood").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmBandFeathers").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmBandIron").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorBronze").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorFeathers").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorIron").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorLeather").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinHelmetBronze").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinHelmetLeather").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinHelmetSkull").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShoulderPadIron").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShoulderPadLeather").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSpear").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSpearLox").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSpearChitin").Configurable = Configurability.Disabled;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinShaman_ragdoll");
            new Item("dybassets", "DwarfGoblinShamanBoat_attack_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShaman_attack_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShaman_attack_poke").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShamanStaffBones").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShamanStaffFeathers").Configurable = Configurability.Disabled;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinLoot_ragdoll");
            new Item("dybassets", "DwarfGoblinLoot_Run").Configurable = Configurability.Disabled;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_ragdoll");

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                if ((bool)config[PluginConfig.DefDwarfGoblin].BoxedValue)
                {
                    creature = new Creature("dybassets", "DwarfGoblin")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                    DwarfGoblinParts(creature);
                }
                if ((bool)config[PluginConfig.DefDwarfGoblinLoot].BoxedValue)
                {
                    creature2 = new Creature("dybassets", "DwarfGoblinLoot")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                    DwarfGoblinLootParts(creature2);
                }
                if ((bool)config[PluginConfig.DefDwarfGoblinShaman].BoxedValue)
                {
                    creature3 = new Creature("dybassets", "DwarfGoblinShaman")
                    {
                        Biome = Heightmap.Biome.None,
                        CanSpawn = false
                    };
                    DwarfGoblinShamanParts(creature3);
                }

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(735)
                            .SetTemplateName("GenDwarfGoblin")
                            .SetPrefabName("DwarfGoblin")
                            .SetConditionBiomes((Heightmap.Biome.Plains))
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(736)
                            .SetTemplateName("GenDwarfGoblinLoot")
                            .SetPrefabName("DwarfGoblinLoot")
                            .SetConditionBiomes((Heightmap.Biome.Plains))
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(737)
                            .SetTemplateName("GenDwarfGoblinShaman")
                            .SetPrefabName("DwarfGoblinShaman")
                            .SetConditionBiomes((Heightmap.Biome.Plains))
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }
            else
            {
                if ((bool)config[PluginConfig.DefDwarfGoblin].BoxedValue)
                {
                    creature = new Creature("dybassets", "DwarfGoblin")
                    {
                        Biome = Heightmap.Biome.Plains,
                        SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                        RequiredAltitude = new Range(1f, 1000f),
                        CheckSpawnInterval = 300,
                        SpawnChance = 25f,
                        GroupSize = new Range(4f, 5f),
                        Maximum = 8,
                        SpecificSpawnTime = SpawnTime.Always
                    };
                    DwarfGoblinParts(creature);
                }
                if ((bool)config[PluginConfig.DefDwarfGoblinLoot].BoxedValue)
                {
                    creature2 = new Creature("dybassets", "DwarfGoblinLoot")
                    {
                        Biome = Heightmap.Biome.Plains,
                        SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                        RequiredAltitude = new Range(1f, 1000f),
                        CheckSpawnInterval = 300,
                        SpawnChance = 5f,
                        GroupSize = new Range(1f, 1f),
                        Maximum = 2,
                        SpecificSpawnTime = SpawnTime.Day
                    };
                    DwarfGoblinLootParts(creature2);
                }
                if ((bool)config[PluginConfig.DefDwarfGoblinShaman].BoxedValue)
                {
                    creature3 = new Creature("dybassets", "DwarfGoblinShaman")
                    {
                        Biome = Heightmap.Biome.Plains,
                        SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                        RequiredAltitude = new Range(1f, 1000f),
                        CheckSpawnInterval = 450,
                        SpawnChance = 10f,
                        GroupSize = new Range(1f, 2f),
                        Maximum = 2,
                        SpecificSpawnTime = SpawnTime.Always
                    };
                    DwarfGoblinShamanParts(creature3);
                }
            }

            GoblinRider(config);
        }

        private static void DwarfGoblinParts(Creature creature)
        {
            creature.Drops["Coins"].Amount = new Range(3f, 5f);
            creature.Drops["Coins"].DropChance = 100f;
            creature.Drops["Coins"].DropOnePerPlayer = false;
            creature.Drops["Coins"].MultiplyDropByLevel = true;
        }

        private static void DwarfGoblinLootParts(Creature creature2)
        {
            creature2.Drops["Coins"].Amount = new Range(5f, 8f);
            creature2.Drops["Coins"].DropChance = 100f;
            creature2.Drops["Coins"].DropOnePerPlayer = false;
            creature2.Drops["Coins"].MultiplyDropByLevel = true;
            creature2.Drops["Amber"].Amount = new Range(2f, 4f);
            creature2.Drops["Amber"].DropChance = 100f;
            creature2.Drops["Amber"].DropOnePerPlayer = false;
            creature2.Drops["Amber"].MultiplyDropByLevel = true;
            creature2.Drops["Ruby"].Amount = new Range(1f, 3f);
            creature2.Drops["Ruby"].DropChance = 100f;
            creature2.Drops["Ruby"].DropOnePerPlayer = false;
            creature2.Drops["Ruby"].MultiplyDropByLevel = true;

        }

        private static void DwarfGoblinShamanParts(Creature creature3)
        {
            creature3.Drops["Coins"].Amount = new Range(4f, 6f);
            creature3.Drops["Coins"].DropChance = 100f;
            creature3.Drops["Coins"].DropOnePerPlayer = false;
            creature3.Drops["Coins"].MultiplyDropByLevel = true;
        }

        private static void GoblinRider(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefDwarfGoblinRider].BoxedValue) return;

            Creature creature;
            Creature creature2;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "ML_GoblinLox")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(729)
                            .SetTemplateName("GenGoblinLox")
                            .SetPrefabName("ML_GoblinLox")
                            .SetConditionBiomes((Heightmap.Biome.Plains))
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            } else
            {
                creature = new Creature("dybassets", "ML_GoblinLox")
                {
                    Biome = Heightmap.Biome.Plains,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Edge,
                    RequiredAltitude = new Range(1f, 1000f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 5f,
                    GroupSize = new Range(2f, 2f),
                    Maximum = 2,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            creature.Drops["LoxMeat"].Amount = new Range(4f, 6f);
            creature.Drops["LoxMeat"].DropChance = 100f;
            creature.Drops["LoxMeat"].DropOnePerPlayer = false;
            creature.Drops["LoxMeat"].MultiplyDropByLevel = true;
            creature.Drops["TrophyLox"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyLox"].DropChance = 10f;
            creature.Drops["TrophyLox"].DropOnePerPlayer = false;
            creature.Drops["TrophyLox"].MultiplyDropByLevel = true;
            creature.Drops["LoxPelt"].Amount = new Range(2f, 3f);
            creature.Drops["LoxPelt"].DropChance = 100f;
            creature.Drops["LoxPelt"].DropOnePerPlayer = false;
            creature.Drops["LoxPelt"].MultiplyDropByLevel = true;

            creature2 = new Creature("dybassets", "GoblinLoxRider")
            {
                Biome = Heightmap.Biome.None
            };
            creature2.ConfigurationEnabled = true;
            creature2.Drops["Coins"].Amount = new Range(3f, 5f);
            creature2.Drops["Coins"].DropChance = 100f;
            creature2.Drops["Coins"].DropOnePerPlayer = false;
            creature2.Drops["Coins"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_GoblinLox_Ragdoll");
        }
    }
}
