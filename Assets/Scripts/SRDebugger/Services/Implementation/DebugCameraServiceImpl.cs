using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class DebugCameraServiceImpl : IDebugCameraService
    {
        // Fields
        private UnityEngine.Camera _debugCamera;
        
        // Properties
        public UnityEngine.Camera Camera { get; }
        
        // Methods
        public DebugCameraServiceImpl()
        {
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            if(val_1._useDebugCamera == false)
            {
                    return;
            }
            
            UnityEngine.Camera val_3 = new UnityEngine.GameObject(name:  "SRDebugCamera").AddComponent<UnityEngine.Camera>();
            this._debugCamera = val_3;
            SRDebugger.Settings val_4 = SRDebugger.Settings.Instance;
            val_3.cullingMask = 1 << val_4._debugLayer;
            SRDebugger.Settings val_6 = SRDebugger.Settings.Instance;
            this._debugCamera.depth = val_6._debugCameraDepth;
            this._debugCamera.clearFlags = 3;
            this._debugCamera.transform.SetParent(p:  SRF.Hierarchy.Get(key:  "SRDebugger"));
        }
        public UnityEngine.Camera get_Camera()
        {
            return (UnityEngine.Camera)this._debugCamera;
        }
    
    }

}
