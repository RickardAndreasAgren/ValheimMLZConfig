using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossGolems
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            FireGolem(config);
            IceGolem(config);
        }

        private static void FireGolem(BepInEx.Configuration.ConfigFile config)
        {
            
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefFireGolem].BoxedValue == false) return;

            Creature creature;
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue == 1)
            {
                creature = new Creature("dybassets", "FireGolem")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(780)
                            .SetTemplateName("GenFireGolem")
                            .SetPrefabName("FireGolem")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            } else
            {
                creature = new Creature("dybassets", "FireGolem")
                {
                    Biome = Heightmap.Biome.AshLands,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 5f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            
            creature.Drops["Stone"].Amount = new Range(3f, 5f);
            creature.Drops["Stone"].DropChance = 100f;
            creature.Drops["Stone"].DropOnePerPlayer = false;
            creature.Drops["Stone"].MultiplyDropByLevel = true;
            creature.Drops["FlametalOre"].Amount = new Range(2f, 4f);
            creature.Drops["FlametalOre"].DropChance = 100f;
            creature.Drops["FlametalOre"].DropOnePerPlayer = false;
            creature.Drops["FlametalOre"].MultiplyDropByLevel = true;
            new Item("dybassets", "firegolem_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "firegolem_groundslam").Configurable = Configurability.Disabled;
            new Item("dybassets", "firegolem_groundslam_jump").Configurable = Configurability.Disabled;
            new Item("dybassets", "firegolem_kick1").Configurable = Configurability.Disabled;
            new Item("dybassets", "firegolem_melee1").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_fireball_start");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_footstep");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolemrock_destroyed");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_attack_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_firegolem_fire_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_firegolem_spray");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_firegolemrock_destroyed");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "firegolem_projectile");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "firegolem_groundslam_aoe");
        }

        private static void IceGolem(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefIceGolem].BoxedValue == false) return;

            Creature creature;
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue == 1)
            {
                creature = new Creature("dybassets", "IceGolem")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(781)
                        .SetTemplateName("GenIceGolem")
                        .SetPrefabName("IceGolem")
                        .SetConditionBiomes(Heightmap.Biome.DeepNorth)
                        .SetMinLevel(1)
                        .SetMaxLevel(1);
                });
            }
            else
            {
                creature = new Creature("dybassets", "IceGolem")
                {
                    Biome = Heightmap.Biome.DeepNorth,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 5f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            creature.Drops["Crystal"].Amount = new Range(5f, 8f);
            creature.Drops["Crystal"].DropChance = 100f;
            creature.Drops["Crystal"].DropOnePerPlayer = false;
            creature.Drops["Crystal"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "IceGolem_ragdoll");
            new Item("dybassets", "icegolem_groundslam").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_jump_groundslam").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_stomp").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_stomp_combo").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_taunt").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_footstep");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_land");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_icegolem_footstep");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_icegolem_land");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_icegolem_taunt_start");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissure0");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissure1");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissure2");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "spawn_icefissure");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissureExp");
        }
    }
}
