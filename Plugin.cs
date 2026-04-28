using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace GloryToGooMod;

[BepInPlugin("com.yourname.glorytogoomod", "GloryToGoo Mod", "1.0.0")]
public class Plugin : BasePlugin
{
    internal new static ManualLogSource Log = null!;
    private Harmony? _harmony;

    public const int EXTRA_ORE_STORAGE = 50;
    public const int EXTRA_URANIUM_STORAGE = 25;
    public const int EXTRA_GAS_STORAGE = 25;

    public override void Load()
    {
        Log = base.Log;
        Log.LogInfo("GloryToGoo Mod loading...");
        _harmony = new Harmony("com.yourname.glorytogoomod");
        _harmony.PatchAll();
        Log.LogInfo("GloryToGoo Mod loaded!");
    }
}

[HarmonyPatch("GameManager", "setOreStorage")]
public class OreStoragePatch
{
    static void Prefix(ref int num)
    {
        if (num > 0)
        {
            num += Plugin.EXTRA_ORE_STORAGE;
            Plugin.Log.LogInfo($"Ore storage set to: {num}");
        }
    }
}

[HarmonyPatch("GameManager", "setUraniumStorage")]
public class UraniumStoragePatch
{
    static void Prefix(ref int num)
    {
        if (num > 0)
        {
            num += Plugin.EXTRA_URANIUM_STORAGE;
            Plugin.Log.LogInfo($"Uranium storage set to: {num}");
        }
    }
}

[HarmonyPatch("GameManager", "setGasStorage")]
public class GasStoragePatch
{
    static void Prefix(ref int num)
    {
        if (num > 0)
        {
            num += Plugin.EXTRA_GAS_STORAGE;
            Plugin.Log.LogInfo($"Gas storage set to: {num}");
        }
    }
}