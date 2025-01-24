using BepInEx.Configuration;
using MonsterLabZConfig.PrefabIniters;

namespace MonsterLabZConfig.Loaders
{
    internal static class BossesLoader
    {
        internal static void Load(BepInEx.Configuration.ConfigFile config)
        {
            LoadQuestBosses(config);
            LoadWildBosses(config);
        }

        private static void LoadWildBosses(ConfigFile config)
        {
            BossGolems.init(config);
            BossSurtr.init(config);
        }

        private static void LoadQuestBosses(ConfigFile config)
        {
            BossAddAsh.init(config);
            BossAddFrigga.init(config);

            BossNightmareDragon.init(config);
            BossKraken.init(config);
            BossHuldra.init(config);
            BossSpiderFrigga.init(config);
        }
    }
}
