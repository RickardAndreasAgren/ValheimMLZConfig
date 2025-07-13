using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossHuldra
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefHuldraQueen].BoxedValue == false) return;

            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldraQueen2_Transform");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "ML_AshHuldraQueen3_Ragdoll");
            new Item("dybassets", "TrophyAshHuldraQueen").Configurable = Configurability.Disabled;
            Huldra.HuldraAssets();

            new Creature("dybassets", "ML_AshHuldraQueen1").Biome = Heightmap.Biome.None;
            new Creature("dybassets", "ML_AshHuldraQueen2")
            {
                Biome = Heightmap.Biome.None,
                ConfigurationEnabled = false,
                CanSpawn = false
            };
            Creature creature2 = new Creature("dybassets", "ML_AshHuldraQueen3")
            {
                Biome = Heightmap.Biome.None,
                CanSpawn = false
            };
            creature2.ConfigurationEnabled = false;
            creature2.Drops["TrophyAshHuldraQueen"].Amount = new Range(1f, 1f);
            creature2.Drops["TrophyAshHuldraQueen"].DropChance = 100f;
            creature2.Drops["TrophyAshHuldraQueen"].DropOnePerPlayer = false;
            creature2.Drops["TrophyAshHuldraQueen"].MultiplyDropByLevel = false;
        }
    }
}
