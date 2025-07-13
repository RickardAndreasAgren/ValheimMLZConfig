using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossSurtr
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefSurtr].BoxedValue == false) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Surtr_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_demon_flamewave_start");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtr_transform");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_rise");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_meteor_flame_ring");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtr_boss_footsteps");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_meteor_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_fireball_expl");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtr_firesword_impact");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtr_transform_firewave_verticle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_fireball");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_fireskull");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_meteor");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "demon_projectile_flamewave");
            new Item("dybassets", "TrophySurtr").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_attack_jump").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_attack_rage").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_fireblast").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_firewave").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_meteors").Configurable = Configurability.Disabled;
            new Item("dybassets", "surtr_stomp").Configurable = Configurability.Disabled;

            Creature creature;
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue == 1)
            {
                creature = new Creature("dybassets", "Surtr")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            else
            {
                creature = new Creature("dybassets", "Surtr")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }

            creature.Drops["TrophySurtr"].Amount = new Range(1f, 1f);
            creature.Drops["TrophySurtr"].DropChance = 100f;
            creature.Drops["TrophySurtr"].DropOnePerPlayer = false;
            creature.Drops["TrophySurtr"].MultiplyDropByLevel = false;
        }
    }
}
