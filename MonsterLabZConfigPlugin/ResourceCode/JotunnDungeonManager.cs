
using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers.MockSystem;
using Jotunn.Utils;
using UnityEngine;

namespace Jotunn.Managers
{
    //
    // Summary:
    //     Manager for handling all custom data added to the game related to creatures.
    public class DungeonManager : IManager
    {
        private static class Patches
        {
            [HarmonyPatch(typeof(ZoneSystem), "SetupLocations")]
            [HarmonyPrefix]
            private static void OnBeforeZoneSystemSetupLocations()
            {
                Instance.OnZoneSystemSetupLocations();
            }

            [HarmonyPatch(typeof(DungeonDB), "Start")]
            [HarmonyPostfix]
            private static void OnDungeonDBStarted()
            {
                Instance.OnDungeonDBStarted();
            }

            [HarmonyPatch(typeof(DungeonDB), "GetRoom")]
            [HarmonyPrefix]
            private static bool OnDungeonDBGetRoom(int hash, ref DungeonDB.RoomData __result)
            {
                DungeonDB.RoomData roomData = Instance.OnDungeonDBGetRoom(hash);
                if (roomData != null)
                {
                    __result = roomData;
                    return false;
                }

                return true;
            }

            [HarmonyPatch(typeof(DungeonGenerator), "SetupAvailableRooms")]
            [HarmonyPostfix]
            private static void OnDungeonGeneratorSetupAvailableRooms(DungeonGenerator __instance)
            {
                Instance.OnDungeonGeneratorSetupAvailableRooms(__instance);
            }
        }

        private static DungeonManager _instance;

        //
        // Summary:
        //     Internal dictionary of all custom rooms
        internal readonly Dictionary<string, CustomRoom> Rooms = new Dictionary<string, CustomRoom>();

        private readonly Dictionary<int, string> hashToName = new Dictionary<int, string>();

        private readonly List<string> themeList = new List<string>();

        private readonly Dictionary<string, GameObject> loadedEnvironments = new Dictionary<string, GameObject>();

        //
        // Summary:
        //     Container for Jötunn's DungeonRooms in the DontDestroyOnLoad scene.
        private GameObject DungeonRoomContainer;

        //
        // Summary:
        //     The singleton instance of this manager.
        public static DungeonManager Instance => _instance ?? (_instance = new DungeonManager());

        //
        // Summary:
        //     Event that gets fired after the vanilla DungeonDB has loaded rooms. Your code
        //     will execute every time a main scene is started (on joining a game).
        //     If you want to execute just once you will need to unregister from the event after
        //     execution.
        public static event Action OnVanillaRoomsAvailable;

        //
        // Summary:
        //     Event that gets fired after all custom rooms are registered to the DungeonDB.
        //     Your code will execute every time a main scene is started (on joining a game).
        //     If you want to execute just once you will need to unregister from the event after
        //     execution.
        public static event Action OnRoomsRegistered;

        //
        // Summary:
        //     Hide .ctor
        private DungeonManager()
        {
        }

        static DungeonManager()
        {
            ((IManager)Instance).Init();
        }

        //
        // Summary:
        //     Creates the spawner container and registers all hooks.
        void IManager.Init()
        {
            Main.LogInit("DungeonManager");
            DungeonRoomContainer = new GameObject("DungeonRooms");
            DungeonRoomContainer.transform.parent = Main.RootObject.transform;
            DungeonRoomContainer.SetActive(value: false);
            Main.Harmony.PatchAll(typeof(Patches));
        }

        //
        // Summary:
        //     Add a Jotunn.Entities.CustomRoom to the game.
        //     Checks if the custom room is valid and unique and adds it to the list of custom
        //     rooms.
        //
        // Parameters:
        //   customRoom:
        //     The custom Room to add.
        //
        // Returns:
        //     true if the custom Room was added to the manager.
        public bool AddCustomRoom(CustomRoom customRoom)
        {
            if (customRoom == null)
            {
                throw new ArgumentException("Cannot be null", "customRoom");
            }

            if (string.IsNullOrEmpty(customRoom.ThemeName))
            {
                throw new ArgumentException("ThemeName of this room must have a value.", "customRoom");
            }

            if (!CustomRoom.IsVanillaTheme(customRoom.ThemeName) && !themeList.Contains(customRoom.ThemeName))
            {
                throw new ArgumentException("ThemeName of this room (" + customRoom.ThemeName + ") match a vanilla Room.Theme value or must be registered.", "customRoom");
            }

            if (Rooms.ContainsKey(customRoom.Name))
            {
                Logger.LogWarning(customRoom.SourceMod, "Room " + customRoom.Name + " already exists");
                return false;
            }

            customRoom.Prefab.transform.SetParent(DungeonRoomContainer.transform);
            customRoom.Prefab.SetActive(value: true);
            Rooms.Add(customRoom.Name, customRoom);
            return true;
        }

