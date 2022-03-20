using UnityEngine;

namespace SRDebugger
{
    public class Settings : ScriptableObject
    {
        // Fields
        private const string ResourcesPath = "/usr/Resources/SRDebugger";
        private const string ResourcesName = "Settings";
        private static SRDebugger.Settings _instance;
        private bool _isEnabled;
        private bool _autoLoad;
        private SRDebugger.DefaultTabs _defaultTab;
        private SRDebugger.Settings.TriggerEnableModes _triggerEnableMode;
        private SRDebugger.Settings.TriggerBehaviours _triggerBehaviour;
        private bool _enableKeyboardShortcuts;
        private SRDebugger.Settings.KeyboardShortcut[] _keyboardShortcuts;
        private SRDebugger.Settings.KeyboardShortcut[] _newKeyboardShortcuts;
        private bool _keyboardModifierControl;
        private bool _keyboardModifierAlt;
        private bool _keyboardModifierShift;
        private bool _keyboardEscapeClose;
        private bool _enableBackgroundTransparency;
        private bool _collapseDuplicateLogEntries;
        private bool _richTextInConsole;
        private bool _requireEntryCode;
        private bool _requireEntryCodeEveryTime;
        private int[] _entryCode;
        private bool _useDebugCamera;
        private int _debugLayer;
        private float _debugCameraDepth;
        private string _apiKey;
        private bool _enableBugReporter;
        private SRDebugger.DefaultTabs[] _disabledTabs;
        private SRDebugger.PinAlignment _profilerAlignment;
        private SRDebugger.PinAlignment _optionsAlignment;
        private SRDebugger.ConsoleAlignment _consoleAlignment;
        private SRDebugger.PinAlignment _triggerPosition;
        private int _maximumConsoleEntries;
        private bool _enableEventSystemCreation;
        private bool _automaticShowCursor;
        
        // Properties
        public static SRDebugger.Settings Instance { get; }
        public bool IsEnabled { get; }
        public bool AutoLoad { get; }
        public SRDebugger.DefaultTabs DefaultTab { get; }
        public SRDebugger.Settings.TriggerEnableModes EnableTrigger { get; }
        public SRDebugger.Settings.TriggerBehaviours TriggerBehaviour { get; }
        public bool EnableKeyboardShortcuts { get; }
        public System.Collections.Generic.IList<SRDebugger.Settings.KeyboardShortcut> KeyboardShortcuts { get; }
        public bool KeyboardEscapeClose { get; }
        public bool EnableBackgroundTransparency { get; }
        public bool RequireCode { get; }
        public bool RequireEntryCodeEveryTime { get; }
        public System.Collections.Generic.IList<int> EntryCode { get; set; }
        public bool UseDebugCamera { get; }
        public int DebugLayer { get; }
        public float DebugCameraDepth { get; }
        public bool CollapseDuplicateLogEntries { get; }
        public bool RichTextInConsole { get; }
        public string ApiKey { get; }
        public bool EnableBugReporter { get; }
        public System.Collections.Generic.IList<SRDebugger.DefaultTabs> DisabledTabs { get; }
        public SRDebugger.PinAlignment TriggerPosition { get; }
        public SRDebugger.PinAlignment ProfilerAlignment { get; }
        public SRDebugger.PinAlignment OptionsAlignment { get; }
        public SRDebugger.ConsoleAlignment ConsoleAlignment { get; set; }
        public int MaximumConsoleEntries { get; set; }
        public bool EnableEventSystemGeneration { get; set; }
        public bool AutomaticallyShowCursor { get; }
        
