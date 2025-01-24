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
    internal class Surtlings
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "Surtling_Spawn")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            Creature creature2 = new Creature("dybassets", "ML_Surtling")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Item("dybassets", "ml_surtling_attack_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "ml_surtling_attack_claw").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_alerted");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_surtling_spawn_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_surtling_spawn_death");
        }
    }
}
