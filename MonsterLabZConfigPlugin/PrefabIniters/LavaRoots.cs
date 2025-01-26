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
    internal static class LavaRoots
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            new Creature("dybassets", "ML_LavaRoot")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
                
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_LavaRoot_Ragdoll");
            new Item("dybassets", "lavaroot_attack").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_lavaroot_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_lavaroot_hit");
        }
    }
}
