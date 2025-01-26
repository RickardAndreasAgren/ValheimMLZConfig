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
    internal static class BossHuldra
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefHuldraQueen].BoxedValue == false) return;


            new Creature("dybassets", "ML_AshHuldraQueen1").Biome = Heightmap.Biome.None;
            new Creature("dybassets", "ML_AshHuldraQueen2")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            Creature creature2 = new Creature("dybassets", "ML_AshHuldraQueen3")
            {
                Biome = Heightmap.Biome.None
            };
            creature2.ConfigurationEnabled = false;
            creature2.Drops["TrophyAshHuldraQueen"].Amount = new Range(1f, 1f);
            creature2.Drops["TrophyAshHuldraQueen"].DropChance = 100f;
            creature2.Drops["TrophyAshHuldraQueen"].DropOnePerPlayer = false;
            creature2.Drops["TrophyAshHuldraQueen"].MultiplyDropByLevel = false;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldra_Ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldraQueen2_Transform");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldraQueen3_Ragdoll");
            new Item("dybassets", "ML_HuldraTail").Configurable = Configurability.Disabled;
            new Item("dybassets", "TrophyAshHuldraQueen").Configurable = Configurability.Disabled;
            new Item("dybassets", "SuccubusArmorChaos").Configurable = Configurability.Disabled;
            new Item("dybassets", "SuccubusArmorHeavy").Configurable = Configurability.Disabled;
            new Item("dybassets", "SuccubusArmorFire").Configurable = Configurability.Disabled;
            new Item("dybassets", "SuccubusQuiver").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_fireball_left").Configurable = Configurability.Disabled;
            new Item("dybassets", "attack_fireball_right").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_shield").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_sword_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_sword_rightlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_sword_slash").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_atgeir_360").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_atgeir_close").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_atgeir_long").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_bow").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_bow_stab").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_bow_swing").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_axe_dualcombo").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_axe_left180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_axe_leftlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_axe_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_axe_rightlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_axe_slash").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_club_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_club_rightlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_club_slash").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_kick_onehand").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_knife_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_knife_rightlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_knife_secondary").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_mace_left180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_mace_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_mace_secondary").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_mace_slash").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_pickaxe_left180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_pickaxe_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_pickaxe_slash").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sledge").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sledge_360").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sledge_left180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sledge_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sword_dualdouble").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sword_left180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sword_leftlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sword_right180").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sword_rightlong").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_sword_slash").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_sword_fire360").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_sword_fire_aoe").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubus_attack_sword_jump_fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubusQ_attack_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubusQ_fireball_left").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubusQ_fireball_right").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubusQ_firewave").Configurable = Configurability.Disabled;
            new Item("dybassets", "succubusQ_stomp").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_attack_secondary");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_transform");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_transform_return");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_attack_secondary");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtling_fireball_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_flame_ring");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_succubus_firewave");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_succubus_transform_firewave");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_return");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_succubusQ_fireball_expl");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "succubus_spawn_projectile");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "succubus_fire_aoe");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "succubusQ_projectile_fireskull");
        }
    }
}
