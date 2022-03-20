using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class ConfigureCanvasFromSettings : SRMonoBehaviour
    {
        // Methods
        private void Start()
        {
            SRDebugger.Internal.SRDebuggerUtil.ConfigureCanvas(canvas:  this.GetComponent<UnityEngine.Canvas>());
            UnityEngine.Object.Destroy(obj:  this);
        }
        public ConfigureCanvasFromSettings()
        {
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
