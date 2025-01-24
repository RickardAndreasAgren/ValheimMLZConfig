
using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers.MockSystem;
using UnityEngine;

namespace Jotunn.Managers
{
    //
    // Summary:
    //     Manager for handling all custom data added to the game related to creatures.
    public class CreatureManager : IManager
    {
        private static class Patches
        {
            [HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
            [HarmonyPrefix]
            private static void InvokeOnVanillaCreaturesAvailable()
            {
                Instance.InvokeOnVanillaCreaturesAvailable();
            }

            [HarmonyPatch(typeof(ZNetScene), "Awake")]
            [HarmonyPostfix]
            private static void FixReferences(ZNetScene __instance)
            {
                Instance.FixReferences(__instance);
            }

            [HarmonyPatch(typeof(SpawnSystem), "Awake")]
            [HarmonyPrefix]
            private static void AddSpawnListToSpawnSystem(SpawnSystem __instance)
            {
                Instance.AddSpawnListToSpawnSystem(__instance);
            }

            [HarmonyPatch(typeof(LevelEffects), "SetupLevelVisualization")]
            [HarmonyPostfix]
            private static void EnableCumulativeLevelEffects(LevelEffects __instance, int level)
            {
                Instance.EnableCumulativeLevelEffects(__instance, level);
            }
        }

        private static CreatureManager _instance;

        //
        // Summary:
        //     Unity "character" layer ID.
        public static int CharacterLayer;

        //
        // Summary:
        //     Internal lists of all custom entities added
        internal readonly List<CustomCreature> Creatures = new List<CustomCreature>();

        //
        // Summary:
        //     Container for Jötunn's SpawnSystemList in the DontDestroyOnLoad scene.
        internal GameObject SpawnListContainer;

        //
        // Summary:
        //     Reference to the SpawnList component of the container.
        internal SpawnSystemList SpawnList;

        //
        // Summary:
        //     The singleton instance of this manager.
        public static CreatureManager Instance => _instance ?? (_instance = new CreatureManager());

        //
        // Summary:
        //     Event that gets fired after the vanilla creatures are in memory and available
        //     for cloning. Your code will execute every time before a new ObjectDB is copied
        //     (on every menu start). If you want to execute just once you will need to unregister
        //     from the event after execution.
        public static event Action OnVanillaCreaturesAvailable;

        //
        // Summary:
        //     Event that gets fired after registering all custom creatures to ZNetScene. Your
        //     code will execute every time a new ZNetScene is created (on every game start).
        //     If you want to execute just once you will need to unregister from the event after
        //     execution.
        public static event Action OnCreaturesRegistered;

        //
        // Summary:
        //     Hide .ctor
        private CreatureManager()
        {
        }

        static CreatureManager()
        {
            CharacterLayer = LayerMask.NameToLayer("character");
            ((IManager)Instance).Init();
        }

        //
        // Summary:
        //     Creates the spawner container and registers all hooks.
        void IManager.Init()
        {
            Main.LogInit("CreatureManager");
            SpawnListContainer = new GameObject("Creatures");
            SpawnListContainer.transform.parent = Main.RootObject.transform;
            SpawnListContainer.SetActive(value: false);
            SpawnList = SpawnListContainer.AddComponent<SpawnSystemList>();
            Main.Harmony.PatchAll(typeof(Patches));
        }

        //
        // Summary:
        //     Add a Jotunn.Entities.CustomCreature to the game.
        //     Checks if the custom creature is valid and unique and adds it to the list of
        //     custom creatures.
        //
        // Parameters:
        //   customCreature:
        //     The custom Creature to add.
        //
        // Returns:
        //     true if the custom Creature was added to the manager.
        public bool AddCreature(CustomCreature customCreature)
        {
            if (!customCreature.IsValid())
            {
                Logger.LogWarning(customCreature.SourceMod, $"Custom creature '{customCreature}' is not valid");
                return false;
            }

            if (Creatures.Contains(customCreature))
            {
                Logger.LogWarning(customCreature.SourceMod, $"Custom creature '{customCreature}' already added");
                return false;
            }

            if (!PrefabManager.Instance.AddPrefab(customCreature.Prefab, customCreature.SourceMod))
            {
                return false;
            }

            if (customCreature.Prefab.layer != CharacterLayer)
            {
                customCreature.Prefab.layer = CharacterLayer;
                foreach (Transform item in customCreature.Prefab.transform)
                {
                    item.gameObject.layer = CharacterLayer;
                }
            }

            customCreature.Prefab.transform.SetParent(SpawnListContainer.transform, worldPositionStays: false);
            Creatures.Add(customCreature);
            SpawnList.m_spawners.AddRange(customCreature.Spawns);
            return true;
        }

        //
        // Summary:
        //     Get a custom creature by its name.
        //
        // Parameters:
        //   creatureName:
        //     Name of the custom creature to search.
        //
        // Returns:
        //     The Jotunn.Entities.CustomCreature if found.
        public CustomCreature GetCreature(string creatureName)
        {
            return Creatures.FirstOrDefault((CustomCreature x) => x.Prefab.name.Equals(creatureName));
        }

