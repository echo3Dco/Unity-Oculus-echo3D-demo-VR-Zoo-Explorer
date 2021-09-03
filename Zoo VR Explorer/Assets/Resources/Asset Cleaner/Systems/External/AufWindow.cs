using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Asset_Cleaner {
    class AufWindow : EditorWindow {
        [SerializeField] PersistentUndoRedoState _persistentUndo;

        [MenuItem("Window/- Asset Cleaner %L")]
        static void OpenActiveWindow() {
            GetWindow<AufWindow>();
        }

        // restore window state after recompilation
        void OnEnable() {
            var wd = Globals<WindowData>.Value = new WindowData();
            wd.Window = this;

            var firstTime = _persistentUndo == null;
            Globals<PersistentUndoRedoState>.Value = _persistentUndo ?? new PersistentUndoRedoState();
            Globals<BacklinkStore>.Value = new BacklinkStore();
            var config = Globals<Config>.Value = new Config();
            PersistenceUtils.Load(ref config);

            if (firstTime || !config.RebuildCacheOnDemand)
                Globals<BacklinkStore>.Value.Init();

            EditorApplication.update += Upd;
            EditorApplication.projectWindowItemOnGUI += ProjectViewGui.OnProjectWindowItemOnGui;

            AufCtx.TryInitWorld();
            
            // need to close window in case of Asset Cleaner uninstalled
            if (!CleanerStyleAsset.Style.TryFindSelf(out wd.Style)) 
                ForceClose();
        }

        void OnGUI() {
            var store = Globals<BacklinkStore>.Value;
            if (!store.Initialized) {
                // prevent further window GUI rendering
                if (!GUILayout.Button("Initialize Cache")) return;
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                store.Init();
                stopwatch.Stop();
                Globals<Config>.Value.InitializationTime = $"Initialized in {stopwatch.Elapsed.TotalSeconds:N} s";
                AufCtx.World.NewEntityWith(out RequestRepaintEvt _);
            }

            AufCtx.OnGuiGroup.Run();
        }

        static void Upd() {
            if (AufCtx.World == null) {
                AufCtx.DestroyWorld();
                return;
            }

            if (!Globals<BacklinkStore>.Value.Initialized) return;
            AufCtx.UpdateGroup.Run();
        }

        bool _closing;

        void ForceClose() {
            if (_closing) return;
            _closing = true;
            Close();
            EditorWindow.DestroyImmediate(this);
        }
        
        void OnDisable() {
            if (AufCtx.Destroyed) return;
            _persistentUndo = Globals<PersistentUndoRedoState>.Value;

            AufCtx.UpdateGroup.Destroy();
            AufCtx.OnGuiGroup.Destroy();
            AufCtx.DestroyWorld();

            Globals<Config>.Value = default;
            Globals<PersistentUndoRedoState>.Value = default;
            Globals<WindowData>.Value = default;

            EditorApplication.update -= Upd;
            EditorApplication.projectWindowItemOnGUI -= ProjectViewGui.OnProjectWindowItemOnGui;
            
            // need to close window in case of Asset Cleaner uninstalled
            if (!CleanerStyleAsset.Style.TryFindSelf(out _)) 
                ForceClose();
        }
    }
}