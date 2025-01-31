using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossAddAsh
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefHuldraQueen].BoxedValue == false) return;

            Creature creature;
            Creature creature2;
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue == 1)
            {
                creature = new Creature("dybassets", "ML_AshHatchling")
                {
                    Biome = Heightmap.Biome.AshLands,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 10f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
                creature2 = new Creature("dybassets", "ML_FrostHatchling")
                {
                    Biome = Heightmap.Biome.None,
                    SpecificSpawnArea = CreatureManager.SpawnArea.Everywhere,
                    RequiredAltitude = new Range(5f, 1000f),
                    CheckSpawnInterval = 1000,
                    SpawnChance = 10f,
                    GroupSize = new Range(1f, 1f),
                    Maximum = 1,
                    SpecificSpawnTime = SpawnTime.Always
                };
            }
            else
            {
                creature = new Creature("dybassets", "ML_AshHatchling")
                {
                    Biome = Heightmap.Biome.AshLands
                };
                creature2 = new Creature("dybassets", "ML_FrostHatchling")
                {
                    Biome = Heightmap.Biome.None
                };
            }
            
            creature.ConfigurationEnabled = true;
            creature.Drops["ML_TrophyAshHatchling"].Amount = new Range(1f, 1f);
            creature.Drops["ML_TrophyAshHatchling"].DropChance = 10f;
            creature.Drops["ML_TrophyAshHatchling"].DropOnePerPlayer = false;
            creature.Drops["ML_TrophyAshHatchling"].MultiplyDropByLevel = false;
            creature.Drops["FireGland"].Amount = new Range(1f, 2f);
            creature.Drops["FireGland"].DropChance = 100f;
            creature.Drops["FireGland"].DropOnePerPlayer = false;
            creature.Drops["FireGland"].MultiplyDropByLevel = true;


            creature2.ConfigurationEnabled = false;
            creature2.Drops["TrophyHatchling"].Amount = new Range(1f, 1f);
            creature2.Drops["TrophyHatchling"].DropChance = 5f;
            creature2.Drops["TrophyHatchling"].DropOnePerPlayer = false;
            creature2.Drops["TrophyHatchling"].MultiplyDropByLevel = false;
            creature2.Drops["FreezeGland"].Amount = new Range(1f, 1f);
            creature2.Drops["FreezeGland"].DropChance = 50f;
            creature2.Drops["FreezeGland"].DropOnePerPlayer = false;
            creature2.Drops["FreezeGland"].MultiplyDropByLevel = true;
            ItemManager.PrefabManager.RegisterAssetBundle("dybassets", "ML_AshHatchling_ragdoll");
            ItemManager.PrefabManager.RegisterAssetBundle("dybassets", "ML_FrostHatchling_ragdoll");
            new Item("dybassets", "ML_TrophyAshHatchling").Configurable = Configurability.Disabled;
            new Item("dybassets", "FireGland").Configurable = Configurability.Disabled;
            new Item("dybassets", "ashhatchling_spit_fire").Configurable = Configurability.Disabled;
            new Item("dybassets", "ml_frosthatchling_spit_cold").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_ashhatchling_fire_launch");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_ashhatchling_fire_start");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ash_fire_launch");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ashhatchling_death");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ashhatchling_hurt");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_frosthatchling_ice_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_ice_hit");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_ml_iceblocker_destroyed");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ashhatchling_fireball_projectile");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_IceBlocker");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ml_frosthatchling_projectile");
        }
    }
}
