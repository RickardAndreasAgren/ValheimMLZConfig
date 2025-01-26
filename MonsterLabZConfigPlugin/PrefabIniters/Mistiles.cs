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
    internal static class Mistiles
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((bool)config[PluginConfig.DefMistileRedAggro].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_RedMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_RedMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
            }
            if ((bool)config[PluginConfig.DefMistileRedPassive].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_RedMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_RedMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
            }
            if ((bool)config[PluginConfig.DefMistileBlueAggro].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_BlueMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_BlueMistile_Aggressive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
            }
            if ((bool)config[PluginConfig.DefMistileBluePassive].BoxedValue)
            {
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
                {
                    new Creature("dybassets", "ML_BlueMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
                else
                {
                    new Creature("dybassets", "ML_BlueMistile_Passive")
                    {
                        Biome = Heightmap.Biome.None
                    };
                }
            }

            if ((bool)config[PluginConfig.DefMistileBluePassive].BoxedValue || (bool)config[PluginConfig.DefMistileBlueAggro].BoxedValue)
            {
                new Item("dybassets", "ML_BlueMistile_kamikaze").Configurable = Configurability.Disabled;
                MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_BlueMistile_attack");
                MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_BlueMistile_die");
            }
            if ((bool)config[PluginConfig.DefMistileRedPassive].BoxedValue || (bool)config[PluginConfig.DefMistileRedAggro].BoxedValue)
            {
                new Item("dybassets", "ML_RedMistile_kamikaze").Configurable = Configurability.Disabled;
                MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_RedMistile_attack");
                MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "fx_ML_RedMistile_die");
            }
        }
    }
}
