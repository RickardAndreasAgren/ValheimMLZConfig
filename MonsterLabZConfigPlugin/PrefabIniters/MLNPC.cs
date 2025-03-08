using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class MLNPC
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 3) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Female0");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Female1");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Female0_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_attack_secondary");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_female0_taunt");

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male0");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male1");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male2");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male3");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male0_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male1_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male2_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "MLNPC_Male3_Ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_attack_secondary");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_male0_taunt");
        }
    }
}
