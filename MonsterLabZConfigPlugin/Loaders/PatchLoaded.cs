using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
