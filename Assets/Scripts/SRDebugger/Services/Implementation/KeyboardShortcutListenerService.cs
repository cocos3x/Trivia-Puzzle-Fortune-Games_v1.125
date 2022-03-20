using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class KeyboardShortcutListenerService : SRServiceBase<SRDebugger.Services.Implementation.KeyboardShortcutListenerService>
    {
        // Fields
        private System.Collections.Generic.List<SRDebugger.Settings.KeyboardShortcut> _shortcuts;
        
        // Methods
        protected override void Awake()
        {
            this.Awake();
            this.CachedTransform.SetParent(p:  SRF.Hierarchy.Get(key:  "SRDebugger"));
            SRDebugger.Settings val_3 = SRDebugger.Settings.Instance;
            this._shortcuts = new System.Collections.Generic.List<KeyboardShortcut>(collection:  val_3._newKeyboardShortcuts);
        }
        private void ToggleTab(SRDebugger.DefaultTabs t)
        {
            SRDebugger.DefaultTabs val_10 = t;
            var val_12 = 0;
            val_12 = val_12 + 1;
            System.Nullable<SRDebugger.DefaultTabs> val_3 = SRDebugger.Internal.Service.Panel.ActiveTab;
            var val_13 = 0;
            val_13 = val_13 + 1;
            if((((val_3.HasValue & true) == 0) && (SRDebugger.Internal.Service.Panel.IsVisible != false)) && (val_3.HasValue.Value == val_10))
            {
                    val_10 = SRDebug.Instance;
                var val_14 = 0;
                val_14 = val_14 + 1;
            }
            else
            {
                    var val_15 = 0;
                val_15 = val_15 + 1;
                SRDebug.Instance.ShowDebugPanel(tab:  val_10 = t, requireEntryCode:  true);
                return;
            }
            
            val_10.HideDebugPanel();
        }
        private void ExecuteShortcut(SRDebugger.Settings.KeyboardShortcut shortcut)
        {
            if((shortcut.Action - 1) <= 10)
            {
                    var val_30 = 32558120;
                val_30 = (32558120 + ((shortcut.Action - 1)) << 2) + val_30;
            }
            else
            {
                    UnityEngine.Debug.LogWarning(message:  "[SRDebugger] Unhandled keyboard shortcut: "("[SRDebugger] Unhandled keyboard shortcut: ") + shortcut.Action);
            }
        
        }
        protected override void Update()
        {
            var val_19;
            var val_20;
            var val_21;
            System.Collections.Generic.List<KeyboardShortcut> val_22;
            this.Update();
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            if((val_1._keyboardEscapeClose != false) && ((UnityEngine.Input.GetKeyDown(key:  27)) != false))
            {
                    var val_18 = 0;
                val_18 = val_18 + 1;
                if(SRDebugger.Internal.Service.Panel.IsVisible != false)
            {
                    var val_19 = 0;
                val_19 = val_19 + 1;
                SRDebug.Instance.HideDebugPanel();
            }
            
            }
            
            if((UnityEngine.Input.GetKey(key:  50)) != false)
            {
                    val_19 = 1;
            }
            else
            {
                    val_19 = UnityEngine.Input.GetKey(key:  49);
            }
            
            if((UnityEngine.Input.GetKey(key:  52)) != false)
            {
                    val_20 = 1;
            }
            else
            {
                    val_20 = UnityEngine.Input.GetKey(key:  51);
            }
            
            if((UnityEngine.Input.GetKey(key:  48)) != false)
            {
                    val_21 = 1;
            }
            else
            {
                    val_21 = UnityEngine.Input.GetKey(key:  47);
            }
            
            val_22 = this._shortcuts;
            var val_20 = 0;
            label_29:
            if(val_20 >= (public System.Void SRDebugger.Services.IDebugService::HideDebugPanel()))
            {
                    return;
            }
            
            if((public System.Void SRDebugger.Services.IDebugService::HideDebugPanel()) <= val_20)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_14 = ((public System.Void SRDebugger.Services.IDebugService::HideDebugPanel().__il2cppRuntimeField_20 + 21) != 0) ? 1 : 0;
            val_14 = val_14 & (~val_19);
            var val_15 = ((public System.Void SRDebugger.Services.IDebugService::HideDebugPanel().__il2cppRuntimeField_20 + 28) != 0) ? 1 : 0;
            val_15 = val_15 & (~val_21);
            var val_16 = ((public System.Void SRDebugger.Services.IDebugService::HideDebugPanel().__il2cppRuntimeField_20 + 20) != 0) ? 1 : 0;
            val_16 = val_16 & (~val_20);
            bool val_17 = UnityEngine.Input.GetKeyDown(key:  public System.Void SRDebugger.Services.IDebugService::HideDebugPanel().__il2cppRuntimeField_20 + 24);
            if(val_17 == true)
            {
                goto label_28;
            }
            
            val_22 = this._shortcuts;
            val_20 = val_20 + 1;
            if(val_22 != null)
            {
                goto label_29;
            }
            
            throw new NullReferenceException();
            label_28:
            val_17.ExecuteShortcut(shortcut:  public System.Void SRDebugger.Services.IDebugService::HideDebugPanel().__il2cppRuntimeField_20);
        }
        public KeyboardShortcutListenerService()
        {
        
        }
    
    }

}
