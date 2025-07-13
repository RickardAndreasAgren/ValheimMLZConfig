using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Huldra
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefHuldra].BoxedValue) return;

            if ((bool)config[PluginConfig.DefHuldraQueen].BoxedValue == false || (short)config[PluginConfig.DefQuestToggle].BoxedValue == (short)0) HuldraAssets();

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "ML_AshHuldra")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };

                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(740)
                            .SetTemplateName("GenML_AshHuldra")
                            .SetPrefabName("ML_AshHuldra")
                            .SetConditionBiomes(Heightmap.Biome.AshLands)
                            .SetMinLevel(1)
                            .SetMaxLevel(3);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "ML_AshHuldra")
                {
                    Biome = Heightmap.Biome.AshLands,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 500,
                    SpawnChance = 10f,
                    GroupSize = new Range(1f, 3f),
                    Maximum = 3,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }

            creature.Drops["ML_HuldraTail"].Amount = new Range(1f, 1f);
            creature.Drops["ML_HuldraTail"].DropChance = 10f;
            creature.Drops["ML_HuldraTail"].DropOnePerPlayer = false;
            creature.Drops["ML_HuldraTail"].MultiplyDropByLevel = false;
            creature.Drops["Entrails"].Amount = new Range(1f, 1f);
            creature.Drops["Entrails"].DropChance = 100f;
            creature.Drops["Entrails"].DropOnePerPlayer = false;
            creature.Drops["Entrails"].MultiplyDropByLevel = true;            
        }

        public static void HuldraAssets()
        {
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldra_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldraQueen2_Transform");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldraQueen3_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_attack_secondary");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_transform");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubus_transform_return");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_attack_secondary");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_succubusQ_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtling_fireball_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_flame_ring");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_succubus_firewave");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_succubus_transform_firewave");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_demon_return");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_succubusQ_fireball_expl");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "succubus_spawn_projectile");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "succubus_fire_aoe");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "succubusQ_projectile_fireskull");
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
        }
    }
}
