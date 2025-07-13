using BepInEx.Configuration;
using MonsterLabZConfig.PrefabIniters;

namespace MonsterLabZConfig.Loaders
{
    public static class BossesLoader
    {
        public static void Load(ConfigFile config)
        {
            LoadQuestBosses(config);
            LoadWildBosses(config);
        }

        public static void LoadWildBosses(ConfigFile config)
        {
            BossGolems.init(config);
            BossSurtr.init(config);
            // BossUndeadJarl.init(config);
            BossesShips.init(config);
        }

        public static void LoadQuestBosses(ConfigFile config)
        {
            BossAddAsh.init(config);

            BossBalderNightmareDragon.init(config);
            BossKraken.init(config);
            BossHuldra.init(config);
            BossSpiderFrigga.init(config);
        }
    }
}
