using UnityEngine;

namespace SRDebugger.UI.Tabs
{
    public class ConsoleTabController : SRMonoBehaviourEx
    {
        // Fields
        private const int MaxLength = 2600;
        private UnityEngine.Canvas _consoleCanvas;
        private bool _isDirty;
        public SRDebugger.UI.Controls.ConsoleLogControl ConsoleLogControl;
        public UnityEngine.UI.Toggle PinToggle;
        public UnityEngine.UI.ScrollRect StackTraceScrollRect;
        public UnityEngine.UI.Text StackTraceText;
        public UnityEngine.UI.Toggle ToggleErrors;
        public UnityEngine.UI.Text ToggleErrorsText;
        public UnityEngine.UI.Toggle ToggleInfo;
        public UnityEngine.UI.Text ToggleInfoText;
        public UnityEngine.UI.Toggle ToggleWarnings;
        public UnityEngine.UI.Text ToggleWarningsText;
        public UnityEngine.UI.Toggle FilterToggle;
        public UnityEngine.UI.InputField FilterField;
        public UnityEngine.GameObject FilterBarContainer;
        
        // Methods
        protected override void Start()
        {
            IntPtr val_16;
            IntPtr val_18;
            this.Start();
            this._consoleCanvas = this.GetComponent<UnityEngine.Canvas>();
            this.ToggleErrors.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SRDebugger.UI.Tabs.ConsoleTabController::<Start>b__16_0(bool isOn)));
            this.ToggleWarnings.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SRDebugger.UI.Tabs.ConsoleTabController::<Start>b__16_1(bool isOn)));
            this.ToggleInfo.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SRDebugger.UI.Tabs.ConsoleTabController::<Start>b__16_2(bool isOn)));
            this.PinToggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SRDebugger.UI.Tabs.ConsoleTabController::PinToggleValueChanged(bool isOn)));
            this.FilterToggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SRDebugger.UI.Tabs.ConsoleTabController::FilterToggleValueChanged(bool isOn)));
            this.FilterBarContainer.SetActive(value:  this.FilterToggle.m_IsOn);
            this.FilterField.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void SRDebugger.UI.Tabs.ConsoleTabController::FilterValueChanged(string filterText)));
            this.ConsoleLogControl.SelectedItemChanged = new System.Action<SRDebugger.Services.ConsoleEntry>(object:  this, method:  System.Void SRDebugger.UI.Tabs.ConsoleTabController::ConsoleLogSelectedItemChanged(object item));
            SRDebugger.Services.ConsoleUpdatedEventHandler val_10 = null;
            val_16 = System.Void SRDebugger.UI.Tabs.ConsoleTabController::ConsoleOnUpdated(SRDebugger.Services.IConsoleService console);
            val_10 = new SRDebugger.Services.ConsoleUpdatedEventHandler(object:  this, method:  val_16);
            var val_16 = 0;
            val_16 = val_16 + 1;
            val_16 = 5;
            SRDebugger.Internal.Service.Console.add_Updated(value:  val_10);
            System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean> val_13 = null;
            val_18 = System.Void SRDebugger.UI.Tabs.ConsoleTabController::PanelOnVisibilityChanged(SRDebugger.Services.IDebugPanelService debugPanelService, bool b);
            val_13 = new System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean>(object:  this, method:  val_18);
            var val_17 = 0;
            val_17 = val_17 + 1;
            val_18 = 4;
            SRDebugger.Internal.Service.Panel.add_VisibilityChanged(value:  val_13);
            SRDebugger.Settings val_15 = SRDebugger.Settings.Instance;
            this.StackTraceText.supportRichText = val_15._richTextInConsole;
            this.PopulateStackTraceArea(entry:  0);
            this.Refresh();
        }
        private void FilterToggleValueChanged(bool isOn)
        {
            if(isOn != false)
            {
                    this.FilterBarContainer.SetActive(value:  true);
                if((System.String.op_Inequality(a:  this.ConsoleLogControl._filter, b:  this.FilterField.m_Text)) == false)
            {
                    return;
            }
            
                this.ConsoleLogControl._filter = this.FilterField.m_Text;
                this.ConsoleLogControl._isDirty = true;
                return;
            }
            
            if((System.String.op_Inequality(a:  this.ConsoleLogControl._filter, b:  0)) != false)
            {
                    this.ConsoleLogControl._filter = 0;
                this.ConsoleLogControl._isDirty = true;
            }
            
            this.FilterBarContainer.SetActive(value:  false);
        }
        private void FilterValueChanged(string filterText)
        {
            string val_5;
            if(this.FilterToggle.m_IsOn != false)
            {
                    val_5 = filterText;
                if((System.String.IsNullOrEmpty(value:  filterText)) != true)
            {
                    string val_2 = val_5.Trim();
                if(val_2.m_stringLength != 0)
            {
                    if((System.String.op_Inequality(a:  this.ConsoleLogControl._filter, b:  val_5)) == false)
            {
                    return;
            }
            
                this.ConsoleLogControl._filter = val_5;
                this.ConsoleLogControl._isDirty = true;
                return;
            }
            
            }
            
            }
            
            val_5 = this.ConsoleLogControl;
            if((System.String.op_Inequality(a:  this.ConsoleLogControl._filter, b:  0)) == false)
            {
                    return;
            }
            
            this.ConsoleLogControl._filter = 0;
            this.ConsoleLogControl._isDirty = true;
        }
        private void PanelOnVisibilityChanged(SRDebugger.Services.IDebugPanelService debugPanelService, bool b)
        {
            var val_2;
            if(this._consoleCanvas == 0)
            {
                    return;
            }
            
            if(b != false)
            {
                    val_2 = 1;
            }
            else
            {
                    val_2 = 0;
            }
            
            this._consoleCanvas.enabled = false;
        }
        private void PinToggleValueChanged(bool isOn)
        {
            var val_4 = 0;
            val_4 = val_4 + 1;
            SRDebugger.Internal.Service.DockConsole.IsVisible = isOn;
        }
        protected override void OnDestroy()
        {
            IntPtr val_5;
            if(SRDebugger.Internal.Service.Console != null)
            {
                    SRDebugger.Services.ConsoleUpdatedEventHandler val_3 = null;
                val_5 = System.Void SRDebugger.UI.Tabs.ConsoleTabController::ConsoleOnUpdated(SRDebugger.Services.IConsoleService console);
                val_3 = new SRDebugger.Services.ConsoleUpdatedEventHandler(object:  this, method:  val_5);
                var val_5 = 0;
                val_5 = val_5 + 1;
                val_5 = 6;
                SRDebugger.Internal.Service.Console.remove_Updated(value:  val_3);
            }
            
            this.OnDestroy();
        }
        protected override void OnEnable()
        {
            this.OnEnable();
            this._isDirty = true;
        }
        private void ConsoleLogSelectedItemChanged(object item)
        {
            var val_1 = 0;
            this.PopulateStackTraceArea(entry:  null);
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
        private void PopulateStackTraceArea(SRDebugger.Services.ConsoleEntry entry)
        {
            var val_7;
            string val_8;
            var val_9;
            var val_10;
            val_7 = entry;
            if(val_7 == null)
            {
                goto label_1;
            }
            
            val_8 = System.Environment.NewLine;
            if((System.String.IsNullOrEmpty(value:  entry.StackTrace)) != false)
            {
                    val_9 = null;
                val_9 = null;
                SRDebugger.Internal.SRDebugStrings.Current.Console_NoStackTrace
            }
            
            if(val_3.m_stringLength < 2601)
            {
                goto label_12;
            }
            
            val_8 = 1152921505017122816;
            val_10 = null;
            val_10 = null;
            string val_5 = entry.Message + val_8 + mem[SRDebugger.Internal.SRDebugStrings.Current.Console_NoStackTrace].Substring(startIndex:  0, length:  40)(entry.Message + val_8 + mem[SRDebugger.Internal.SRDebugStrings.Current.Console_NoStackTrace].Substring(startIndex:  0, length:  40)) + "\n" + SRDebugger.Internal.SRDebugStrings.Current.Console_MessageTruncated;
            goto label_12;
            label_1:
            label_12:
            UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  0f, y:  1f);
            this.StackTraceScrollRect.normalizedPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        }
        private void Refresh()
        {
            var val_17 = 0;
            val_17 = val_17 + 1;
            string val_4 = SRDebugger.Internal.SRDebuggerUtil.GetNumberString(value:  SRDebugger.Internal.Service.Console.InfoCount, max:  231, exceedsMaxString:  "999+");
            var val_18 = 0;
            val_18 = val_18 + 1;
            string val_8 = SRDebugger.Internal.SRDebuggerUtil.GetNumberString(value:  SRDebugger.Internal.Service.Console.WarningCount, max:  231, exceedsMaxString:  "999+");
            var val_19 = 0;
            val_19 = val_19 + 1;
            string val_12 = SRDebugger.Internal.SRDebuggerUtil.GetNumberString(value:  SRDebugger.Internal.Service.Console.ErrorCount, max:  231, exceedsMaxString:  "999+");
            this.ConsoleLogControl._isDirty = true;
            this.ConsoleLogControl._showErrors = this.ToggleErrors.m_IsOn;
            this.ConsoleLogControl._isDirty = true;
            this.ConsoleLogControl._showWarnings = this.ToggleWarnings.m_IsOn;
            this.ConsoleLogControl._isDirty = true;
            this.ConsoleLogControl._showInfo = this.ToggleInfo.m_IsOn;
            var val_20 = 0;
            val_20 = val_20 + 1;
            this.PinToggle.isOn = SRDebugger.Internal.Service.DockConsole.IsVisible;
            this._isDirty = false;
        }
        private void ConsoleOnUpdated(SRDebugger.Services.IConsoleService console)
        {
            this._isDirty = true;
        }
        public void Clear()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRDebugger.Internal.Service.Console.Clear();
            this._isDirty = true;
        }
        public ConsoleTabController()
        {
        
        }
        private void <Start>b__16_0(bool isOn)
        {
            this._isDirty = true;
        }
        private void <Start>b__16_1(bool isOn)
        {
            this._isDirty = true;
        }
        private void <Start>b__16_2(bool isOn)
        {
            this._isDirty = true;
        }
    
    }

}
