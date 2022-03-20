using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class ConsoleLogControl : SRMonoBehaviourEx
    {
        // Fields
        private SRF.UI.Layout.VirtualVerticalLayoutGroup _consoleScrollLayoutGroup;
        private UnityEngine.UI.ScrollRect _consoleScrollRect;
        private bool _isDirty;
        private System.Nullable<UnityEngine.Vector2> _scrollPosition;
        private bool _showErrors;
        private bool _showInfo;
        private bool _showWarnings;
        public System.Action<SRDebugger.Services.ConsoleEntry> SelectedItemChanged;
        private string _filter;
        
        // Properties
        public bool ShowErrors { get; set; }
        public bool ShowWarnings { get; set; }
        public bool ShowInfo { get; set; }
        public bool EnableSelection { get; set; }
        public string Filter { get; set; }
        
        // Methods
        public bool get_ShowErrors()
        {
            return (bool)this._showErrors;
        }
        public void set_ShowErrors(bool value)
        {
            this._showErrors = value;
            this._isDirty = true;
        }
        public bool get_ShowWarnings()
        {
            return (bool)this._showWarnings;
        }
        public void set_ShowWarnings(bool value)
        {
            this._showWarnings = value;
            this._isDirty = true;
        }
        public bool get_ShowInfo()
        {
            return (bool)this._showInfo;
        }
        public void set_ShowInfo(bool value)
        {
            this._showInfo = value;
            this._isDirty = true;
        }
        public bool get_EnableSelection()
        {
            if(this._consoleScrollLayoutGroup != null)
            {
                    return (bool)this._consoleScrollLayoutGroup.EnableSelection;
            }
            
            throw new NullReferenceException();
        }
        public void set_EnableSelection(bool value)
        {
            if(this._consoleScrollLayoutGroup != null)
            {
                    this._consoleScrollLayoutGroup.EnableSelection = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public string get_Filter()
        {
            return (string)this._filter;
        }
        public void set_Filter(string value)
        {
            if((System.String.op_Inequality(a:  this._filter, b:  value)) == false)
            {
                    return;
            }
            
            this._filter = value;
            this._isDirty = true;
        }
        protected override void Awake()
        {
            IntPtr val_5;
            this.Awake();
            this._consoleScrollLayoutGroup._selectedItemChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Object>(object:  this, method:  System.Void SRDebugger.UI.Controls.ConsoleLogControl::OnSelectedItemChanged(object arg0)));
            SRDebugger.Services.ConsoleUpdatedEventHandler val_3 = null;
            val_5 = System.Void SRDebugger.UI.Controls.ConsoleLogControl::ConsoleOnUpdated(SRDebugger.Services.IConsoleService console);
            val_3 = new SRDebugger.Services.ConsoleUpdatedEventHandler(object:  this, method:  val_5);
            var val_5 = 0;
            val_5 = val_5 + 1;
            val_5 = 5;
            SRDebugger.Internal.Service.Console.add_Updated(value:  val_3);
        }
        protected override void Start()
        {
            this.Start();
            this._isDirty = true;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.ScrollToBottom());
        }
        private System.Collections.IEnumerator ScrollToBottom()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ConsoleLogControl.<ScrollToBottom>d__26();
        }
        protected override void OnDestroy()
        {
            IntPtr val_5;
            if(SRDebugger.Internal.Service.Console != null)
            {
                    SRDebugger.Services.ConsoleUpdatedEventHandler val_3 = null;
                val_5 = System.Void SRDebugger.UI.Controls.ConsoleLogControl::ConsoleOnUpdated(SRDebugger.Services.IConsoleService console);
                val_3 = new SRDebugger.Services.ConsoleUpdatedEventHandler(object:  this, method:  val_5);
                var val_5 = 0;
                val_5 = val_5 + 1;
                val_5 = 6;
                SRDebugger.Internal.Service.Console.remove_Updated(value:  val_3);
            }
            
            this.OnDestroy();
        }
        private void OnSelectedItemChanged(object arg0)
        {
            var val_1 = 0;
            if(this.SelectedItemChanged == null)
            {
                    return;
            }
            
            this.SelectedItemChanged.Invoke(obj:  null);
        }
        protected override void Update()
        {
            this.Update();
            if(true != 0)
            {
                    UnityEngine.Vector2 val_1 = this._scrollPosition.Value;
                this._consoleScrollRect.normalizedPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
                mem2[0] = 0;
                mem2[0] = 0;
            }
            
            if(this._isDirty == false)
            {
                    return;
            }
            
            this.Refresh();
        }
        private void Refresh()
        {
            var val_12;
            UnityEngine.Vector2 val_1 = this._consoleScrollRect.normalizedPosition;
            if((SRF.SRFFloatExtensions.ApproxZero(f:  val_1.y)) != false)
            {
                    UnityEngine.Vector2 val_3 = this._consoleScrollRect.normalizedPosition;
                System.Nullable<UnityEngine.Vector2> val_4 = new System.Nullable<UnityEngine.Vector2>(value:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
                this._scrollPosition = val_4.HasValue;
                mem[1152921519531153284] = 0;
            }
            
            this._consoleScrollLayoutGroup.ClearItems();
            var val_14 = 0;
            val_14 = val_14 + 1;
            SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry> val_7 = SRDebugger.Internal.Service.Console.Entries;
            val_12 = 0;
            goto label_11;
            label_35:
            var val_15 = 0;
            val_15 = val_15 + 1;
            T val_9 = val_7.Item[0];
            if((val_9 + 36) > 4)
            {
                goto label_21;
            }
            
            var val_16 = 32557708 + (val_9 + 36) << 2;
            val_16 = val_16 + 32557708;
            goto (32557708 + (val_9 + 36) << 2 + 32557708);
            label_21:
            if((System.String.IsNullOrEmpty(value:  this._filter)) != true)
            {
                    if(((val_9 + 40.IndexOf(value:  this._filter, comparisonType:  5)) & 2147483648) != 0)
            {
                goto label_26;
            }
            
            }
            
            this._consoleScrollLayoutGroup.AddItem(item:  val_9);
            goto label_30;
            label_26:
            if(val_9 == this._consoleScrollLayoutGroup._selectedItem)
            {
                    this._consoleScrollLayoutGroup.SelectedItem = 0;
            }
            
            label_30:
            val_12 = 1;
            label_11:
            var val_17 = 0;
            val_17 = val_17 + 1;
            if(val_12 < val_7.Count)
            {
                goto label_35;
            }
            
            this._isDirty = false;
        }
        private void SetIsDirty()
        {
            this._isDirty = true;
        }
        private void ConsoleOnUpdated(SRDebugger.Services.IConsoleService console)
        {
            this._isDirty = true;
        }
        public ConsoleLogControl()
        {
            this._showErrors = true;
        }
    
    }

}
