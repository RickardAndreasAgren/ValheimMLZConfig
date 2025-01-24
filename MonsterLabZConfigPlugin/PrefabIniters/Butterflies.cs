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
    internal class Butterflies
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "Rainbow_Butterfly")
            {
                Biome = Heightmap.Biome.Meadows,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                CheckSpawnInterval = 300,
                RequiredWeather = (Weather.ClearSkies | Weather.MeadowsClearSkies),
                ForestSpawn = Forest.No,
                SpawnChance = 50f,
                GroupSize = new Range(1f, 1f),
                Maximum = 3,
                CanHaveStars = false,
                SpecificSpawnTime = SpawnTime.Day
            };
            creature.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = false;
            Creature creature2 = new Creature("dybassets", "Green_Butterfly")
            {
                Biome = Heightmap.Biome.BlackForest,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                CheckSpawnInterval = 300,
                RequiredWeather = (Weather.ClearSkies | Weather.MeadowsClearSkies | Weather.BlackForestFog),
                SpawnChance = 50f,
                GroupSize = new Range(1f, 1f),
                Maximum = 3,
                CanHaveStars = false,
                SpecificSpawnTime = SpawnTime.Day
            };
            creature2.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature2.Drops["Ooze"].DropChance = 100f;
            creature2.Drops["Ooze"].DropOnePerPlayer = false;
            creature2.Drops["Ooze"].MultiplyDropByLevel = false;
            Creature creature3 = new Creature("dybassets", "Silkworm_Butterfly")
            {
                Biome = Heightmap.Biome.Mistlands,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                CheckSpawnInterval = 300,
                RequiredWeather = Weather.MistlandsDark,
                SpawnChance = 50f,
                GroupSize = new Range(1f, 1f),
                Maximum = 3,
                CanHaveStars = false,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature3.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature3.Drops["Ooze"].DropChance = 100f;
            creature3.Drops["Ooze"].DropOnePerPlayer = false;
            creature3.Drops["Ooze"].MultiplyDropByLevel = false;
        }
    }
}