        //
        // Summary:
        //     Get a custom room by its name.
        //
        // Parameters:
        //   name:
        //     Name of the custom room to search.
        //
        // Returns:
        //     The Jotunn.Entities.CustomRoom if found.
        public CustomRoom GetRoom(string name)
        {
            if (!Rooms.TryGetValue(name, out var value))
            {
                return null;
            }

            return value;
        }

        //
        // Summary:
        //     Remove a custom room by its name.
        //
        // Parameters:
        //   name:
        //     Name of the room to remove.
        public bool RemoveRoom(string name)
        {
            return Rooms.Remove(name);
        }

        //
        // Summary:
        //     Registers a new dungeon theme, identified by a unique theme name string.
        //     Assets can be added at any time and will be registered as soon as the vanilla
        //     loader is ready.
        //
        // Parameters:
        //   prefab:
        //     The DungeonGenerator prefab.
        //
        //   themeName:
        //     The name of the theme to register.
        //
        // Returns:
        //     True if theme is successfullly registered, otherwise false.
        public bool RegisterDungeonTheme(GameObject prefab, string themeName)
        {
            Logger.LogDebug("RegisterDungeonTheme called with prefab " + prefab.name + " and themeName " + themeName + ".");
            if (prefab == null)
            {
                throw new ArgumentException("Cannot be null", "prefab");
            }

            if (string.IsNullOrEmpty(themeName))
            {
                throw new ArgumentException("Cannot be null or empty", "themeName");
            }

            DungeonGenerator componentInChildren = prefab.GetComponentInChildren<DungeonGenerator>();
            if (componentInChildren == null)
            {
                Logger.LogError("Cannot find DungeonGenerator component in prefab " + prefab.name + ".");
                throw new ArgumentException("Prefab must contain a DungeonGenerator component", "prefab");
            }

            if (componentInChildren.gameObject.TryGetComponent<DungeonGeneratorTheme>(out var component))
            {
                if (!string.IsNullOrEmpty(component.m_themeName) && component.m_themeName != themeName)
                {
                    Logger.LogWarning("Overwriting existing theme name " + component.m_themeName + " with " + themeName + ".");
                }
            }
            else
            {
                component = componentInChildren.gameObject.AddComponent<DungeonGeneratorTheme>();
            }

            component.m_themeName = themeName;
            themeList.Add(themeName);
            return true;
        }

        //
        // Summary:
        //     Adds a new environment prefab to be registered when ZoneSystem.SetupLocations
        //     runs.
        //     If you intend to use a custom interior environment Location.m_interiorEnvironment,
        //     this method enables you to provide a prefab with an appropriately configured
        //     LocationList containing atleast one EnvSetup within LocationList.m_environments.
        //
        // Parameters:
        //   assetBundle:
        //     The UnityEngine.AssetBundle containing the prefab.
        //
        //   prefabName:
        //     The name of the prefab to register.
        public void RegisterEnvironment(AssetBundle assetBundle, string prefabName)
        {
            if (assetBundle == null)
            {
                throw new ArgumentException("Cannot be null", "assetBundle");
            }

            if (string.IsNullOrEmpty(prefabName))
            {
                throw new ArgumentException("Cannot be null or empty", "prefabName");
            }

            GameObject value = assetBundle.LoadAsset<GameObject>(prefabName);
            loadedEnvironments.Add(prefabName, value);
        }

        private void GenerateHashes()
        {
            hashToName.Clear();
            foreach (CustomRoom value in Rooms.Values)
            {
                int stableHashCode = value.Prefab.name.GetStableHashCode();
                if (hashToName.ContainsKey(stableHashCode))
                {
                    Logger.LogWarning($"Room {value.Name} is already registered with hash {stableHashCode}");
                }
                else
                {
                    hashToName.Add(stableHashCode, value.Name);
                }
            }
        }

        private void OnZoneSystemSetupLocations()
        {
            if (loadedEnvironments.Count <= 0)
            {
                return;
            }

            foreach (KeyValuePair<string, GameObject> loadedEnvironment in loadedEnvironments)
            {
                Logger.LogDebug("Registering environment " + loadedEnvironment.Key + ".");
                GameObject value = loadedEnvironment.Value;
                value.FixReferences(recursive: true);
                UnityEngine.Object.Instantiate(value);
            }
        }

