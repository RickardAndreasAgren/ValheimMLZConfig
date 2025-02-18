using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Obsidian
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefObsidianGolem].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "ObsidianGolem")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }
            else
            {
                creature = new Creature("dybassets", "ObsidianGolem")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
            }

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
            {
                MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(708)
                        .SetTemplateName("GenObsidianGolem")
                        .SetPrefabName("ObsidianGolem")
                        .SetConditionBiomes(Heightmap.Biome.Mountain)
                        .SetMinLevel(1)
                        .SetMaxLevel(1);
                });
            }
            creature.ConfigurationEnabled = true;
            creature.Drops["TrophyObsidianGolem"].Amount = new Range(1f, 1f);
            creature.Drops["TrophyObsidianGolem"].DropChance = 10f;
            creature.Drops["TrophyObsidianGolem"].DropOnePerPlayer = false;
            creature.Drops["TrophyObsidianGolem"].MultiplyDropByLevel = false;
            creature.Drops["Stone"].Amount = new Range(3f, 5f);
            creature.Drops["Stone"].DropChance = 100f;
            creature.Drops["Stone"].DropOnePerPlayer = false;
            creature.Drops["Stone"].MultiplyDropByLevel = true;
            creature.Drops["Obsidian"].Amount = new Range(5f, 8f);
            creature.Drops["Obsidian"].DropChance = 100f;
            creature.Drops["Obsidian"].DropOnePerPlayer = false;
            creature.Drops["Obsidian"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ObsidianGolem_ragdoll");
            new Item("dybassets", "TrophyObsidianGolem").Configurable = Configurability.Disabled;
            new Item("dybassets", "ObsidianGolem_clubs").Configurable = Configurability.Disabled;
            new Item("dybassets", "ObsidianGolem_hat").Configurable = Configurability.Disabled;
            new Item("dybassets", "ObsidianGolem_spikes").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_obsidiangolem_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_obsidiangolem_wakeup");
        }
    }
}
