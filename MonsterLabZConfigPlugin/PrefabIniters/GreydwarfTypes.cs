using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class GreydwarfTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple_Shroom");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple");
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple_ragdoll");
            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
            {
                MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(702)
                        .SetPrefabName("Greydwarf_Purple")
                        .SetConditionBiomes(Heightmap.Biome.BlackForest)
                        .SetMinLevel(1)
                        .SetMaxLevel(3);
                });

                MonsterLabZConfig.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(703)
                        .SetPrefabName("Greydwarf_Purple_Shroom")
                        .SetConditionBiomes(Heightmap.Biome.BlackForest)
                        .SetMinLevel(1)
                        .SetMaxLevel(3);
                });
            }
        }
    }
}
