
using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using HarmonyLib;
using Jotunn.Extensions;
using Jotunn.Utils;
using SoftReferenceableAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace Jotunn.Managers
{
    //
    // Summary:
    //     Manager to handle interactions with the vanilla asset system, called SoftReferenceableAssets.
    //     See the Vanilla FAQ for more information.
    public class AssetManager : IManager
    {
        private static class Patches
        {
            [HarmonyPatch(typeof(AssetBundleLoader), "OnInitCompleted")]
            [HarmonyPostfix]
            private static void AssetBundleLoader_Load(AssetBundleLoader __instance)
            {
                //IL_001d: Unknown result type (might be due to invalid IL or missing references)
                foreach (KeyValuePair<AssetID, AssetRef> asset in Instance.assets)
                {
                    AddAssetToBundleLoader(__instance, asset.Key, asset.Value);
                }
            }
        }

        private struct AssetRef
        {
            public BepInPlugin sourceMod;

            public UnityEngine.Object asset;

            public AssetID originalID;

            public AssetRef(BepInPlugin sourceMod, UnityEngine.Object asset, UnityEngine.Object original)
            {
                //IL_0025: Unknown result type (might be due to invalid IL or missing references)
                //IL_002b: Unknown result type (might be due to invalid IL or missing references)
                //IL_003f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0044: Unknown result type (might be due to invalid IL or missing references)
                this.sourceMod = sourceMod;
                this.asset = asset;
                originalID = (AssetID)(((bool)original && Instance.IsReady()) ? Instance.GetAssetID(original.GetType(), original.name) : default(AssetID));
            }
        }

        private static AssetManager instance;

        private Dictionary<AssetID, AssetRef> assets = new Dictionary<AssetID, AssetRef>();

        private Dictionary<Type, Dictionary<string, AssetID>> mapNameToAssetID;

        //
        // Summary:
        //     The singleton instance of this manager.
        public static AssetManager Instance => instance ?? (instance = new AssetManager());

        internal Dictionary<Type, Dictionary<string, AssetID>> MapNameToAssetID => mapNameToAssetID ?? (mapNameToAssetID = CreateNameToAssetID());

        //
        // Summary:
        //     Hide .ctor
        private AssetManager()
        {
        }

        static AssetManager()
        {
            ((IManager)Instance).Init();
        }

        void IManager.Init()
        {
            Main.LogInit("AssetManager");
            Main.Harmony.PatchAll(typeof(Patches));
        }

        //
        // Summary:
        //     Checks if the vanilla loader is ready. If false, Runtime.Loader must not be accessed
        //     and no assets may be loaded. If the vanilla loader is initialized too early,
        //     mods can become incompatible.
        //
        // Returns:
        //     true if the vanilla asset loader is ready, false otherwise
        public bool IsReady()
        {
            //IL_000c: Unknown result type (might be due to invalid IL or missing references)
            if (Runtime.s_assetLoader != null)
            {
                return ((AssetBundleLoader)Runtime.s_assetLoader).get_Initialized();
            }

            return false;
        }

        //
        // Summary:
        //     Registers a new asset with the same asset dependencies as the original asset
        //     and generates a unique AssetID.
        //     Assets can be added at any time and will be registered as soon as the vanilla
        //     loader is ready.
        //
        // Parameters:
        //   asset:
        //     The asset to register
        //
        //   original:
        //     Assets to copy dependencies from
        //
        // Returns:
        //     AssetID generated from the prefab's name
        public AssetID AddAsset(UnityEngine.Object asset, UnityEngine.Object original)
        {
            //IL_0002: Unknown result type (might be due to invalid IL or missing references)
            //IL_0007: Unknown result type (might be due to invalid IL or missing references)
            //IL_000e: Unknown result type (might be due to invalid IL or missing references)
            //IL_0016: Unknown result type (might be due to invalid IL or missing references)
            //IL_002c: Unknown result type (might be due to invalid IL or missing references)
            //IL_003f: Unknown result type (might be due to invalid IL or missing references)
            //IL_0046: Unknown result type (might be due to invalid IL or missing references)
            AssetID val = GenerateAssetID(asset);
            if (assets.ContainsKey(val))
            {
                return val;
            }

            AssetRef assetRef = new AssetRef(BepInExUtils.GetSourceModMetadata(), asset, original);
            assets.Add(val, assetRef);
            if (AssetBundleLoader.get_Instance() != null)
            {
                AddAssetToBundleLoader(AssetBundleLoader.get_Instance(), val, assetRef);
            }

            return val;
        }

        //
        // Summary:
        //     Registers a new asset and generates a unique AssetID.
        //     Assets can be added at any time and will be registered as soon as the vanilla
        //     loader is ready.
        //
        // Parameters:
        //   asset:
        //     The asset to register
        //
        // Returns:
        //     AssetID generated from the prefab's name
        public AssetID AddAsset(UnityEngine.Object asset)
        {
            //IL_0003: Unknown result type (might be due to invalid IL or missing references)
            return AddAsset(asset, null);
        }

        private static void AddAssetToBundleLoader(AssetBundleLoader assetBundleLoader, AssetID assetID, AssetRef assetRef)
        {
            //IL_009a: Unknown result type (might be due to invalid IL or missing references)
            //IL_00be: Unknown result type (might be due to invalid IL or missing references)
            //IL_00f4: Unknown result type (might be due to invalid IL or missing references)
            //IL_00f9: Unknown result type (might be due to invalid IL or missing references)
            //IL_00fd: Unknown result type (might be due to invalid IL or missing references)
            //IL_0174: Unknown result type (might be due to invalid IL or missing references)
            //IL_0176: Unknown result type (might be due to invalid IL or missing references)
            //IL_017d: Unknown result type (might be due to invalid IL or missing references)
            //IL_017e: Unknown result type (might be due to invalid IL or missing references)
            //IL_01a3: Unknown result type (might be due to invalid IL or missing references)
            //IL_01b8: Unknown result type (might be due to invalid IL or missing references)
            //IL_01f8: Unknown result type (might be due to invalid IL or missing references)
            string text = "JVL_BundleWrapper_" + assetRef.asset.name;
            string text2 = assetRef.sourceMod.GUID + "/Prefabs/" + assetRef.asset.name;
            if (assetBundleLoader.m_bundleNameToLoaderIndex.ContainsKey(text))
            {
                return;
            }

            AssetLocation val = default(AssetLocation);
            ((AssetLocation)(ref val))._002Ector(text, text2);
            BundleLoader val2 = default(BundleLoader);
            ((BundleLoader)(ref val2))._002Ector(text, "");
            ((BundleLoader)(ref val2)).HoldReference();
            assetBundleLoader.m_bundleNameToLoaderIndex.Add(text, assetBundleLoader.m_bundleLoaders.Length);
            assetBundleLoader.m_bundleLoaders = assetBundleLoader.m_bundleLoaders.AddItem(val2).ToArray();
            int originalBundleLoaderIndex = assetBundleLoader.m_assetLoaders.FirstOrDefault((AssetLoader l) => l.m_assetID == assetRef.originalID).m_bundleLoaderIndex;
            if (((AssetID)(ref assetRef.originalID)).get_IsValid() && originalBundleLoaderIndex > 0)
            {
                BundleLoader val3 = assetBundleLoader.m_bundleLoaders[originalBundleLoaderIndex];
                val2.m_bundleLoaderIndicesOfThisAndDependencies = (from i in val3.m_bundleLoaderIndicesOfThisAndDependencies.Where((int i) => i != originalBundleLoaderIndex).AddItem(assetBundleLoader.m_bundleNameToLoaderIndex[text])
                                                                   orderby i
                                                                   select i).ToArray();
            }
            else
            {
                ((BundleLoader)(ref val2)).SetDependencies(Array.Empty<string>());
            }

            assetBundleLoader.m_bundleLoaders[assetBundleLoader.m_bundleNameToLoaderIndex[text]] = val2;
            AssetLoader item = default(AssetLoader);
            ((AssetLoader)(ref item))._002Ector(assetID, val);
            item.m_asset = assetRef.asset;
            ((AssetLoader)(ref item)).HoldReference();
            assetBundleLoader.m_assetIDToLoaderIndex.Add(assetID, assetBundleLoader.m_assetLoaders.Length);
            assetBundleLoader.m_assetLoaders = assetBundleLoader.m_assetLoaders.AddItem(item).ToArray();
            Instance.MapNameToAssetID[assetRef.asset.GetType()][assetRef.asset.name] = assetID;
        }

        //
        // Summary:
        //     Generates a unique AssetID, based on the asset name
        //
        // Parameters:
        //   asset:
        //
        // Returns:
        //     AssetID generated from the prefab's name
        public AssetID GenerateAssetID(UnityEngine.Object asset)
        {
            //IL_0010: Unknown result type (might be due to invalid IL or missing references)
            uint stableHashCode = (uint)asset.name.GetStableHashCode();
            return new AssetID(stableHashCode, stableHashCode, stableHashCode, stableHashCode);
        }

        //
        // Summary:
        //     Clones a prefab and registers it in the SoftReference system with the same dependencies
        //     as the original asset
        //
        // Parameters:
        //   asset:
        //
        //   newName:
        //
        //   parent:
        public GameObject ClonePrefab(GameObject asset, string newName, Transform parent)
        {
            //IL_0012: Unknown result type (might be due to invalid IL or missing references)
            GameObject gameObject = UnityEngine.Object.Instantiate(asset, parent);
            gameObject.name = newName;
            AddAsset(gameObject, asset);
            return gameObject;
        }

        //
        // Summary:
        //     Finds the AssetID by an asset name at runtime.
        //     The closed matching base type must be used. E.g. for prefabs use UnityEngine.GameObject,
        //     for Textures use UnityEngine.Texture2D etc.
        //     If no asset is found, an invalid AssetID is returned.
        //
        // Parameters:
        //   type:
        //     Asset type to search for
        //
        //   name:
        //     Asset name to search for
        //
        // Returns:
        //     The AssetID of the searched asset if found, otherwise an invalid AssetID
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown if the vanilla asset system is not initialized yet
        public AssetID GetAssetID(Type type, string name)
        {
            //IL_002e: Unknown result type (might be due to invalid IL or missing references)
            //IL_0054: Unknown result type (might be due to invalid IL or missing references)
            //IL_0058: Unknown result type (might be due to invalid IL or missing references)
            //IL_005e: Unknown result type (might be due to invalid IL or missing references)
            if (!IsReady())
            {
                throw new InvalidOperationException("The vanilla asset system is not initialized yet");
            }

            if (MapNameToAssetID.TryGetValue(type, out var value) && value.TryGetValue(name, out var value2))
            {
                return value2;
            }

            if (MapNameToAssetID.TryGetValue(typeof(UnityEngine.Object), out value) && value.TryGetValue(name, out value2))
            {
                return value2;
            }

            return default(AssetID);
        }

        //
        // Summary:
        //     Finds the AssetID by an asset name at runtime.
        //     The closed matching base type must be used. E.g. for prefabs use UnityEngine.GameObject,
        //     for Textures use UnityEngine.Texture2D etc.
        //     If no asset is found, an invalid AssetID is returned.
        //
        // Parameters:
        //   name:
        //     Asset name to search for
        //
        // Type parameters:
        //   T:
        //     Asset type to search for
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown if the vanilla asset system is not initialized yet
        public AssetID GetAssetID<T>(string name) where T : UnityEngine.Object
        {
            //IL_000c: Unknown result type (might be due to invalid IL or missing references)
            return GetAssetID(typeof(T), name);
        }

        //
        // Summary:
        //     Finds the AssetID by an asset name at runtime and returns a SoftReference to
        //     the asset.
        //
        // Parameters:
        //   type:
        //     Asset type to search for
        //
        //   name:
        //     Asset name to search for
        public SoftReference<UnityEngine.Object> GetSoftReference(Type type, string name)
        {
            //IL_0003: Unknown result type (might be due to invalid IL or missing references)
            //IL_0008: Unknown result type (might be due to invalid IL or missing references)
            //IL_0014: Unknown result type (might be due to invalid IL or missing references)
            //IL_001a: Unknown result type (might be due to invalid IL or missing references)
            //IL_001c: Unknown result type (might be due to invalid IL or missing references)
            //IL_001d: Unknown result type (might be due to invalid IL or missing references)
            AssetID assetID = GetAssetID(type, name);
            if (!((AssetID)(ref assetID)).get_IsValid())
            {
                return default(SoftReference<UnityEngine.Object>);
            }

            return new SoftReference<UnityEngine.Object>(assetID);
        }

        //
        // Summary:
        //     Finds the AssetID by an asset name at runtime and returns a SoftReference to
        //     the asset.
        //
        // Parameters:
        //   name:
        //     Asset name to search for
        //
        // Type parameters:
        //   T:
        //     Asset type to search for
        public SoftReference<T> GetSoftReference<T>(string name) where T : UnityEngine.Object
        {
            //IL_0002: Unknown result type (might be due to invalid IL or missing references)
            //IL_0007: Unknown result type (might be due to invalid IL or missing references)
            //IL_0013: Unknown result type (might be due to invalid IL or missing references)
            //IL_0019: Unknown result type (might be due to invalid IL or missing references)
            //IL_001b: Unknown result type (might be due to invalid IL or missing references)
            //IL_001c: Unknown result type (might be due to invalid IL or missing references)
            AssetID assetID = GetAssetID<T>(name);
            if (!((AssetID)(ref assetID)).get_IsValid())
            {
                return default(SoftReference<T>);
            }

            return new SoftReference<T>(assetID);
        }

        private static Dictionary<Type, Dictionary<string, AssetID>> CreateNameToAssetID()
        {
            //IL_015a: Unknown result type (might be due to invalid IL or missing references)
            if (!Instance.IsReady())
            {
                throw new InvalidOperationException("The vanilla asset system is not initialized yet");
            }

            Dictionary<Type, Dictionary<string, AssetID>> dictionary = new Dictionary<Type, Dictionary<string, AssetID>>();
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            foreach (KeyValuePair<string, AssetID> item in Runtime.GetAllAssetPathsInBundleMappedToAssetID().ToList())
            {
                string text = item.Key.Split('/').Last();
                string text2 = text.Split('.').Last();
                string key = text.RemoveSuffix("." + text2);
                if (!(item.Key == "Assets/UI/prefabs/radials/elements/Hammer.prefab") && !(item.Key == "Assets/UI/prefabs/Radial/elements/Hammer.prefab"))
                {
                    Type type = Instance.TypeFromExtension(text2);
                    if (type == null && text2 == "asset" && text.StartsWith("Recipe_"))
                    {
                        type = typeof(Recipe);
                    }

                    if (type == null)
                    {
                        type = typeof(UnityEngine.Object);
                    }

                    if (!dictionary.ContainsKey(type))
                    {
                        dictionary.Add(type, new Dictionary<string, AssetID>());
                    }

                    if (!dictionary[type].ContainsKey(key) || !SkipAmbiguousPath(dictionary2[key], item.Key, text2))
                    {
                        dictionary[type][key] = item.Value;
                        dictionary2[key] = item.Key;
                    }
                }
            }

            return dictionary;
        }

        private static bool SkipAmbiguousPath(string oldPath, string newPath, string extension)
        {
            if (extension == "prefab")
            {
                if (oldPath.StartsWith("Assets/world/Locations"))
                {
                    return false;
                }

                if (newPath.StartsWith("Assets/world/Locations"))
                {
                    return true;
                }

                Logger.LogWarning("Ambiguous asset name for path. old: " + oldPath + ", new: " + newPath + ", using old path");
            }

            return true;
        }

        private Type TypeFromExtension(string extension)
        {
            string text = extension.ToLower();
            if (text != null)
            {
                switch (text.Length)
                {
                    case 6:
                        switch (text[0])
                        {
                            case 'p':
                                if (!(text == "prefab"))
                                {
                                    break;
                                }

                                return typeof(GameObject);
                            case 's':
                                if (!(text == "shader"))
                                {
                                    break;
                                }

                                return typeof(Shader);
                        }

                        break;
                    case 3:
                        switch (text[2])
                        {
                            case 't':
                                if (!(text == "mat"))
                                {
                                    if (!(text == "txt"))
                                    {
                                        break;
                                    }

                                    return typeof(TextAsset);
                                }

                                return typeof(Material);
                            case 'j':
                                if (!(text == "obj"))
                                {
                                    break;
                                }

                                goto IL_026f;
                            case 'x':
                                if (!(text == "fbx"))
                                {
                                    break;
                                }

                                goto IL_026f;
                            case 'g':
                                if (!(text == "png") && !(text == "jpg"))
                                {
                                    break;
                                }

                                goto IL_027a;
                            case 'a':
                                if (!(text == "tga"))
                                {
                                    break;
                                }

                                goto IL_027a;
                            case 'f':
                                switch (text)
                                {
                                    case "tif":
                                        break;
                                    case "ttf":
                                    case "otf":
                                        return typeof(TMP_FontAsset);
                                    default:
                                        goto end_IL_0073;
                                }

                                goto IL_027a;
                            case 'v':
                                if (!(text == "wav"))
                                {
                                    break;
                                }

                                goto IL_0285;
                            case '3':
                                {
                                    if (!(text == "mp3"))
                                    {
                                        break;
                                    }

                                    goto IL_0285;
                                }

                            IL_0285:
                                return typeof(AudioClip);
                            IL_027a:
                                return typeof(Texture2D);
                            IL_026f:
                                return typeof(Mesh);
                            end_IL_0073:
                                break;
                        }

                        break;
                    case 10:
                        if (!(text == "controller"))
                        {
                            break;
                        }

                        return typeof(RuntimeAnimatorController);
                    case 14:
                        if (!(text == "physicmaterial"))
                        {
                            break;
                        }

                        return typeof(PhysicMaterial);
                    case 4:
                        if (!(text == "anim"))
                        {
                            break;
                        }

                        return typeof(AnimationClip);
                    case 5:
                        if (!(text == "mixer"))
                        {
                            break;
                        }

                        return typeof(AudioMixer);
                    case 13:
                        if (!(text == "rendertexture"))
                        {
                            break;
                        }

                        return typeof(RenderTexture);
                    case 8:
                        if (!(text == "lighting"))
                        {
                            break;
                        }

                        return typeof(LightingSettings);
                }
            }

            return null;
        }
    }
}