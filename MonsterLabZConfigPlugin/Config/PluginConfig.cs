extern alias ServerSyncStandalone;

using BepInEx.Configuration;
using MonsterLabZConfig.PrefabIniters;
using static UnityEngine.EventSystems.EventTrigger;

namespace MonsterLabZConfig
{
    public static class PluginConfig
    {
        public static void BindConfig(ConfigFile config)
        {
            MonsterSpawnDataConfig(config);
            QuestToggleConfig(config);
            WildBossesConfig(config);
            BalderConfig(config);
            FriggaConfig(config);
            HuldraConfig(config);
            KrakenConfig(config);
            SurtrConfig(config);
            IceGolemConfig(config);
            UndeadJarlConfig(config);
            FireGolemConfig(config);
            FulingShipConfig(config);
            DraugrShipConfig(config);
            Mobs(config);
        }

        public static ConfigEntry<short> MonsterSpawnData { get; internal set; }
        public static ConfigDefinition DefMonsterSpawnData { get; internal set; }
        public static ConfigEntry<short> QuestToggle { get; internal set; }
        public static ConfigDefinition DefQuestToggle { get; internal set; }
        public static ConfigEntry<short> WildBosses { get; internal set; }
        public static ConfigDefinition DefWildBosses { get; internal set; }
        public static ConfigEntry<bool> Balder { get; internal set; }
        public static ConfigDefinition DefBalder { get; internal set; }
        public static ConfigEntry<bool> Frigga { get; internal set; }
        public static ConfigDefinition DefFrigga { get; internal set; }
        public static ConfigEntry<bool> HuldraQueen { get; internal set; }
        public static ConfigDefinition DefHuldraQueen { get; internal set; }
        public static ConfigEntry<bool> Kraken { get; internal set; }
        public static ConfigDefinition DefKraken { get; internal set; }
        public static ConfigEntry<bool> Surtr { get; internal set; }
        public static ConfigDefinition DefSurtr { get; internal set; }
        public static ConfigEntry<bool> IceGolem { get; internal set; }
        public static ConfigDefinition DefIceGolem { get; internal set; }
        public static ConfigEntry<bool> FireGolem { get; internal set; }
        public static ConfigDefinition DefFireGolem { get; internal set; }
        public static ConfigDefinition DefBossJarl { get; internal set; }
        public static ConfigEntry<bool> BossJarl { get; internal set; }
        public static ConfigEntry<bool> FulingShip { get; internal set; }
        public static ConfigDefinition DefFulingShip { get; internal set; }
        public static ConfigEntry<bool> DraugrShip { get; internal set; }
        public static ConfigDefinition DefDraugrShip { get; internal set; }
        public static ConfigDefinition DefDisasters { get; internal set; }
        public static ConfigEntry<bool> Disasters { get; internal set; }
        public static ConfigDefinition DefButterflies { get; internal set; }
        public static ConfigEntry<bool> Butterflies { get; internal set; }
        public static ConfigDefinition DefDeepSeaSerpent { get; internal set; }
        public static ConfigEntry<bool> DeepSeaSerpent { get; internal set; }
        public static ConfigDefinition DefDwarfGoblin { get; internal set; }
        public static ConfigEntry<bool> DwarfGoblin { get; internal set; }
        public static ConfigDefinition DefDwarfGoblinLoot { get; internal set; }
        public static ConfigEntry<bool> DwarfGoblinLoot { get; internal set; }
        public static ConfigDefinition DefDwarfGoblinShaman { get; internal set; }
        public static ConfigEntry<bool> DwarfGoblinShaman { get; internal set; }
        public static ConfigDefinition DefDwarfGoblinRider { get; internal set; }
        public static ConfigEntry<bool> DwarfGoblinRider { get; internal set; }
        public static ConfigDefinition DefGhostWarrior { get; internal set; }
        public static ConfigEntry<bool> GhostWarrior { get; internal set; }
        public static ConfigDefinition DefWraithWarrior { get; internal set; }
        public static ConfigEntry<bool> WraithWarrior { get; internal set; }
        public static ConfigDefinition DefHuldra { get; internal set; }
        public static ConfigEntry<bool> Huldra { get; internal set; }
        public static ConfigDefinition DefJellyfish { get; internal set; }
        public static ConfigEntry<bool> Jellyfish { get; internal set; }
        public static ConfigDefinition DefMistileRedAggro { get; internal set; }
        public static ConfigEntry<bool> MistileRedAggro { get; internal set; }
        public static ConfigDefinition DefMistileRedPassive { get; internal set; }
        public static ConfigEntry<bool> MistileRedPassive { get; internal set; }
        public static ConfigDefinition DefMistileBlueAggro { get; internal set; }
        public static ConfigEntry<bool> MistileBlueAggro { get; internal set; }
        public static ConfigDefinition DefMistileBluePassive { get; internal set; }
        public static ConfigEntry<bool> MistileBluePassive { get; internal set; }
        public static ConfigDefinition DefMolluscan { get; internal set; }
        public static ConfigEntry<bool> Molluscan { get; internal set; }
        public static ConfigDefinition DefDeepMolluscan { get; internal set; }
        public static ConfigEntry<bool> DeepMolluscan { get; internal set; }
        public static ConfigDefinition DefObsidianGolem { get; internal set; }
        public static ConfigEntry<bool> ObsidianGolem { get; internal set; }
        public static ConfigDefinition DefNormalSkeleton { get; internal set; }
        public static ConfigEntry<bool> NormalSkeleton { get; internal set; }
        public static ConfigDefinition DefFireSkeleton { get; internal set; }
        public static ConfigEntry<bool> FireSkeleton { get; internal set; }
        public static ConfigDefinition DefPoisonSkeleton { get; internal set; }
        public static ConfigEntry<bool> PoisonSkeleton { get; internal set; }
        public static ConfigDefinition DefIceSkeleton { get; internal set; }
        public static ConfigEntry<bool> IceSkeleton { get; internal set; }
        public static ConfigDefinition DefChaosSkeleton { get; internal set; }
        public static ConfigEntry<bool> ChaosSkeleton { get; internal set; }
        public static ConfigDefinition DefTreeSpider { get; internal set; }
        public static ConfigEntry<bool> TreeSpider { get; internal set; }
        public static ConfigDefinition DefGreenSpider { get; internal set; }
        public static ConfigEntry<bool> GreenSpider { get; internal set; }
        public static ConfigDefinition DefFrostSpider { get; internal set; }
        public static ConfigEntry<bool> FrostSpider { get; internal set; }
        public static ConfigDefinition DefFrigidSpider { get; internal set; }
        public static ConfigEntry<bool> FrigidSpider { get; internal set; }
        public static ConfigDefinition DefForestSpider { get; internal set; }
        public static ConfigEntry<bool> ForestSpider { get; internal set; }
        public static ConfigDefinition DefBrownSpider { get; internal set; }
        public static ConfigEntry<bool> BrownSpider { get; internal set; }
        public static ConfigDefinition DefTanSpider { get; internal set; }
        public static ConfigEntry<bool> TanSpider { get; internal set; }
        public static ConfigDefinition DefTrollGiant { get; internal set; }
        public static ConfigEntry<bool> TrollGiant { get; internal set; }

