using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class SetLayerFromSettings : SRMonoBehaviour
    {
        // Methods
        private void Start()
        {
            SRDebugger.Settings val_2 = SRDebugger.Settings.Instance;
            SRF.SRFGameObjectExtensions.SetLayerRecursive(o:  this.CachedGameObject, layer:  val_2._debugLayer);
        }
        public SetLayerFromSettings()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
