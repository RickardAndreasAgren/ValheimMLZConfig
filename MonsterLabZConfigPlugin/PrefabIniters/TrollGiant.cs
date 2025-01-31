using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class TrollGiant
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if (!(bool)config[PluginConfig.DefTrollGiant].BoxedValue) return;

            Creature creature;
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue > 0)
            {
                creature = new Creature("dybassets", "TrollGiant")
                {
                    Biome = Heightmap.Biome.None
                };
            }
            else
            {
                creature = new Creature("dybassets", "TrollGiant")
                {
                    Biome = Heightmap.Biome.None
                };
            }
            
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "TrollGiant_Ragdoll");
            new Item("dybassets", "trollgiant_slam").Configurable = Configurability.Disabled;
            new Item("dybassets", "trollgiant_stomp").Configurable = Configurability.Disabled;
        }
    }
}
