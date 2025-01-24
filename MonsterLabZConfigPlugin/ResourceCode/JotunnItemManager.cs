
using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers.MockSystem;
using Jotunn.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jotunn.Managers
{
    //
    // Summary:
    //     Manager for handling all custom data added to the game related to items.
    public class ItemManager : IManager
    {
        private static class Patches
        {
            [HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
            [HarmonyPrefix]
            [HarmonyPriority(-100)]
            private static void RegisterCustomDataFejd(ObjectDB __instance, ObjectDB other)
            {
                Instance.RegisterCustomDataFejd(__instance, other);
            }

            [HarmonyPatch(typeof(ObjectDB), "Awake")]
            [HarmonyPrefix]
            private static void RegisterCustomData(ObjectDB __instance)
            {
                Instance.RegisterCustomData(__instance);
            }

            [HarmonyPatch(typeof(Player), "OnSpawned")]
            [HarmonyPostfix]
            private static void ReloadKnownRecipes(Player __instance)
            {
                Instance.ReloadKnownRecipes(__instance);
            }

            [HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
            [HarmonyPostfix]
            [HarmonyPriority(0)]
            private static void InvokeOnItemsRegisteredFejd()
            {
                Instance.InvokeOnItemsRegisteredFejd();
            }

            [HarmonyPatch(typeof(ObjectDB), "Awake")]
            [HarmonyPostfix]
            [HarmonyPriority(0)]
            private static void InvokeOnItemsRegistered()
            {
                Instance.InvokeOnItemsRegistered();
            }
        }

        private static ItemManager _instance;

        internal readonly Dictionary<string, CustomItem> Items = new Dictionary<string, CustomItem>();

        internal readonly HashSet<CustomRecipe> Recipes = new HashSet<CustomRecipe>();

        internal readonly HashSet<CustomStatusEffect> StatusEffects = new HashSet<CustomStatusEffect>();

        internal readonly HashSet<CustomItemConversion> ItemConversions = new HashSet<CustomItemConversion>();

        //
        // Summary:
        //     The singleton instance of this manager.
        public static ItemManager Instance => _instance ?? (_instance = new ItemManager());

        //
        // Summary:
        //     Event that gets fired after the vanilla items are in memory and available for
        //     cloning. Your code will execute every time a new ObjectDB is copied (on every
        //     menu start). If you want to execute just once you will need to unregister from
        //     the event after execution.
        [Obsolete("Use PrefabManager.OnVanillaPrefabsAvailable instead")]
        public static event Action OnVanillaItemsAvailable;

        //
        // Summary:
        //     Internal event that gets fired after Jotunn.Managers.ItemManager.OnVanillaItemsAvailable
        //     did run. On this point all mods should have their items and pieces registered
        //     with the managers.
        internal static event Action OnKitbashItemsAvailable;

        //
        // Summary:
        //     Event that gets fired after all items were added to the ObjectDB on the FejdStartup
        //     screen. Your code will execute every time a new ObjectDB is copied (on every
        //     menu start). If you want to execute just once you will need to unregister from
        //     the event after execution.
        public static event Action OnItemsRegisteredFejd;

        //
        // Summary:
        //     Event that gets fired after all items were added to the ObjectDB. Your code will
        //     execute every time a new ObjectDB is created (on every game start). If you want
        //     to execute just once you will need to unregister from the event after execution.
        public static event Action OnItemsRegistered;

        //
        // Summary:
        //     Hide .ctor
        private ItemManager()
        {
        }

        static ItemManager()
        {
            ((IManager)Instance).Init();
        }

        //
        // Summary:
        //     Registers all hooks.
        void IManager.Init()
        {
            Main.LogInit("ItemManager");
            Main.Harmony.PatchAll(typeof(Patches));
            PrefabManager.Instance.Activate();
        }

        //
        // Summary:
        //     Add a Jotunn.Entities.CustomItem to the game.
        //     Checks if the custom item is valid and unique and adds it to the list of custom
        //     items.
        //     Also adds the prefab of the custom item to the Jotunn.Managers.PrefabManager.
        //     Custom items are added to the current ObjectDB on every ObjectDB.Awake.
        //
        // Parameters:
        //   customItem:
        //     The custom item to add.
        //
        // Returns:
        //     true if the custom item was added to the manager.
        public bool AddItem(CustomItem customItem)
        {
            if (!customItem.IsValid())
            {
                Logger.LogWarning(customItem.SourceMod, $"Custom item {customItem} is not valid");
                return false;
            }

            if (Items.ContainsKey(customItem.ItemPrefab.name))
            {
                Logger.LogWarning(customItem.SourceMod, $"Custom item {customItem} already added");
                return false;
            }

            if (!PrefabManager.Instance.AddPrefab(customItem.ItemPrefab, customItem.SourceMod))
            {
                return false;
            }

            if (customItem.ItemPrefab.layer == 0)
            {
                customItem.ItemPrefab.layer = LayerMask.NameToLayer("item");
            }

            Items.Add(customItem.ItemPrefab.name, customItem);
            if (customItem.Recipe != null)
            {
                AddRecipe(customItem.Recipe);
            }

            if ((bool)PrefabManager.Instance.MenuObjectDB)
            {
                RegisterItemInObjectDB(PrefabManager.Instance.MenuObjectDB, customItem.ItemPrefab, customItem.SourceMod);
            }

            return true;
        }

        //
        // Summary:
        //     Get a custom item by its name.
        //
        // Parameters:
        //   itemName:
        //     Name of the item to search.
        public CustomItem GetItem(string itemName)
        {
            if (Items.TryGetValue(itemName, out var value))
            {
                return value;
            }

            return null;
        }

        //
        // Summary:
        //     Remove a custom item by its name. Removes the custom recipe, too.
        //
        // Parameters:
        //   itemName:
        //     Name of the item to remove.
        public void RemoveItem(string itemName)
        {
            CustomItem item = GetItem(itemName);
            if (item == null)
            {
                Logger.LogWarning("Could not remove item " + itemName + ": Not found");
            }
            else
            {
                RemoveItem(item);
            }
        }

        //
        // Summary:
        //     Remove a custom item by its ref. Removes the custom recipe, too.
        //
        // Parameters:
        //   item:
        //     Jotunn.Entities.CustomItem to remove.
        public void RemoveItem(CustomItem item)
        {
            Items.Remove(item.ItemPrefab.name);
            if ((bool)ObjectDB.instance && (bool)item.ItemPrefab)
            {
                ObjectDB.instance.m_items.Remove(item.ItemPrefab);
                ObjectDB.instance.m_itemByHash.Remove(item.ItemPrefab.name.GetStableHashCode());
            }

            if ((bool)item.ItemPrefab)
            {
                PrefabManager.Instance.RemovePrefab(item.ItemPrefab.name);
            }

            if (item.Recipe != null)
            {
                RemoveRecipe(item.Recipe);
            }
        }

        //
        // Summary:
        //     Add a Jotunn.Entities.CustomRecipe to the game.
        //     Checks if the custom recipe is unique and adds it to the list of custom recipes.
        //     Custom recipes are added to the current ObjectDB on every ObjectDB.Awake.
        //
        // Parameters:
        //   customRecipe:
        //     The custom recipe to add.
        //
        // Returns:
        //     true if the custom recipe was added to the manager.
        public bool AddRecipe(CustomRecipe customRecipe)
        {
            if (!customRecipe.IsValid())
            {
                Logger.LogWarning(customRecipe.SourceMod, $"Custom recipe {customRecipe} is not valid");
                return false;
            }

            if (Recipes.Contains(customRecipe))
            {
                Logger.LogWarning(customRecipe.SourceMod, $"Custom recipe {customRecipe} already added");
                return false;
            }

            Recipes.Add(customRecipe);
            return true;
        }

        //
        // Summary:
        //     Adds recipes defined in a JSON file at given path, relative to BepInEx/plugins
        //
        // Parameters:
        //   path:
        //     JSON file path, relative to BepInEx/plugins folder
        public void AddRecipesFromJson(string path)
        {
            string text = AssetUtils.LoadText(path);
            if (string.IsNullOrEmpty(text))
            {
                Logger.LogError("Failed to load recipes from invalid JSON: " + path);
                return;
            }

            List<RecipeConfig> list = RecipeConfig.ListFromJson(text);
            foreach (RecipeConfig item in list)
            {
                AddRecipe(new CustomRecipe(item));
            }
        }

        //
        // Summary:
        //     Get a custom recipe by its name.
        //
        // Parameters:
        //   recipeName:
        //     Name of the recipe to search.
        public CustomRecipe GetRecipe(string recipeName)
        {
            return Recipes.FirstOrDefault((CustomRecipe x) => x.Recipe.name.Equals(recipeName));
        }

        //
        // Summary:
        //     Remove a custom recipe by its name. Removes it from the manager and the ObjectDB,
        //     if instantiated.
        //
        // Parameters:
        //   recipeName:
        //     Name of the recipe to remove.
        public void RemoveRecipe(string recipeName)
        {
            CustomRecipe recipe = GetRecipe(recipeName);
            if (recipe == null)
            {
                Logger.LogWarning("Could not remove recipe " + recipeName + ": Not found");
            }
            else
            {
                RemoveRecipe(recipe);
            }
        }

        //
        // Summary:
        //     Remove a custom recipe by its ref. Removes it from the manager and the ObjectDB,
        //     if instantiated.
        //
        // Parameters:
        //   recipe:
        //     Jotunn.Entities.CustomRecipe to remove.
        public void RemoveRecipe(CustomRecipe recipe)
        {
            Recipes.Remove(recipe);
            if ((bool)ObjectDB.instance && (bool)recipe.Recipe)
            {
                ObjectDB.instance.m_recipes.Remove(recipe.Recipe);
            }
        }

        //
        // Summary:
        //     Add a Jotunn.Entities.CustomStatusEffect to the game.
        //     Checks if the custom status effect is unique and adds it to the list of custom
        //     status effects.
        //     Custom status effects are added to the current ObjectDB on every ObjectDB.Awake.
        //
        // Parameters:
        //   customStatusEffect:
        //     The custom status effect to add.
        //
        // Returns:
        //     true if the custom status effect was added to the manager.
        public bool AddStatusEffect(CustomStatusEffect customStatusEffect)
        {
            if (!customStatusEffect.IsValid())
            {
                Logger.LogWarning(customStatusEffect.SourceMod, $"Custom status effect {customStatusEffect} is not valid");
                return false;
            }

            if (StatusEffects.Contains(customStatusEffect))
            {
                Logger.LogWarning(customStatusEffect.SourceMod, $"Custom status effect {customStatusEffect} already added");
                return false;
            }

            StatusEffects.Add(customStatusEffect);
            return true;
        }

        //
        // Summary:
        //     Add a new item conversion
        //
        // Parameters:
        //   itemConversion:
        //     Item conversion details
        //
        // Returns:
        //     Whether the addition was successful or not
        public bool AddItemConversion(CustomItemConversion itemConversion)
        {
            if (!itemConversion.IsValid())
            {
                Logger.LogWarning(itemConversion.SourceMod, $"Custom item conversion {itemConversion} is not valid");
                return false;
            }

            if (ItemConversions.Contains(itemConversion))
            {
                Logger.LogWarning(itemConversion.SourceMod, $"Custom item conversion {itemConversion} already added");
                return false;
            }

            ItemConversions.Add(itemConversion);
            return true;
        }

        //
        // Summary:
        //     Remove an item conversion
        //
        // Parameters:
        //   itemConversion:
        //     item conversion to remove
        //
        // Returns:
        //     Whether the removal was successful or not
        public bool RemoveItemConversion(CustomItemConversion itemConversion)
        {
            if (!ItemConversions.Contains(itemConversion))
            {
                Logger.LogWarning($"Could not remove item conversion {itemConversion}: not found");
                return false;
            }

            ItemConversions.Remove(itemConversion);
            return true;
        }

        //
        // Summary:
        //     Register all custom items added to the manager to the given ObjectDB
        //
        // Parameters:
        //   objectDB:
        private void RegisterCustomItems(ObjectDB objectDB)
        {
            if (Items.Count <= 0)
            {
                return;
            }

            Logger.LogInfo($"Adding {Items.Count} custom items to the ObjectDB");
            List<CustomItem> list = new List<CustomItem>();
            foreach (CustomItem value in Items.Values)
            {
                try
                {
                    ItemDrop itemDrop = value.ItemDrop;
                    if (value.FixReference || value.FixConfig)
                    {
                        value.ItemPrefab.FixReferences(value.FixReference);
                        itemDrop.m_itemData.m_shared.FixReferences();
                        value.FixVariants();
                        value.FixReference = false;
                        value.FixConfig = false;
                    }

                    if (!itemDrop.m_itemData.m_dropPrefab)
                    {
                        itemDrop.m_itemData.m_dropPrefab = value.ItemPrefab;
                    }

                    RegisterItemInObjectDB(objectDB, value.ItemPrefab, value.SourceMod);
                }
                catch (MockResolveException ex)
                {
                    Logger.LogWarning(value?.SourceMod, $"Skipping item {value}: {ex.Message}");
                    list.Add(value);
                }
                catch (Exception arg)
                {
                    Logger.LogWarning(value?.SourceMod, $"Error caught while adding item {value}: {arg}");
                    list.Add(value);
                }
            }

            foreach (CustomItem item in list)
            {
                if ((bool)item.ItemPrefab)
                {
                    PrefabManager.Instance.DestroyPrefab(item.ItemPrefab.name);
                }

                RemoveItem(item);
            }
        }

        //
        // Summary:
        //     Register a single item in the current ObjectDB. Also adds the prefab to the Jotunn.Managers.PrefabManager
        //     and ZNetScene if necessary.
        //     No mock references are fixed.
        //
        // Parameters:
        //   prefab:
        //     UnityEngine.GameObject with an ItemDrop component to add to the ObjectDB
        public void RegisterItemInObjectDB(GameObject prefab)
        {
            RegisterItemInObjectDB(ObjectDB.instance, prefab, BepInExUtils.GetSourceModMetadata());
        }

        //
        // Summary:
        //     Internal method for adding a prefab to a specific ObjectDB.
        //
        // Parameters:
        //   objectDB:
        //     ObjectDB the prefab should be added to
        //
        //   prefab:
        //     UnityEngine.GameObject with an ItemDrop component to add
        //
        //   sourceMod:
        //     BepInEx.BepInPlugin which created the prefab
        private void RegisterItemInObjectDB(ObjectDB objectDB, GameObject prefab, BepInPlugin sourceMod)
        {
            ItemDrop component = prefab.GetComponent<ItemDrop>();
            if (component == null)
            {
                throw new Exception("Prefab " + prefab.name + " has no ItemDrop component attached");
            }

            string name = prefab.name;
            int stableHashCode = name.GetStableHashCode();
            if (objectDB.m_itemByHash.ContainsKey(stableHashCode))
            {
                Logger.LogDebug("Already added item " + prefab.name);
            }
            else
            {
                if (!PrefabManager.Instance.Prefabs.ContainsKey(name))
                {
                    PrefabManager.Instance.AddPrefab(prefab, sourceMod);
                }

                if (ZNetScene.instance != null && !ZNetScene.instance.m_namedPrefabs.ContainsKey(stableHashCode))
                {
                    PrefabManager.Instance.RegisterToZNetScene(prefab);
                }

                objectDB.m_items.Add(prefab);
                objectDB.m_itemByHash.Add(stableHashCode, prefab);
            }

            Logger.LogDebug("Added item " + prefab.name + " | Token: " + component.TokenName());
        }

        //
        // Summary:
        //     Register the custom recipes added to the manager to the given ObjectDB
        //
        // Parameters:
        //   objectDB:
        private void RegisterCustomRecipes(ObjectDB objectDB)
        {
            if (!Recipes.Any())
            {
                return;
            }

            Logger.LogInfo($"Adding {Recipes.Count} custom recipes to the ObjectDB");
            List<CustomRecipe> list = new List<CustomRecipe>();
            foreach (CustomRecipe recipe2 in Recipes)
            {
                try
                {
                    Recipe recipe = recipe2.Recipe;
                    if (recipe2.FixReference)
                    {
                        recipe.FixReferences();
                        recipe2.FixReference = false;
                    }

                    if (recipe2.FixRequirementReferences)
                    {
                        Piece.Requirement[] resources = recipe.m_resources;
                        foreach (Piece.Requirement objectToFix in resources)
                        {
                            objectToFix.FixReferences();
                        }

                        recipe2.FixRequirementReferences = false;
                    }

                    objectDB.m_recipes.Add(recipe);
                    Logger.LogDebug("Added recipe for " + recipe.m_item.TokenName());
                }
                catch (MockResolveException ex)
                {
                    Logger.LogWarning(recipe2?.SourceMod, $"Skipping recipe {recipe2}: {ex.Message}");
                    list.Add(recipe2);
                }
                catch (Exception arg)
                {
                    Logger.LogWarning(recipe2?.SourceMod, $"Error caught while adding recipe {recipe2}: {arg}");
                    list.Add(recipe2);
                }
            }

            foreach (CustomRecipe item in list)
            {
                Recipes.Remove(item);
            }
        }

        //
        // Summary:
        //     Register the custom status effects added to the manager to the given ObjectDB
        //
        // Parameters:
        //   objectDB:
        private void RegisterCustomStatusEffects(ObjectDB objectDB)
        {
            if (!StatusEffects.Any())
            {
                return;
            }

            Logger.LogInfo($"Adding {StatusEffects.Count} custom status effects to the ObjectDB");
            List<CustomStatusEffect> list = new List<CustomStatusEffect>();
            foreach (CustomStatusEffect statusEffect2 in StatusEffects)
            {
                try
                {
                    StatusEffect statusEffect = statusEffect2.StatusEffect;
                    if (statusEffect2.FixReference)
                    {
                        statusEffect.FixReferences();
                        statusEffect2.FixReference = false;
                    }

                    objectDB.m_StatusEffects.Add(statusEffect);
                    Logger.LogDebug($"Added status effect {statusEffect2}");
                }
                catch (MockResolveException ex)
                {
                    Logger.LogWarning(statusEffect2?.SourceMod, $"Skipping status effect {statusEffect2}: {ex.Message}");
                    list.Add(statusEffect2);
                }
                catch (Exception arg)
                {
                    Logger.LogWarning(statusEffect2?.SourceMod, $"Error caught while adding status effect {statusEffect2}: {arg}");
                    list.Add(statusEffect2);
                }
            }

            foreach (CustomStatusEffect item in list)
            {
                StatusEffects.Remove(item);
            }
        }

        //
        // Summary:
        //     Register the custom item conversions added to the manager
        private void RegisterCustomItemConversions()
        {
            if (!ItemConversions.Any())
            {
                return;
            }

            Logger.LogInfo($"Adding {ItemConversions.Count} custom item conversions");
            List<CustomItemConversion> list = new List<CustomItemConversion>();
            CookingStation.ItemConversion cookConversion;
            Fermenter.ItemConversion fermenterConversion;
            Smelter.ItemConversion smelterConversion;
            Incinerator.IncineratorConversion incineratorConversion;
            foreach (CustomItemConversion itemConversion in ItemConversions)
            {
                try
                {
                    GameObject prefab = PrefabManager.Instance.GetPrefab(itemConversion.Config.Station);
                    if (!prefab)
                    {
                        throw new Exception("Invalid station prefab " + itemConversion.Config.Station);
                    }

                    if (itemConversion.FixReference)
                    {
                        itemConversion.ItemConversion.FixReferences();
                        itemConversion.FixReference = false;
                    }

                    switch (itemConversion.Type)
                    {
                        case CustomItemConversion.ConversionType.CookingStation:
                            {
                                CookingStation component3 = prefab.GetComponent<CookingStation>();
                                cookConversion = (CookingStation.ItemConversion)itemConversion.ItemConversion;
                                if (component3.m_conversion.Exists((CookingStation.ItemConversion c) => c.m_from == cookConversion.m_from))
                                {
                                    Logger.LogDebug($"Already added conversion ${itemConversion}");
                                    continue;
                                }

                                component3.m_conversion.Add(cookConversion);
                                break;
                            }
                        case CustomItemConversion.ConversionType.Fermenter:
                            {
                                Fermenter component2 = prefab.GetComponent<Fermenter>();
                                fermenterConversion = (Fermenter.ItemConversion)itemConversion.ItemConversion;
                                if (component2.m_conversion.Exists((Fermenter.ItemConversion c) => c.m_from == fermenterConversion.m_from))
                                {
                                    Logger.LogDebug($"Already added conversion ${itemConversion}");
                                    continue;
                                }

                                component2.m_conversion.Add(fermenterConversion);
                                break;
                            }
                        case CustomItemConversion.ConversionType.Smelter:
                            {
                                Smelter component4 = prefab.GetComponent<Smelter>();
                                smelterConversion = (Smelter.ItemConversion)itemConversion.ItemConversion;
                                if (component4.m_conversion.Exists((Smelter.ItemConversion c) => c.m_from == smelterConversion.m_from))
                                {
                                    Logger.LogDebug($"Already added conversion ${itemConversion}");
                                    continue;
                                }

                                component4.m_conversion.Add(smelterConversion);
                                break;
                            }
                        case CustomItemConversion.ConversionType.Incinerator:
                            {
                                Incinerator component = prefab.GetComponent<Incinerator>();
                                incineratorConversion = (Incinerator.IncineratorConversion)itemConversion.ItemConversion;
                                if (component.m_conversions.Exists((Incinerator.IncineratorConversion c) => c.m_requirements == incineratorConversion.m_requirements))
                                {
                                    Logger.LogDebug($"Already added conversion ${itemConversion}");
                                    continue;
                                }

                                component.m_conversions.Add(incineratorConversion);
                                break;
                            }
                        default:
                            throw new Exception("Unknown conversion type");
                    }

                    Logger.LogDebug($"Added item conversion {itemConversion}");
                }
                catch (MockResolveException ex)
                {
                    Logger.LogWarning(itemConversion?.SourceMod, $"Skipping item conversion {itemConversion}: {ex.Message}");
                    list.Add(itemConversion);
                }
                catch (Exception arg)
                {
                    Logger.LogWarning(itemConversion?.SourceMod, $"Error caught while adding item conversion {itemConversion}: {arg}");
                    list.Add(itemConversion);
                }
            }

            foreach (CustomItemConversion item in list)
            {
                ItemConversions.Remove(item);
            }
        }

        //
        // Summary:
        //     Prefix on ObjectDB.CopyOtherDB(ObjectDB) to add custom items to FejdStartup screen
        //     (aka main menu)
        private void RegisterCustomDataFejd(ObjectDB self, ObjectDB other)
        {
            InvokeOnVanillaItemsAvailable();
            InvokeOnKitbashItemsAvailable();
            UpdateRegistersSafe(other);
            RegisterCustomItems(other);
        }

        //
        // Summary:
        //     Safely invoke the Jotunn.Managers.ItemManager.OnVanillaItemsAvailable event
        [Obsolete]
        private void InvokeOnVanillaItemsAvailable()
        {
            ItemManager.OnVanillaItemsAvailable?.SafeInvoke();
        }

        //
        // Summary:
        //     Safely invoke the Jotunn.Managers.ItemManager.OnKitbashItemsAvailable event
        private void InvokeOnKitbashItemsAvailable()
        {
            ItemManager.OnKitbashItemsAvailable?.SafeInvoke();
        }

        //
        // Summary:
        //     Safely invoke the Jotunn.Managers.ItemManager.OnItemsRegisteredFejd event late
        //     in the detour chain
        private void InvokeOnItemsRegisteredFejd()
        {
            ItemManager.OnItemsRegisteredFejd?.SafeInvoke();
        }

        //
        // Summary:
        //     Hook on ObjectDB.Awake to register all custom entities from this manager to the
        //     ObjectDB.
        //
        // Parameters:
        //   self:
        private void RegisterCustomData(ObjectDB self)
        {
            if (SceneManager.GetActiveScene().name == "main")
            {
                UpdateRegistersSafe(self);
                RegisterCustomItems(self);
                RegisterCustomRecipes(self);
                RegisterCustomStatusEffects(self);
                RegisterCustomItemConversions();
            }
        }

        //
        // Summary:
        //     Safely invoke the Jotunn.Managers.ItemManager.OnItemsRegistered event
        private void InvokeOnItemsRegistered()
        {
            if (SceneManager.GetActiveScene().name == "main")
            {
                ItemManager.OnItemsRegistered?.SafeInvoke();
            }
        }

        //
        // Summary:
        //     Hook on Player.OnSpawned(System.Boolean) to refresh recipes for the custom items.
        //
        // Parameters:
        //   self:
        private void ReloadKnownRecipes(Player self)
        {
            if (Items.Count > 0 || Recipes.Count > 0)
            {
                try
                {
                    self.UpdateKnownRecipesList();
                }
                catch (Exception arg)
                {
                    Logger.LogWarning($"Exception caught while reloading player recipes: {arg}");
                }
            }
        }

        private static void UpdateRegistersSafe(ObjectDB objectDB)
        {
            objectDB.m_itemByHash.Clear();
            objectDB.m_itemByData.Clear();
            foreach (GameObject item in objectDB.m_items)
            {
                if (!item)
                {
                    Logger.LogWarning("Found null item in ObjectDB.m_items");
                    continue;
                }

                string name = item.name;
                int stableHashCode = name.GetStableHashCode();
                if (objectDB.m_itemByHash.ContainsKey(stableHashCode))
                {
                    BepInPlugin sourceMod = ModQuery.GetPrefab(name)?.SourceMod;
                    Logger.LogWarning(sourceMod, $"Found duplicate item '{name}' ({stableHashCode}) in ObjectDB.m_items");
                    continue;
                }

                objectDB.m_itemByHash.Add(stableHashCode, item);
                ItemDrop component = item.GetComponent<ItemDrop>();
                if (component != null)
                {
                    objectDB.m_itemByData[component.m_itemData.m_shared] = item;
                }
            }
        }
    }
}