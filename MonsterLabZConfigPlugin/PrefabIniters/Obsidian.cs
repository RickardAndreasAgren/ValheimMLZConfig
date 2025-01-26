﻿extern alias MonsterLabZN;

using MonsterLabZN::CreatureManager;
using MonsterLabZN::ItemManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Biome = Heightmap.Biome.None
                };
            }
            else
            {
                creature = new Creature("dybassets", "ObsidianGolem")
                {
                    Biome = Heightmap.Biome.None
                };
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
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "ObsidianGolem_ragdoll");
            new Item("dybassets", "TrophyObsidianGolem").Configurable = Configurability.Disabled;
            new Item("dybassets", "ObsidianGolem_clubs").Configurable = Configurability.Disabled;
            new Item("dybassets", "ObsidianGolem_hat").Configurable = Configurability.Disabled;
            new Item("dybassets", "ObsidianGolem_spikes").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_obsidiangolem_death");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "vfx_obsidiangolem_wakeup");
        }
    }
}
