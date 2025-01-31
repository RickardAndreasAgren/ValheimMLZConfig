using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

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
                    Biome = Heightmap.Biome.None,
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(734)
                            .SetPrefabName("DeepSea_Serpent")
                            .SetConditionBiomes(Heightmap.Biome.Ocean)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            }
            else
            {
                creature = new Creature("dybassets", "DeepSea_Serpent")
                {
                    Biome = Heightmap.Biome.Ocean,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Center,
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
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "DeepSea_Serpent_Flying");
            new Item("dybassets", "TrophyDeepSeaSerpent").Configurable = Configurability.Disabled;
            new Item("dybassets", "DeepSea_Serpent_Attack").Configurable = Configurability.Disabled;
            new Item("dybassets", "DeepSea_Serpent_Cast").Configurable = Configurability.Disabled;
            new Item("dybassets", "DeepSea_Serpent_Laser").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "projectile_serpent_laser");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_deepseaserpent_attack_trigger");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_serpent_laser");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_deepseaserpent_alerted");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_serpent_fire_launch");
        }
    }
}
