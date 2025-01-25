extern alias MonsterLabZN;

using MonsterLabZN::CreatureManager;
using MonsterLabZN::ItemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLabZConfig.PrefabIniters
{
    internal class BossGolems
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
                    Biome = Heightmap.Biome.AshLands
                };
            } else
            {
                creature = new Creature("dybassets", "FireGolem")
                {
                    Biome = Heightmap.Biome.AshLands,
                    SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
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
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_fireball_start");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_footstep");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolemrock_destroyed");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_firegolem_attack_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_firegolem_fire_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_firegolem_spray");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_firegolemrock_destroyed");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "firegolem_projectile");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "firegolem_groundslam_aoe");
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
                    Biome = Heightmap.Biome.DeepNorth
                };
            }
            else
            {
                creature = new Creature("dybassets", "IceGolem")
                {
                    Biome = Heightmap.Biome.DeepNorth,
                    SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
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
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "IceGolem_ragdoll");
            new Item("dybassets", "icegolem_groundslam").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_jump_groundslam").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_stomp").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_stomp_combo").Configurable = Configurability.Disabled;
            new Item("dybassets", "icegolem_taunt").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_footstep");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_land");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_icegolem_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_icegolem_footstep");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_icegolem_land");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_icegolem_taunt_start");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissure0");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissure1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissure2");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "spawn_icefissure");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceFissureExp");
        }
    }
}
