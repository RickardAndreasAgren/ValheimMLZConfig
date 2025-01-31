using CreatureManager;
using ItemManager;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class Shadow
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefQuestToggle].BoxedValue < 3) return;

            Creature creature = new Creature("dybassets", "EvilShadow")
            {
                Biome = Heightmap.Biome.None
            };
            new Item("dybassets", "evilshadow_attack").Configurable = Configurability.Disabled;
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_evilspirit_attack");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_evilshadow_attack");
        }
    }
}
