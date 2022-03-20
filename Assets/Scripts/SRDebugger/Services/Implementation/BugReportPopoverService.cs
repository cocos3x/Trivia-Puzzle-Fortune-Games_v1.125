using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class BugReportPopoverService : SRServiceBase<SRDebugger.Services.Implementation.BugReportPopoverService>
    {
        // Fields
        private SRDebugger.Services.BugReportCompleteCallback _callback;
        private bool _isVisible;
        private SRDebugger.UI.Other.BugReportPopoverRoot _popover;
        private SRDebugger.UI.Other.BugReportSheetController _sheet;
        
        // Properties
        public bool IsShowingPopover { get; }
        
        // Methods
        public bool get_IsShowingPopover()
        {
            return (bool)this._isVisible;
        }
        public void ShowBugReporter(SRDebugger.Services.BugReportCompleteCallback callback, bool takeScreenshotFirst = True, string descriptionText)
        {
            if(this._isVisible == true)
            {
                    throw new System.InvalidOperationException(message:  "Bug report popover is already visible.");
            }
            
            if(this._popover == 0)
            {
                    this.Load();
            }
            
            if(this._popover == 0)
            {
                    UnityEngine.Debug.LogWarning(message:  "[SRDebugger] Bug report popover failed loading, executing callback with fail result");
                callback.Invoke(didSucceed:  false, errorMessage:  "Resource load failed");
                return;
            }
            
            this._callback = callback;
            this._isVisible = true;
            bool val_3 = SRDebugger.Internal.SRDebuggerUtil.EnsureEventSystemExists();
            UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.OpenCo(takeScreenshot:  takeScreenshotFirst, descriptionText:  descriptionText));
        }
        private System.Collections.IEnumerator OpenCo(bool takeScreenshot, string descriptionText)
        {
            .<>1__state = 0;
            .takeScreenshot = takeScreenshot;
            .<>4__this = this;
            .descriptionText = descriptionText;
            return (System.Collections.IEnumerator)new BugReportPopoverService.<OpenCo>d__7();
        }
        private void SubmitComplete(bool didSucceed, string errorMessage)
        {
            this.OnComplete(success:  didSucceed, errorMessage:  errorMessage, close:  false);
        }
        private void CancelPressed()
        {
            this.OnComplete(success:  false, errorMessage:  "User Cancelled", close:  true);
        }
        private void OnComplete(bool success, string errorMessage, bool close)
        {
            if(this._isVisible == false)
            {
                goto label_1;
            }
            
            if((success == true) || (close == true))
            {
                goto label_3;
            }
            
            return;
            label_1:
            UnityEngine.Debug.LogWarning(message:  "[SRDebugger] Received callback at unexpected time. ???");
            return;
            label_3:
            this._isVisible = false;
            this._popover.gameObject.SetActive(value:  false);
            UnityEngine.Object.Destroy(obj:  this._popover.gameObject);
            this._popover = 0;
            mem[1152921519554668832] = 0;
            SRDebugger.Internal.BugReportScreenshotUtil.ScreenshotData = 0;
            this._callback.Invoke(didSucceed:  success, errorMessage:  errorMessage);
        }
        private void TakingScreenshot()
        {
            if(this._isVisible != false)
            {
                    this._popover.CanvasGroup.alpha = 0f;
                return;
            }
            
            UnityEngine.Debug.LogWarning(message:  "[SRDebugger] Received callback at unexpected time. ???");
        }
        private void ScreenshotComplete()
        {
            if(this._isVisible != false)
            {
                    this._popover.CanvasGroup.alpha = 1f;
                return;
            }
            
            UnityEngine.Debug.LogWarning(message:  "[SRDebugger] Received callback at unexpected time. ???");
        }
        protected override void Awake()
        {
            this.Awake();
            this.CachedTransform.SetParent(p:  SRF.Hierarchy.Get(key:  "SRDebugger"));
        }
        private void Load()
        {
            object val_15;
            SRDebugger.UI.Other.BugReportPopoverRoot val_1 = UnityEngine.Resources.Load<SRDebugger.UI.Other.BugReportPopoverRoot>(path:  "SRDebugger/UI/Prefabs/BugReportPopover");
            SRDebugger.UI.Other.BugReportSheetController val_2 = UnityEngine.Resources.Load<SRDebugger.UI.Other.BugReportSheetController>(path:  "SRDebugger/UI/Prefabs/BugReportSheet");
            if(val_1 != 0)
            {
                goto label_3;
            }
            
            val_15 = "[SRDebugger] Unable to load bug report popover prefab";
            goto label_6;
            label_3:
            if(val_2 != 0)
            {
                goto label_9;
            }
            
            val_15 = "[SRDebugger] Unable to load bug report sheet prefab";
            label_6:
            UnityEngine.Debug.LogError(message:  val_15);
            return;
            label_9:
            SRDebugger.UI.Other.BugReportPopoverRoot val_5 = SRInstantiate.Instantiate<SRDebugger.UI.Other.BugReportPopoverRoot>(prefab:  val_1);
            this._popover = val_5;
            val_5.CachedTransform.SetParent(parent:  this.CachedTransform, worldPositionStays:  false);
            SRDebugger.UI.Other.BugReportSheetController val_8 = SRInstantiate.Instantiate<SRDebugger.UI.Other.BugReportSheetController>(prefab:  val_2);
            this._sheet = val_8;
            val_8.CachedTransform.SetParent(parent:  this._popover.Container, worldPositionStays:  false);
            this._sheet.SubmitComplete = new System.Action<System.Boolean, System.String>(object:  this, method:  System.Void SRDebugger.Services.Implementation.BugReportPopoverService::SubmitComplete(bool didSucceed, string errorMessage));
            this._sheet.CancelPressed = new System.Action(object:  this, method:  System.Void SRDebugger.Services.Implementation.BugReportPopoverService::CancelPressed());
            this._sheet.TakingScreenshot = new System.Action(object:  this, method:  System.Void SRDebugger.Services.Implementation.BugReportPopoverService::TakingScreenshot());
            this._sheet.ScreenshotComplete = new System.Action(object:  this, method:  System.Void SRDebugger.Services.Implementation.BugReportPopoverService::ScreenshotComplete());
            this._popover.CachedGameObject.SetActive(value:  false);
        }
        public BugReportPopoverService()
        {
        
        }
    
    }

}
