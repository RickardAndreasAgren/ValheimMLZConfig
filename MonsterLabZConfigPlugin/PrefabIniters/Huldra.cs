extern alias MonsterLabZN;

using Jotunn.Managers;
using MonsterLabZN::CreatureManager;
using MonsterLabZN::ItemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLabZConfig.PrefabIniters
{
    internal class Huldra
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "ML_AshHuldra")
            {
                Biome = Heightmap.Biome.AshLands,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                RequiredAltitude = new Range(5f, 1000f),
                CheckSpawnInterval = 500,
                SpawnChance = 10f,
                GroupSize = new Range(1f, 3f),
                Maximum = 3,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature.Drops["ML_HuldraTail"].Amount = new Range(1f, 1f);
            creature.Drops["ML_HuldraTail"].DropChance = 10f;
            creature.Drops["ML_HuldraTail"].DropOnePerPlayer = false;
            creature.Drops["ML_HuldraTail"].MultiplyDropByLevel = false;
            creature.Drops["Entrails"].Amount = new Range(1f, 1f);
            creature.Drops["Entrails"].DropChance = 100f;
            creature.Drops["Entrails"].DropOnePerPlayer = false;
            creature.Drops["Entrails"].MultiplyDropByLevel = true;
        }
    }
}
