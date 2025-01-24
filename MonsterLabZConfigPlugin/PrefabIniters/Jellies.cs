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
    internal class Jellies
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "ML_JellyFish0")
            {
                Biome = Heightmap.Biome.Ocean,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                RequiredAltitude = new Range(-1000f, -10f),
                RequiredOceanDepth = new Range(20f, 30f),
                CheckSpawnInterval = 800,
                SpawnAltitude = -10f,
                SpawnChance = 55f,
                GroupSize = new Range(1f, 3f),
                Maximum = 6,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature.Drops["Guck"].Amount = new Range(1f, 2f);
            creature.Drops["Guck"].DropChance = 100f;
            creature.Drops["Guck"].DropOnePerPlayer = false;
            creature.Drops["Guck"].MultiplyDropByLevel = true;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_jellyfish_death");
        }
    }
}
