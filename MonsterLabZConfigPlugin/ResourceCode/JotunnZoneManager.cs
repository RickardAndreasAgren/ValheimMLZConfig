#region Assembly Jotunn, Version=2.22.0.0, Culture=neutral, PublicKeyToken=null
// D:\Spel\SteamLibrary\steamapps\common\Valheim\BepInEx\plugins\Jotunn\Jotunn.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers.MockSystem;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers
{
    //
    // Summary:
    //     Manager for adding custom Locations, Vegetation and Clutter.
    public class ZoneManager : IManager
    {
        private static class Patches
        {
            [HarmonyPatch(typeof(ZoneSystem), "SetupLocations")]
            [HarmonyPostfix]
            private static void ZoneSystem_SetupLocations(ZoneSystem __instance)
            {
                Instance.RegisterLocations(__instance);
                Instance.RegisterVegetation(__instance);
            }

            [HarmonyPatch(typeof(ClutterSystem), "Awake")]
            [HarmonyPostfix]
            private static void ClutterSystem_Awake(ClutterSystem __instance)
            {
                Instance.ClutterSystem_Awake(__instance);
            }
        }

        private static ZoneManager _instance;

        //
        // Summary:
        //     Container for custom locations in the DontDestroyOnLoad scene.
        internal GameObject LocationContainer;

        //
        // Summary:
        //     The singleton instance of this manager.
        public static ZoneManager Instance => _instance ?? (_instance = new ZoneManager());

        internal Dictionary<string, CustomLocation> Locations { get; } = new Dictionary<string, CustomLocation>();


        internal Dictionary<string, CustomVegetation> Vegetations { get; } = new Dictionary<string, CustomVegetation>();


        internal Dictionary<string, CustomClutter> Clutter { get; } = new Dictionary<string, CustomClutter>();


        //
        // Summary:
        //     Event that gets fired after the vanilla locations are in memory and available
        //     for cloning or editing. Your code will execute every time a new ZoneSystem is
        //     available. If you want to execute just once you will need to unregister from
        //     the event after execution.
        public static event Action OnVanillaLocationsAvailable;

        //
        // Summary:
        //     Event that gets fired after all Jotunn.Entities.CustomLocation are registered
        //     in the ZoneSystem. Your code will execute every time a new ZoneSystem is available.
        //     If you want to execute just once you will need to unregister from the event after
        //     execution.
        public static event Action OnLocationsRegistered;

        //
        // Summary:
        //     Event that gets fired after the vanilla clutter is in memory and available obtain.
        //     Your code will execute every time a new ClutterSystem is available. If you want
        //     to execute just once you will need to unregister from the event after execution.
        public static event Action OnVanillaClutterAvailable;

        //
        // Summary:
        //     Event that gets fired after all Jotunn.Entities.CustomClutter are registered
        //     in the ClutterSystem. Your code will execute every time a new ClutterSystem is
        //     available. If you want to execute just once you will need to unregister from
        //     the event after execution.
        public static event Action OnClutterRegistered;

        //
        // Summary:
        //     Event that gets fired after the vanilla vegetation is in memory and available
        //     obtain. Your code will execute every time a new ZoneSystem is available. If you
        //     want to execute just once you will need to unregister from the event after execution.
        public static event Action OnVanillaVegetationAvailable;

        //
        // Summary:
        //     Event that gets fired after all Jotunn.Entities.CustomVegetation are registered
        //     in the ZoneSystem. Your code will execute every time a new ZoneSystem is available.
        //     If you want to execute just once you will need to unregister from the event after
        //     execution.
        public static event Action OnVegetationRegistered;

        //
        // Summary:
        //     Hide .ctor
        private ZoneManager()
        {
        }

        static ZoneManager()
        {
            ((IManager)Instance).Init();
        }

        //
        // Summary:
        //     Initialize the manager
        void IManager.Init()
        {
            Main.LogInit("ZoneManager");
            LocationContainer = new GameObject("Locations");
            LocationContainer.transform.parent = Main.RootObject.transform;
            LocationContainer.SetActive(value: false);
            Main.Harmony.PatchAll(typeof(Patches));
            PrefabManager.Instance.Activate();
        }

        //
        // Summary:
        //     Return a Heightmap.Biome that matches any of the provided Biomes
        //
        // Parameters:
        //   biomes:
        //     Biomes that should match
        public static Heightmap.Biome AnyBiomeOf(params Heightmap.Biome[] biomes)
        {
            Heightmap.Biome biome = Heightmap.Biome.None;
            foreach (Heightmap.Biome biome2 in biomes)
            {
                biome |= biome2;
            }

            return biome;
        }

        //
        // Summary:
        //     Returns a list of all Heightmap.Biome that match biome
        //
        // Parameters:
        //   biome:
        public static List<Heightmap.Biome> GetMatchingBiomes(Heightmap.Biome biome)
        {
            List<Heightmap.Biome> list = new List<Heightmap.Biome>();
            foreach (Heightmap.Biome value in Enum.GetValues(typeof(Heightmap.Biome)))
            {
                if ((biome & value) != 0)
                {
                    list.Add(value);
                }
            }

            return list;
        }

        //
        // Summary:
        //     Create an empty GameObject that is disabled, so any Components in instantiated
        //     GameObjects will not start their lifecycle.
        //
        // Parameters:
        //   name:
        //     Name of the location
        //
        // Returns:
        //     Empty and hierarchy disabled GameObject
        public GameObject CreateLocationContainer(string name)
        {
            GameObject gameObject = new GameObject
            {
                name = name
            };
            gameObject.transform.SetParent(LocationContainer.transform);
            return gameObject;
        }

        //
        // Summary:
        //     Create a copy that is disabled, so any Components in instantiated child GameObjects
        //     will not start their lifecycle.
        //     Use this if you plan to alter your location prefab in code after importing it.
        //     Don't create a separate container if you won't alter the prefab afterwards as
        //     it creates a new instance for the container.
        //
        // Parameters:
        //   gameObject:
        //     Instantiated and hierarchy disabled location prefab
        public GameObject CreateLocationContainer(GameObject gameObject)
        {
            GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, LocationContainer.transform);
            gameObject2.name = gameObject.name;
            return gameObject2;
        }

        //
        // Summary:
        //     Loads and spawns a GameObject from an AssetBundle as a location container.
        //     The copy is disabled, so any Components in instantiated child GameObjects will
        //     not start their lifecycle.
        //     Use this if you plan to alter your location prefab in code after importing it.
        //     Don't create a separate container if you won't alter the prefab afterwards as
        //     it creates a new instance for the container.
        //
        // Parameters:
        //   assetBundle:
        //     A preloaded UnityEngine.AssetBundle
        //
        //   assetName:
        //     Name of the prefab in the bundle to be instantiated as the location cotainer
        public GameObject CreateLocationContainer(AssetBundle assetBundle, string assetName)
        {
            BepInPlugin bepInPlugin = BepInExUtils.GetPluginInfoFromAssembly(Assembly.GetCallingAssembly())?.Metadata;
            if (bepInPlugin == null || bepInPlugin.GUID == Main.Instance.Info.Metadata.GUID)
            {
                bepInPlugin = BepInExUtils.GetSourceModMetadata();
            }

            if (!AssetUtils.TryLoadPrefab(bepInPlugin, assetBundle, assetName, out var prefab))
            {
                Logger.LogError(bepInPlugin, "Failed to create location container for '" + assetName + "'");
                return null;
            }

            return CreateLocationContainer(prefab);
        }

        //
        // Summary:
        //     Create a copy that is disabled, so any Components in instantiated GameObjects
        //     will not start their lifecycle
        //
        // Parameters:
        //   gameObject:
        //     Prefab to copy
        //
        //   fixLocationReferences:
        //     Replace JVLmock GameObjects with a copy of their real prefab
        [Obsolete("Use CreateLocationContainer(GameObject) instead and define if references should be fixed in CustomLocation")]
        public GameObject CreateLocationContainer(GameObject gameObject, bool fixLocationReferences = false)
        {
            GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, LocationContainer.transform);
            gameObject2.name = gameObject.name;
            if (fixLocationReferences)
            {
                gameObject2.FixReferences(recursive: true);
            }

            return gameObject2;
        }

        //
        // Summary:
        //     Register a CustomLocation to be added to the ZoneSystem
        //
        // Parameters:
        //   customLocation:
        //
        // Returns:
        //     true if the custom location could be added to the manager
        public bool AddCustomLocation(CustomLocation customLocation)
        {
            if (Locations.ContainsKey(customLocation.Name))
            {
                Logger.LogWarning(customLocation.SourceMod, "Location " + customLocation.Name + " already exists");
                return false;
            }

            customLocation.Prefab.transform.SetParent(LocationContainer.transform);
            customLocation.Prefab.SetActive(value: true);
            Locations.Add(customLocation.Name, customLocation);
            return true;
        }

        //
        // Summary:
        //     Get a custom location by name.
        //
        // Parameters:
        //   name:
        //     Name of the location (normally the prefab name)
        //
        // Returns:
        //     The Jotunn.Entities.CustomLocation object with the given name if found
        public CustomLocation GetCustomLocation(string name)
        {
            return Locations[name];
        }

        //
        // Summary:
        //     Get a ZoneLocation by its name.
        //     Search hierarchy:
        //     1. Custom Location with the exact name
        //     2. Vanilla Location with the exact name from ZoneSystem
        //
        // Parameters:
        //   name:
        //     Name of the ZoneLocation to search for.
        //
        // Returns:
        //     The existing ZoneLocation, or null if none exists with given name
        public ZoneSystem.ZoneLocation GetZoneLocation(string name)
        {
            if (Locations.TryGetValue(name, out var value))
            {
                return value.ZoneLocation;
            }

            int stableHashCode = name.GetStableHashCode();
            if ((bool)ZoneSystem.instance && ZoneSystem.instance.m_locationsByHash.TryGetValue(stableHashCode, out var value2))
            {
                return value2;
            }

            return null;
        }

        //
        // Summary:
        //     Create a CustomLocation that is a deep copy of the original.
        //     Changes will not affect the original. The CustomLocation is already registered
        //     in the manager.
        //
        // Parameters:
        //   name:
        //     name of the custom location
        //
        //   baseName:
        //     name of the existing location to copy
        //
        // Returns:
        //     A CustomLocation object with the cloned location prefab
        public CustomLocation CreateClonedLocation(string name, string baseName)
        {
            //IL_000e: Unknown result type (might be due to invalid IL or missing references)
            ZoneSystem.ZoneLocation zoneLocation = GetZoneLocation(baseName);
            zoneLocation.m_prefab.Load();
            GameObject exteriorPrefab = AssetManager.Instance.ClonePrefab(zoneLocation.m_prefab.get_Asset(), name, LocationContainer.transform);
            CustomLocation customLocation = new CustomLocation(exteriorPrefab, fixReference: false, new LocationConfig(zoneLocation));
            AddCustomLocation(customLocation);
            zoneLocation.m_prefab.Release();
            return customLocation;
        }

        //
        // Summary:
        //     Remove a CustomLocation by its name.
        //     Removes the CustomLocation from the manager. Does not remove the location from
        //     any current ZoneSystem instance.
        //
        // Parameters:
        //   name:
        //     Name of the CustomLocation to search for.
        public bool RemoveCustomLocation(string name)
        {
            return Locations.Remove(name);
        }

        //
        // Summary:
        //     Destroy a CustomLocation by its name.
        //     Removes the CustomLocation from the manager and from the ZoneSystem if instantiated.
        //
        // Parameters:
        //   name:
        //     Name of the CustomLocation to search for.
        public bool DestroyCustomLocation(string name)
        {
            if (!Locations.TryGetValue(name, out var value))
            {
                return false;
            }

            int stableHashCode = name.GetStableHashCode();
            if ((bool)ZoneSystem.instance && ZoneSystem.instance.m_locationsByHash.TryGetValue(stableHashCode, out var value2))
            {
                ZoneSystem.instance.m_locationsByHash.Remove(stableHashCode);
                ZoneSystem.instance.m_locations.Remove(value2);
            }

            if ((bool)value.Prefab)
            {
                UnityEngine.Object.Destroy(value.Prefab);
            }

            return Locations.Remove(name);
        }

        //
        // Summary:
        //     Register a CustomVegetation to be added to the ZoneSystem
        //
        // Parameters:
        //   customVegetation:
        public bool AddCustomVegetation(CustomVegetation customVegetation)
        {
            if (!customVegetation.IsValid())
            {
                return false;
            }

            if (!PrefabManager.Instance.AddPrefab(customVegetation.Prefab, customVegetation.SourceMod))
            {
                return false;
            }

            Vegetations.Add(customVegetation.Name, customVegetation);
            return true;
        }

        //
        // Summary:
        //     Get a ZoneVegetation by its name.
        //     Search hierarchy:
        //     1. Custom Vegetation with the exact name
        //     2. Vanilla Vegetation with the exact name from ZoneSystem
        //
        // Parameters:
        //   name:
        //     Name of the ZoneVegetation to search for.
        //
        // Returns:
        //     The existing ZoneVegetation, or null if none exists with given name
        public ZoneSystem.ZoneVegetation GetZoneVegetation(string name)
        {
            if (Vegetations.TryGetValue(name, out var value))
            {
                return value.Vegetation;
            }

            return ZoneSystem.instance.m_vegetation.DefaultIfEmpty(null).FirstOrDefault((ZoneSystem.ZoneVegetation zv) => (bool)zv.m_prefab && zv.m_prefab.name == name);
        }

        //
        // Summary:
        //     Remove a CustomVegetation from this manager by its name.
        //     Does not remove it from any current ZoneSystem instance.
        //
        // Parameters:
        //   name:
        //     Name of the CustomVegetation to search for.
        public bool RemoveCustomVegetation(string name)
        {
            return Vegetations.Remove(name);
        }

        //
        // Summary:
        //     Register a CustomClutter to be added to the ClutterSystem
        //
        // Parameters:
        //   customClutter:
        public bool AddCustomClutter(CustomClutter customClutter)
        {
            if (!customClutter.IsValid())
            {
                Logger.LogWarning(customClutter.SourceMod, $"Custom clutter '{customClutter}' is not valid");
                return false;
            }

            if (Clutter.ContainsKey(customClutter.Name))
            {
                return false;
            }

            Clutter.Add(customClutter.Name, customClutter);
            return true;
        }

        //
        // Summary:
        //     Get a Clutter by its name.
        //     Search hierarchy:
        //     1. Custom Clutter with the exact name
        //     2. Vanilla Clutter with the exact name from ClutterSystem
        //
        // Parameters:
        //   name:
        //     Name of the Clutter to search for.
        //
        // Returns:
        //     The existing Clutter, or null if none exists with given name
        public ClutterSystem.Clutter GetClutter(string name)
        {
            if (Clutter.TryGetValue(name, out var value))
            {
                return value.Clutter;
            }

            if (!ClutterSystem.instance)
            {
                return null;
            }

            return ClutterSystem.instance.m_clutter.DefaultIfEmpty(null).FirstOrDefault((ClutterSystem.Clutter zv) => zv?.m_name == name);
        }

        //
        // Summary:
        //     Remove a CustomClutter from this manager by its name.
        //     Does not remove it from any current ClutterSystem instance.
        //
        // Parameters:
        //   name:
        //     Name of the CustomClutter to search for.
        public bool RemoveCustomClutter(string name)
        {
            return Clutter.Remove(name);
        }

        private void ClutterSystem_Awake(ClutterSystem instance)
        {
            InvokeOnVanillaClutterAvailable();
            if (Clutter.Count > 0)
            {
                Logger.LogInfo($"Injecting {Clutter.Count} custom clutter");
                List<string> list = new List<string>();
                foreach (CustomClutter value in Clutter.Values)
                {
                    try
                    {
                        if (value.FixReference)
                        {
                            value.Prefab.FixReferences(recursive: true);
                            value.FixReference = false;
                        }

                        instance.m_clutter.Add(value.Clutter);
                    }
                    catch (MockResolveException ex)
                    {
                        Logger.LogWarning(value?.SourceMod, $"Skipping clutter {value}: {ex.Message}");
                        list.Add(value.Name);
                    }
                    catch (Exception arg)
                    {
                        Logger.LogWarning(value?.SourceMod, $"Exception caught while adding clutter: {arg}");
                        list.Add(value.Name);
                    }
                }

                foreach (string item in list)
                {
                    Clutter.Remove(item);
                }
            }

            InvokeOnClutterRegistered();
        }

        private void RegisterLocations(ZoneSystem self)
        {
            InvokeOnVanillaLocationsAvailable();
            if (Locations.Count > 0)
            {
                List<string> list = new List<string>();
                Logger.LogInfo($"Injecting {Locations.Count} custom locations");
                foreach (CustomLocation value in Locations.Values)
                {
                    try
                    {
                        Logger.LogDebug(string.Format("Adding custom location {0} in {1}", value, string.Join(", ", GetMatchingBiomes(value.ZoneLocation.m_biome))));
                        if (value.FixReference)
                        {
                            value.Prefab.FixReferences(recursive: true);
                            value.FixReference = false;
                        }

                        ZoneSystem.ZoneLocation zoneLocation = value.ZoneLocation;
                        RegisterLocationInZoneSystem(self, zoneLocation, value.SourceMod);
                    }
                    catch (MockResolveException ex)
                    {
                        Logger.LogWarning(value?.SourceMod, $"Skipping location {value}: {ex.Message}");
                        list.Add(value.Name);
                    }
                    catch (Exception arg)
                    {
                        Logger.LogWarning(value?.SourceMod, $"Exception caught while adding location: {arg}");
                        list.Add(value.Name);
                    }
                }

                foreach (string item in list)
                {
                    Locations.Remove(item);
                }
            }

            InvokeOnLocationsRegistered();
        }

        private void RegisterVegetation(ZoneSystem self)
        {
            InvokeOnVanillaVegetationAvailable();
            if (Vegetations.Count > 0)
            {
                List<string> list = new List<string>();
                Logger.LogInfo($"Injecting {Vegetations.Count} custom vegetation");
                foreach (CustomVegetation value in Vegetations.Values)
                {
                    try
                    {
                        Logger.LogDebug(string.Format("Adding custom vegetation {0} in {1}", value, string.Join(", ", GetMatchingBiomes(value.Vegetation.m_biome))));
                        if (value.FixReference)
                        {
                            value.Prefab.FixReferences(recursive: true);
                            value.FixReference = false;
                        }

                        self.m_vegetation.Add(value.Vegetation);
                    }
                    catch (MockResolveException ex)
                    {
                        Logger.LogWarning(value?.SourceMod, $"Skipping vegetation {value}: {ex.Message}");
                        list.Add(value.Name);
                    }
                    catch (Exception arg)
                    {
                        Logger.LogWarning(value?.SourceMod, $"Exception caught while adding vegetation: {arg}");
                        list.Add(value.Name);
                    }
                }

                foreach (string item in list)
                {
                    Vegetations.Remove(item);
                }
            }

            InvokeOnVegetationRegistered();
        }

        //
        // Summary:
        //     Register a single ZoneLocaton in the current ZoneSystem. Also adds the location
        //     prefabs to the Jotunn.Managers.PrefabManager and ZNetScene if necessary.
        //     No mock references are fixed.
        //
        // Parameters:
        //   zoneLocation:
        //     ZoneSystem.ZoneLocation to add to the ZoneSystem
        public void RegisterLocationInZoneSystem(ZoneSystem.ZoneLocation zoneLocation)
        {
            RegisterLocationInZoneSystem(ZoneSystem.instance, zoneLocation, BepInExUtils.GetSourceModMetadata());
        }

        //
        // Summary:
        //     Internal method for adding a ZoneLocation to a specific ZoneSystem.
        //
        // Parameters:
        //   zoneSystem:
        //     ZoneSystem the location should be added to
        //
        //   zoneLocation:
        //     ZoneSystem.ZoneLocation to add
        //
        //   sourceMod:
        //     BepInEx.BepInPlugin which created the location
        private void RegisterLocationInZoneSystem(ZoneSystem zoneSystem, ZoneSystem.ZoneLocation zoneLocation, BepInPlugin sourceMod)
        {
            //IL_0006: Unknown result type (might be due to invalid IL or missing references)
            zoneLocation.m_prefab.Load();
            ZNetView[] enabledComponentsInChildren = global::Utils.GetEnabledComponentsInChildren<ZNetView>(zoneLocation.m_prefab.get_Asset());
            foreach (ZNetView zNetView in enabledComponentsInChildren)
            {
                string prefabName = zNetView.GetPrefabName();
                if (!ZNetScene.instance.m_namedPrefabs.ContainsKey(prefabName.GetStableHashCode()))
                {
                    GameObject gameObject = UnityEngine.Object.Instantiate(zNetView.gameObject, PrefabManager.Instance.PrefabContainer.transform);
                    gameObject.name = prefabName;
                    CustomPrefab customPrefab = new CustomPrefab(gameObject, sourceMod);
                    PrefabManager.Instance.AddPrefab(customPrefab);
                    PrefabManager.Instance.RegisterToZNetScene(customPrefab.Prefab);
                }
            }

            RandomSpawn[] enabledComponentsInChildren2 = global::Utils.GetEnabledComponentsInChildren<RandomSpawn>(zoneLocation.m_prefab.get_Asset());
            RandomSpawn[] array = enabledComponentsInChildren2;
            foreach (RandomSpawn randomSpawn in array)
            {
                randomSpawn.Prepare();
            }

            foreach (ZNetView item in enabledComponentsInChildren2.SelectMany((RandomSpawn x) => x.m_childNetViews))
            {
                string prefabName2 = item.GetPrefabName();
                if (!ZNetScene.instance.m_namedPrefabs.ContainsKey(prefabName2.GetStableHashCode()))
                {
                    GameObject gameObject2 = UnityEngine.Object.Instantiate(item.gameObject, PrefabManager.Instance.PrefabContainer.transform);
                    gameObject2.name = prefabName2;
                    CustomPrefab customPrefab2 = new CustomPrefab(gameObject2, sourceMod);
                    PrefabManager.Instance.AddPrefab(customPrefab2);
                    PrefabManager.Instance.RegisterToZNetScene(customPrefab2.Prefab);
                }
            }

            if (!zoneSystem.m_locationsByHash.ContainsKey(zoneLocation.Hash))
            {
                zoneSystem.m_locationsByHash.Add(zoneLocation.Hash, zoneLocation);
                zoneSystem.m_locations.Add(zoneLocation);
            }

            zoneLocation.m_prefab.Release();
        }

        private static void InvokeOnVanillaLocationsAvailable()
        {
            ZoneManager.OnVanillaLocationsAvailable?.SafeInvoke();
        }

        private static void InvokeOnLocationsRegistered()
        {
            ZoneManager.OnLocationsRegistered?.SafeInvoke();
        }

        private static void InvokeOnVanillaVegetationAvailable()
        {
            ZoneManager.OnVanillaVegetationAvailable?.SafeInvoke();
        }

        private static void InvokeOnVegetationRegistered()
        {
            ZoneManager.OnVegetationRegistered?.SafeInvoke();
        }

        private static void InvokeOnVanillaClutterAvailable()
        {
            ZoneManager.OnVanillaClutterAvailable?.SafeInvoke();
        }

        private static void InvokeOnClutterRegistered()
        {
            ZoneManager.OnClutterRegistered?.SafeInvoke();
        }
    }
}