        // Methods
        public static SRDebugger.Settings get_Instance()
        {
            SRDebugger.Settings val_3;
            if(SRDebugger.Settings._instance == 0)
            {
                    SRDebugger.Settings._instance = SRDebugger.Settings.GetOrCreateInstance();
            }
            
            val_3 = SRDebugger.Settings._instance;
            if(val_2._keyboardShortcuts == null)
            {
                    return val_3;
            }
            
            if(val_2._keyboardShortcuts.Length == 0)
            {
                    return val_3;
            }
            
            val_3.UpgradeKeyboardShortcuts();
            val_3 = SRDebugger.Settings._instance;
            return val_3;
        }
        private static SRDebugger.Settings.KeyboardShortcut[] GetDefaultKeyboardShortcuts()
        {
            KeyboardShortcut[] val_1 = new KeyboardShortcut[4];
            .Control = true;
            .Shift = true;
            .Key = 282;
            .Action = true;
            val_1[0] = new Settings.KeyboardShortcut();
            .Control = true;
            .Shift = true;
            .Key = 283;
            .Action = 2;
            val_1[1] = new Settings.KeyboardShortcut();
            .Control = true;
            .Shift = true;
            .Key = 284;
            .Action = 3;
            val_1[2] = new Settings.KeyboardShortcut();
            .Control = true;
            .Shift = true;
            .Key = 285;
            .Action = 4;
            val_1[3] = new Settings.KeyboardShortcut();
            return val_1;
        }
        private void UpgradeKeyboardShortcuts()
        {
            UnityEngine.Debug.Log(message:  "[SRDebugger] Upgrading Settings format");
            System.Collections.Generic.List<KeyboardShortcut> val_1 = new System.Collections.Generic.List<KeyboardShortcut>();
            var val_6 = 0;
            label_9:
            if(val_6 >= this._keyboardShortcuts.Length)
            {
                goto label_4;
            }
            
            KeyboardShortcut val_5 = this._keyboardShortcuts[val_6];
            .Action = this._keyboardShortcuts[0x0][0].Action;
            .Key = this._keyboardShortcuts[0x0][0].Key;
            .Alt = this._keyboardModifierAlt;
            .Shift = this._keyboardModifierShift;
            .Control = this._keyboardModifierControl;
            val_1.Add(item:  new Settings.KeyboardShortcut());
            val_6 = val_6 + 1;
            if(this._keyboardShortcuts != null)
            {
                goto label_9;
            }
            
            throw new NullReferenceException();
            label_4:
            this._keyboardShortcuts = new KeyboardShortcut[0];
            this._newKeyboardShortcuts = val_1.ToArray();
        }
        public bool get_IsEnabled()
        {
            return (bool)this._isEnabled;
        }
        public bool get_AutoLoad()
        {
            return (bool)this._autoLoad;
        }
        public SRDebugger.DefaultTabs get_DefaultTab()
        {
            return (SRDebugger.DefaultTabs)this._defaultTab;
        }
        public SRDebugger.Settings.TriggerEnableModes get_EnableTrigger()
        {
            return (TriggerEnableModes)this._triggerEnableMode;
        }
        public SRDebugger.Settings.TriggerBehaviours get_TriggerBehaviour()
        {
            return (TriggerBehaviours)this._triggerBehaviour;
        }
        public bool get_EnableKeyboardShortcuts()
        {
            return (bool)this._enableKeyboardShortcuts;
        }
        public System.Collections.Generic.IList<SRDebugger.Settings.KeyboardShortcut> get_KeyboardShortcuts()
        {
            return (System.Collections.Generic.IList<KeyboardShortcut>)this._newKeyboardShortcuts;
        }
        public bool get_KeyboardEscapeClose()
        {
            return (bool)this._keyboardEscapeClose;
        }
        public bool get_EnableBackgroundTransparency()
        {
            return (bool)this._enableBackgroundTransparency;
        }
        public bool get_RequireCode()
        {
            return (bool)this._requireEntryCode;
        }
        public bool get_RequireEntryCodeEveryTime()
        {
            return (bool)this._requireEntryCodeEveryTime;
        }
        public System.Collections.Generic.IList<int> get_EntryCode()
        {
            return (System.Collections.Generic.IList<System.Int32>)new System.Collections.ObjectModel.ReadOnlyCollection<System.Int32>(list:  this._entryCode);
        }
        public void set_EntryCode(System.Collections.Generic.IList<int> value)
        {
            var val_7;
            System.Func<System.Int32, System.Boolean> val_9;
            string val_11;
            var val_7 = 0;
            val_7 = val_7 + 1;
            if(value.Count != 4)
            {
                goto label_6;
            }
            
            val_7 = null;
            val_7 = null;
            val_9 = Settings.<>c.<>9__35_0;
            if(val_9 == null)
            {
                    System.Func<System.Int32, System.Boolean> val_3 = null;
                val_9 = val_3;
                val_3 = new System.Func<System.Int32, System.Boolean>(object:  Settings.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean Settings.<>c::<set_EntryCode>b__35_0(int p));
                Settings.<>c.<>9__35_0 = val_9;
            }
            
            if((System.Linq.Enumerable.Any<System.Int32>(source:  value, predicate:  val_3)) == true)
            {
                goto label_12;
            }
            
            this._entryCode = System.Linq.Enumerable.ToArray<System.Int32>(source:  value);
            return;
            label_6:
            val_11 = "Entry code must be length 4";
            goto label_13;
            label_12:
            System.Exception val_6 = null;
            val_11 = "All digits in entry code must be >= 0 and <= 9";
            label_13:
            val_6 = new System.Exception(message:  val_11);
            throw val_6;
        }
        public bool get_UseDebugCamera()
        {
            return (bool)this._useDebugCamera;
        }
        public int get_DebugLayer()
        {
            return (int)this._debugLayer;
        }
        public float get_DebugCameraDepth()
        {
            return (float)this._debugCameraDepth;
        }
        public bool get_CollapseDuplicateLogEntries()
        {
            return (bool)this._collapseDuplicateLogEntries;
        }
        public bool get_RichTextInConsole()
        {
            return (bool)this._richTextInConsole;
        }
        public string get_ApiKey()
        {
            return (string)this._apiKey;
        }
        public bool get_EnableBugReporter()
        {
            return (bool)this._enableBugReporter;
        }
        public System.Collections.Generic.IList<SRDebugger.DefaultTabs> get_DisabledTabs()
        {
            return (System.Collections.Generic.IList<SRDebugger.DefaultTabs>)this._disabledTabs;
        }
        public SRDebugger.PinAlignment get_TriggerPosition()
        {
            return (SRDebugger.PinAlignment)this._triggerPosition;
        }
        public SRDebugger.PinAlignment get_ProfilerAlignment()
        {
            return (SRDebugger.PinAlignment)this._profilerAlignment;
        }
        public SRDebugger.PinAlignment get_OptionsAlignment()
        {
            return (SRDebugger.PinAlignment)this._optionsAlignment;
        }
        public SRDebugger.ConsoleAlignment get_ConsoleAlignment()
        {
            return (SRDebugger.ConsoleAlignment)this._consoleAlignment;
        }
        public void set_ConsoleAlignment(SRDebugger.ConsoleAlignment value)
        {
            this._consoleAlignment = value;
        }
        public int get_MaximumConsoleEntries()
        {
            return (int)this._maximumConsoleEntries;
        }
        public void set_MaximumConsoleEntries(int value)
        {
            this._maximumConsoleEntries = value;
        }
        public bool get_EnableEventSystemGeneration()
        {
            return (bool)this._enableEventSystemCreation;
        }
        public void set_EnableEventSystemGeneration(bool value)
        {
            this._enableEventSystemCreation = value;
        }
        public bool get_AutomaticallyShowCursor()
        {
            return (bool)this._automaticShowCursor;
        }
        private static SRDebugger.Settings GetOrCreateInstance()
        {
            SRDebugger.Settings val_1 = UnityEngine.Resources.Load<SRDebugger.Settings>(path:  "SRDebugger/Settings");
            if(val_1 != 0)
            {
                    return val_1;
            }
            
            return UnityEngine.ScriptableObject.CreateInstance<SRDebugger.Settings>();
        }
        public Settings()
        {
            this._isEnabled = true;
            this._autoLoad = true;
            this._enableKeyboardShortcuts = true;
            this._newKeyboardShortcuts = SRDebugger.Settings.GetDefaultKeyboardShortcuts();
            this._keyboardModifierControl = true;
            this._richTextInConsole = true;
            this._keyboardModifierShift = true;
            this._keyboardEscapeClose = true;
            this._enableBackgroundTransparency = true;
            this._collapseDuplicateLogEntries = true;
            this._entryCode = new int[4];
            this._debugLayer = 5;
            this._debugCameraDepth = 100f;
            this._apiKey = "";
            this._disabledTabs = new SRDebugger.DefaultTabs[0];
            this._maximumConsoleEntries = 1500;
            this._profilerAlignment = 6.36598737388395E-314;
            this._enableEventSystemCreation = true;
            this._automaticShowCursor = true;
        }
    
    }

}
