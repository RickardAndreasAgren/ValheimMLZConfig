
using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers.MockSystem;
using SoftReferenceableAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jotunn.Managers
{
    //
    // Summary:
    //     Manager for handling custom prefabs added to the game.
    public class PrefabManager : IManager
    {
        private static class Patches
        {
            [HarmonyPatch(typeof(ZNetScene), "Awake")]
            [HarmonyPostfix]
            private static void RegisterAllToZNetScene()
            {
                Instance.RegisterAllToZNetScene();
            }

            [HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
            [HarmonyPrefix]
            [HarmonyPriority(0)]
            private static void InvokeOnVanillaObjectsAvailable(ObjectDB other)
            {
                Instance.MenuObjectDB = other;
                Instance.InvokeOnVanillaObjectsAvailable();
            }

            [HarmonyPatch(typeof(ZNetScene), "Awake")]
            [HarmonyPostfix]
            [HarmonyPriority(0)]
            private static void InvokeOnPrefabsRegistered()
            {
                Instance.InvokeOnPrefabsRegistered();
            }

            [HarmonyPatch(typeof(ZoneSystem), "SetupLocations")]
            [HarmonyPrefix]
            [HarmonyPriority(600)]
            private static void ZoneSystem_ClearPrefabCache(ZoneSystem __instance)
            {
                Cache.Clear();
            }
        }

        //
        // Summary:
        //     Global cache of Unity Objects by asset name.
        //     Built on first access of every type and is cleared on scene change.
        public static class Cache
        {
            private static readonly Dictionary<Type, Dictionary<string, UnityEngine.Object>> dictionaryCache = new Dictionary<Type, Dictionary<string, UnityEngine.Object>>();

            //
            // Summary:
            //     Get an instance of an Unity Object from the current scene with the given name.
            //
            // Parameters:
            //   type:
            //     System.Type to search for.
            //
            //   name:
            //     Name of the actual object to search for.
            public static UnityEngine.Object GetPrefab(Type type, string name)
            {
                //IL_0013: Unknown result type (might be due to invalid IL or missing references)
                //IL_0018: Unknown result type (might be due to invalid IL or missing references)
                //IL_0024: Unknown result type (might be due to invalid IL or missing references)
                if (AssetManager.Instance.IsReady())
                {
                    SoftReference<UnityEngine.Object> softReference = AssetManager.Instance.GetSoftReference(type, name);
                    if (softReference.get_IsValid())
                    {
                        softReference.Load();
                        if ((bool)softReference.get_Asset())
                        {
                            if (softReference.get_Asset().GetType() == type)
                            {
                                return softReference.get_Asset();
                            }

                            GameObject gameObject = softReference.get_Asset() as GameObject;
                            if ((object)gameObject != null && TryFindAssetInSelfOrChildComponents(gameObject, type, out var asset))
                            {
                                return asset;
                            }
                        }
                    }
                }

                if (GetCachedMap(type).TryGetValue(name, out var value))
                {
                    return value;
                }

                return null;
            }

            //
            // Summary:
            //     Get an instance of an Unity Object from the current scene by name.
            //
            // Parameters:
            //   name:
            //
            // Type parameters:
            //   T:
            public static T GetPrefab<T>(string name) where T : UnityEngine.Object
            {
                return (T)GetPrefab(typeof(T), name);
            }

            //
            // Summary:
            //     Get all instances of an Unity Object from the current scene by type.
            //
            // Parameters:
            //   type:
            //     System.Type to search for.
            public static Dictionary<string, UnityEngine.Object> GetPrefabs(Type type)
            {
                return GetCachedMap(type);
            }

            private static Transform GetParent(UnityEngine.Object obj)
            {
                return (obj as GameObject)?.transform.parent;
            }

            //
            // Summary:
            //     Determines the best matching asset for a given name. Only one asset can be associated
            //     with a name, this ties to find the best match if there is already a cached one
            //     present.
            //
            // Parameters:
            //   map:
            //
            //   newObject:
            //
            //   name:
            private static UnityEngine.Object FindBestAsset(IDictionary<string, UnityEngine.Object> map, UnityEngine.Object newObject, string name)
            {
                if (!map.TryGetValue(name, out var value))
                {
                    return newObject;
                }

                if (name == "_NetScene")
                {
                    GameObject gameObject = value as GameObject;
                    if ((object)gameObject != null)
                    {
                        GameObject gameObject2 = newObject as GameObject;
                        if ((object)gameObject2 != null && !gameObject.activeInHierarchy && gameObject2.activeInHierarchy)
                        {
                            return gameObject2;
                        }
                    }
                }

                Material material = value as Material;
                if ((object)material != null)
                {
                    Material material2 = newObject as Material;
                    if ((object)material2 != null && FindBestMaterial(material, material2, out var material3))
                    {
                        return material3;
                    }
                }

                bool flag = GetParent(value);
                bool flag2 = GetParent(newObject);
                if (!flag && flag2)
                {
                    return value;
                }

                if (flag)
                {
                    return newObject;
                }

                return newObject;
            }

            private static bool FindBestMaterial(Material cachedMaterial, Material newMaterial, out UnityEngine.Object material)
            {
                string name = cachedMaterial.shader.name;
                string name2 = newMaterial.shader.name;
                if (name == "Hidden/InternalErrorShader" && name2 != "Hidden/InternalErrorShader")
                {
                    material = newMaterial;
                    return true;
                }

                if (name != "Hidden/InternalErrorShader" && name2 == "Hidden/InternalErrorShader")
                {
                    material = cachedMaterial;
                    return true;
                }

                material = null;
                return false;
            }

            private static Dictionary<string, UnityEngine.Object> GetCachedMap(Type type)
            {
                if (dictionaryCache.TryGetValue(type, out var value))
                {
                    return value;
                }

                return InitCache(type);
            }

            private static Dictionary<string, UnityEngine.Object> InitCache(Type type)
            {
                Dictionary<string, UnityEngine.Object> dictionary = new Dictionary<string, UnityEngine.Object>();
                UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(type);
                foreach (UnityEngine.Object @object in array)
                {
                    string name = @object.name;
                    dictionary[name] = FindBestAsset(dictionary, @object, name);
                }

                dictionaryCache[type] = dictionary;
                return dictionary;
            }

            //
            // Summary:
            //     Clears the entire cache, resulting in a rebuilt on the next access.
            //     This can be useful if an asset is loaded late after a scene change and might
            //     be missing in the cache. Rebuilding can be an expensive operation, so use with
            //     caution.
            public static void Clear()
            {
                dictionaryCache.Clear();
            }

            //
            // Summary:
            //     Clears the cache for a specific type, resulting in a rebuilt on the next access.
            //     This can be useful if an asset is loaded late after a scene change and might
            //     be missing in the cache. Rebuilding can be an expensive operation, so use with
            //     caution.
            //
            // Type parameters:
            //   T:
            //     The type of object to clear the cache for
            public static void Clear<T>() where T : UnityEngine.Object
            {
                dictionaryCache.Remove(typeof(T));
            }
        }

        private static PrefabManager _instance;

        //
        // Summary:
        //     The singleton instance of this manager.
        public static PrefabManager Instance => _instance ?? (_instance = new PrefabManager());

        //
        // Summary:
        //     Container for custom prefabs in the DontDestroyOnLoad scene.
        internal GameObject PrefabContainer { get; private set; }

        //
        // Summary:
        //     Dictionary of all added custom prefabs by name hash.
        internal Dictionary<string, CustomPrefab> Prefabs { get; } = new Dictionary<string, CustomPrefab>();


        internal ObjectDB MenuObjectDB { get; private set; }

        //
        // Summary:
        //     Event that gets fired after the vanilla prefabs are in memory and available for
        //     cloning. Your code will execute every time before a new ObjectDB is copied (on
        //     every menu start). If you want to execute just once you will need to unregister
        //     from the event after execution.
        public static event Action OnVanillaPrefabsAvailable;

        //
        // Summary:
        //     Event that gets fired after registering all custom prefabs to ZNetScene. Your
        //     code will execute every time a new ZNetScene is created (on every game start).
        //     If you want to execute just once you will need to unregister from the event after
        //     execution.
        public static event Action OnPrefabsRegistered;

        //
        // Summary:
        //     Hide .ctor
        private PrefabManager()
        {
        }

        static PrefabManager()
        {
            ((IManager)Instance).Init();
        }

        //
        // Summary:
        //     Creates the prefab container and registers all hooks.
        void IManager.Init()
        {
            Main.LogInit("PrefabManager");
            PrefabContainer = new GameObject("Prefabs");
            PrefabContainer.transform.parent = Main.RootObject.transform;
            PrefabContainer.SetActive(value: false);
            Main.Harmony.PatchAll(typeof(Patches));
            SceneManager.sceneUnloaded += delegate
            {
                Cache.Clear();
                Instance.MenuObjectDB = null;
            };
        }

        //
        // Summary:
        //     Makes sure the PrefabManager initializes. Only needed if timing is important.
        internal void Activate()
        {
        }

        //
        // Summary:
        //     Add a custom prefab to the manager with known source mod metadata. Don't fix
        //     references.
        //
        // Parameters:
        //   prefab:
        //     Prefab to add
        //
        //   sourceMod:
        //     Metadata of the mod adding this prefab
        //
        // Returns:
        //     true if the custom prefab was added to the manager.
        internal bool AddPrefab(GameObject prefab, BepInPlugin sourceMod)
        {
            CustomPrefab customPrefab = new CustomPrefab(prefab, sourceMod);
            AddPrefab(customPrefab);
            return Prefabs.ContainsKey(prefab.name);
        }

        //
        // Summary:
        //     Add a custom prefab to the manager.
        //     Checks if a prefab with the same name is already added.
        //     Added prefabs get registered to the ZNetScene on ZNetScene.Awake.
        //
        // Parameters:
        //   prefab:
        //     Prefab to add
        public void AddPrefab(GameObject prefab)
        {
            CustomPrefab customPrefab = new CustomPrefab(prefab, fixReference: false);
            AddPrefab(customPrefab);
        }

        //
        // Summary:
        //     Add a custom prefab to the manager.
        //     Checks if a prefab with the same name is already added.
        //     Added prefabs get registered to the ZNetScene on ZNetScene.Awake.
        //
        // Parameters:
        //   customPrefab:
        //     Prefab to add
        public void AddPrefab(CustomPrefab customPrefab)
        {
            //IL_0085: Unknown result type (might be due to invalid IL or missing references)
            if (!customPrefab.IsValid())
            {
                Logger.LogWarning(customPrefab.SourceMod, $"Custom prefab {customPrefab} is not valid");
                return;
            }

            string name = customPrefab.Prefab.name;
            if (Prefabs.ContainsKey(name))
            {
                Logger.LogWarning(customPrefab.SourceMod, $"Prefab '{customPrefab}' already exists");
                return;
            }

            customPrefab.Prefab.transform.SetParent(PrefabContainer.transform, worldPositionStays: false);
            Prefabs.Add(name, customPrefab);
            AssetManager.Instance.AddAsset(customPrefab.Prefab, null);
        }

        //
        // Summary:
        //     Create a new prefab from an empty primitive.
        //
        // Parameters:
        //   name:
        //     The name of the new GameObject
        //
        //   addZNetView:
        //     When true a ZNetView component is added to the new GameObject for ZDO generation
        //     and networking. Default: true
        //
        // Returns:
        //     The newly created empty prefab
        public GameObject CreateEmptyPrefab(string name, bool addZNetView = true)
        {
            if (string.IsNullOrEmpty(name))
            {
                Logger.LogWarning("Failed to create prefab with invalid name: " + name);
                return null;
            }

            if ((bool)GetPrefab(name))
            {
                Logger.LogWarning("Failed to create prefab, name already exists: " + name);
                return null;
            }

            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.name = name;
            gameObject.transform.parent = PrefabContainer.transform;
            if (addZNetView)
            {
                ZNetView zNetView = gameObject.AddComponent<ZNetView>();
                zNetView.m_persistent = true;
            }

            return gameObject;
        }

        //
        // Summary:
        //     Create a copy of a given prefab without modifying the original.
        //
        // Parameters:
        //   name:
        //     Name of the new prefab.
        //
        //   baseName:
        //     Name of the vanilla prefab to copy from.
        //
        // Returns:
        //     Newly created prefab object
        public GameObject CreateClonedPrefab(string name, string baseName)
        {
            if (string.IsNullOrEmpty(baseName))
            {
                Logger.LogWarning("Failed to clone prefab with invalid baseName: " + baseName);
                return null;
            }

            GameObject prefab = GetPrefab(baseName);
            if (!prefab)
            {
                Logger.LogWarning("Failed to clone prefab, can not find base prefab with name: " + baseName);
                return null;
            }

            return CreateClonedPrefab(name, prefab);
        }

        //
        // Summary:
        //     Create a copy of a given prefab without modifying the original.
        //
        // Parameters:
        //   name:
        //     Name of the new prefab.
        //
        //   prefab:
        //     Prefab instance to copy.
        //
        // Returns:
        //     Newly created prefab object
        public GameObject CreateClonedPrefab(string name, GameObject prefab)
        {
            if (string.IsNullOrEmpty(name))
            {
                Logger.LogWarning("Failed to clone prefab with invalid name: " + name);
                return null;
            }

            if (!prefab)
            {
                Logger.LogWarning("Failed to clone prefab, base prefab is not valid");
                return null;
            }

            if ((bool)GetPrefab(name))
            {
                Logger.LogWarning("Failed to clone prefab, name already exists: " + name);
                return null;
            }

            return AssetManager.Instance.ClonePrefab(prefab, name, PrefabContainer.transform);
        }

        //
        // Summary:
        //     Get a prefab by its name.
        //     Search hierarchy:
        //     1. Custom prefab with the exact name
        //     2. Vanilla prefab with the exact name from ZNetScene if already instantiated
        //     3. Vanilla prefab from the prefab cache
        //
        // Parameters:
        //   name:
        //     Name of the prefab to search for.
        //
        // Returns:
        //     The existing prefab, or null if none exists with given name
        public GameObject GetPrefab(string name)
        {
            if (Prefabs.TryGetValue(name, out var value))
            {
                return value.Prefab;
            }

            int stableHashCode = name.GetStableHashCode();
            if ((bool)ZNetScene.instance && ZNetScene.instance.m_namedPrefabs.TryGetValue(stableHashCode, out var value2))
            {
                return value2;
            }

            if ((bool)ObjectDB.instance && ObjectDB.instance.m_itemByHash.TryGetValue(stableHashCode, out var value3))
            {
                return value3;
            }

            return Cache.GetPrefab<GameObject>(name);
        }

        //
        // Summary:
        //     Remove a custom prefab from the manager.
        //
        // Parameters:
        //   name:
        //     Name of the prefab to remove
        public void RemovePrefab(string name)
        {
            Prefabs.Remove(name);
        }

        //
        // Summary:
        //     Destroy a custom prefab.
        //     Removes it from the manager and if already instantiated also from the ZNetScene.
        //
        // Parameters:
        //   name:
        //     The name of the prefab to destroy
        public void DestroyPrefab(string name)
        {
            if (!Prefabs.TryGetValue(name, out var value))
            {
                return;
            }

            if ((bool)ZNetScene.instance)
            {
                int stableHashCode = name.GetStableHashCode();
                if (ZNetScene.instance.m_namedPrefabs.TryGetValue(stableHashCode, out var value2))
                {
                    ZNetScene.instance.m_prefabs.Remove(value2);
                    ZNetScene.instance.m_nonNetViewPrefabs.Remove(value2);
                    ZNetScene.instance.m_namedPrefabs.Remove(stableHashCode);
                    ZNetScene.instance.Destroy(value2);
                }
            }

            if ((bool)value.Prefab)
            {
                UnityEngine.Object.Destroy(value.Prefab);
            }

            Prefabs.Remove(name);
        }

        //
        // Summary:
        //     Register all custom prefabs to m_prefabs/m_namedPrefabs in ZNetScene.
        private void RegisterAllToZNetScene()
        {
            if (!Prefabs.Any())
            {
                return;
            }

            Logger.LogInfo($"Adding {Prefabs.Count} custom prefabs to the ZNetScene");
            List<CustomPrefab> list = new List<CustomPrefab>();
            foreach (CustomPrefab value in Prefabs.Values)
            {
                try
                {
                    if (value.FixReference)
                    {
                        value.Prefab.FixReferences(recursive: true);
                        value.FixReference = false;
                    }

                    RegisterToZNetScene(value.Prefab);
                }
                catch (MockResolveException ex)
                {
                    Logger.LogWarning(value?.SourceMod, $"Skipping prefab {value}: {ex.Message}");
                    list.Add(value);
                }
                catch (Exception arg)
                {
                    Logger.LogWarning(value?.SourceMod, $"Error caught while adding prefab {value}: {arg}");
                    list.Add(value);
                }
            }

            foreach (CustomPrefab item in list)
            {
                if ((bool)item.Prefab)
                {
                    DestroyPrefab(item.Prefab.name);
                }
            }
        }

        //
        // Summary:
        //     Register a single prefab to the current ZNetScene.
        //     Checks for existence of the object via GetStableHashCode() and adds the prefab
        //     if it is not already added.
        //
        // Parameters:
        //   gameObject:
        public void RegisterToZNetScene(GameObject gameObject)
        {
            ZNetScene instance = ZNetScene.instance;
            if (!instance)
            {
                return;
            }

            string name = gameObject.name;
            int stableHashCode = name.GetStableHashCode();
            if (instance.m_namedPrefabs.ContainsKey(stableHashCode))
            {
                Logger.LogDebug("Prefab " + name + " already in ZNetScene");
                return;
            }

            if (gameObject.GetComponent<ZNetView>() != null)
            {
                instance.m_prefabs.Add(gameObject);
            }
            else
            {
                instance.m_nonNetViewPrefabs.Add(gameObject);
            }

            instance.m_namedPrefabs.Add(stableHashCode, gameObject);
            Logger.LogDebug("Added prefab " + name);
        }

        //
        // Summary:
        //     Safely invoke the Jotunn.Managers.PrefabManager.OnVanillaPrefabsAvailable event
        private void InvokeOnVanillaObjectsAvailable()
        {
            PrefabManager.OnVanillaPrefabsAvailable?.SafeInvoke();
        }

        private void InvokeOnPrefabsRegistered()
        {
            PrefabManager.OnPrefabsRegistered?.SafeInvoke();
        }

        private static bool TryFindAssetOfComponent(Component unityObject, Type objectType, out UnityEngine.Object asset)
        {
            Type type = unityObject.GetType();
            ClassMember classMember = ClassMember.GetClassMember(type);
            foreach (MemberBase member in classMember.Members)
            {
                if (member.MemberType == objectType && member.HasGetMethod)
                {
                    asset = (UnityEngine.Object)member.GetValue(unityObject);
                    if (asset != null)
                    {
                        return asset;
                    }
                }
            }

            asset = null;
            return false;
        }

        internal static bool TryFindAssetInSelfOrChildComponents(GameObject unityObject, Type objectType, out UnityEngine.Object asset)
        {
            if (!unityObject)
            {
                asset = null;
                return false;
            }

            if (objectType.IsSubclassOf(typeof(Component)))
            {
                Component component = unityObject.GetComponent(objectType);
                if ((bool)component)
                {
                    asset = component;
                    return true;
                }
            }

            Component[] components = unityObject.GetComponents<Component>();
            foreach (Component component2 in components)
            {
                if (!(component2 is Transform) && TryFindAssetOfComponent(component2, objectType, out asset))
                {
                    return asset;
                }
            }

            foreach (Transform item in unityObject.transform)
            {
                if (TryFindAssetInSelfOrChildComponents(item.gameObject, objectType, out asset))
                {
                    return asset;
                }
            }

            asset = null;
            return false;
        }
    }
}