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
    internal class BossAddFrigga
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            new Item("dybassets", "ML_Sword_Frigga_1").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_1").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_1").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_1");
            new Item("dybassets", "ML_Sword_Frigga_2").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_2").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_2").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_2");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_2");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_2");
            new Item("dybassets", "ML_Sword_Frigga_3_Cold").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Cold").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Cold").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Cold");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Cold");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Cold");
            new Item("dybassets", "ML_Sword_Frigga_3_Fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Fire").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Fire");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Fire");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Fire");
            new Item("dybassets", "ML_Sword_Frigga_3_Light").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_L_3_Light").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Sword_Spider_R_3_Light").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spider_3_Light");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_Spawn_3_Light");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Sword_Frigga_SpawnP_3_Light");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_spawn");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_despawn");
        }
    }
}
