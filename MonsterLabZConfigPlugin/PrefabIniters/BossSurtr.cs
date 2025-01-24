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
    internal class BossSurtr
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "Surtr")
            {
                Biome = Heightmap.Biome.None
            };
            creature.Drops["TrophySurtr"].Amount = new Range(1f, 1f);
            creature.Drops["TrophySurtr"].DropChance = 100f;
            creature.Drops["TrophySurtr"].DropOnePerPlayer = false;
            creature.Drops["TrophySurtr"].MultiplyDropByLevel = false;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "Surtr_Ragdoll");
            new Item("dybassets", "TrophySurtr").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_attack_jump").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_attack_rage").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_fireblast").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_firewave").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_meteors").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_stomp").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_demon_flamewave_start");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_transform");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_rise");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_meteor_flame_ring");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtr_boss_footsteps");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_meteor_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_fireball_expl");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtr_firesword_impact");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtr_transform_firewave_verticle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_fireball");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_fireskull");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_meteor");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_flamewave");
        }
    }
}
