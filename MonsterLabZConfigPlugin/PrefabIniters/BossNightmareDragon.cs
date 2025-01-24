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
    internal class BossNightmareDragon
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "NightmareDragon")
            {
                Biome = Heightmap.Biome.None
            };
            creature.Drops["TrophyNightmareDragon"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyNightmareDragon"].DropChance = 100f;
            creature.Drops["TrophyNightmareDragon"].DropOnePerPlayer = false;
            creature.Drops["TrophyNightmareDragon"].MultiplyDropByLevel = false;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "NightmareDragonEV");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "NightmareDragon_Ragdoll");
            new Item("dybassets", "TrophyNightmareDragon").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_claw_right").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_horn").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_jump").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_attack_spit").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_tauntev").Configurable = Configurability.Disabled;
            new Item("dybassets", "nightmaredragon_hatchling_call").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_claw");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_horn");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_lightning");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_attack_start");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_nightmaredragon_call");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "dragonlightningAOE");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "dragonlightningAOEEV");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_lightning_attack_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_nightmaredragon_forwardshockwave");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_nightmaredragon_lightning_start");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_nightmaredragon_land");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "nightmaredragon_hatchling_call_trigger");
        }
    }
}
