using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class DockConsoleServiceImpl : IDockConsoleService
    {
        // Fields
        private SRDebugger.ConsoleAlignment _alignment;
        private SRDebugger.UI.Other.DockConsoleController _consoleRoot;
        private bool _didSuspendTrigger;
        private bool _isExpanded;
        private bool _isVisible;
        
        // Properties
        public bool IsVisible { get; set; }
        public bool IsExpanded { get; set; }
        public SRDebugger.ConsoleAlignment Alignment { get; set; }
        
        // Methods
        public DockConsoleServiceImpl()
        {
            this._isExpanded = true;
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            this._alignment = val_1._consoleAlignment;
        }
        public bool get_IsVisible()
        {
            return (bool)this._isVisible;
        }
        public void set_IsVisible(bool value)
        {
            var val_1 = (this._isVisible == false) ? 1 : 0;
            val_1 = val_1 ^ value;
            if(val_1 != false)
            {
                    return;
            }
            
            this._isVisible = value;
            if((this._consoleRoot == 0) && (value != false))
            {
                    this.Load();
            }
            else
            {
                    this._consoleRoot.CachedGameObject.SetActive(value:  value);
            }
            
            this.CheckTrigger();
        }
        public bool get_IsExpanded()
        {
            return (bool)this._isExpanded;
        }
        public void set_IsExpanded(bool value)
        {
            var val_1 = (this._isExpanded == false) ? 1 : 0;
            val_1 = val_1 ^ value;
            if(val_1 != false)
            {
                    return;
            }
            
            this._isExpanded = value;
            if((this._consoleRoot == 0) && (value != false))
            {
                    this.Load();
            }
            else
            {
                    this._consoleRoot.SetDropdownVisibility(visible:  value);
            }
            
            this.CheckTrigger();
        }
        public SRDebugger.ConsoleAlignment get_Alignment()
        {
            return (SRDebugger.ConsoleAlignment)this._alignment;
        }
        public void set_Alignment(SRDebugger.ConsoleAlignment value)
        {
            this._alignment = value;
            if(this._consoleRoot != 0)
            {
                    this._consoleRoot.SetAlignmentMode(alignment:  value);
            }
            
            this.CheckTrigger();
        }
        private void Load()
        {
            var val_5;
            object val_6;
            if((SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IPinnedUIService>()) == null)
            {
                goto label_3;
            }
            
            val_5 = 0;
            goto label_5;
            label_3:
            val_6 = "[DockConsoleService] PinnedUIService not found";
            goto label_8;
            label_5:
            if( != 0)
            {
                goto label_11;
            }
            
            val_6 = "[DockConsoleService] Expected IPinnedUIService to be PinnedUIServiceImpl";
            label_8:
            UnityEngine.Debug.LogError(message:  val_6);
            return;
            label_11:
            SRDebugger.UI.Other.DockConsoleController val_4 = DockConsoleController;
            this._consoleRoot = val_4;
            val_4.SetDropdownVisibility(visible:  this._isExpanded);
            this._consoleRoot.IsVisible = this._isVisible;
            this._consoleRoot.SetAlignmentMode(alignment:  this._alignment);
            this.CheckTrigger();
        }
        private void CheckTrigger()
        {
            var val_13;
            var val_15;
            SRDebugger.ConsoleAlignment val_16;
            var val_17;
            var val_18;
            var val_20;
            bool val_23;
            var val_15 = 0;
            val_15 = val_15 + 1;
            val_13 = 2;
            SRDebugger.PinAlignment val_3 = SRDebugger.Internal.Service.Trigger.Position;
            if(val_3 > 7)
            {
                goto label_8;
            }
            
            var val_16 = 1;
            val_16 = val_16 << val_3;
            if(val_16 != 67)
            {
                goto label_7;
            }
            
            if((val_16 & 140) != 0)
            {
                goto label_8;
            }
            
            val_15 = 1152921519560811792;
            val_16 = 1;
            goto label_9;
            label_7:
            val_15 = 1152921519560811792;
            val_16 = 0;
            label_9:
            System.Nullable<SRDebugger.ConsoleAlignment> val_4 = new System.Nullable<SRDebugger.ConsoleAlignment>(value:  val_16);
            label_8:
            if((0 != 0) && (this._isVisible != false))
            {
                    var val_6 = (this._alignment == val_4.HasValue.Value) ? 1 : 0;
            }
            else
            {
                    val_17 = 0;
            }
            
            SRDebugger.Services.IDebugTriggerService val_7 = SRDebugger.Internal.Service.Trigger;
            var val_8 = (this._didSuspendTrigger == false) ? 1 : 0;
            val_8 = val_17 | val_8;
            if((val_8 & 1) == 0)
            {
                goto label_14;
            }
            
            var val_17 = 0;
            val_17 = val_17 + 1;
            val_18 = 0;
            goto label_18;
            label_14:
            var val_18 = 0;
            val_18 = val_18 + 1;
            val_20 = 1;
            goto label_22;
            label_18:
            if((val_17 & val_7.IsEnabled) != true)
            {
                    return;
            }
            
            var val_19 = 0;
            val_19 = val_19 + 1;
            val_18 = 1;
            goto label_28;
            label_22:
            val_7.IsEnabled = true;
            val_23 = 0;
            goto label_29;
            label_28:
            SRDebugger.Internal.Service.Trigger.IsEnabled = false;
            val_23 = true;
            label_29:
            this._didSuspendTrigger = val_23;
        }
    
    }

}
