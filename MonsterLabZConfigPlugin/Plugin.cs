extern alias ServerSyncStandalone;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using MonsterLabZConfig.Loaders;
using ServerSyncStandalone::ServerSync;
using UnityEngine;
using static MonsterLabZConfig.PluginConfig;

namespace MonsterLabZConfig
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    [BepInDependency(DependencyModGUID, BepInDependency.DependencyFlags.HardDependency)]
    public class MonsterLabZConfig : BaseUnityPlugin
    {
        internal const string ModName = "MonsterLabZConfig";
        internal const string ModNameGUID = "monsterlabzconfig";
        internal const string ModVersion = "1.0.0";
        internal const string Author = "Rickie26k";
        internal const string AuthorGUID = "rickie26k";
        private const string ModGUID = AuthorGUID + ".valheim." + ModNameGUID;

        internal const string DependencyModNameGUID = "monsterlabzconfigpatcher";
        internal const string DependencyAuthorGUID = "rickie26k";
        private const string DependencyModGUID = AuthorGUID + ".valheim." + ModNameGUID;

        internal static string ConnectionError = "MonsterLabZConfig: Failed to connect during application of plugin patches";
        public static string ConfigFileName = ModName + ".cfg";
        public static string ConfigFileFullPath = Paths.ConfigPath;
        public static bool fixedReferences;
        public static Harmony HarmonyInstance { get; private set; }

        public static readonly ManualLogSource PluginLogger =
            BepInEx.Logging.Logger.CreateLogSource(ModName);

        public static readonly ConfigSync Sync = new(ModGUID)
            { DisplayName = ModName, CurrentVersion = ModVersion, MinimumRequiredVersion = ModVersion };

        private static ConfigEntry<Toggle> _serverConfigLocked = null!;

        public void Awake()
        {
            Config.Reload();
            (_, _serverConfigLocked) = new ConfigData<Toggle>("1 - General", "Lock Configuration", true)
                .Describe("If on, the configuration is locked and can be changed by server admins only.")
                .Bind(Config, Toggle.On);
            _ = Sync.AddLockingConfigEntry(_serverConfigLocked);
            BindConfig(Config);
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            HarmonyInstance = Harmony.CreateAndPatchAll(assembly, harmonyInstanceId: ModGUID);

            LocalizationLoader.Load();
            OtherLoader.Load(Config);
            LocationsLoader.Load(Config);
            BossesLoader.Load(Config);
            CreaturesLoader.Load(Config);

            SetupWatcher();
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

    public static class KeyboardExtensions
    {
        public static bool IsKeyDown(this KeyboardShortcut shortcut)
        {
            return shortcut.MainKey != KeyCode.None && Input.GetKeyDown(shortcut.MainKey) && shortcut.Modifiers.All(Input.GetKey);
        }

        public static bool IsKeyHeld(this KeyboardShortcut shortcut)
        {
            return shortcut.MainKey != KeyCode.None && Input.GetKey(shortcut.MainKey) && shortcut.Modifiers.All(Input.GetKey);
        }
    }
}