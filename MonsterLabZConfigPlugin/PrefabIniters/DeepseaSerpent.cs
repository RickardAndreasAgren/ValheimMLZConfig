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
    internal static class DeepseaSerpent
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefDeepSeaSerpent].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "DeepSea_Serpent")
                {
                    Biome = Heightmap.Biome.Ocean
                };
            }
            else
            {
                creature = new Creature("dybassets", "DeepSea_Serpent")
                {
                    Biome = Heightmap.Biome.Ocean,
                    SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Center,
                    RequiredAltitude = new Range(-1000f, -10f),
                    RequiredOceanDepth = new Range(20f, 30f),
                    CheckSpawnInterval = 800,
                    SpawnAltitude = -10f,
                    SpawnChance = 10f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Night
                };
            }
            
            creature.Drops["TrophyDeepSeaSerpent"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyDeepSeaSerpent"].DropChance = 30f;
            creature.Drops["TrophyDeepSeaSerpent"].DropOnePerPlayer = false;
            creature.Drops["TrophyDeepSeaSerpent"].MultiplyDropByLevel = false;
            creature.Drops["SerpentMeat"].Amount = new Range(6f, 8f);
            creature.Drops["SerpentMeat"].DropChance = 100f;
            creature.Drops["SerpentMeat"].DropOnePerPlayer = false;
            creature.Drops["SerpentMeat"].MultiplyDropByLevel = true;
            creature.Drops["SerpentScale"].Amount = new Range(8f, 10f);
            creature.Drops["SerpentScale"].DropChance = 100f;
            creature.Drops["SerpentScale"].DropOnePerPlayer = false;
            creature.Drops["SerpentScale"].MultiplyDropByLevel = true;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DeepSea_Serpent_Flying");
            new Item("dybassets", "TrophyDeepSeaSerpent").Configurable = Configurability.Disabled;
            new Item("dybassets", "DeepSea_Serpent_Attack").Configurable = Configurability.Disabled;
            new Item("dybassets", "DeepSea_Serpent_Cast").Configurable = Configurability.Disabled;
            new Item("dybassets", "DeepSea_Serpent_Laser").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "projectile_serpent_laser");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_deepseaserpent_attack_trigger");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_serpent_laser");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_deepseaserpent_alerted");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_serpent_fire_launch");
        }
    }
}
