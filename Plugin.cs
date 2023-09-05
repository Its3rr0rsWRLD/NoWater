using System;
using BepInEx;
using UnityEngine;
using Utilla;

namespace NoWater
{
    // Constants for easier maintenance
    public static class GameObjectPaths
    {
        public const string WaterVolumes = "Environment Objects/LocalObjects_Prefab/Beach/B_WaterVolumes";
    }

    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        // Called when the mod is enabled
        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        // Called when the mod is disabled
        void OnDisable()
        {
            ToggleWater(true);
            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
        }

        // Called when the game is initialized
        void OnGameInitialized(object sender, EventArgs e)
        {
            // Code that runs after the game is initialized
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            ToggleWater(false);
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            ToggleWater(true);
        }

        // Helper method to toggle water
        private void ToggleWater(bool isActive)
        {
            GameObject obj = GameObject.Find(GameObjectPaths.WaterVolumes);
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
        }
    }
}
