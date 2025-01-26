extern alias MonsterLabZN;

using MonsterLabZConfig.PrefabIniters;
using MonsterLabZN::MonsterLabZ;

namespace MonsterLabZConfig.Loaders
{
    internal static class OtherLoader
    {
        public static void Load(BepInEx.Configuration.ConfigFile config)
        {
            // MonsterLabZN::CreatureManager.Creature;
            ML_CustomProps.init();

            NPC_Items.init();

            Svartalf.init(config);
            MLNPC.init(config);
            Surtlings.init(config);
            Shadow.init(config);
        }
    }
}
