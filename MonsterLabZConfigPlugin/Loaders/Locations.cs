extern alias MonsterLabZN;

using MonsterLabZN::LocationManager;
using MonsterLabZN::MonsterLabZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLabZConfig.Loaders
{
    internal static class LocationsLoader
    {
        public static short questSetting { get; set; }
        public static short wildSetting { get; set; }
        internal static void Load(BepInEx.Configuration.ConfigFile config)
        {
            questSetting = (short)config[PluginConfig.DefQuestToggle].BoxedValue;
            wildSetting = (short)config[PluginConfig.DefWildBosses].BoxedValue;
            LoadL(config);
            LoadO(config);
        }

        internal static void LoadL(BepInEx.Configuration.ConfigFile config)
        {
            if ((bool)config[PluginConfig.DefHuldraQueen].BoxedValue == true && questSetting > 1)
            {
                new MonsterLabZN::LocationManager.Location("dybassets", "AshHuldraQueen_Altar")
                {
                    Prioritize = true,
                    MapIcon = "bossicon.png",
                    ShowMapIcon = ShowIcon.Never,
                    Biome = Heightmap.Biome.AshLands,
                    SpawnArea = Heightmap.BiomeArea.Median,
                    SpawnDistance = new Range(50f, 10000f),
                    SpawnAltitude = new Range(5f, 1000f),
                    MinimumDistanceFromGroup = 2000f,
                    Count = 1,
                    Unique = false
                };
            }
            if (questSetting > 1)
            {
                new MonsterLabZN::LocationManager.Location("dybassets", "AshlandsCave_01")
                {
                    Prioritize = true,
                    MapIcon = "bossicon.png",
                    ShowMapIcon = ShowIcon.Never,
                    Biome = Heightmap.Biome.AshLands,
                    SpawnDistance = new Range(500f, 10000f),
                    SpawnAltitude = new Range(20f, 1000f),
                    MinimumDistanceFromGroup = 2000f,
                    Count = 7,
                    Unique = false
                };
            }
            if (questSetting > 1)
            {
                new MonsterLabZN::LocationManager.Location("dybassets", "AshlandsCave_02")
                {
                    Prioritize = true,
                    MapIcon = "bossicon.png",
                    ShowMapIcon = ShowIcon.Never,
                    Biome = Heightmap.Biome.AshLands,
                    SpawnDistance = new Range(500f, 10000f),
                    SpawnAltitude = new Range(20f, 1000f),
                    MinimumDistanceFromGroup = 2000f,
                    Count = 7,
                    Unique = false
                };
            }

            if ((bool)config[PluginConfig.DefFrigga].BoxedValue == true && questSetting > 1)
            {
                new MonsterLabZN::LocationManager.Location("dybassets", "SpiderCave01")
                {
                    Prioritize = true,
                    MapIcon = "bossicon.png",
                    ShowMapIcon = ShowIcon.Never,
                    Biome = Heightmap.Biome.BlackForest,
                    SpawnArea = Heightmap.BiomeArea.Everything,
                    SpawnDistance = new Range(500f, 1000f),
                    SpawnAltitude = new Range(5f, 1000f),
                    MinimumDistanceFromGroup = 3000f,
                    Count = 1,
                    Unique = false
                };
            }

            if (questSetting == 3)
            {
                new MonsterLabZN::LocationManager.Location("dybassets", "Mystical_Well0")
                {
                    Prioritize = true,
                    MapIcon = "ML_Hammer_Icon.png",
                    ShowMapIcon = ShowIcon.Always,
                    Biome = Heightmap.Biome.Meadows,
                    SpawnDistance = new Range(100f, 500f),
                    SpawnAltitude = new Range(10f, 1000f),
                    MinimumDistanceFromGroup = 3000f,
                    Count = 1,
                    Unique = false
                };
            }
        }
        internal static void LoadO(BepInEx.Configuration.ConfigFile config)
        {
            if (questSetting > 1)
            {
                new MonsterLabZN::LocationManager.Location("dybassets", "ML_ShipWreck03")
                {
                    MapIcon = "bossicon.png",
                    ShowMapIcon = ShowIcon.Never,
                    SpawnArea = Heightmap.BiomeArea.Median,
                    Biome = Heightmap.Biome.Ocean,
                    SpawnDistance = new Range(50f, 10000f),
                    SpawnAltitude = new Range(-1000f, -20f),
                    MinimumDistanceFromGroup = 1000f,
                    Count = 10,
                    Unique = false
                };

                new MonsterLabZN::LocationManager.Location("dybassets", "ML_ShipWreck02")
                {
                    MapIcon = "bossicon.png",
                    ShowMapIcon = ShowIcon.Never,
                    SpawnArea = Heightmap.BiomeArea.Median,
                    Biome = Heightmap.Biome.Ocean,
                    SpawnDistance = new Range(50f, 10000f),
                    SpawnAltitude = new Range(-1000f, -20f),
                    MinimumDistanceFromGroup = 1000f,
                    Count = 10,
                    Unique = false
                };
            }


            if ((bool)config[PluginConfig.DefBalder].BoxedValue == true && questSetting > 1)
            {
                new MonsterLabZN::LocationManager.Location("dybassets", "Balder_Altar")
                {
                    Prioritize = true,
                    MapIcon = "bossicon.png",
                    ShowMapIcon = ShowIcon.Never,
                    SpawnArea = Heightmap.BiomeArea.Median,
                    Biome = Heightmap.Biome.Ocean,
                    SpawnDistance = new Range(200f, 3000f),
                    SpawnAltitude = new Range(-1000f, -25f),
                    MinimumDistanceFromGroup = 1000f,
                    Count = 1,
                    Unique = false
                };
            }
        }
    }
}
