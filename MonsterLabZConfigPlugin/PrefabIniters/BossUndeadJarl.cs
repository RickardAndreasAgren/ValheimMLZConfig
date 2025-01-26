extern alias MonsterLabZN;

using MonsterLabZN::CreatureManager;
using MonsterLabZN::ItemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLabZConfig.PrefabIniters
{
    internal static class BossUndeadJarl
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue < 1) return;
            if ((bool)config[PluginConfig.DefBossJarl].BoxedValue == false) return;

            Creature creature;
            Creature creature2;
            if ((short)config[PluginConfig.DefWildBosses].BoxedValue == 1)
            {
                creature = new Creature("dybassets", "NormalSkeletonWarrior_Boss")
                {
                    Biome = Heightmap.Biome.None
                };
                creature2 = new Creature("dybassets", "NormalSkeletonWarrior_Spawn")
                {
                    Biome = Heightmap.Biome.None
                };
            }
            else
            {
                creature = new Creature("dybassets", "NormalSkeletonWarrior_Boss")
                {
                    Biome = Heightmap.Biome.None
                };
                creature2 = new Creature("dybassets", "NormalSkeletonWarrior_Spawn")
                {
                    Biome = Heightmap.Biome.None
                };
            }
            creature.Localize().English("Undead Jarl").Japanese("骸骨");
            creature2.Localize().English("Skeleton").Japanese("骸骨");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "spawn_projectile_T1");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "attack_spawn_T1");
        }
    }
}
