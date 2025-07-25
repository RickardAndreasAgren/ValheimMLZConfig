﻿extern alias Syncer;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using MonsterLabZConfig.Extensions;
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
        public (ConfigDefinition, ConfigEntry<T>) Bind(BepInEx.Configuration.ConfigFile config, T value)
        {
            ConfigEntry<T> useEntry;
            if(!config.TryGetEntry<T>(Definition, out useEntry)) {
                ConfigDescription extendedDescription =
                new(
                    Description.Description +
                    (SyncOn ? " [Synced with Server]" : " [Not Synced with Server]"),
                    Description.AcceptableValues, Description.Tags);
                useEntry = config.Bind(Definition, value, extendedDescription);
            }

            Syncer.ServerSync.SyncedConfigEntry<T> syncedConfigEntry = MonsterLabZConfigPlugin.Sync.AddConfigEntry(useEntry);
            syncedConfigEntry.SynchronizedConfig = SyncOn;
            return (Definition, useEntry);
        }
    }
}