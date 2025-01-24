extern alias ServerSyncStandalone;

using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using MonsterLabZConfig.Extensions;
using ServerSyncStandalone::ServerSync;
using System.IO;

namespace MonsterLabZConfig
{
    public static class PluginConfig
    {
        public static void BindConfig(ConfigFile config)
        {
            QuestToggleConfig(config);
        }
        public static ConfigEntry<bool> QuestToggle { get; private set; }
        public static ConfigEntry<bool> StandaloneBosses { get; private set; }
        public static void QuestToggleConfig(ConfigFile config)
        {
            QuestToggle = new ConfigData<bool>("1 - General", "MLZQuest", true)
            .Describe("Enable the boss hunt quest of MLZ, generating their locations and the mystical well.", null, "MLZ", "Quest", "Boss")
            .Bind(config, true);
        }
        public static ConfigEntry<bool> fla { get; private set; }

        //remove default spawndata creatures (does not affect bosses)

        //generate SpawnThat replacement

        //ÍF NO QUEST: NO WELL
        //make quest bosses 'standalone': remove quest drops
        //disable Balder (includes altar location)
        //  remove default spawndata
        //disable Frigga (includes altar location)
        //  remove default spawndata
        //disable Kraken (includes altar location)
        //  remove default spawndata
        //disable Ash Huldra (includes altar location)
        //  remove default spawndata
        //disable Surtr (includes altar location)
        //  remove default spawndata
        //ENDIF

        //bosses (Arg SpawnThat)
        //  Ice Golem
        //  Fire Golem
        //  DraugrShip (includes location)
        //  Fuling Ship (includes location)

        //dungeons (Arg remove default spawndata, Arg SpawnThat, Arg disabled bosses settings)
        //SpiderCave
        //AshlandsCave01
        //AshlandsCave02

        //each enemy (Arg remove default spawndata, Arg SpawnThat)
        //each enemy not default (Arg remove default spawndata, Arg SpawnThat)



        /*
        public static ConfigEntry<Color> EnemyHudNameTextColor { get; private set; }

        public static void BindEnemyHudConfig(ConfigFile config)
        {
            EnemyHudNameTextColor =
                config.BindInOrder(
                    "EnemyHud.Name",
                    "nameTextColor",
                    Color.white,
                    "EnemyHud.Name text color (vanilla: white).");
        }

        public static ConfigEntry<bool> EnemyLevelUseVanillaStar { get; private set; }
        public static ConfigEntry<string> EnemyLevelStarSymbol { get; private set; }
        public static ConfigEntry<int> EnemyLevelStarCutoff { get; private set; }

        public static void BindEnemyLevelConfig(ConfigFile config)
        {

            EnemyLevelUseVanillaStar =
                config.BindInOrder(
                    "EnemyLevel",
                    "enemyLevelUseVanillaStar",
                    false,
                    "If true, uses the vanilla 'star' image for 1* and 2* monsters.");

            EnemyLevelStarSymbol =
                config.BindInOrder(
                    "EnemyLevel",
                    "enemyLevelStarSymbol",
                    "\u2605",
                    "Symbol to use for 'star' for enemy levels above vanilla 2*.",
                    new AcceptableValueList<string>("\u2605", "\u2606", "\u2734", "\u2733", "\u2756", "\u2716"));

            EnemyLevelStarCutoff =
                config.BindInOrder(
                    "EnemyLevel",
                    "enemyLevelStarCutoff",
                    2,
                    "When showing enemy levels using stars, max stars to show before switching to 'X\u2605' format.",
                    new AcceptableValueRange<int>(0, 10));
        }*/
    }
}