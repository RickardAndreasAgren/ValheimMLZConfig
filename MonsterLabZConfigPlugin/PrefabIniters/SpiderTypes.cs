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
    internal class SpiderTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "BrownSpider")
            {
                Biome = Heightmap.Biome.None
            };
            creature.ConfigurationEnabled = false;
            creature.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature.Drops["SpiderFang"].DropChance = 10f;
            creature.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature.Drops["Ooze"].Amount = new Range(2f, 3f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = true;
            new Creature("dybassets", "BrownSpider_Spawn")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "ForestSpider")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "FrigidSpider")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "FrostSpider")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            Creature creature2 = new Creature("dybassets", "GreenSpider")
            {
                Biome = Heightmap.Biome.Meadows,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                CheckSpawnInterval = 600,
                ForestSpawn = Forest.No,
                SpawnChance = 15f,
                GroupSize = new Range(1f, 1f),
                Maximum = 2,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature2.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature2.Drops["SpiderFang"].DropChance = 10f;
            creature2.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature2.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature2.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature2.Drops["Ooze"].DropChance = 100f;
            creature2.Drops["Ooze"].DropOnePerPlayer = false;
            creature2.Drops["Ooze"].MultiplyDropByLevel = true;
            new Creature("dybassets", "TanSpider")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            Creature creature3 = new Creature("dybassets", "TreeSpider")
            {
                Biome = Heightmap.Biome.Meadows,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Center,
                SpawnAltitude = 10f,
                CheckSpawnInterval = 600,
                ForestSpawn = Forest.Yes,
                SpawnChance = 10f,
                GroupSize = new Range(1f, 1f),
                Maximum = 3,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature3.Drops["SpiderFang"].Amount = new Range(1f, 1f);
            creature3.Drops["SpiderFang"].DropChance = 10f;
            creature3.Drops["SpiderFang"].DropOnePerPlayer = false;
            creature3.Drops["SpiderFang"].MultiplyDropByLevel = false;
            creature3.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature3.Drops["Ooze"].DropChance = 100f;
            creature3.Drops["Ooze"].DropOnePerPlayer = false;
            creature3.Drops["Ooze"].MultiplyDropByLevel = true;
            new Creature("dybassets", "TreeSpider_Spawn")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "BrownSpider_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ForestSpider_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "FrigidSpider_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "FrostSpider_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "GreenSpider_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "TanSpider_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "TreeSpider_ragdoll");
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
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_footstep_spider");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_alerted");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spider_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_jumpingspider_spit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_web_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_spider_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_spider_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "swoop_trail");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_jumpingspider_spit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "jumpingspider_poison_aoe");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "web_projectile");
        }
    }
}
