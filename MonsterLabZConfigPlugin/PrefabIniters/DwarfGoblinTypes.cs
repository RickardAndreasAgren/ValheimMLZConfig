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
    internal class DwarfGoblinTypes
    {
        public static void init(BepInEx.Configuration.ConfigFile config)
        {
            Creature creature = new Creature("dybassets", "DwarfGoblin")
            {
                Biome = Heightmap.Biome.Plains,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                RequiredAltitude = new Range(1f, 1000f),
                CheckSpawnInterval = 300,
                SpawnChance = 25f,
                GroupSize = new Range(4f, 5f),
                Maximum = 8,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature.Drops["Coins"].Amount = new Range(3f, 5f);
            creature.Drops["Coins"].DropChance = 100f;
            creature.Drops["Coins"].DropOnePerPlayer = false;
            creature.Drops["Coins"].MultiplyDropByLevel = true;
            Creature creature2 = new Creature("dybassets", "DwarfGoblinLoot")
            {
                Biome = Heightmap.Biome.Plains,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                RequiredAltitude = new Range(1f, 1000f),
                CheckSpawnInterval = 300,
                SpawnChance = 5f,
                GroupSize = new Range(1f, 1f),
                Maximum = 2,
                SpecificSpawnTime = SpawnTime.Day
            };
            creature2.Drops["Coins"].Amount = new Range(5f, 8f);
            creature2.Drops["Coins"].DropChance = 100f;
            creature2.Drops["Coins"].DropOnePerPlayer = false;
            creature2.Drops["Coins"].MultiplyDropByLevel = true;
            creature2.Drops["Amber"].Amount = new Range(2f, 4f);
            creature2.Drops["Amber"].DropChance = 100f;
            creature2.Drops["Amber"].DropOnePerPlayer = false;
            creature2.Drops["Amber"].MultiplyDropByLevel = true;
            creature2.Drops["Ruby"].Amount = new Range(1f, 3f);
            creature2.Drops["Ruby"].DropChance = 100f;
            creature2.Drops["Ruby"].DropOnePerPlayer = false;
            creature2.Drops["Ruby"].MultiplyDropByLevel = true;
            Creature creature3 = new Creature("dybassets", "DwarfGoblinShaman")
            {
                Biome = Heightmap.Biome.Plains,
                SpecificSpawnArea = MonsterLabZN::CreatureManager.SpawnArea.Everywhere,
                RequiredAltitude = new Range(1f, 1000f),
                CheckSpawnInterval = 450,
                SpawnChance = 10f,
                GroupSize = new Range(1f, 2f),
                Maximum = 2,
                SpecificSpawnTime = SpawnTime.Always
            };
            creature3.Drops["Coins"].Amount = new Range(4f, 6f);
            creature3.Drops["Coins"].DropChance = 100f;
            creature3.Drops["Coins"].DropOnePerPlayer = false;
            creature3.Drops["Coins"].MultiplyDropByLevel = true;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblin_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinLoot_ragdoll");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinShaman_ragdoll");
            new Item("dybassets", "DwarfGoblinBow").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinPickAxe").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinClub").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSword").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinTorch").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShieldBlackMetal").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShieldWood").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmBandFeathers").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmBandIron").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorBronze").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorFeathers").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorIron").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinArmorLeather").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinHelmetBronze").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinHelmetLeather").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinHelmetSkull").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShamanStaffBones").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShamanStaffFeathers").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShoulderPadIron").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShoulderPadLeather").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSpear").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSpearLox").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinSpearChitin").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShamanBoat_attack_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShaman_attack_fireball").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinShaman_attack_poke").Configurable = Configurability.Disabled;
            new Item("dybassets", "DwarfGoblinLoot_Run").Configurable = Configurability.Disabled;
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_alert");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_die");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_hit");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_idle");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "sfx_goblin_loot_taunt");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinSpear_projectile");
            MonsterLabZN::ItemManager.PrefabManager.RegisterPrefab("dybassets", "DwarfGoblinSpearChitin_projectile");
        }
    }
}
