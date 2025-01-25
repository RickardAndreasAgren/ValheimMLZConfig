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
    internal class TrollGiant
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "TrollGiant")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "TrollGiant_Ragdoll");
            new Item("dybassets", "trollgiant_slam").Configurable = Configurability.Disabled;
            new Item("dybassets", "trollgiant_stomp").Configurable = Configurability.Disabled;
        }
    }
}
