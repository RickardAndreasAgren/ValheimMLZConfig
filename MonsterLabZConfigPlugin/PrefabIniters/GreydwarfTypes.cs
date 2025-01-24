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
    internal class GreydwarfTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple_Shroom");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple_ragdoll");
        }
    }
}
