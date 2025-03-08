#nullable enable
extern alias ServerSyncStandalone;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Jotunn.Utils;
using MonsterLabZConfig.Loaders;
using ServerSyncStandalone::ServerSync;
using SpawnThat.Spawners;
using UnityEngine;
using static MonsterLabZConfig.PluginConfig;
using Paths = BepInEx.Paths;

namespace MonsterLabZConfig
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    // [BepInDependency(DependencyModGUID,BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(Dependency2ModGUID, BepInDependency.DependencyFlags.SoftDependency)]
    public class MonsterLabZConfig : BaseUnityPlugin
    {
        internal const string ModName = "MonsterLabZConfig";
        internal const string ModNameGUID = "monsterlabzconfig";
        internal const string ModVersion = "1.0.1";
        internal const string Author = "Rickie26k";
        internal const string AuthorGUID = "rickie26k";
        private const string ModGUID = AuthorGUID + ".valheim." + ModNameGUID;
        // private const string DependencyModGUID = "MonsterLabZ";
        private const string Dependency2ModGUID = "asharppen.valheim.spawn_that";

        internal static string ConnectionError = "MonsterLabZConfig: Failed to connect during application of plugin patches";
        public static string ConfigFileName = ModName + ".cfg";
        public static string ConfigFileFullPath = Paths.ConfigPath + Path.DirectorySeparatorChar + ConfigFileName;
        public static bool fixedReferences;
        public static Harmony? HarmonyInstance { get; private set; } = null;

        public static readonly ManualLogSource PluginLogger =
            BepInEx.Logging.Logger.CreateLogSource(ModName);

        public static readonly ConfigSync Sync = new(ModGUID)
            { DisplayName = ModName, CurrentVersion = ModVersion, MinimumRequiredVersion = ModVersion };

        private static ConfigEntry<Toggle> _serverConfigLocked = null!;
        private static bool SpawnThatPresent = false;
        public static List<Action<ISpawnerConfigurationCollection>> SpawnThatMonsters { get; private set; } = new List<Action<ISpawnerConfigurationCollection>>();
        public static AssetBundle? EmbeddedResourceBundle { get; set; } = null;
        public void Awake()
        {
            Config.Reload();
            (_, _serverConfigLocked) = new ConfigData<Toggle>("1 - General", "Lock Configuration", true)
                .Describe("If on, the configuration is locked and can be changed by server admins only.")
                .Bind(Config, Toggle.On);
            _ = Sync.AddLockingConfigEntry(_serverConfigLocked);
            BindConfig(Config);

            LoadAssembly();

            var AllAss = AccessTools.AllAssemblies();
            if (AllAss.Any(ass => ass.GetName().ToString().Contains("SpawnThat")))
            {
                SpawnThatPresent = true;
                SpawnerConfigurationManager.OnConfigure += MonsterLabZSpawnConfigs;
            } else
            {
                if ((short)Config[PluginConfig.DefMonsterSpawnData].BoxedValue == 2)
                {
                    PluginLogger.LogError("MLZC: SpawnThat is required to create worldspawners.");
                }
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            HarmonyInstance = Harmony.CreateAndPatchAll(assembly, harmonyInstanceId: ModGUID);

            //LocalizationManager.Load();
            LocationsLoader.Load(Config);
            OtherLoader.Load(Config);
            BossesLoader.Load(Config);
            CreaturesLoader.Load(Config);

            SetupWatcher();
        }

        private void LoadAssembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var pathParts = assembly.Location.Replace(".dll", "").Split('\\');
            string cleanedPath = string.Join("\\", pathParts.Take(pathParts.Length - 1));
            var libPath = $"{cleanedPath}\\Managed_Data";
            string dllPath = $"{libPath}\\MonsterLabZ.libassembly";
            var MLZ = Assembly.LoadFrom(dllPath);
            string a = " assembly ";
            string b = "nothing";
            if (MLZ == null) return;
            var original = Assembly.Load(MLZ.FullName);

            var manifests = original.GetManifestResourceNames();
            foreach(var res in manifests)
            {
                if (res.Contains("dybassets")) continue;
                if (res.Contains("ILRepack")) continue;
                if (res.Contains("Localization"))
                {
                    PluginLocalizationManager.LocalizationManager.ReadEmbeddedFileBytes(res, original);
                }
            }
            EmbeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("MonsterLabZ.assets.dybassets", original);
        }
        public void MonsterLabZSpawnConfigs(ISpawnerConfigurationCollection spawnerConfig)
        {
            if (!SpawnThatPresent) return;
            foreach(var spawn in SpawnThatMonsters)
            {
                spawn(spawnerConfig);
            }
        }

        [HarmonyPatch(typeof(ZNetScene), "Awake")]
        public static class ZNetScene_Awake_PostPatch
        {
            public static void Prefix(ZNetScene __instance)
            {
                PatchedLoader.LoadPrefix(__instance);
            }

            [HarmonyPriority(0)]
            public static void Postfix(ZNetScene __instance)
            {
                if (!(__instance == null) && !fixedReferences)
                {
                    PatchedLoader.LoadPostfix();
                    fixedReferences = true;
                }
            }
        }

        private void OnDestroy()
        {
            Config.Save();
            HarmonyInstance?.UnpatchSelf();
        }

        private void SetupWatcher()
        {
            FileSystemWatcher watcher = new(Paths.ConfigPath, ConfigFileName);
            watcher.Changed += ReadConfigValues;
            watcher.Created += ReadConfigValues;
            watcher.Renamed += ReadConfigValues;
            watcher.IncludeSubdirectories = true;
            watcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
            watcher.EnableRaisingEvents = true;
        }
        internal void ReadConfigValues(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(MonsterLabZConfig.ConfigFileFullPath)) return;
            try
            {
                MonsterLabZConfig.PluginLogger.LogDebug("ReadConfigValues called");
                Config.Reload();
            }
            catch
            {
                MonsterLabZConfig.PluginLogger.LogError($"There was an issue loading your {MonsterLabZConfig.ConfigFileName}");
                MonsterLabZConfig.PluginLogger.LogError("Please check your config entries for spelling and format!");
            }
        }
        public enum Toggle
        {
            On = 1,
            Off = 0
        }
    }
}