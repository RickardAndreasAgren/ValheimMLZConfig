extern alias MonsterLabZN;
using BepInEx.Configuration;
using MonsterLabZConfig.PrefabIniters;

namespace MonsterLabZConfig.Loaders
{
    internal static class CreaturesLoader
    {
        internal static void Load(ConfigFile config)
        {
            LoadPassive(config);
            LoadUndead(config);
            LoadHumanoids(config);
            LoadMonsters(config);

            Disasters.init(config);
            LavaRoots.init(config);
        }

        private static void LoadPassive(ConfigFile config)
        {
            Butterflies.init(config);
            Jellies.init(config);

            // #No default MonsterLabZ spawns
            Mistiles.init(config);
        }
        private static void LoadUndead(ConfigFile config)
        {
            Ghosts.init(config);
            Skeletons.init(config);

            // #No default MonsterLabZ spawns
            GreydwarfTypes.init(config);
        }
        private static void LoadHumanoids(ConfigFile config)
        {
            DwarfGoblinTypes.init(config);
            Huldra.init(config);
        }
        private static void LoadMonsters(ConfigFile config)
        {
            DeepseaSerpent.init(config);
            Molluscans.init(config);
            SpiderTypes.init(config);

            // #No default MonsterLabZ spawns
            Surtlings.init(config);
            Obsidian.init(config);
        }
    }
}
