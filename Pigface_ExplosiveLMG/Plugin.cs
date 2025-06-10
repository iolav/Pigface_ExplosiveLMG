using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Pigface_ExplosiveLMG
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PluginGUID = "iolav.Pigface_ExplosiveLMG";
        private const string PluginName = "Explosive LMG";
        private const string PluginVersion = "1.0.1";

        private readonly Harmony MyHarmony = new Harmony(PluginGUID);

        public static ManualLogSource? Log;

        private void Awake()
        {
            Log = Logger;
            Logger.LogInfo($"Loaded {PluginGUID}");

            MyHarmony.PatchAll();
        }
    }
}