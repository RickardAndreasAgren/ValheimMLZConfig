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
    internal class Mistiles
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            new Creature("dybassets", "ML_RedMistile_Aggressive")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "ML_BlueMistile_Aggressive")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "ML_RedMistile_Passive")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Creature("dybassets", "ML_BlueMistile_Passive")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            new Item("dybassets", "ML_RedMistile_kamikaze").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_BlueMistile_kamikaze").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_RedMistile_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_RedMistile_die");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_BlueMistile_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_BlueMistile_die");
        }
    }
}
