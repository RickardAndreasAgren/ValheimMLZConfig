extern alias ServerSyncStandalone;

using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using MonsterLabZConfig.Extensions;
using ServerSyncStandalone::ServerSync;
using System.IO;
using YamlDotNet.Core.Tokens;

namespace MonsterLabZConfig
{
    public class ConfigData<T>
    {
        public ConfigData(ConfigDefinition definition, bool sync = false)
        {
            _key = definition.Key;
            _section = definition.Section;
            Definition = definition;
            SyncOn = sync;
        }
        public ConfigData(string section, string key, bool sync = false)
        {
            _key = key;
            _section = section;
            Definition = new ConfigDefinition(section, key);
            SyncOn = sync;
        }
        private string _key { get; set; } = string.Empty;
        private string _section { get; set; } = string.Empty;
        public ConfigDefinition Definition { get; private set; }
        public ConfigDescription Description { get; private set; }
        public bool SyncOn { get; set; } = false;
        public ConfigData<T> Describe(string description, AcceptableValueBase okValues = null, params object[] tags)
        {
            Description = new ConfigDescription(description, okValues, tags);
            return this;
        }
        public ConfigEntry<T> Bind(BepInEx.Configuration.ConfigFile config, T value)
        {
            ConfigDescription extendedDescription =
                new(
                    Description +
                    (SyncOn? " [Synced with Server]" : " [Not Synced with Server]"),
                    Description.AcceptableValues, Description.Tags);
            ConfigEntry<T> configEntry = config.Bind(Definition, value, extendedDescription);

            SyncedConfigEntry<T> syncedConfigEntry = MonsterLabZConfig.Sync.AddConfigEntry(configEntry);
            syncedConfigEntry.SynchronizedConfig = SyncOn;
            return configEntry;
        }
    }
}