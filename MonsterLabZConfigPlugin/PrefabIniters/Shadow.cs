extern alias MonsterLabZN;

using MonsterLabZN::CreatureManager;
using MonsterLabZN::ItemManager;

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
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_evilspirit_attack");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_evilshadow_attack");
        }
    }
}
