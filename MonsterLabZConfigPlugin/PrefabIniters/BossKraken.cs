using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossKraken
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefKraken].BoxedValue == false) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "KrakenLD_ragdoll");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_kraken_alert");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_kraken_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_kraken_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_kraken_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_kraken_idle");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_kraken_taunt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_krakenpoison_launch");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_kraken_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_kraken_attacklightning");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_kraken_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_kraken_spit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_kraken_watersurface");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_krakenpoison_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_krakenpoison_hitground");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_watersplash_kraken");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_krakenblob_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_kraken_lightning_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "inkblob_projectile");
            new Item("dybassets", "KrakenMeat").Configurable = Configurability.Disabled;
            new Item("dybassets", "kraken_attack1").Configurable = Configurability.Disabled;
            new Item("dybassets", "kraken_attack2").Configurable = Configurability.Disabled;
            new Item("dybassets", "kraken_attack3").Configurable = Configurability.Disabled;
            new Item("dybassets", "kraken_attack4").Configurable = Configurability.Disabled;
            new Item("dybassets", "kraken_attacklightning").Configurable = Configurability.Disabled;
            new Item("dybassets", "kraken_poisonball").Configurable = Configurability.Disabled;
            new Item("dybassets", "kraken_taunt").Configurable = Configurability.Disabled;
            new Item("dybassets", "krakenblob_attack").Configurable = Configurability.Disabled;

            Creature creature;
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue == 1)
            {
                creature = new Creature("dybassets", "KrakenLD")
                {
                    Biome = Heightmap.Biome.None,
                    CanSpawn = false
                };
                if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                    {
                        collection
                            .ConfigureWorldSpawner(783)
                            .SetTemplateName("GenKrakenLD")
                            .SetPrefabName("KrakenLD")
                            .SetConditionBiomes(Heightmap.Biome.Ocean)
                            .SetMinLevel(1)
                            .SetMaxLevel(1);
                    });
                }
            } else
            {
                creature = new Creature("dybassets", "KrakenLD")
                {
                    Biome = Heightmap.Biome.Ocean,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Center,
                    RequiredAltitude = new Range(-1000f, -5f),
                    RequiredOceanDepth = new Range(20f, 30f),
                    CheckSpawnInterval = 600,
                    RequiredGlobalKey = GlobalKey.KilledBonemass,
                    RequiredWeather = Weather.ThunderStorm,
                    SpawnChance = 2f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
                
            creature.Drops["KrakenMeat"].Amount = new Range(10f, 15f);
            creature.Drops["KrakenMeat"].DropChance = 100f;
            creature.Drops["KrakenMeat"].DropOnePerPlayer = false;
            creature.Drops["KrakenMeat"].MultiplyDropByLevel = false;
            creature.Drops["Chitin"].Amount = new Range(5f, 8f);
            creature.Drops["Chitin"].DropChance = 100f;
            creature.Drops["Chitin"].DropOnePerPlayer = false;
            creature.Drops["Chitin"].MultiplyDropByLevel = true;


            new Creature("dybassets", "Kraken_Blob")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false
            };
        }
    }
}
