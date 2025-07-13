using BepInEx.Configuration;
using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;
using SpawnThat.Spawners.WorldSpawner;
using System;
using static Heightmap;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Skeletons
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            NormalSkeleton(config);
            FireSkeletonAssets(config);
            FireSkeleton(config);
            FireSkeletonNoFx(config);
            IceSkeletonAssets(config);
            IceSkeleton(config);
            IceSkeletonNoFx(config);
            IceSkeletonT6(config);
            PoisonSkeletonAssets(config);
            PoisonSkeleton(config);
            PoisonSkeletonNoFx(config);
            ChaosSkeleton(config);
            ChaosSkeletonNoFx(config);
        }
        private static void NormalSkeleton(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefNormalSkeleton].BoxedValue) return;


            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_mlskeleton_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_mlskeleton_cast");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_mlskeleton_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_skeletonwarrior_tauntburn");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_skeletonwarrior_heal_aoe");
            new Item("dybassets", "attack_taunt_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_left180_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_leftlong_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_right180_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_rightlong_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_slash_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_bow_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_right180_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_rightlong_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_slash_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_right180_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_rightlong_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_secondary_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_left180_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_right180_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_slash_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_shield_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_right180_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_rightlong_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_slash_T1").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_unarmed_T1").Configurable = Configurability.Disabled;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "NormalSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                SpawnSystem.m_instances.RemoveAll(spawn => spawn.gameObject.name == "NormalSkeletonWarrior");

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(712)
                            .SetTemplateName("GenNormalSkeletonWarrior")
                            .SetPrefabName("NormalSkeletonWarrior")
                            .SetConditionBiomes(Heightmap.Biome.BlackForest)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "NormalSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.BlackForest,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    CheckSpawnInterval = 350,
                    SpawnChance = 30f,
                    GroupSize = new Range(1f, 2f),
                    Maximum = 3,
                    SpecificSpawnTime = SpawnTime.Night
                };
            }

            creature.Drops["TrophySkeleton"].Amount = new Range(1f, 1f);
            creature.Drops["TrophySkeleton"].DropChance = 10f;
            creature.Drops["TrophySkeleton"].DropOnePerPlayer = false;
            creature.Drops["TrophySkeleton"].MultiplyDropByLevel = false;
            creature.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature.Drops["BoneFragments"].DropChance = 100f;
            creature.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
        private static void FireSkeleton(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefFireSkeleton].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "FireSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(713)
                            .SetTemplateName("GenFireSkeletonWarrior")
                            .SetPrefabName("FireSkeletonWarrior")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "FireSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }

            creature.ConfigurationEnabled = true;
            creature.Drops["TrophySkeletonFire"].Amount = new Range(1f, 1f);
            creature.Drops["TrophySkeletonFire"].DropChance = 10f;
            creature.Drops["TrophySkeletonFire"].DropOnePerPlayer = false;
            creature.Drops["TrophySkeletonFire"].MultiplyDropByLevel = false;
            creature.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature.Drops["BoneFragments"].DropChance = 100f;
            creature.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature.Drops["BoneFragments"].MultiplyDropByLevel = true;
            
        }
        private static void FireSkeletonNoFx(ConfigFile config)
        {

            if (!(bool)config[PluginConfig.DefFireSkeletonNoFx].BoxedValue) return;
            Creature creature2;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature2 = new Creature("dybassets", "FireSkeletonWarriorNoFx")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(714)
                            .SetTemplateName("GenFireSkeletonWarriorNoFx")
                            .SetPrefabName("FireSkeletonWarriorNoFx")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature2 = new Creature("dybassets", "FireSkeletonWarriorNoFx")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            creature2.ConfigurationEnabled = true;
            creature2.Drops["TrophySkeletonFire"].Amount = new Range(1f, 1f);
            creature2.Drops["TrophySkeletonFire"].DropChance = 10f;
            creature2.Drops["TrophySkeletonFire"].DropOnePerPlayer = false;
            creature2.Drops["TrophySkeletonFire"].MultiplyDropByLevel = false;
            creature2.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature2.Drops["BoneFragments"].DropChance = 100f;
            creature2.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature2.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
        private static void FireSkeletonAssets(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefFireSkeleton].BoxedValue && !(bool)config[PluginConfig.DefFireSkeletonNoFx].BoxedValue) return;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "BurningBonePileSpawner");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "FireSkeletonWarriorNoFx_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_skeleton_death_fire");
            new Item("dybassets", "TrophySkeletonFire").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_shield_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "axe_dualcombo_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "axe_left180_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "axe_left_long_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "axe_right180_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "axe_rightlong_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "axe_slash_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "mace_left180_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "mace_right180_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "mace_secondary_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "mace_slash_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "sword_dualcombo_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "sword_left180_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "sword_leftlong_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "sword_right180_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "sword_rightlong_T5").Configurable = Configurability.Disabled;
            new Item("dybassets", "sword_slash_T5").Configurable = Configurability.Disabled;
        }
        private static void IceSkeleton(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefIceSkeleton].BoxedValue) return;
            Creature creature;

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "IceSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(715)
                            .SetTemplateName("GenIceSkeletonWarrior")
                            .SetPrefabName("IceSkeletonWarrior")
                            .SetConditionBiomes(Heightmap.Biome.Mountain)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "IceSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.Mountain,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    CheckSpawnInterval = 350,
                    SpawnChance = 30f,
                    GroupSize = new Range(2f, 3f),
                    Maximum = 4,
                    SpecificSpawnTime = SpawnTime.Night
                };
            }

            creature.Drops["TrophySkeletonIce"].Amount = new Range(1f, 1f);
            creature.Drops["TrophySkeletonIce"].DropChance = 10f;
            creature.Drops["TrophySkeletonIce"].DropOnePerPlayer = false;
            creature.Drops["TrophySkeletonIce"].MultiplyDropByLevel = false;
            creature.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature.Drops["BoneFragments"].DropChance = 100f;
            creature.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
        private static void IceSkeletonNoFx(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefIceSkeletonNoFx].BoxedValue) return;
            Creature creature2;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature2 = new Creature("dybassets", "IceSkeletonWarriorNoFx")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(716)
                            .SetTemplateName("GenIceSkeletonWarriorNoFx")
                            .SetPrefabName("IceSkeletonWarriorNoFx")
                            .SetConditionBiomes(Heightmap.Biome.Mountain)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature2 = new Creature("dybassets", "IceSkeletonWarriorNoFx")
                {
                    Biome = Heightmap.Biome.Mountain,
                    CanSpawn = false
                };
            }

            creature2.Drops["TrophySkeletonIce"].Amount = new Range(1f, 1f);
            creature2.Drops["TrophySkeletonIce"].DropChance = 10f;
            creature2.Drops["TrophySkeletonIce"].DropOnePerPlayer = false;
            creature2.Drops["TrophySkeletonIce"].MultiplyDropByLevel = false;
            creature2.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature2.Drops["BoneFragments"].DropChance = 100f;
            creature2.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature2.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
        private static void IceSkeletonT6(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefIceSkeletonT6].BoxedValue) return;
            Creature creature3;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature3 = new Creature("dybassets", "IceSkeletonWarriorT6")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(717)
                            .SetTemplateName("GenIceSkeletonWarriorT6")
                            .SetPrefabName("IceSkeletonWarriorT6")
                            .SetConditionBiomes(Heightmap.Biome.DeepNorth)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature3 = new Creature("dybassets", "IceSkeletonWarriorT6")
                {
                    Biome = Heightmap.Biome.DeepNorth,
                    CanSpawn = false
                };
            }
            creature3.Drops["TrophySkeletonIce"].Amount = new Range(1f, 1f);
            creature3.Drops["TrophySkeletonIce"].DropChance = 10f;
            creature3.Drops["TrophySkeletonIce"].DropOnePerPlayer = false;
            creature3.Drops["TrophySkeletonIce"].MultiplyDropByLevel = false;
            creature3.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature3.Drops["BoneFragments"].DropChance = 100f;
            creature3.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature3.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
        private static void IceSkeletonAssets(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefIceSkeletonT6].BoxedValue && !(bool)config[PluginConfig.DefIceSkeleton].BoxedValue && !(bool)config[PluginConfig.DefIceSkeletonNoFx].BoxedValue) return;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_skeleton_death_ice");
            new Item("dybassets", "TrophySkeletonIce").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_atgeir_360_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_atgeir_close_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_atgeir_long_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_dualcombo_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_left180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_leftlong_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_right180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_rightlong_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_slash_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_bow_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_right180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_rightlong_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_slash_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_right180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_rightlong_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_secondary_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_mace_left180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_mace_right180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_mace_secondary_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_mace_slash_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_left180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_right180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_slash_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_shield_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sledge_360_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sledge_left180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sledge_right180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sledge_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_right180_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_rightlong_T3").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_slash_T3").Configurable = Configurability.Disabled;
        }
        private static void PoisonSkeleton(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefPoisonSkeleton].BoxedValue) return;
            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "PoisonSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(717)
                            .SetTemplateName("GenPoisonSkeletonWarrior")
                            .SetPrefabName("PoisonSkeletonWarrior")
                            .SetConditionBiomes(Heightmap.Biome.Swamp)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "PoisonSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.Swamp,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    CheckSpawnInterval = 350,
                    SpawnChance = 30f,
                    GroupSize = new Range(1f, 3f),
                    Maximum = 4,
                    SpecificSpawnTime = SpawnTime.Night
                };
            }
            
            creature.Drops["TrophySkeletonPoison"].Amount = new Range(1f, 1f);
            creature.Drops["TrophySkeletonPoison"].DropChance = 10f;
            creature.Drops["TrophySkeletonPoison"].DropOnePerPlayer = false;
            creature.Drops["TrophySkeletonPoison"].MultiplyDropByLevel = false;
            creature.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature.Drops["BoneFragments"].DropChance = 100f;
            creature.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
        private static void PoisonSkeletonNoFx(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefPoisonSkeleton].BoxedValue) return;
            Creature creature2;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature2 = new Creature("dybassets", "PoisonSkeletonWarriorNoFx")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(718)
                            .SetTemplateName("GenPoisonSkeletonWarriorNoFx")
                            .SetPrefabName("PoisonSkeletonWarriorNoFx")
                            .SetConditionBiomes(Heightmap.Biome.Swamp)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature2 = new Creature("dybassets", "PoisonSkeletonWarriorNoFx")
                {
                    Biome = Heightmap.Biome.Swamp,
                    CanSpawn = false
                };
            }
            creature2.Drops.None();
        }
        private static void PoisonSkeletonAssets(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefPoisonSkeleton].BoxedValue && !(bool)config[PluginConfig.DefPoisonSkeletonNoFx].BoxedValue) return;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_skeleton_death_poison");
            new Item("dybassets", "attack_axe_left180_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_leftlong_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_right180_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_rightlong_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_axe_slash_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_bow_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_right180_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_rightlong_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_club_slash_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_right180_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_rightlong_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_knife_secondary_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_left180_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_right180_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_pickaxe_slash_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_shield_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_right180_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_rightlong_T2").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_sword_slash_T2").Configurable = Configurability.Disabled;
        }
        private static void ChaosSkeleton(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefChaosSkeleton].BoxedValue) return;
            Creature creature;

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "ChaosSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(719)
                            .SetTemplateName("GenChaosSkeletonWarrior")
                            .SetPrefabName("ChaosSkeletonWarrior")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "ChaosSkeletonWarrior")
                {
                    Biome = Heightmap.Biome.AshLands,
                    CanSpawn = false
                };
            }
            creature.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature.Drops["BoneFragments"].DropChance = 100f;
            creature.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
        private static void ChaosSkeletonNoFx(ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefChaosSkeletonNoFx].BoxedValue) return;
            Creature creature2;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature2 = new Creature("dybassets", "ChaosSkeletonWarriorNoFX")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(720)
                            .SetTemplateName("GenChaosSkeletonWarriorNoFX")
                            .SetPrefabName("ChaosSkeletonWarriorNoFX")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature2 = new Creature("dybassets", "ChaosSkeletonWarriorNoFX")
                {
                    Biome = Heightmap.Biome.AshLands,
                    CanSpawn = false
                };
            }
            creature2.Drops["BoneFragments"].Amount = new Range(1f, 1f);
            creature2.Drops["BoneFragments"].DropChance = 100f;
            creature2.Drops["BoneFragments"].DropOnePerPlayer = false;
            creature2.Drops["BoneFragments"].MultiplyDropByLevel = true;
        }
    }
}
