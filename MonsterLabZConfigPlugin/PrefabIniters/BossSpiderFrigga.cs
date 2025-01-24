extern alias MonsterLabZN;

using Jotunn.Managers;
using MonsterLabZN::CreatureManager;
using MonsterLabZN::ItemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLabZConfig.PrefabIniters
{
    internal class BossSpiderFrigga
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "Spider_Boss")
            {
                Biome = Heightmap.Biome.None
            };
            creature.Drops["FriggaHand"].Amount = new Range(1f, 1f);
            creature.Drops["FriggaHand"].DropChance = 100f;
            creature.Drops["FriggaHand"].DropOnePerPlayer = false;
            creature.Drops["FriggaHand"].MultiplyDropByLevel = false;
            new Creature("dybassets", "SpiderBoss_Egg")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "Spider_Hatchling")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "BlackSpider").Biome = Heightmap.Biome.None;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "Spider_Boss_Ragdoll");
            new Item("dybassets", "FriggaHand").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_bothattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_comboattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_leftattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_rightattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_spit").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "small_spider_attack").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_alerted");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_groundslam");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spideregg_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spideregg_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_egg_lay");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_spideregg_hatch");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_SpiderBoss_Egg_Hatch");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "spiderboss_projectile");
        }
    }
}
