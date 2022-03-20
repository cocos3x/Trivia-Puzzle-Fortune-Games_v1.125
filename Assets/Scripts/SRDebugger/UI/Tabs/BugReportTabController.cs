using UnityEngine;

namespace SRDebugger.UI.Tabs
{
    public class BugReportTabController : SRMonoBehaviourEx, IEnableTab
    {
        // Fields
        public SRDebugger.UI.Other.BugReportSheetController BugReportSheetPrefab;
        public UnityEngine.RectTransform Container;
        
        // Properties
        public bool IsEnabled { get; }
        
        // Methods
        public bool get_IsEnabled()
        {
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            return (bool)val_1._enableBugReporter;
        }
        protected override void Start()
        {
            this.Start();
            SRDebugger.UI.Other.BugReportSheetController val_1 = SRInstantiate.Instantiate<SRDebugger.UI.Other.BugReportSheetController>(prefab:  this.BugReportSheetPrefab);
            val_1.IsCancelButtonEnabled = false;
            val_1.TakingScreenshot = new System.Action(object:  this, method:  System.Void SRDebugger.UI.Tabs.BugReportTabController::TakingScreenshot());
            val_1.ScreenshotComplete = new System.Action(object:  this, method:  System.Void SRDebugger.UI.Tabs.BugReportTabController::ScreenshotComplete());
            val_1.CachedTransform.SetParent(parent:  this.Container, worldPositionStays:  false);
        }
        private void TakingScreenshot()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRDebug.Instance.HideDebugPanel();
        }
        private void ScreenshotComplete()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRDebug.Instance.ShowDebugPanel(requireEntryCode:  false);
        }
        public BugReportTabController()
        {
        
        }
    
    }

}
