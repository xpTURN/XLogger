using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Unity.CodeEditor;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace xpTURN.XLogger.Editor
{
    /// <summary>
    /// Editor utilities for applying and removing XLogger scripting define symbols across all active build targets.
    /// </summary>
    public static class PlayerSettingsScriptingDefineSymbols
    {
        /// <summary>Define symbol that enables all XLog* methods (except XLogRelease). When absent, those calls are removed at compile time.</summary>
        public const string ScriptingDefineSymbolForEnableXLogger = "ENABLE_XLOGGER";

        /// <summary>Define symbol that enables XLogRelease. When absent, XLogRelease calls are removed at compile time.</summary>
        public const string ScriptingDefineSymbolForEnableXLoggerRelease = "ENABLE_XLOGGER_RELEASE";

        /// <summary>Adds ENABLE_XLOGGER to scripting define symbols for all active build targets, then regenerates project files.</summary>
        [MenuItem("Edit/XLogger/Player Settings/Apply 'ENABLE_XLOGGER' Define Symbol")]
        public static void ApplyEnableXLogger()
        {
            foreach (var target in GetActiveNamedBuildTargets())
            {
                try
                {
                    AddScriptingDefineSymbol(target, ScriptingDefineSymbolForEnableXLogger);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning($"[XLogger] Skip {target.TargetName}: {ex.Message}");
                }
            }

            RegenerateProjectFiles();
        }

        /// <summary>Removes ENABLE_XLOGGER from scripting define symbols for all active build targets, then regenerates project files.</summary>
        [MenuItem("Edit/XLogger/Player Settings/Remove 'ENABLE_XLOGGER' Define Symbol")]
        public static void RemoveEnableXLogger()
        {
            foreach (var target in GetActiveNamedBuildTargets())
            {
                try
                {
                    RemoveScriptingDefineSymbol(target, ScriptingDefineSymbolForEnableXLogger);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning($"[XLogger] Skip {target.TargetName}: {ex.Message}");
                }
            }

            RegenerateProjectFiles();
        }

        /// <summary>Adds ENABLE_XLOGGER_RELEASE to scripting define symbols for all active build targets, then regenerates project files.</summary>
        [MenuItem("Edit/XLogger/Player Settings/Apply 'ENABLE_XLOGGER_RELEASE' Define Symbol")]
        public static void ApplyEnableXLoggerRelease()
        {
            foreach (var target in GetActiveNamedBuildTargets())
            {
                try
                {
                    AddScriptingDefineSymbol(target, ScriptingDefineSymbolForEnableXLoggerRelease);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning($"[XLogger] Skip {target.TargetName}: {ex.Message}");
                }
            }

            RegenerateProjectFiles();
        }

        /// <summary>Removes ENABLE_XLOGGER_RELEASE from scripting define symbols for all active build targets, then regenerates project files.</summary>
        [MenuItem("Edit/XLogger/Player Settings/Remove 'ENABLE_XLOGGER_RELEASE' Define Symbol")]
        public static void RemoveEnableXLoggerRelease()
        {
            foreach (var target in GetActiveNamedBuildTargets())
            {
                try
                {
                    RemoveScriptingDefineSymbol(target, ScriptingDefineSymbolForEnableXLoggerRelease);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning($"[XLogger] Skip {target.TargetName}: {ex.Message}");
                }
            }

            RegenerateProjectFiles();
        }

        /// <summary>Synchronizes solution and project files with the current Unity project (e.g. after define symbol changes). Requires an external code editor to be set.</summary>
        public static void RegenerateProjectFiles()
        {
            try
            {
                var editor = CodeEditor.Editor;
                if (editor?.CurrentCodeEditor == null)
                {
                    Debug.LogWarning("[XLogger] Regenerate Project Files: no external code editor registered.");
                    return;
                }
                editor.CurrentCodeEditor.SyncAll();
                Debug.Log("[XLogger] Project files (.sln / .csproj) regenerated.");
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        /// <summary>Returns all named build targets that are currently supported by the build pipeline (e.g. Standalone, iOS, Android).</summary>
        private static IEnumerable<NamedBuildTarget> GetActiveNamedBuildTargets()
        {
            var supportedGroups = new HashSet<BuildTargetGroup>();
#pragma warning disable IL3050
            var targets = (BuildTarget[])Enum.GetValues(typeof(BuildTarget));
#pragma warning restore IL3050
            foreach (var buildTarget in targets)
            {
                try
                {
                    var group = BuildPipeline.GetBuildTargetGroup(buildTarget);
                    if (group == BuildTargetGroup.Unknown) continue;
                    if (BuildPipeline.IsBuildTargetSupported(group, buildTarget))
                        supportedGroups.Add(group);
                }
                catch (Exception ex)
                {
                    // Some targets may throw from GetBuildTargetGroup etc.
                    Debug.LogWarning($"[XLogger] Skip {buildTarget}: {ex.Message}");
                }
            }

            foreach (var group in supportedGroups)
            {
                NamedBuildTarget target;
                try
                {
                    target = NamedBuildTarget.FromBuildTargetGroup(group);
                }
                catch
                {
                    continue;
                }
                if (target.TargetName == "Unknown") continue;
                yield return target;
            }
        }

        /// <summary>
        /// Adds the given define symbol to Scripting Define Symbols for the build target if not already present.
        /// </summary>
        private static void AddScriptingDefineSymbol(NamedBuildTarget buildTarget, string symbol)
        {
            var current = PlayerSettings.GetScriptingDefineSymbols(buildTarget);

            var list = new List<string>();
            foreach (var s in current.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var trimmed = s.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                    list.Add(trimmed);
            }

            if (list.Contains(symbol))
                return;

            list.Add(symbol);
            PlayerSettings.SetScriptingDefineSymbols(buildTarget, list.ToArray());
        }

        /// <summary>
        /// Removes the given define symbol from Scripting Define Symbols for the build target.
        /// </summary>
        private static void RemoveScriptingDefineSymbol(NamedBuildTarget buildTarget, string symbol)
        {
            var current = PlayerSettings.GetScriptingDefineSymbols(buildTarget);

            var list = new List<string>();
            foreach (var s in current.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var trimmed = s.Trim();
                if (string.IsNullOrEmpty(trimmed) || string.Equals(trimmed, symbol, StringComparison.Ordinal))
                    continue;

                list.Add(trimmed);
            }

            PlayerSettings.SetScriptingDefineSymbols(buildTarget, list.ToArray());
        }
    }
}
