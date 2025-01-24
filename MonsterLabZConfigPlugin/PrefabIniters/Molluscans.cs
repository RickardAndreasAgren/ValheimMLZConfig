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
    internal class Molluscans
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "Molluscan")
            {
                Biome = Heightmap.Biome.Ocean,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                RequiredAltitude = new Range(-1000f, -10f),
                RequiredOceanDepth = new Range(15f, 30f),
                CheckSpawnInterval = 450,
                SpawnChance = 15f,
                GroupSize = new Range(1f, 2f),
                Maximum = 4,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature.Drops["TrophyDeepSeaMolluscan"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyDeepSeaMolluscan"].DropChance = 10f;
            creature.Drops["TrophyDeepSeaMolluscan"].DropOnePerPlayer = false;
            creature.Drops["TrophyDeepSeaMolluscan"].MultiplyDropByLevel = false;
            creature.Drops["Chitin"].Amount = new Range(2f, 3f);
            creature.Drops["Chitin"].DropChance = 100f;
            creature.Drops["Chitin"].DropOnePerPlayer = false;
            creature.Drops["Chitin"].MultiplyDropByLevel = true;
            Creature creature2 = new Creature("dybassets", "MolluscanLand")
            {
                Biome = Heightmap.Biome.BlackForest,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                RequiredOceanDepth = new Range(1f, 2f),
                RequiredAltitude = new Range(-1f, 10f),
                RequiredWeather = (Weather.LightRain | Weather.Rain | Weather.ThunderStorm),
                CheckSpawnInterval = 450,
                SpawnChance = 25f,
                GroupSize = new Range(1f, 1f),
                Maximum = 2,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature2.Drops["TrophyMolluscan"].Amount = new Range(1f, 1f);
            creature2.Drops["TrophyMolluscan"].DropChance = 10f;
            creature2.Drops["TrophyMolluscan"].DropOnePerPlayer = false;
            creature2.Drops["TrophyMolluscan"].MultiplyDropByLevel = false;
            creature2.Drops["Chitin"].Amount = new Range(1f, 1f);
            creature2.Drops["Chitin"].DropChance = 100f;
            creature2.Drops["Chitin"].DropOnePerPlayer = false;
            creature2.Drops["Chitin"].MultiplyDropByLevel = true;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "Molluscan_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DeepSeaMolluscan_ragdoll");
            new Item("dybassets", "TrophyMolluscan").Configurable = Configurability.Disabled;
            new Item("dybassets", "TrophyDeepSeaMolluscan").Configurable = Configurability.Disabled;
            new Item("dybassets", "Molluscan_attack").Configurable = Configurability.Disabled;
            new Item("dybassets", "Molluscan_attack2").Configurable = Configurability.Disabled;
            new Item("dybassets", "Molluscan_attack3").Configurable = Configurability.Disabled;
            new Item("dybassets", "Molluscan_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "MolluscanLand_attack").Configurable = Configurability.Disabled;
            new Item("dybassets", "MolluscanLand_attack2").Configurable = Configurability.Disabled;
            new Item("dybassets", "MolluscanLand_attack3").Configurable = Configurability.Disabled;
            new Item("dybassets", "MolluscanLand_taunt").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscan_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_molluscanland_taunt");
        }
    }
}
