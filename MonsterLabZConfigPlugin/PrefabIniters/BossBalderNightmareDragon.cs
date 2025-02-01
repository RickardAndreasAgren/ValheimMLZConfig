using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossBalderNightmareDragon
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefBalder].BoxedValue == false) return;

            Creature creature = new Creature("dybassets", "NightmareDragon")
            {
                Biome = Heightmap.Biome.None
            };
            creature.Drops["TrophyNightmareDragon"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyNightmareDragon"].DropChance = 100f;
            creature.Drops["TrophyNightmareDragon"].DropOnePerPlayer = false;
            creature.Drops["TrophyNightmareDragon"].MultiplyDropByLevel = false;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "NightmareDragonEV");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "NightmareDragon_Ragdoll");
            new Item("dybassets", "TrophyNightmareDragon").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_claw_right").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_horn").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_jump").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_spit").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_tauntev").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_hatchling_call").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_claw");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_horn");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_lightning");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_start");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_call");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "dragonlightningAOE");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "dragonlightningAOEEV");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_lightning_attack_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_nightmaredragon_forwardshockwave");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_nightmaredragon_lightning_start");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_nightmaredragon_land");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "nightmaredragon_hatchling_call_trigger");
        }
    }
}
