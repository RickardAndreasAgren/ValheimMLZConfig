﻿using BepInEx.Configuration;
using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Ghosts
    {
        public static void init(ConfigFile config)
        {
            GhostWarrior(config);
            WraithWarrior(config);
        }

        public static void GhostWarrior(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefGhostWarrior].BoxedValue) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "GhostWarrior");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_ghost_poison_explode");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_ghost_poison_start");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ghostpoison_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ghost_poison_explosion");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ghost_poisonball_projectile");
            new Item("dybassets", "ghost_poisonball").Configurable = Configurability.Disabled;

            Creature warrior;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                warrior = new Creature("dybassets", "NormalGhostWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(738)
                            .SetTemplateName("GenNormalGhostWarrior")
                            .SetPrefabName("NormalGhostWarrior")
                            .SetConditionBiomes((Heightmap.Biome.Plains))
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }
            else
            {
                warrior = new Creature("dybassets", "NormalGhostWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            warrior.Drops["Ruby"].Amount = new Range(1f, 1f);
            warrior.Drops["Ruby"].DropChance = 100f;
            warrior.Drops["Ruby"].DropOnePerPlayer = false;
            warrior.Drops["Ruby"].MultiplyDropByLevel = false;
        }

        public static void WraithWarrior(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefWraithWarrior].BoxedValue) return;


            ItemManager.PrefabManager.RegisterPrefab("dybassets", "WraithWarrior_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_wraithwarrior_attack");
            new Item("dybassets", "wraith_bow").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_scythe_180").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_scythe_360").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_scythe_long").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_shield_attack").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_sword_dualcombo").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_sword_dualdouble").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_sword_left180").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_sword_leftlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_sword_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_sword_rightlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_sword_slash").Configurable = Configurability.Disabled;
            new Item("dybassets", "wraith_taunt").Configurable = Configurability.Disabled;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "WraithWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(739)
                            .SetTemplateName("GenWraithWarrior")
                            .SetPrefabName("WraithWarrior")
                            .SetConditionBiomes((Heightmap.Biome.Swamp))
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "WraithWarrior")
                {
                    Biome = Heightmap.Biome.Swamp,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(1f, 1000f),
                    CheckSpawnInterval = 300,
                    SpawnChance = 70f,
                    SpawnAltitude = 15f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 2,
                    SpecificSpawnTime = SpawnTime.Night,
                    RequiredWeather = Weather.SwampRain
                };
            }

            creature.Drops["TrophyWraith"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyWraith"].DropChance = 5f;
            creature.Drops["TrophyWraith"].DropOnePerPlayer = false;
            creature.Drops["TrophyWraith"].MultiplyDropByLevel = false;
            creature.Drops["Chain"].Amount = new Range(1f, 1f);
            creature.Drops["Chain"].DropChance = 100f;
            creature.Drops["Chain"].DropOnePerPlayer = false;
            creature.Drops["Chain"].MultiplyDropByLevel = true;
        }
    }
}
