extern alias MonsterLabZN;

using MonsterLabZN::CreatureManager;
using MonsterLabZN::ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Butterflies
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefButterflies].BoxedValue) return;

            Creature creature;
            Creature creature2;
            Creature creature3;

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "Rainbow_Butterfly")
                {
                    Biome = Heightmap.Biome.Meadows
                };
                creature2 = new Creature("dybassets", "Green_Butterfly")
                {
                    Biome = Heightmap.Biome.BlackForest
                };

                creature3 = new Creature("dybassets", "Silkworm_Butterfly")
                {
                    Biome = Heightmap.Biome.Mistlands
                };
            } else
            {
                creature = new Creature("dybassets", "Rainbow_Butterfly")
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
                creature2 = new Creature("dybassets", "Green_Butterfly")
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

                creature3 = new Creature("dybassets", "Silkworm_Butterfly")
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
            }
                
            creature.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature.Drops["Ooze"].DropChance = 100f;
            creature.Drops["Ooze"].DropOnePerPlayer = false;
            creature.Drops["Ooze"].MultiplyDropByLevel = false;

            creature2.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature2.Drops["Ooze"].DropChance = 100f;
            creature2.Drops["Ooze"].DropOnePerPlayer = false;
            creature2.Drops["Ooze"].MultiplyDropByLevel = false;

            creature3.Drops["Ooze"].Amount = new Range(1f, 1f);
            creature3.Drops["Ooze"].DropChance = 100f;
            creature3.Drops["Ooze"].DropOnePerPlayer = false;
            creature3.Drops["Ooze"].MultiplyDropByLevel = false;
        }
    }
}
