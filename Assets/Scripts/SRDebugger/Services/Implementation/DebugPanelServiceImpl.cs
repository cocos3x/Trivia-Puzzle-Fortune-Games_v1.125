using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class DebugPanelServiceImpl : ScriptableObject, IDebugPanelService
    {
        // Fields
        private SRDebugger.UI.DebugPanelRoot _debugPanelRootObject;
        private System.Action<SRDebugger.Services.IDebugPanelService, bool> VisibilityChanged;
        private bool _isVisible;
        private System.Nullable<bool> _cursorWasVisible;
        private System.Nullable<UnityEngine.CursorLockMode> _cursorLockMode;
        
        // Properties
        public SRDebugger.UI.DebugPanelRoot RootObject { get; }
        public bool IsLoaded { get; }
        public bool IsVisible { get; set; }
        public System.Nullable<SRDebugger.DefaultTabs> ActiveTab { get; }
        
        // Methods
        public void add_VisibilityChanged(System.Action<SRDebugger.Services.IDebugPanelService, bool> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.VisibilityChanged, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.VisibilityChanged != 1152921519556682944);
            
            return;
            label_2:
        }
        public void remove_VisibilityChanged(System.Action<SRDebugger.Services.IDebugPanelService, bool> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.VisibilityChanged, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.VisibilityChanged != 1152921519556819520);
            
            return;
            label_2:
        }
        public SRDebugger.UI.DebugPanelRoot get_RootObject()
        {
            return (SRDebugger.UI.DebugPanelRoot)this._debugPanelRootObject;
        }
        public bool get_IsLoaded()
        {
            return UnityEngine.Object.op_Inequality(x:  this._debugPanelRootObject, y:  0);
        }
        public bool get_IsVisible()
        {
            var val_3;
            if(this.IsLoaded != false)
            {
                    var val_2 = (this._isVisible == true) ? 1 : 0;
                return (bool)val_3;
            }
            
            val_3 = 0;
            return (bool)val_3;
        }
        public void set_IsVisible(bool value)
        {
            var val_1 = (this._isVisible == false) ? 1 : 0;
            val_1 = val_1 ^ value;
            if(val_1 == true)
            {
                    return;
            }
            
            bool val_2 = this.IsLoaded;
            if(value == false)
            {
                goto label_2;
            }
            
            if(val_2 != true)
            {
                    this.Load();
            }
            
            bool val_3 = SRDebugger.Internal.SRDebuggerUtil.EnsureEventSystemExists();
            this._debugPanelRootObject.CanvasGroup.alpha = 1f;
            this._debugPanelRootObject.CanvasGroup.interactable = true;
            this._debugPanelRootObject.CanvasGroup.blocksRaycasts = true;
            System.Nullable<System.Boolean> val_6 = new System.Nullable<System.Boolean>(value:  UnityEngine.Cursor.visible);
            this._cursorWasVisible = val_6.HasValue;
            System.Nullable<UnityEngine.CursorLockMode> val_8 = new System.Nullable<UnityEngine.CursorLockMode>(value:  UnityEngine.Cursor.lockState);
            this._cursorLockMode = val_8.HasValue;
            SRDebugger.Settings val_9 = SRDebugger.Settings.Instance;
            if(val_9._automaticShowCursor == false)
            {
                goto label_21;
            }
            
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = 0;
            goto label_21;
            label_2:
            if(val_2 != false)
            {
                    this._debugPanelRootObject.CanvasGroup.alpha = 0f;
                this._debugPanelRootObject.CanvasGroup.interactable = false;
                this._debugPanelRootObject.CanvasGroup.blocksRaycasts = false;
            }
            
            if(this._debugPanelRootObject != null)
            {
                    UnityEngine.Cursor.visible = this._cursorWasVisible.Value;
                mem2[0] = 0;
            }
            
            if((public System.Boolean System.Nullable<System.Boolean>::get_Value()) != 0)
            {
                    UnityEngine.Cursor.lockState = this._cursorLockMode.Value;
                mem2[0] = 0;
            }
            
            label_21:
            bool val_13 = value;
            this._isVisible = val_13;
            if(this.VisibilityChanged == null)
            {
                    return;
            }
            
            this.VisibilityChanged.Invoke(arg1:  this, arg2:  val_13);
        }
        public System.Nullable<SRDebugger.DefaultTabs> get_ActiveTab()
        {
            if(this._debugPanelRootObject != 0)
            {
                    return this._debugPanelRootObject.TabController.ActiveTab;
            }
            
            return 0;
        }
        public void OpenTab(SRDebugger.DefaultTabs tab)
        {
            if(this.IsLoaded != false)
            {
                    if(this._isVisible == true)
            {
                goto label_1;
            }
            
            }
            
            this.IsVisible = true;
            label_1:
            bool val_2 = this._debugPanelRootObject.TabController.OpenTab(tab:  tab);
        }
        public void Unload()
        {
            if(this._debugPanelRootObject == 0)
            {
                    return;
            }
            
            this.IsVisible = false;
            this._debugPanelRootObject.CachedGameObject.SetActive(value:  false);
            UnityEngine.Object.Destroy(obj:  this._debugPanelRootObject.CachedGameObject);
            this._debugPanelRootObject = 0;
        }
        private void Load()
        {
            SRDebugger.UI.DebugPanelRoot val_1 = UnityEngine.Resources.Load<SRDebugger.UI.DebugPanelRoot>(path:  "SRDebugger/UI/Prefabs/DebugPanel");
            if(val_1 == 0)
            {
                    UnityEngine.Debug.LogError(message:  "[SRDebugger] Error loading debug panel prefab");
                return;
            }
            
            SRDebugger.UI.DebugPanelRoot val_3 = SRInstantiate.Instantiate<SRDebugger.UI.DebugPanelRoot>(prefab:  val_1);
            this._debugPanelRootObject = val_3;
            val_3.name = "Panel";
            UnityEngine.Object.DontDestroyOnLoad(target:  this._debugPanelRootObject);
            this._debugPanelRootObject.CachedTransform.SetParent(parent:  SRF.Hierarchy.Get(key:  "SRDebugger"), worldPositionStays:  true);
            bool val_6 = SRDebugger.Internal.SRDebuggerUtil.EnsureEventSystemExists();
        }
        public DebugPanelServiceImpl()
        {
        
        }
    
    }

}
