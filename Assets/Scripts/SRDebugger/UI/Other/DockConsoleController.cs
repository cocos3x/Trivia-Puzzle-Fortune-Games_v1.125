using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class DockConsoleController : SRMonoBehaviourEx, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
    {
        // Fields
        public const float NonFocusOpacity = 0.65;
        private bool _isDirty;
        private bool _isDragging;
        private int _pointersOver;
        public UnityEngine.GameObject BottomHandle;
        public UnityEngine.CanvasGroup CanvasGroup;
        public SRDebugger.UI.Controls.ConsoleLogControl Console;
        public UnityEngine.GameObject Dropdown;
        public UnityEngine.UI.Image DropdownToggleSprite;
        public UnityEngine.UI.Text TextErrors;
        public UnityEngine.UI.Text TextInfo;
        public UnityEngine.UI.Text TextWarnings;
        public UnityEngine.UI.Toggle ToggleErrors;
        public UnityEngine.UI.Toggle ToggleInfo;
        public UnityEngine.UI.Toggle ToggleWarnings;
        public UnityEngine.GameObject TopBar;
        public UnityEngine.GameObject TopHandle;
        
        // Properties
        public bool IsVisible { get; set; }
        
        // Methods
        public bool get_IsVisible()
        {
            return this.CachedGameObject.activeSelf;
        }
        public void set_IsVisible(bool value)
        {
            value = value;
            this.CachedGameObject.SetActive(value:  value);
        }
        protected override void Start()
        {
            IntPtr val_4;
            this.Start();
            SRDebugger.Services.ConsoleUpdatedEventHandler val_2 = null;
            val_4 = System.Void SRDebugger.UI.Other.DockConsoleController::ConsoleOnUpdated(SRDebugger.Services.IConsoleService console);
            val_2 = new SRDebugger.Services.ConsoleUpdatedEventHandler(object:  this, method:  val_4);
            var val_4 = 0;
            val_4 = val_4 + 1;
            val_4 = 5;
            SRDebugger.Internal.Service.Console.add_Updated(value:  val_2);
            this.Refresh();
            this.RefreshAlpha();
        }
        protected override void OnDestroy()
        {
            IntPtr val_5;
            this.OnDestroy();
            if(SRDebugger.Internal.Service.Console == null)
            {
                    return;
            }
            
            SRDebugger.Services.ConsoleUpdatedEventHandler val_3 = null;
            val_5 = System.Void SRDebugger.UI.Other.DockConsoleController::ConsoleOnUpdated(SRDebugger.Services.IConsoleService console);
            val_3 = new SRDebugger.Services.ConsoleUpdatedEventHandler(object:  this, method:  val_5);
            var val_5 = 0;
            val_5 = val_5 + 1;
            val_5 = 6;
            SRDebugger.Internal.Service.Console.remove_Updated(value:  val_3);
        }
        protected override void OnEnable()
        {
            this.OnEnable();
            this._pointersOver = 0;
            this._isDragging = false;
            this.RefreshAlpha();
        }
        protected override void OnDisable()
        {
            this.OnDisable();
            this._pointersOver = 0;
        }
        protected override void Update()
        {
            this.Update();
            if(this._isDirty == false)
            {
                    return;
            }
            
            this.Refresh();
        }
        private void ConsoleOnUpdated(SRDebugger.Services.IConsoleService console)
        {
            this._isDirty = true;
        }
        public void SetDropdownVisibility(bool visible)
        {
            visible = visible;
            this.Dropdown.SetActive(value:  visible);
            UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.Euler(x:  0f, y:  0f, z:  (visible != true) ? 0f : 180f);
            this.DropdownToggleSprite.rectTransform.localRotation = new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w};
        }
        public void SetAlignmentMode(SRDebugger.ConsoleAlignment alignment)
        {
            var val_12;
            if(alignment != 1)
            {
                    if(alignment != 0)
            {
                    return;
            }
            
                this.TopBar.transform.SetSiblingIndex(index:  0);
                this.Dropdown.transform.SetSiblingIndex(index:  2);
                this.TopHandle.SetActive(value:  false);
                this.BottomHandle.SetActive(value:  true);
                this.CachedTransform.SetSiblingIndex(index:  0);
                val_12 = this.DropdownToggleSprite.rectTransform.parent;
            }
            else
            {
                    this.Dropdown.transform.SetSiblingIndex(index:  0);
                this.TopBar.transform.SetSiblingIndex(index:  2);
                this.TopHandle.SetActive(value:  true);
                this.BottomHandle.SetActive(value:  false);
                this.CachedTransform.SetSiblingIndex(index:  1);
                val_12 = this.DropdownToggleSprite.rectTransform.parent;
            }
            
            UnityEngine.Quaternion val_11 = UnityEngine.Quaternion.Euler(x:  0f, y:  0f, z:  180f);
            val_12.localRotation = new UnityEngine.Quaternion() {x = val_11.x, y = val_11.y, z = val_11.z, w = val_11.w};
        }
        private void Refresh()
        {
            var val_13 = 0;
            val_13 = val_13 + 1;
            string val_4 = SRDebugger.Internal.SRDebuggerUtil.GetNumberString(value:  SRDebugger.Internal.Service.Console.InfoCount, max:  231, exceedsMaxString:  "999+");
            var val_14 = 0;
            val_14 = val_14 + 1;
            string val_8 = SRDebugger.Internal.SRDebuggerUtil.GetNumberString(value:  SRDebugger.Internal.Service.Console.WarningCount, max:  231, exceedsMaxString:  "999+");
            var val_15 = 0;
            val_15 = val_15 + 1;
            string val_12 = SRDebugger.Internal.SRDebuggerUtil.GetNumberString(value:  SRDebugger.Internal.Service.Console.ErrorCount, max:  231, exceedsMaxString:  "999+");
            this._isDirty = false;
        }
        private void RefreshAlpha()
        {
            if(this._isDragging != true)
            {
                    if(this._pointersOver < 1)
            {
                goto label_4;
            }
            
            }
            
            label_4:
            this.CanvasGroup.alpha = 1f;
        }
        public void ToggleDropdownVisible()
        {
            this.SetDropdownVisibility(visible:  (~this.Dropdown.activeSelf) & 1);
        }
        public void MenuButtonPressed()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRDebug.Instance.ShowDebugPanel(tab:  2, requireEntryCode:  true);
        }
        public void ClearButtonPressed()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRDebugger.Internal.Service.Console.Clear();
        }
        public void TogglesUpdated()
        {
            this.Console._isDirty = true;
            this.Console._showErrors = this.ToggleErrors.m_IsOn;
            this.Console._isDirty = true;
            this.Console._showWarnings = this.ToggleWarnings.m_IsOn;
            this.Console._isDirty = true;
            this.Console._showInfo = this.ToggleInfo.m_IsOn;
            this.SetDropdownVisibility(visible:  true);
        }
        public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData e)
        {
            this._pointersOver = 1;
            this.RefreshAlpha();
        }
        public void OnPointerExit(UnityEngine.EventSystems.PointerEventData e)
        {
            this._pointersOver = 0;
            this.RefreshAlpha();
        }
        public void OnBeginDrag()
        {
            this._isDragging = true;
            this.RefreshAlpha();
        }
        public void OnEndDrag()
        {
            this._isDragging = false;
            this._pointersOver = 0;
            this.RefreshAlpha();
        }
        public DockConsoleController()
        {
        
        }
    
    }

}
