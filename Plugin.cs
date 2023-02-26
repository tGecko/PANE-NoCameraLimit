using BepInEx;
using HarmonyLib;

namespace NoCameraLimit
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class NoCameraLimit : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony.CreateAndPatchAll(typeof(NoCameraLimit));
        }

        [HarmonyPatch(typeof(CameraManager), "GetZoomMax")]
        [HarmonyPostfix]
        private static void CameraManagerGetZoomMaxPostfixPatch(ref float __result)
        {
            __result = 60f;
        }
    }
}
