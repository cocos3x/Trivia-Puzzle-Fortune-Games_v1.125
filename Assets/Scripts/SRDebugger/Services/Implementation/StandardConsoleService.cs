using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class StandardConsoleService : IConsoleService
    {
        // Fields
        private readonly bool _collapseEnabled;
        private bool _hasCleared;
        private readonly SRDebugger.CircularBuffer<SRDebugger.Services.ConsoleEntry> _allConsoleEntries;
        private SRDebugger.CircularBuffer<SRDebugger.Services.ConsoleEntry> _consoleEntries;
        private readonly object _threadLock;
        private int <ErrorCount>k__BackingField;
        private int <WarningCount>k__BackingField;
        private int <InfoCount>k__BackingField;
        private SRDebugger.Services.ConsoleUpdatedEventHandler Updated;
        
        // Properties
        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
        public int InfoCount { get; set; }
        public SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry> Entries { get; }
        public SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry> AllEntries { get; }
        
        // Methods
        public StandardConsoleService()
        {
            this._threadLock = new System.Object();
            UnityEngine.Application.RegisterLogCallbackThreaded(handler:  new Application.LogCallback(object:  this, method:  System.Void SRDebugger.Services.Implementation.StandardConsoleService::UnityLogCallback(string condition, string stackTrace, UnityEngine.LogType type)));
            SRF.Service.SRServiceManager.RegisterService<SRDebugger.Services.IConsoleService>(service:  this);
            SRDebugger.Settings val_3 = SRDebugger.Settings.Instance;
            this._collapseEnabled = val_3._collapseDuplicateLogEntries;
            SRDebugger.Settings val_4 = SRDebugger.Settings.Instance;
            this._allConsoleEntries = new SRDebugger.CircularBuffer<SRDebugger.Services.ConsoleEntry>(capacity:  val_4._maximumConsoleEntries);
        }
        public int get_ErrorCount()
        {
            return (int)this.<ErrorCount>k__BackingField;
        }
        private void set_ErrorCount(int value)
        {
            this.<ErrorCount>k__BackingField = value;
        }
        public int get_WarningCount()
        {
            return (int)this.<WarningCount>k__BackingField;
        }
        private void set_WarningCount(int value)
        {
            this.<WarningCount>k__BackingField = value;
        }
        public int get_InfoCount()
        {
            return (int)this.<InfoCount>k__BackingField;
        }
        private void set_InfoCount(int value)
        {
            this.<InfoCount>k__BackingField = value;
        }
        public void add_Updated(SRDebugger.Services.ConsoleUpdatedEventHandler value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.Updated, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Updated != 1152921519572477456);
            
            return;
            label_2:
        }
        public void remove_Updated(SRDebugger.Services.ConsoleUpdatedEventHandler value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Updated, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Updated != 1152921519572614032);
            
            return;
            label_2:
        }
        public SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry> get_Entries()
        {
            var val_1 = (this._hasCleared == false) ? 24 : 32;
            return (SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry>)null;
        }
        public SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry> get_AllEntries()
        {
            return (SRDebugger.IReadOnlyList<SRDebugger.Services.ConsoleEntry>)this._allConsoleEntries;
        }
        public void Clear()
        {
            bool val_1 = false;
            System.Threading.Monitor.Enter(obj:  this._threadLock, lockTaken: ref  val_1);
            this._hasCleared = true;
            if(this._consoleEntries == null)
            {
                    SRDebugger.Settings val_2 = SRDebugger.Settings.Instance;
                this._consoleEntries = new SRDebugger.CircularBuffer<SRDebugger.Services.ConsoleEntry>(capacity:  val_2._maximumConsoleEntries);
            }
            
            this.<InfoCount>k__BackingField = 0;
            this.<ErrorCount>k__BackingField = 0;
            this.<WarningCount>k__BackingField = 0;
            if(val_1 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  this._threadLock);
            }
            
            if(0 != 0)
            {
                    throw 0;
            }
            
            this.OnUpdated();
        }
        protected void OnEntryAdded(SRDebugger.Services.ConsoleEntry entry)
        {
            SRDebugger.CircularBuffer<SRDebugger.Services.ConsoleEntry> val_5;
            if(this._hasCleared == false)
            {
                goto label_1;
            }
            
            if(this._consoleEntries.IsFull == false)
            {
                goto label_3;
            }
            
            SRDebugger.Services.ConsoleEntry val_2 = this._consoleEntries.Front();
            if(val_2.LogType > 4)
            {
                goto label_14;
            }
            
            var val_5 = 32558196 + (val_2.LogType) << 2;
            val_5 = val_5 + 32558196;
            goto (32558196 + (val_2.LogType) << 2 + 32558196);
            label_1:
            val_5 = this;
            if(this._allConsoleEntries.IsFull == false)
            {
                goto label_17;
            }
            
            SRDebugger.Services.ConsoleEntry val_4 = this._allConsoleEntries.Front();
            if(val_4.LogType > 4)
            {
                goto label_18;
            }
            
            var val_7 = 32558216 + (val_4.LogType) << 2;
            val_7 = val_7 + 32558216;
            goto (32558216 + (val_4.LogType) << 2 + 32558216);
            label_14:
            this._consoleEntries.PopFront();
            label_3:
            this._consoleEntries.PushBack(item:  entry);
            val_5 = this._allConsoleEntries;
            goto label_17;
            label_18:
            this._allConsoleEntries._start.PopFront();
            label_17:
            this._allConsoleEntries._start.PushBack(item:  entry);
            this.OnUpdated();
        }
        protected void OnEntryDuplicated(SRDebugger.Services.ConsoleEntry entry)
        {
            int val_2 = entry.Count;
            val_2 = val_2 + 1;
            entry.Count = val_2;
            this.OnUpdated();
            if(this._hasCleared == false)
            {
                    return;
            }
            
            if(this._consoleEntries != null)
            {
                    return;
            }
            
            .Count = 1;
            this.OnEntryAdded(entry:  new SRDebugger.Services.ConsoleEntry(other:  entry));
        }
        private void OnUpdated()
        {
            if(this.Updated == null)
            {
                    return;
            }
            
            this.Updated.Invoke(console:  this);
        }
        private void UnityLogCallback(string condition, string stackTrace, UnityEngine.LogType type)
        {
            var val_7;
            bool val_1 = false;
            System.Threading.Monitor.Enter(obj:  this._threadLock, lockTaken: ref  val_1);
            if((this._collapseEnabled == false) || (W9 <= 0))
            {
                goto label_7;
            }
            
            SRDebugger.Services.ConsoleEntry val_3 = this._allConsoleEntries.Item[W9 - 1];
            if((((val_3 == null) || (val_3.LogType != type)) || ((System.String.op_Equality(a:  val_3.Message, b:  condition)) == false)) || ((System.String.op_Equality(a:  val_3.StackTrace, b:  stackTrace)) == false))
            {
                goto label_7;
            }
            
            this.OnEntryDuplicated(entry:  val_3);
            goto label_8;
            label_7:
            SRDebugger.Services.ConsoleEntry val_6 = null;
            .Count = 1;
            val_6 = new SRDebugger.Services.ConsoleEntry();
            .LogType = type;
            .Message = condition;
            .StackTrace = stackTrace;
            this.OnEntryAdded(entry:  val_6);
            label_8:
            if(type <= 4)
            {
                    var val_7 = 32558256 + (type) << 2;
                val_7 = val_7 + 32558256;
            }
            else
            {
                    val_7 = 0;
                if(val_1 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  this._threadLock);
            }
            
                if(val_7 != 0)
            {
                    throw val_7;
            }
            
            }
        
        }
        private void AdjustCounter(UnityEngine.LogType type, int amount)
        {
            if(type > 4)
            {
                    return;
            }
            
            var val_1 = 32558236 + (type) << 2;
            val_1 = val_1 + 32558236;
            goto (32558236 + (type) << 2 + 32558236);
        }
    
    }

}
