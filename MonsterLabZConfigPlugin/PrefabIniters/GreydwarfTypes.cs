using CreatureManager;
using ItemManager;
using SpawnThat.Spawners;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class GreydwarfTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            ItemManager.PrefabManager.RegisterPrefab("dybassets", "Greydwarf_Purple_ragdoll");
            var creature3 = new Creature("dybassets", "Greydwarf_Purple_Shroom")
            {
                Biome = Heightmap.Biome.None,
                CanSpawn = false
            };
            creature3.Prefab.name = "$enemy_raigreydwarfpurple";
            var creature4 = new Creature("dybassets", "Greydwarf_Purple")
            {
                Biome = Heightmap.Biome.None,
                CanSpawn = false
            };
            creature4.Prefab.name = "$enemy_raigreydwarfpurpleshroom";

            if ((short)config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
            {
                MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(702)
                        .SetTemplateName("GenGreydwarf_Purple")
                        .SetPrefabName("Greydwarf_Purple")
                        .SetConditionBiomes(Heightmap.Biome.BlackForest)
                        .SetMinLevel(1)
                        .SetMaxLevel(3);
                });

                MonsterLabZConfigPlugin.SpawnThatMonsters.Add((collection) =>
                {
                    collection
                        .ConfigureWorldSpawner(703)
                        .SetTemplateName("GenGreydwarf_Purple_Shroom")
                        .SetPrefabName("Greydwarf_Purple_Shroom")
                        .SetConditionBiomes(Heightmap.Biome.BlackForest)
                        .SetMinLevel(1)
                        .SetMaxLevel(3);
                });
            }
        }
    }
}