        public static void MonsterSpawnDataConfig(ConfigFile config)
        {
            (DefMonsterSpawnData, MonsterSpawnData)  = new ConfigData<short>("1 - General", "Monster Spawn Data", true)
            .Describe("Handling of default spawn data. Does not apply to bosses.\r\n" +
                "(0): Defaults. Use MonsterLabZ spawns.\r\n" +
                "1: Remove default spawndata.\r\n" +
                "2: 1 and generate SpawnThat entries for all \r\n", new AcceptableValueList<short>(0, 1, 2), "MLZ", "Monster", "Spawn")
            .Bind(config, (short)0);
        }
        public static void QuestToggleConfig(ConfigFile config)
        {
            (DefQuestToggle, QuestToggle) = new ConfigData<short>("2 - Bosses", "MLZQuest", true)
            .Describe("Enable the boss hunt quest of MLZ, generating their locations and the mystical well.\r\n" +
                "0: Disabled. No quest bosses.\r\n" +
                "1: Bosses and add prefabs loaded. No locations or spawns generated (This is for those heavy modders)\r\n" +
                "2: Bosses active with their MLZ locations. Quest well is disabled. \r\n" +
                "(3): MLZ Quest is on. Well spawns and bosses are active\r\n", new AcceptableValueList<short>(0,1,2,3), "MLZ", "Quest", "Boss")
            .Bind(config, (short)3);
        }
        public static void WildBossesConfig(ConfigFile config)
        {
            (DefWildBosses, WildBosses) = new ConfigData<short>("2 - Bosses", "WildBosses", true)
            .Describe("Setting for wild bosses. \r\n" +
                "0: Disabled. No Wild bosses.\r\n" +
                "1: Bosses and add prefabs loaded. No locations or spawns generated (This is for those heavy modders)\r\n" +
                "(2): Bosses active with their MLZ locations. \r\n", new AcceptableValueList<short>(0, 1, 2), "MLZ", "Quest", "Boss")
            .Bind(config, (short)2);
        }
        public static void BalderConfig(ConfigFile config)
        {
            (DefBalder, Balder) = new ConfigData<bool>("2 - Bosses", "Balder", true)
            .Describe("If MLZQuest is set to 1, this can be used. Balder settings. \r\n" +
                "false: Disable Balder.\r\n" +
                "(true): Enable Balder.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void FriggaConfig(ConfigFile config)
        {
            (DefFrigga, Frigga) = new ConfigData<bool>("2 - Bosses", "Frigga", true)
            .Describe("If MLZQuest is set to 1, this can be used. Frigga settings. \r\n" +
                "false: Disable Frigga.\r\n" +
                "(true): Enable Frigga.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void KrakenConfig(ConfigFile config)
        {
            (DefKraken, Kraken) = new ConfigData<bool>("2 - Bosses", "Kraken", true)
            .Describe("If MLZQuest is set to 1, this can be used. Kraken settings. \r\n" +
                "false: Disable Kraken.\r\n" +
                "(true): Enable Kraken.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void HuldraConfig(ConfigFile config)
        {
            (DefHuldraQueen, HuldraQueen) = new ConfigData<bool>("2 - Bosses", "HuldraQueen", true)
            .Describe("If MLZQuest is set to 1, this can be used. Huldra settings. \r\n" +
                "false: Disable Huldra.\r\n" +
                "(true): Enable Huldra.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void SurtrConfig(ConfigFile config)
        {
            (DefSurtr, Surtr) = new ConfigData<bool>("2 - Bosses", "Surtr", true)
            .Describe("If WildBosses is set to 1, this can be used. Surtr settings. \r\n" +
                "false: Disable Surtr.\r\n" +
                "(true): Enable Surtr.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void IceGolemConfig(ConfigFile config)
        {
            (DefIceGolem, IceGolem) = new ConfigData<bool>("2 - Bosses", "Ice Golem", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "false: Disable IceGolem.\r\n" +
                "(true): Enable IceGolem.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void UndeadJarlConfig(ConfigFile config)
        {
            (DefBossJarl, BossJarl) = new ConfigData<bool>("2 - Bosses", "Undead Jarl", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "false: Disable Undead Jarl.\r\n" +
                "(true): Enable Undead Jarl.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void FireGolemConfig(ConfigFile config)
        {
            (DefFireGolem, FireGolem) = new ConfigData<bool>("2 - Bosses", "Fire Golem", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "false: Disable FireGolem.\r\n" +
                "(true): Enable FireGolem.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void DraugrShipConfig(ConfigFile config)
        {
            (DefDraugrShip, DraugrShip) = new ConfigData<bool>("2 - Bosses", "Draugr Ship", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "false: Disable DraugrShip.\r\n" +
                "(true): Enable DraugrShip.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void FulingShipConfig(ConfigFile config)
        {
            (DefFulingShip, FulingShip) = new ConfigData<bool>("2 - Bosses", "Fuling Ship", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "false: Disable FulingShip.\r\n" +
                "(true): Enable FulingShip.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void Mobs(ConfigFile config)
        {
            (DefDisasters, Disasters) = MobConfig("Disasters", config);
            (DefButterflies, Butterflies) = MobConfig("Butterflies", config);
            (DefDeepSeaSerpent, DeepSeaSerpent) = MobConfig("DeepSeaSerpent", config);
            (DefDwarfGoblin, DwarfGoblin) = MobConfig("DwarfGoblin", config);
            (DefDwarfGoblinLoot, DwarfGoblinLoot) = MobConfig("DwarfGoblinLoot", config);
            (DefDwarfGoblinShaman, DwarfGoblinShaman) = MobConfig("DwarfGoblinShaman", config);
            (DefDwarfGoblinRider, DwarfGoblinRider) = MobConfig("DwarfGoblinRider", config);
            (DefGhostWarrior, GhostWarrior) = MobConfig("GhostWarrior", config);
            (DefWraithWarrior, WraithWarrior) = MobConfig("WraithWarrior", config);
            (DefHuldra, Huldra) = MobConfig("Huldra", config);
            (DefJellyfish, Jellyfish) = MobConfig("Jellyfish", config);
            (DefMistileRedAggro, MistileRedAggro) = MobConfig("MistileRedAggro", config);
            (DefMistileRedPassive, MistileRedPassive) = MobConfig("MistileRedPassive", config);
            (DefMistileBlueAggro, MistileBlueAggro) = MobConfig("MistileBlueAggro", config);
            (DefMistileBluePassive, MistileBluePassive) = MobConfig("MistileBluePassive", config);
            (DefMolluscan, Molluscan) = MobConfig("Molluscan", config);
            (DefDeepMolluscan, DeepMolluscan) = MobConfig("DeepMolluscan", config);
            (DefObsidianGolem, ObsidianGolem) = MobConfig("ObsidianGolem", config);
            (DefNormalSkeleton, NormalSkeleton) = MobConfig("NormalSkeleton", config);
            (DefIceSkeleton, IceSkeleton) = MobConfig("IceSkeleton", config);
            (DefFireSkeleton, FireSkeleton) = MobConfig("FireSkeleton", config);
            (DefPoisonSkeleton, PoisonSkeleton) = MobConfig("PoisonSkeleton", config);
            (DefChaosSkeleton, ChaosSkeleton) = MobConfig("ChaosSkeleton", config);
            (DefTreeSpider, TreeSpider) = MobConfig("TreeSpider", config);
            (DefGreenSpider, GreenSpider) = MobConfig("GreenSpider", config);
            (DefFrostSpider, FrostSpider) = MobConfig("FrostSpider", config);
            (DefFrigidSpider, FrigidSpider) = MobConfig("FrigidSpider", config);
            (DefForestSpider, ForestSpider) = MobConfig("ForestSpider", config);
            (DefBrownSpider, BrownSpider) = MobConfig("BrownSpider", config);
            (DefTanSpider, TanSpider) = MobConfig("TanSpider", config);
            (DefTrollGiant, TrollGiant) = MobConfig("TrollGiant", config);
        }
        public static (ConfigDefinition, ConfigEntry<bool>) MobConfig(string name, ConfigFile config)
        {
            return new ConfigData<bool>("3 - Monsters", $"{name}", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                $"false: Disable {name}.\r\n" +
                $"(true): Enable {name}.\r\n", null, "MLZ", "Monster", "Creature")
            .Bind(config, true);
        }
    }
}