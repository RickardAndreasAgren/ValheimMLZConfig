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
    internal class SeaDraugr
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "ML_DraugrShip")
            {
                Biome = Heightmap.Biome.BlackForest,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Edge,
                RequiredAltitude = new Range(-1000f, 0f),
                SpawnAltitude = 20f,
                RequiredOceanDepth = new Range(15f, 20f),
                CheckSpawnInterval = 1000,
                SpawnChance = 10f,
                GroupSize = new Range(1f, 1f),
                Maximum = 1,
                SpecificSpawnTime = SpawnTime.Night,
                RequiredWeather = Weather.Fog,
                RequiredGlobalKey = GlobalKey.KilledBonemass
            };
            creature.Drops["DeerHide"].Amount = new Range(1f, 2f);
            creature.Drops["DeerHide"].DropChance = 100f;
            creature.Drops["DeerHide"].DropOnePerPlayer = false;
            creature.Drops["DeerHide"].MultiplyDropByLevel = true;
            creature.Drops["ElderBark"].Amount = new Range(1f, 2f);
            creature.Drops["ElderBark"].DropChance = 100f;
            creature.Drops["ElderBark"].DropOnePerPlayer = false;
            creature.Drops["ElderBark"].MultiplyDropByLevel = true;
            creature.Drops["FineWood"].Amount = new Range(1f, 2f);
            creature.Drops["FineWood"].DropChance = 100f;
            creature.Drops["FineWood"].DropOnePerPlayer = false;
            creature.Drops["FineWood"].MultiplyDropByLevel = true;
            creature.Drops["ML_DraugrShip_Cargo"].Amount = new Range(3f, 5f);
            creature.Drops["ML_DraugrShip_Cargo"].DropChance = 100f;
            creature.Drops["ML_DraugrShip_Cargo"].DropOnePerPlayer = false;
            creature.Drops["ML_DraugrShip_Cargo"].MultiplyDropByLevel = false;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Draugr_Boat");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_DraugrBomber_Boat");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Draugr_Spawn");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_Draugr_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_DraugrShip_Cargo");
            new Item("dybassets", "ml_draugrship_spawn").Configurable = Configurability.Disabled;
            new Item("dybassets", "Draugr_OozeBomb").Configurable = Configurability.Disabled;
            new Item("dybassets", "ML_Draugr_Bow").Configurable = Configurability.Disabled;
            new Item("dybassets", "draugrboat_axe").Configurable = Configurability.Disabled;
            new Item("dybassets", "draugrboat_sword").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ml_draugrship_spawn_projectile");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "draugr_oozebomb_projectile");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "draugr_oozebomb_explosion");
        }
    }
}