        //
        // Summary:
        //     Get a custom or vanilla creature prefab by its name.
        //
        // Parameters:
        //   creatureName:
        //     Name of the creature to search.
        //
        // Returns:
        //     The prefab of the creature if found.
        public GameObject GetCreaturePrefab(string creatureName)
        {
            CustomCreature creature = GetCreature(creatureName);
            if (creature != null)
            {
                return creature.Prefab;
            }

            Character prefab = PrefabManager.Cache.GetPrefab<Character>(creatureName);
            if (prefab != null)
            {
                return prefab.gameObject;
            }

            return null;
        }

        //
        // Summary:
        //     Remove a custom creature by its name.
        //
        // Parameters:
        //   creatureName:
        //     Name of the creature to remove.
        public void RemoveCreature(string creatureName)
        {
            CustomCreature creature = GetCreature(creatureName);
            if (creature == null)
            {
                Logger.LogWarning("Could not remove Creature " + creatureName + ": Not found");
            }
            else
            {
                RemoveCreature(creature);
            }
        }

        //
        // Summary:
        //     Remove a custom creature by its ref. Removes the custom recipe, too.
        //
        // Parameters:
        //   creature:
        //     Jotunn.Entities.CustomCreature to remove.
        public void RemoveCreature(CustomCreature creature)
        {
            Creatures.Remove(creature);
            if ((bool)creature.Prefab)
            {
                PrefabManager.Instance.RemovePrefab(creature.Prefab.name);
            }
        }

        //
        // Summary:
        //     Safely invoke the Jotunn.Managers.CreatureManager.OnVanillaCreaturesAvailable
        //     event
        private void InvokeOnVanillaCreaturesAvailable()
        {
            CreatureManager.OnVanillaCreaturesAvailable?.SafeInvoke();
        }

        //
        // Summary:
        //     Resolve mocks of all custom creatures if necessary.
        private void FixReferences(ZNetScene self)
        {
            if (Creatures.Any())
            {
                Logger.LogInfo($"Adding {Creatures.Count} custom creatures");
                List<CustomCreature> list = new List<CustomCreature>();
                foreach (CustomCreature creature in Creatures)
                {
                    try
                    {
                        creature.Prefab.GetComponent<CapsuleCollider>()?.FixReferences();
                        if (creature.FixReference | creature.FixConfig)
                        {
                            creature.Prefab.FixReferences(creature.FixReference);
                            creature.FixReference = false;
                            creature.FixConfig = false;
                        }

                        Logger.LogDebug($"Added creature {creature} | Spawns: {creature.Spawns.Count}");
                    }
                    catch (MockResolveException ex)
                    {
                        Logger.LogWarning(creature?.SourceMod, $"Skipping creature {creature}: {ex.Message}");
                        list.Add(creature);
                    }
                    catch (Exception arg)
                    {
                        Logger.LogWarning(creature?.SourceMod, $"Error caught while adding creature {creature}: {arg}");
                        list.Add(creature);
                    }
                }

                foreach (CustomCreature item in list)
                {
                    if ((bool)item.Prefab)
                    {
                        PrefabManager.Instance.DestroyPrefab(item.Prefab.name);
                    }

                    RemoveCreature(item);
                }
            }

            InvokeOnCreaturesRegistered();
        }

        //
        // Summary:
        //     Safely invoke the Jotunn.Managers.CreatureManager.OnCreaturesRegistered event.
        private void InvokeOnCreaturesRegistered()
        {
            CreatureManager.OnCreaturesRegistered?.SafeInvoke();
        }

        //
        // Summary:
        //     Add the internal SpawnSystemList to the awoken spawner if not already added.
        private void AddSpawnListToSpawnSystem(SpawnSystem self)
        {
            if (!self.m_spawnLists.Contains(SpawnList))
            {
                self.m_spawnLists.Add(SpawnList);
            }
        }

        //
        // Summary:
        //     Enable cumulative level effects for custom creatures requesting it. Thx ASP for
        //     the code.
        private void EnableCumulativeLevelEffects(LevelEffects self, int level)
        {
            if (level <= 2 || !Creatures.Any((CustomCreature x) => x.Prefab.name == self.m_character.m_nview.GetPrefabName() && x.UseCumulativeLevelEffects))
            {
                return;
            }

            for (int num = level - 2; num >= 0; num--)
            {
                if (num < self.m_levelSetups.Count)
                {
                    LevelEffects.LevelSetup levelSetup = self.m_levelSetups[num];
                    if ((bool)levelSetup.m_enableObject)
                    {
                        Logger.LogDebug($"Enabling {level - 1} star equipment: '{levelSetup.m_enableObject.name}'");
                        levelSetup.m_enableObject.SetActive(value: true);
                    }
                }
            }
        }
    }
}