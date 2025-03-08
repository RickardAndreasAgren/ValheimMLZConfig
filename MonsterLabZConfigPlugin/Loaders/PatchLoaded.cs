using CreatureManager;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Reflection;
using ItemManager;
using MonsterLabZConfig.Extensions;

namespace MonsterLabZConfig.Loaders
{
    internal static class PatchedLoader
    {
        public static void LoadPrefix(ZNetScene __instance)
        {
            ShaderSwapper.GatherCustomShaders(__instance);
        }

        internal static void LoadPostfix()
        {
            ShaderSwapper.ReplaceCustomShaders();
            CommonResources.FindCommonResources();
        }
    }
}

namespace MonsterLabZConfig
{

    public static class CommonResources
    {
        public static GameObject DwarfGoblinSpear;

        public static ItemDrop.ItemData DwarfGoblinSpearData;

        public static void FindCommonResources()
        {
            DwarfGoblinSpear = ZNetScene.instance?.m_prefabs.Where((GameObject p) => p.name == "DwarfGoblinSpear").FirstOrDefault();
            DwarfGoblinSpearData = DwarfGoblinSpear?.GetComponent<ItemDrop>().m_itemData;

            /*
            var lox = ZNetScene.instance?.m_prefabs.Where((GameObject p) => p.name == "ML_GoblinLox").FirstOrDefault();

            GameObject? partObject = null;
            Type? originalType = null;
            GameObject? componentParent = null;
            Component component = null;
            foreach (var comp in lox.GetComponentsInChildren<UnityEngine.Component>())
            {
                MonsterLabZConfig.PluginLogger.LogWarning($"{comp.name} of type {comp.GetType().ToString()} component with on {lox.name} found");
                if (comp.GetType().ToString() == "MonsterLabZ.InstantiatePrefabLoxRider")
                {
                    MonsterLabZConfig.PluginLogger.LogWarning($"object name is {comp.transform.gameObject.name}");
                    MonsterLabZConfig.PluginLogger.LogWarning($"parent name is {comp.transform.parent.gameObject.name}");
                    partObject = comp.transform.gameObject;
                    originalType = comp.GetType();
                    component = comp;
                    componentParent = comp.transform.parent.gameObject;
                    MonsterLabZConfig.PluginLogger.LogWarning($"{(component != null ? "Instantiate " : "No ")} component on {lox.name} found");
                    if (component != null)
                    {
                        var instantiater = componentParent.AddComponent<InstantiatePrefabLoxRider>();
                        instantiater.gameObject.name = component.gameObject.name;
                        FieldInfo infoAttach = originalType.GetField("m_attach");
                        FieldInfo infoTop = originalType.GetField("m_moveToTop");
                        FieldInfo infoPrefab = originalType.GetField("m_spawnPrefab");

                        instantiater.m_attach = (bool)infoAttach.GetValue(component);
                        instantiater.m_moveToTop = (bool)infoTop.GetValue(component);
                        instantiater.m_spawnPrefab = new List<GameObject>();
                        var sourceList = (List<GameObject>)infoPrefab.GetValue(component);
                        foreach(var srcObject in sourceList)
                        {
                            instantiater.m_spawnPrefab.Add(srcObject);
                        }
                        foreach (var child in Utils.ChildrenOfGameObject(component.gameObject))
                        {
                            child.transform.SetParent(instantiater.gameObject.transform);
                        }
                        MonsterLabZConfig.PluginLogger.LogWarning($"Replacing Instantiate");
                        MonoBehaviour.Destroy(component);

                        MonsterAI defaultAI = instantiater.GetComponent<MonsterAI>();
                        defaultAI.enabled = false;
                        var AItarget = defaultAI.transform.gameObject;
                        MonsterAI.Destroy(defaultAI);
                        AItarget.AddComponent<MonsterAIMounted>();
                    }
                }
            }*/
        }
    }

    internal static class ShaderSwapper
    {

        public static readonly Dictionary<string, Shader> customShaders = new Dictionary<string, Shader>();

        public static void AddCustomShader(Material mat)
        {
            if (IsCustomShader(mat) && !customShaders.ContainsKey(mat.shader.name))
            {
                customShaders[mat.shader.name] = mat.shader;
            }
        }

        public static bool IsCustomShader(Material mat)
        {
            return mat != null && mat.shader != null && mat.shader.name.StartsWith("Custom");
        }

        public static void GatherCustomShaders(ZNetScene instance)
        {
            instance.m_prefabs?.Do(delegate (GameObject prefab)
            {
                ((IEnumerable<Renderer>)prefab.GetComponentsInChildren<MeshRenderer>(includeInactive: true)).Union((IEnumerable<Renderer>)prefab.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true)).Do(delegate (Renderer renderer)
                {
                    renderer.sharedMaterials?.Do(delegate (Material mat)
                    {
                        AddCustomShader(mat);
                    });
                });
            });
        }

        public static void ReplaceCustomShader(Material mat)
        {
            if (IsCustomShader(mat))
            {
                mat.shader = customShaders[mat.shader.name];
            }
        }

        public static void ReplaceCustomShaders()
        {
            ZNetScene.instance?.m_prefabs.Where((GameObject p) => p.name.StartsWith("ML_") || p.name.StartsWith("MLNPC")).Do(delegate (GameObject gameObject)
            {
                ((IEnumerable<Renderer>)gameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true)).Union((IEnumerable<Renderer>)gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true)).Do(delegate (Renderer renderer)
                {
                    renderer.sharedMaterials?.Do(delegate (Material mat)
                    {
                        ReplaceCustomShader(mat);
                    });
                });
            });
        }
    }
}
