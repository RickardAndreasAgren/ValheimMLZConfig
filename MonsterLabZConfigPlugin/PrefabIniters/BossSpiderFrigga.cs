using CreatureManager;
using ItemManager;

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
                Biome = Heightmap.Biome.None,
                CanSpawn = false
            };

            creature.Drops["FriggaHand"].Amount = new Range(1f, 1f);
            creature.Drops["FriggaHand"].DropChance = 100f;
            creature.Drops["FriggaHand"].DropOnePerPlayer = false;
            creature.Drops["FriggaHand"].MultiplyDropByLevel = false;
            new Creature("dybassets", "SpiderBoss_Egg")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false,
                CanSpawn = false
            };
            new Creature("dybassets", "Spider_Hatchling")
            {
                Biome = Heightmap.Biome.None,
                CanSpawn = false
            };
            new Creature("dybassets", "BlackSpider").Biome = Heightmap.Biome.None;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Spider_Boss_Ragdoll");
            new Item("dybassets", "FriggaHand").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_bothattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_comboattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_leftattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_rightattack").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_spit").Configurable = Configurability.Disabled;
            new Item("dybassets", "spiderboss_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "small_spider_attack").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_alerted");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_groundslam");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spiderboss_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spideregg_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_spideregg_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_egg_lay");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_spideregg_hatch");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_SpiderBoss_Egg_Hatch");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "spiderboss_projectile");


            new Item("dybassets", "ML_Sword_Frigga_1").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_1").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_1").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_1");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_1");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_1");
            new Item("dybassets", "ML_Sword_Frigga_2").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_2").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_2").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_2");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_2");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_2");
            new Item("dybassets", "ML_Sword_Frigga_3_Cold").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Cold").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Cold").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Cold");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Cold");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Cold");
            new Item("dybassets", "ML_Sword_Frigga_3_Fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Fire").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Fire");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Fire");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Fire");
            new Item("dybassets", "ML_Sword_Frigga_3_Light").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Light").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Light").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Light");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Light");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Light");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_spawn");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_despawn");
        }
    }
}
