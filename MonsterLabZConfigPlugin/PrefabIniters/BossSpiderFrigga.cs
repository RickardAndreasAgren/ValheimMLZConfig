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
    internal static class BossSpiderFrigga
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefFrigga].BoxedValue == false) return;

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
                Biome = Heightmap.Biome.None
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


            new Item("dybassets", "ML_Sword_Frigga_1").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_1").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_1").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_1");
            new Item("dybassets", "ML_Sword_Frigga_2").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_2").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_2").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_2");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_2");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_2");
            new Item("dybassets", "ML_Sword_Frigga_3_Cold").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Cold").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Cold").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Cold");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Cold");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Cold");
            new Item("dybassets", "ML_Sword_Frigga_3_Fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Fire").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Fire");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Fire");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Fire");
            new Item("dybassets", "ML_Sword_Frigga_3_Light").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Light").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Light").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Light");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Light");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Light");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_spawn");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_despawn");
        }
    }
}
