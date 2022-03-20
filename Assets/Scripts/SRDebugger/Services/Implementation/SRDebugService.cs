using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class SRDebugService : IDebugService
    {
        // Fields
        private readonly SRDebugger.Services.IDebugPanelService _debugPanelService;
        private readonly SRDebugger.Services.IDebugTriggerService _debugTrigger;
        private readonly SRDebugger.Services.ISystemInformationService _informationService;
        private readonly SRDebugger.Services.IOptionsService _optionsService;
        private readonly SRDebugger.Services.IPinnedUIService _pinnedUiService;
        private bool _entryCodeEnabled;
        private bool _hasAuthorised;
        private System.Nullable<SRDebugger.DefaultTabs> _queuedTab;
        private UnityEngine.RectTransform _worldSpaceTransform;
        private SRDebugger.VisibilityChangedDelegate PanelVisibilityChanged;
        
        // Properties
        public SRDebugger.Settings Settings { get; }
        public bool IsDebugPanelVisible { get; }
        public bool IsTriggerEnabled { get; set; }
        public bool IsProfilerDocked { get; set; }
        public SRDebugger.Services.IDockConsoleService DockConsole { get; }
        
        // Methods
        public SRDebugService()
        {
            IntPtr val_26;
            var val_28;
            var val_29;
            var val_31;
            bool val_33;
            SRF.Service.SRServiceManager.RegisterService<SRDebugger.Services.IDebugService>(service:  this);
            SRDebugger.Services.IProfilerService val_1 = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IProfilerService>();
            this._debugTrigger = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IDebugTriggerService>();
            this._informationService = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.ISystemInformationService>();
            this._pinnedUiService = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IPinnedUIService>();
            this._optionsService = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IOptionsService>();
            SRDebugger.Services.IDebugPanelService val_6 = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IDebugPanelService>();
            this._debugPanelService = val_6;
            System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean> val_7 = null;
            val_26 = System.Void SRDebugger.Services.Implementation.SRDebugService::DebugPanelServiceOnVisibilityChanged(SRDebugger.Services.IDebugPanelService debugPanelService, bool b);
            val_7 = new System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean>(object:  this, method:  val_26);
            var val_26 = 0;
            val_26 = val_26 + 1;
            val_26 = 4;
            val_28 = public System.Void SRDebugger.Services.IDebugPanelService::add_VisibilityChanged(System.Action<SRDebugger.Services.IDebugPanelService, bool> value);
            val_6.add_VisibilityChanged(value:  val_7);
            SRDebugger.Settings val_9 = SRDebugger.Settings.Instance;
            if(val_9._triggerEnableMode == 0)
            {
                goto label_9;
            }
            
            SRDebugger.Settings val_10 = SRDebugger.Settings.Instance;
            if(val_10._triggerEnableMode != 1)
            {
                goto label_11;
            }
            
            val_29 = UnityEngine.Application.isMobilePlatform;
            if(this._debugTrigger != null)
            {
                goto label_14;
            }
            
            label_9:
            val_29 = 1;
            if(this._debugTrigger != null)
            {
                goto label_14;
            }
            
            label_11:
            val_29 = 0;
            label_14:
            var val_27 = 0;
            val_27 = val_27 + 1;
            val_28 = 1;
            val_31 = public System.Void SRDebugger.Services.IDebugTriggerService::set_IsEnabled(bool value);
            this._debugTrigger.IsEnabled = false;
            SRDebugger.Settings val_13 = SRDebugger.Settings.Instance;
            var val_28 = 0;
            val_28 = val_28 + 1;
            val_31 = 3;
            this._debugTrigger.Position = val_13._triggerPosition;
            SRDebugger.Settings val_15 = SRDebugger.Settings.Instance;
            if(val_15._enableKeyboardShortcuts != false)
            {
                    SRDebugger.Services.Implementation.KeyboardShortcutListenerService val_16 = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.Implementation.KeyboardShortcutListenerService>();
            }
            
            SRDebugger.Settings val_17 = SRDebugger.Settings.Instance;
            val_33 = val_17._requireEntryCode;
            if(val_33 != false)
            {
                    var val_29 = 0;
                val_29 = val_29 + 1;
            }
            
            this._entryCodeEnabled = (SRDebugger.Settings.Instance.EntryCode.Count == 4) ? 1 : 0;
            SRDebugger.Settings val_23 = SRDebugger.Settings.Instance;
            if((val_23._requireEntryCode != false) && (this._entryCodeEnabled != true))
            {
                    UnityEngine.Debug.LogError(message:  "[SRDebugger] RequireCode is enabled, but pin is not 4 digits");
            }
            
            UnityEngine.Object.DontDestroyOnLoad(target:  SRF.Hierarchy.Get(key:  "SRDebugger").gameObject);
        }
        public SRDebugger.Settings get_Settings()
        {
            return SRDebugger.Settings.Instance;
        }
        public bool get_IsDebugPanelVisible()
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            return this._debugPanelService.IsVisible;
        }
        public bool get_IsTriggerEnabled()
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            return this._debugTrigger.IsEnabled;
        }
        public void set_IsTriggerEnabled(bool value)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            this._debugTrigger.IsEnabled = value;
        }
        public bool get_IsProfilerDocked()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return SRDebugger.Internal.Service.PinnedUI.IsProfilerPinned;
        }
        public void set_IsProfilerDocked(bool value)
        {
            var val_4 = 0;
            val_4 = val_4 + 1;
            SRDebugger.Internal.Service.PinnedUI.IsProfilerPinned = value;
        }
        public void AddSystemInfo(SRDebugger.InfoEntry entry, string category = "Default")
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this._informationService.Add(info:  entry, category:  category);
        }
        public void ShowDebugPanel(bool requireEntryCode = True)
        {
            if((requireEntryCode != false) && (this._entryCodeEnabled != false))
            {
                    if(this._hasAuthorised == false)
            {
                goto label_3;
            }
            
            }
            
            var val_5 = 0;
            val_5 = val_5 + 1;
            this._debugPanelService.IsVisible = true;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<ApplovinMaxPlugin>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
            return;
            label_3:
            this.PromptEntryCode();
        }
        public void ShowDebugPanel(SRDebugger.DefaultTabs tab, bool requireEntryCode = True)
        {
            var val_7;
            SRDebugger.DefaultTabs val_8;
            var val_10;
            val_7 = requireEntryCode;
            val_8 = tab;
            if((val_7 != false) && (this._entryCodeEnabled != false))
            {
                    if(this._hasAuthorised == false)
            {
                goto label_3;
            }
            
            }
            
            var val_7 = 0;
            val_7 = val_7 + 1;
            val_10 = public System.Void SRDebugger.Services.IDebugPanelService::set_IsVisible(bool value);
            this._debugPanelService.IsVisible = true;
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_10 = 7;
            this._debugPanelService.OpenTab(tab:  val_8);
            val_7 = 1152921515825666416;
            val_8 = MonoSingleton<ApplovinMaxPlugin>.Instance;
            if((UnityEngine.Object.op_Implicit(exists:  val_8)) == false)
            {
                    return;
            }
            
            MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
            return;
            label_3:
            System.Nullable<SRDebugger.DefaultTabs> val_6 = new System.Nullable<SRDebugger.DefaultTabs>(value:  val_8);
            this._queuedTab = val_6.HasValue;
            this.PromptEntryCode();
        }
        public void HideDebugPanel()
        {
            var val_5 = 0;
            val_5 = val_5 + 1;
            this._debugPanelService.IsVisible = false;
            if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<AdsUIController>.Instance)) == false)
            {
                    return;
            }
            
            MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
        }
        public void DestroyDebugPanel()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            this._debugPanelService.IsVisible = false;
            var val_4 = 0;
            val_4 = val_4 + 1;
            this._debugPanelService.Unload();
        }
        public void AddOptionContainer(object container)
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this._optionsService.AddContainer(obj:  container);
        }
        public void RemoveOptionContainer(object container)
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this._optionsService.RemoveContainer(obj:  container);
        }
        public void PinAllOptions(string category)
        {
            string val_8;
            SRDebugger.Services.IOptionsService val_9;
            val_8 = category;
            val_9 = this._optionsService;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> val_2 = val_9.Options;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_9 = val_2.GetEnumerator();
            label_28:
            var val_14 = 0;
            val_14 = val_14 + 1;
            if(val_9.MoveNext() == false)
            {
                goto label_16;
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            T val_8 = val_9.Current;
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  val_8 + 24, b:  val_8)) == false)
            {
                goto label_28;
            }
            
            if(this._pinnedUiService == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = 0;
            val_16 = val_16 + 1;
            this._pinnedUiService.Pin(option:  val_8, order:  0);
            goto label_28;
            label_16:
            val_8 = 0;
            if(val_9 != null)
            {
                    var val_17 = 0;
                val_17 = val_17 + 1;
                val_9.Dispose();
            }
            
            if(val_8 != 0)
            {
                    throw val_8;
            }
        
        }
        public void UnpinAllOptions(string category)
        {
            string val_8;
            SRDebugger.Services.IOptionsService val_9;
            var val_14;
            val_8 = category;
            val_9 = this._optionsService;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> val_2 = val_9.Options;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_9 = val_2.GetEnumerator();
            label_28:
            var val_14 = 0;
            val_14 = val_14 + 1;
            if(val_9.MoveNext() == false)
            {
                goto label_16;
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            T val_8 = val_9.Current;
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = 0;
            if((System.String.op_Equality(a:  val_8 + 24, b:  val_8)) == false)
            {
                goto label_28;
            }
            
            if(this._pinnedUiService == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = 0;
            val_16 = val_16 + 1;
            val_14 = 5;
            this._pinnedUiService.Unpin(option:  val_8);
            goto label_28;
            label_16:
            val_8 = 0;
            if(val_9 != null)
            {
                    var val_17 = 0;
                val_17 = val_17 + 1;
                val_9.Dispose();
            }
            
            if(val_8 != 0)
            {
                    throw val_8;
            }
        
        }
        public void PinOption(string name)
        {
            string val_8;
            SRDebugger.Services.IOptionsService val_9;
            val_8 = name;
            val_9 = this._optionsService;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> val_2 = val_9.Options;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_9 = val_2.GetEnumerator();
            label_28:
            var val_14 = 0;
            val_14 = val_14 + 1;
            if(val_9.MoveNext() == false)
            {
                goto label_16;
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            T val_8 = val_9.Current;
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  val_8 + 16, b:  val_8)) == false)
            {
                goto label_28;
            }
            
            if(this._pinnedUiService == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = 0;
            val_16 = val_16 + 1;
            this._pinnedUiService.Pin(option:  val_8, order:  0);
            goto label_28;
            label_16:
            val_8 = 0;
            if(val_9 != null)
            {
                    var val_17 = 0;
                val_17 = val_17 + 1;
                val_9.Dispose();
            }
            
            if(val_8 != 0)
            {
                    throw val_8;
            }
        
        }
        public void UnpinOption(string name)
        {
            string val_8;
            SRDebugger.Services.IOptionsService val_9;
            var val_14;
            val_8 = name;
            val_9 = this._optionsService;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> val_2 = val_9.Options;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_9 = val_2.GetEnumerator();
            label_28:
            var val_14 = 0;
            val_14 = val_14 + 1;
            if(val_9.MoveNext() == false)
            {
                goto label_16;
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            T val_8 = val_9.Current;
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = 0;
            if((System.String.op_Equality(a:  val_8 + 16, b:  val_8)) == false)
            {
                goto label_28;
            }
            
            if(this._pinnedUiService == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = 0;
            val_16 = val_16 + 1;
            val_14 = 5;
            this._pinnedUiService.Unpin(option:  val_8);
            goto label_28;
            label_16:
            val_8 = 0;
            if(val_9 != null)
            {
                    var val_17 = 0;
                val_17 = val_17 + 1;
                val_9.Dispose();
            }
            
            if(val_8 != 0)
            {
                    throw val_8;
            }
        
        }
        public void ClearPinnedOptions()
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this._pinnedUiService.UnpinAll();
        }
        public void ShowBugReportSheet(SRDebugger.ActionCompleteCallback onComplete, bool takeScreenshot = True, string descriptionContent)
        {
            .onComplete = onComplete;
            if(val_2._isVisible != false)
            {
                    return;
            }
            
            takeScreenshot = takeScreenshot;
            mem[1152921519570334800] = new SRDebugService.<>c__DisplayClass32_0();
            mem[1152921519570334808] = System.Void SRDebugService.<>c__DisplayClass32_0::<ShowBugReportSheet>b__0(bool succeed, string message);
            mem[1152921519570334784] = System.Void SRDebugService.<>c__DisplayClass32_0::<ShowBugReportSheet>b__0(bool succeed, string message);
            SRF.Service.SRServiceManager.GetService<SRDebugger.Services.Implementation.BugReportPopoverService>().ShowBugReporter(callback:  new SRDebugger.Services.BugReportCompleteCallback(), takeScreenshotFirst:  takeScreenshot, descriptionText:  descriptionContent);
        }
        public SRDebugger.Services.IDockConsoleService get_DockConsole()
        {
            return SRDebugger.Internal.Service.DockConsole;
        }
        public void add_PanelVisibilityChanged(SRDebugger.VisibilityChangedDelegate value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.PanelVisibilityChanged, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.PanelVisibilityChanged != 1152921519570543232);
            
            return;
            label_2:
        }
        public void remove_PanelVisibilityChanged(SRDebugger.VisibilityChangedDelegate value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.PanelVisibilityChanged, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.PanelVisibilityChanged != 1152921519570679808);
            
            return;
            label_2:
        }
        private void DebugPanelServiceOnVisibilityChanged(SRDebugger.Services.IDebugPanelService debugPanelService, bool b)
        {
            if(this.PanelVisibilityChanged == null)
            {
                    return;
            }
            
            this.PanelVisibilityChanged.Invoke(isVisible:  b);
        }
        private void PromptEntryCode()
        {
            var val_5 = null;
            mem[1152921519570995168] = this;
            mem[1152921519570995176] = System.Void SRDebugger.Services.Implementation.SRDebugService::<PromptEntryCode>b__39_0(bool entered);
            mem[1152921519570995152] = System.Void SRDebugger.Services.Implementation.SRDebugService::<PromptEntryCode>b__39_0(bool entered);
            var val_5 = 0;
            val_5 = val_5 + 1;
            SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IPinEntryService>().ShowPinEntry(requiredPin:  SRDebugger.Settings.Instance.EntryCode, message:  SRDebugger.Internal.SRDebugStrings.Current.PinEntryPrompt, callback:  new SRDebugger.Services.PinEntryCompleteCallback(), allowCancel:  true);
        }
        public UnityEngine.RectTransform EnableWorldSpaceMode()
        {
            var val_10;
            UnityEngine.RectTransform val_11;
            val_10 = 0;
            if(this._worldSpaceTransform != 0)
            {
                    val_11 = this._worldSpaceTransform;
                return val_11;
            }
            
            SRDebugger.Settings val_2 = SRDebugger.Settings.Instance;
            if(val_2._useDebugCamera == true)
            {
                    throw new System.InvalidOperationException(message:  "UseDebugCamera cannot be enabled at the same time as EnableWorldSpaceMode.");
            }
            
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_10 = 2;
            this._debugPanelService.IsVisible = true;
            UnityEngine.GameObject val_4 = this._debugPanelService.gameObject;
            SRF.SRFGameObjectExtensions.RemoveComponentIfExists<SRF.UI.SRRetinaScaler>(obj:  val_4);
            UnityEngine.GameObject val_5 = val_4.gameObject;
            SRF.SRFGameObjectExtensions.RemoveComponentIfExists<UnityEngine.UI.CanvasScaler>(obj:  val_5);
            val_5.renderMode = 2;
            val_11 = val_5.GetComponent<UnityEngine.RectTransform>();
            UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  1024f, y:  768f);
            val_11.sizeDelta = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
            UnityEngine.Vector3 val_8 = UnityEngine.Vector3.zero;
            val_11.position = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
            this._worldSpaceTransform = val_11;
            return val_11;
        }
        private void <PromptEntryCode>b__39_0(bool entered)
        {
            System.Nullable<SRDebugger.DefaultTabs> val_3;
            if(entered == false)
            {
                goto label_1;
            }
            
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            if(val_1._requireEntryCodeEveryTime != true)
            {
                    this._hasAuthorised = true;
            }
            
            val_3 = this._queuedTab;
            if(true == 0)
            {
                goto label_4;
            }
            
            this._queuedTab = 0;
            this.ShowDebugPanel(tab:  val_3.Value, requireEntryCode:  false);
            goto label_6;
            label_1:
            val_3 = this._queuedTab;
            goto label_6;
            label_4:
            this.ShowDebugPanel(requireEntryCode:  false);
            label_6:
            mem2[0] = 0;
        }
    
    }

}
