extern alias ServerSyncStandalone;

using BepInEx.Configuration;

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
            FireGolemConfig(config);
            FulingShipConfig(config);
            DraugrShipConfig(config);
        }

        public static ConfigEntry<short> MonsterSpawnData { get; set; }
        public static ConfigDefinition DefMonsterSpawnData { get; set; }
        public static ConfigEntry<short> QuestToggle { get; set; }
        public static ConfigDefinition DefQuestToggle { get; set; }
        public static ConfigEntry<short> WildBosses { get; set; }
        public static ConfigDefinition DefWildBosses { get; set; }
        public static ConfigEntry<bool> Balder { get; set; }
        public static ConfigDefinition DefBalder { get; set; }
        public static ConfigEntry<bool> Frigga { get; set; }
        public static ConfigDefinition DefFrigga { get; set; }
        public static ConfigEntry<bool> HuldraQueen { get; set; }
        public static ConfigDefinition DefHuldraQueen { get; set; }
        public static ConfigEntry<bool> Kraken { get; set; }
        public static ConfigDefinition DefKraken { get; set; }
        public static ConfigEntry<bool> Surtr { get; set; }
        public static ConfigDefinition DefSurtr { get; set; }
        public static ConfigEntry<bool> IceGolem { get; set; }
        public static ConfigDefinition DefIceGolem { get; set; }
        public static ConfigEntry<bool> FireGolem { get; set; }
        public static ConfigDefinition DefFireGolem { get; set; }
        public static ConfigEntry<bool> FulingShip { get; set; }
        public static ConfigDefinition DefFulingShip { get; set; }
        public static ConfigEntry<bool> DraugrShip { get; set; }
        public static ConfigDefinition DefDraugrShip { get; set; }
        public static void MonsterSpawnDataConfig(ConfigFile config)
        {
            (DefMonsterSpawnData, MonsterSpawnData)  = new ConfigData<short>("1 - General", "Monster Spawn Data", true)
            .Describe("Handling of default spawn data. Does not apply to bosses.\r\n" +
                "(0): Defaults. Use MonsterLabZ spawns.\r\n" +
                "1: Remove default spawndata.\r\n" +
                "2: Generate SpawnThat entries for all \r\n", new AcceptableValueList<short>(0, 1, 2), "MLZ", "Monster", "Spawn")
            .Bind(config, (short)3);
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
                "0: Disable Balder.\r\n" +
                "(1): Enable Balder.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void FriggaConfig(ConfigFile config)
        {
            (DefFrigga, Frigga) = new ConfigData<bool>("2 - Bosses", "Frigga", true)
            .Describe("If MLZQuest is set to 1, this can be used. Frigga settings. \r\n" +
                "0: Disable Frigga.\r\n" +
                "(1): Enable Frigga.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void KrakenConfig(ConfigFile config)
        {
            (DefKraken, Kraken) = new ConfigData<bool>("2 - Bosses", "Kraken", true)
            .Describe("If MLZQuest is set to 1, this can be used. Kraken settings. \r\n" +
                "0: Disable Kraken.\r\n" +
                "(1): Enable Kraken.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void HuldraConfig(ConfigFile config)
        {
            (DefHuldraQueen, HuldraQueen) = new ConfigData<bool>("2 - Bosses", "HuldraQueen", true)
            .Describe("If MLZQuest is set to 1, this can be used. Huldra settings. \r\n" +
                "0: Disable Huldra.\r\n" +
                "(1): Enable Huldra.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void SurtrConfig(ConfigFile config)
        {
            (DefSurtr, Surtr) = new ConfigData<bool>("2 - Bosses", "Surtr", true)
            .Describe("If WildBosses is set to 1, this can be used. Surtr settings. \r\n" +
                "0: Disable Surtr.\r\n" +
                "(1): Enable Surtr.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void IceGolemConfig(ConfigFile config)
        {
            (DefIceGolem, IceGolem) = new ConfigData<bool>("2 - Bosses", "Ice Golem", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "0: Disable IceGolem.\r\n" +
                "(1): Enable IceGolem.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void FireGolemConfig(ConfigFile config)
        {
            (DefFireGolem, FireGolem) = new ConfigData<bool>("2 - Bosses", "Fire Golem", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "0: Disable FireGolem.\r\n" +
                "(1): Enable FireGolem.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void DraugrShipConfig(ConfigFile config)
        {
            (DefDraugrShip, DraugrShip) = new ConfigData<bool>("2 - Bosses", "Draugr Ship", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "0: Disable DraugrShip.\r\n" +
                "(1): Enable DraugrShip.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }
        public static void FulingShipConfig(ConfigFile config)
        {
            (DefFulingShip, FulingShip) = new ConfigData<bool>("2 - Bosses", "Fuling Ship", true)
            .Describe("If WildBosses is set to 1, this can be used. Allows specific disablers. \r\n" +
                "0: Disable FulingShip.\r\n" +
                "(1): Enable FulingShip.\r\n", null, "MLZ", "Boss")
            .Bind(config, true);
        }



        //each enemy (Arg remove default spawndata, Arg SpawnThat)
        //each enemy not default (Arg remove default spawndata, Arg SpawnThat)
    }
}