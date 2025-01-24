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
    internal class SeaGoblins
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "ML_GoblinShip")
            {
                Biome = Heightmap.Biome.Plains,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Edge,
                RequiredAltitude = new Range(-1000f, 0f),
                SpawnAltitude = 20f,
                RequiredOceanDepth = new Range(15f, 20f),
                CheckSpawnInterval = 1000,
                SpawnChance = 10f,
                GroupSize = new Range(1f, 1f),
                Maximum = 1,
                SpecificSpawnTime = SpawnTime.Day,
                RequiredWeather = Weather.MeadowsClearSkies,
                RequiredGlobalKey = GlobalKey.KilledModer
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
            creature.Drops["DwarfGoblin_NoAttack"].Amount = new Range(3f, 5f);
            creature.Drops["DwarfGoblin_NoAttack"].DropChance = 100f;
            creature.Drops["DwarfGoblin_NoAttack"].DropOnePerPlayer = false;
            creature.Drops["DwarfGoblin_NoAttack"].MultiplyDropByLevel = false;
            creature.Drops["ML_GoblinShip_Cargo"].Amount = new Range(3f, 5f);
            creature.Drops["ML_GoblinShip_Cargo"].DropChance = 100f;
            creature.Drops["ML_GoblinShip_Cargo"].DropOnePerPlayer = false;
            creature.Drops["ML_GoblinShip_Cargo"].MultiplyDropByLevel = false;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_Boat");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinShaman_Boat");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_NoAttack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_Spawn");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_GoblinShip_Cargo");
            new Item("dybassets", "ml_aiship_move").Configurable = Configurability.Disabled;
            new Item("dybassets", "ml_goblinship_spawn").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_shipwater_surface");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ship_move_slow");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ship_move_fast");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ml_goblinship_spawn_projectile");
        }
    }
}
