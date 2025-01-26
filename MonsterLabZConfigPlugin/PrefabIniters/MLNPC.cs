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
    internal static class MLNPC
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 3) return;

            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Female0");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Female1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Female0_Ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_attack_secondary");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_taunt");

            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male0");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male2");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male3");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male0_Ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male1_Ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male2_Ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male3_Ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_attack_secondary");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_taunt");
        }
    }
}