        private void OnDungeonDBStarted()
        {
            InvokeOnVanillaRoomsAvailable();
            if (Rooms.Count > 0)
            {
                hashToName.Clear();
                List<string> list = new List<string>();
                Logger.LogInfo($"Registering {Rooms.Count} custom rooms");
                foreach (CustomRoom value in Rooms.Values)
                {
                    try
                    {
                        Logger.LogDebug("Adding custom room " + value.Name + " with " + value.ThemeName + " theme");
                        if (value.FixReference)
                        {
                            value.Prefab.FixReferences(recursive: true);
                            value.FixReference = false;
                        }

                        if (CustomRoom.IsVanillaTheme(value.ThemeName))
                        {
                            RegisterRoomInDungeonDB(value);
                        }
                    }
                    catch (MockResolveException ex)
                    {
                        Logger.LogWarning(value.SourceMod, $"Skipping Room {value}: could not resolve mock {ex.MockType.Name} {ex.FailedMockName}");
                        list.Add(value.Name);
                    }
                    catch (Exception arg)
                    {
                        Logger.LogWarning(value.SourceMod, $"Exception caught while adding Room: {arg}");
                        list.Add(value.Name);
                    }
                }

                foreach (string item in list)
                {
                    Rooms.Remove(item);
                }

                DungeonDB.instance.GenerateHashList();
                GenerateHashes();
            }

            InvokeOnRoomsRegistered();
        }

        private void OnDungeonGeneratorSetupAvailableRooms(DungeonGenerator self)
        {
            DungeonGeneratorTheme proxy = self.gameObject.GetComponent<DungeonGeneratorTheme>();
            if (DungeonGenerator.m_availableRooms == null)
            {
                return;
            }

            if (proxy != null)
            {
                Logger.LogDebug($"Found DungeonGeneratorTheme component in prefab with name {self.gameObject}");
                Logger.LogDebug("This dungeon generator has a custom theme = " + proxy.m_themeName + ", adding available rooms");
                IEnumerable<CustomRoom> enumerable = from r in Rooms.Values
                                                     where r.Room.m_enabled
                                                     where r.ThemeName == proxy.m_themeName
                                                     select r;
                foreach (CustomRoom item in enumerable)
                {
                    Logger.LogDebug("Adding Room with name " + item.Name + " and theme " + item.ThemeName);
                    DungeonGenerator.m_availableRooms.Add(item.RoomData);
                }
            }
            else if (self.m_themes != 0)
            {
                Logger.LogDebug($"No DungeonGeneratorTheme component in prefab with name {self.gameObject}");
                Logger.LogDebug($"Adding additional rooms of type {self.m_themes} to available rooms");
                IEnumerable<CustomRoom> enumerable2 = Rooms.Values.Where((CustomRoom r) => r.Room.m_enabled).Where(delegate (CustomRoom r)
                {
                    if (!Enum.TryParse<Room.Theme>(r.ThemeName, ignoreCase: false, out var result))
                    {
                        return false;
                    }

                    return result != 0 && self.m_themes.HasFlag(result);
                });
                foreach (CustomRoom item2 in enumerable2)
                {
                    Logger.LogDebug("Adding Room with name " + item2.Name + " and theme " + item2.ThemeName);
                    DungeonGenerator.m_availableRooms.Add(item2.RoomData);
                }
            }
            else
            {
                Logger.LogWarning("DungeonManager's SetupAvailableRooms was invoked without a valid DungeonGeneratorTheme or DungeonGenerator.m_themes value. Something may be wrong with " + self.name + "'s generator.");
            }

            if (DungeonGenerator.m_availableRooms.Count <= 0)
            {
                Logger.LogDebug("DungeonManager's SetupAvailableRooms yielded zero rooms.");
            }
        }

        private void InvokeOnVanillaRoomsAvailable()
        {
            DungeonManager.OnVanillaRoomsAvailable?.SafeInvoke();
        }

        private void InvokeOnRoomsRegistered()
        {
            DungeonManager.OnRoomsRegistered?.SafeInvoke();
        }

        private void RegisterRoomInDungeonDB(CustomRoom room)
        {
            DungeonDB.instance.m_rooms.Add(room.RoomData);
        }

        //
        // Summary:
        //     Attempt to get room by hash.
        //
        // Parameters:
        //   hash:
        private DungeonDB.RoomData OnDungeonDBGetRoom(int hash)
        {
            if (hashToName.TryGetValue(hash, out var value) && Rooms.TryGetValue(value, out var value2))
            {
                return value2.RoomData;
            }

            return null;
        }
    }
}