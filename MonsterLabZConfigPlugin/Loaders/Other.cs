extern alias MonsterLabZN;

using Jotunn.Managers;
using MonsterLabZN::MonsterLabZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MonsterLabZConfig.Loaders
{
    internal static class OtherLoader
    {
        public static void Load(BepInEx.Configuration.ConfigFile config)
        {
            ML_CustomProps.init();

            NPC_Items.init();
        }
    }
}
