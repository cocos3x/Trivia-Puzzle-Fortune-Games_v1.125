using UnityEngine;

namespace SRDebugger.UI
{
    public class DebugPanelRoot : SRMonoBehaviourEx
    {
        // Fields
        public UnityEngine.Canvas Canvas;
        public UnityEngine.CanvasGroup CanvasGroup;
        public SRDebugger.Scripts.DebuggerTabController TabController;
        
        // Methods
        public void Close()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IDebugService>().HideDebugPanel();
        }
        public void CloseAndDestroy()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IDebugService>().DestroyDebugPanel();
        }
        public DebugPanelRoot()
        {
        
        }
    
    }

}
