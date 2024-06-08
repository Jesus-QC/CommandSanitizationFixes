using GameCore;
using HarmonyLib;
using PluginAPI.Core.Attributes;
using RemoteAdmin;

namespace CommandSanitizationFixes;

public class MainClass
{
    public const string PluginVersion = "1.0.0.0";
    
    private static readonly Harmony Harmony = new ("commandsanitizationfixes.jesusqc.com");

    [PluginEntryPoint("CommandSanitizationFixes", PluginVersion, "Defaults sanitization to false", "jesusqc")]
    private void EntryPoint()
    {
        HarmonyMethod transpiler = new (typeof(SanitizationPatch), nameof(SanitizationPatch.Transpiler));
        
        Harmony.Patch(AccessTools.Method(typeof(Console), nameof(Console.TypeCommand)), transpiler: transpiler);
        Harmony.Patch(AccessTools.Method(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery)), transpiler: transpiler);
        Harmony.Patch(AccessTools.Method(typeof(QueryProcessor), nameof(QueryProcessor.ProcessGameConsoleQuery)), transpiler: transpiler);
    }
}