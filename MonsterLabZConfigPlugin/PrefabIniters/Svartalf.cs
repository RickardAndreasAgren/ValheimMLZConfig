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
    internal class Svartalf
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "MLNPC_Svartalfar0")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            creature.Drops["Entrails"].Amount = new Range(1f, 1f);
            creature.Drops["Entrails"].DropChance = 100f;
            creature.Drops["Entrails"].DropOnePerPlayer = false;
            creature.Drops["Entrails"].MultiplyDropByLevel = true;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Svartalfar0_Ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_svartalfar_taunt");
        }
    }
}
