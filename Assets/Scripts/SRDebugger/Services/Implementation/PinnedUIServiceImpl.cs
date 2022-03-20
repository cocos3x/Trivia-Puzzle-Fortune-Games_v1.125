using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class PinnedUIServiceImpl : SRServiceBase<SRDebugger.Services.IPinnedUIService>, IPinnedUIService
    {
        // Fields
        private readonly System.Collections.Generic.List<SRDebugger.UI.Controls.OptionsControlBase> _controlList;
        private readonly System.Collections.Generic.Dictionary<SRDebugger.Internal.OptionDefinition, SRDebugger.UI.Controls.OptionsControlBase> _pinnedObjects;
        private bool _queueRefresh;
        private SRDebugger.UI.Other.PinnedUIRoot _uiRoot;
        private System.Action<SRDebugger.Internal.OptionDefinition, bool> OptionPinStateChanged;
        
        // Properties
        public SRDebugger.UI.Other.DockConsoleController DockConsoleController { get; }
        public bool IsProfilerPinned { get; set; }
        
        // Methods
        public SRDebugger.UI.Other.DockConsoleController get_DockConsoleController()
        {
            if(this._uiRoot != 0)
            {
                    return (SRDebugger.UI.Other.DockConsoleController)this._uiRoot.DockConsoleController;
            }
            
            this.Load();
            return (SRDebugger.UI.Other.DockConsoleController)this._uiRoot.DockConsoleController;
        }
        public void add_OptionPinStateChanged(System.Action<SRDebugger.Internal.OptionDefinition, bool> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.OptionPinStateChanged, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OptionPinStateChanged != 1152921519564895288);
            
            return;
            label_2:
        }
        public void remove_OptionPinStateChanged(System.Action<SRDebugger.Internal.OptionDefinition, bool> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.OptionPinStateChanged, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.OptionPinStateChanged != 1152921519565031864);
            
            return;
            label_2:
        }
        public bool get_IsProfilerPinned()
        {
            if(this._uiRoot != 0)
            {
                    return this._uiRoot.Profiler.activeSelf;
            }
            
            return false;
        }
        public void set_IsProfilerPinned(bool value)
        {
            if(this._uiRoot == 0)
            {
                    this.Load();
            }
            
            this._uiRoot.Profiler.SetActive(value:  value);
        }
        public void Pin(SRDebugger.Internal.OptionDefinition obj, int order = -1)
        {
            if(this._uiRoot == 0)
            {
                    this.Load();
            }
            
            if((this._pinnedObjects.ContainsKey(key:  obj)) != false)
            {
                    return;
            }
            
            SRDebugger.UI.Controls.OptionsControlBase val_3 = SRDebugger.Internal.OptionControlFactory.CreateControl(from:  obj, categoryPrefix:  0);
            val_3.CachedTransform.SetParent(parent:  this._uiRoot.Container, worldPositionStays:  false);
            if((order & 2147483648) == 0)
            {
                    val_3.CachedTransform.SetSiblingIndex(index:  order);
            }
            
            this._pinnedObjects.Add(key:  obj, value:  val_3);
            this._controlList.Add(item:  val_3);
            this.OnPinnedStateChanged(option:  obj, isPinned:  true);
        }
        public void Unpin(SRDebugger.Internal.OptionDefinition obj)
        {
            if((this._pinnedObjects.ContainsKey(key:  obj)) == false)
            {
                    return;
            }
            
            SRDebugger.UI.Controls.OptionsControlBase val_2 = this._pinnedObjects.Item[obj];
            bool val_3 = this._pinnedObjects.Remove(key:  obj);
            bool val_4 = this._controlList.Remove(item:  val_2);
            UnityEngine.Object.Destroy(obj:  val_2.CachedGameObject);
            this.OnPinnedStateChanged(option:  obj, isPinned:  false);
        }
        private void OnPinnedStateChanged(SRDebugger.Internal.OptionDefinition option, bool isPinned)
        {
            if(this.OptionPinStateChanged == null)
            {
                    return;
            }
            
            isPinned = isPinned;
            this.OptionPinStateChanged.Invoke(arg1:  option, arg2:  isPinned);
        }
        public void UnpinAll()
        {
            Dictionary.Enumerator<TKey, TValue> val_1 = this._pinnedObjects.GetEnumerator();
            label_6:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  0.CachedGameObject);
            goto label_6;
            label_2:
            0.Dispose();
            this._pinnedObjects.Clear();
            this._controlList.Clear();
        }
        public bool HasPinned(SRDebugger.Internal.OptionDefinition option)
        {
            return this._pinnedObjects.ContainsKey(key:  option);
        }
        protected override void Awake()
        {
            this.Awake();
            this.CachedTransform.SetParent(p:  SRF.Hierarchy.Get(key:  "SRDebugger"));
        }
        private void Load()
        {
            IntPtr val_15;
            IntPtr val_17;
            IntPtr val_19;
            SRDebugger.UI.Other.PinnedUIRoot val_1 = UnityEngine.Resources.Load<SRDebugger.UI.Other.PinnedUIRoot>(path:  "SRDebugger/UI/Prefabs/PinnedUI");
            if(val_1 == 0)
            {
                    UnityEngine.Debug.LogError(message:  "[SRDebugger.PinnedUI] Error loading ui prefab");
                return;
            }
            
            SRDebugger.UI.Other.PinnedUIRoot val_3 = SRInstantiate.Instantiate<SRDebugger.UI.Other.PinnedUIRoot>(prefab:  val_1);
            val_3.CachedTransform.SetParent(parent:  this.CachedTransform, worldPositionStays:  false);
            this._uiRoot = val_3;
            this.UpdateAnchors();
            SRDebugger.VisibilityChangedDelegate val_7 = null;
            val_15 = System.Void SRDebugger.Services.Implementation.PinnedUIServiceImpl::OnDebugPanelVisibilityChanged(bool isVisible);
            val_7 = new SRDebugger.VisibilityChangedDelegate(object:  this, method:  val_15);
            var val_15 = 0;
            val_15 = val_15 + 1;
            val_15 = 20;
            SRDebug.Instance.add_PanelVisibilityChanged(value:  val_7);
            System.EventHandler val_10 = null;
            val_17 = System.Void SRDebugger.Services.Implementation.PinnedUIServiceImpl::OnOptionsUpdated(object sender, System.EventArgs eventArgs);
            val_10 = new System.EventHandler(object:  this, method:  val_17);
            var val_16 = 0;
            val_16 = val_16 + 1;
            val_17 = 0;
            SRDebugger.Internal.Service.Options.add_OptionsUpdated(value:  val_10);
            System.EventHandler<System.ComponentModel.PropertyChangedEventArgs> val_13 = null;
            val_19 = System.Void SRDebugger.Services.Implementation.PinnedUIServiceImpl::OptionsOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs);
            val_13 = new System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(object:  this, method:  val_19);
            var val_17 = 0;
            val_17 = val_17 + 1;
            val_19 = 2;
            SRDebugger.Internal.Service.Options.add_OptionsValueUpdated(value:  val_13);
        }
        private void UpdateAnchors()
        {
            var val_11;
            UnityEngine.TextAnchor val_12;
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            SRDebugger.PinAlignment val_11 = val_1._profilerAlignment;
            if(val_11 <= 5)
            {
                    val_11 = 1 << val_11;
                if((val_11 & 21) == 0)
            {
                    UnityEngine.Transform val_2 = this._uiRoot.Profiler.transform;
                val_11 = 0;
            }
            else
            {
                    val_11 = 1;
            }
            
                this._uiRoot.Profiler.transform.SetSiblingIndex(index:  1);
            }
            
            SRDebugger.Settings val_4 = SRDebugger.Settings.Instance;
            SRDebugger.PinAlignment val_12 = val_4._profilerAlignment;
            if(val_12 > 5)
            {
                goto label_30;
            }
            
            val_12 = 1 << val_12;
            if(val_12 != 3)
            {
                goto label_12;
            }
            
            if((val_12 & 12) != 0)
            {
                goto label_13;
            }
            
            val_12 = 7;
            goto label_19;
            label_12:
            val_12 = 1;
            goto label_19;
            label_13:
            val_12 = 4;
            label_19:
            this._uiRoot.ProfilerVerticalLayoutGroup.childAlignment = val_12;
            label_30:
            SRDebugger.Settings val_5 = SRDebugger.Settings.Instance;
            this._uiRoot.ProfilerHandleManager.SetAlignment(alignment:  val_5._profilerAlignment);
            SRDebugger.Settings val_6 = SRDebugger.Settings.Instance;
            if(val_6._optionsAlignment > 7)
            {
                    return;
            }
            
            var val_13 = 32558164 + (val_6._optionsAlignment) << 2;
            val_13 = val_13 + 32558164;
            goto (32558164 + (val_6._optionsAlignment) << 2 + 32558164);
        }
        protected override void Update()
        {
            this.Update();
            if(this._queueRefresh == false)
            {
                    return;
            }
            
            this._queueRefresh = false;
            this.Refresh();
        }
        private void OnOptionsUpdated(object sender, System.EventArgs eventArgs)
        {
            SRDebugger.Internal.OptionDefinition val_4;
            var val_5;
            var val_10;
            var val_11;
            var val_12;
            List.Enumerator<T> val_3 = System.Linq.Enumerable.ToList<SRDebugger.Internal.OptionDefinition>(source:  this._pinnedObjects.Keys).GetEnumerator();
            label_15:
            val_10 = public System.Boolean List.Enumerator<SRDebugger.Internal.OptionDefinition>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_3;
            }
            
            SRDebugger.Services.IOptionsService val_7 = SRDebugger.Internal.Service.Options;
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_12 = 4;
            val_10 = public System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> SRDebugger.Services.IOptionsService::get_Options();
            val_11 = val_7;
            System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> val_9 = val_11.Options;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_12 = 4;
            if((val_9.Contains(item:  null)) == true)
            {
                goto label_15;
            }
            
            this.Unpin(obj:  val_4);
            goto label_15;
            label_3:
            val_5.Dispose();
        }
        private void OptionsOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs)
        {
            this._queueRefresh = true;
        }
        private void OnDebugPanelVisibilityChanged(bool isVisible)
        {
            if(isVisible == true)
            {
                    return;
            }
            
            this._queueRefresh = true;
        }
        private void Refresh()
        {
            bool val_1 = true;
            var val_2 = 0;
            do
            {
                if(val_2 >= val_1)
            {
                    return;
            }
            
                if(val_1 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + 0;
                val_2 = val_2 + 1;
            }
            while(this._controlList != null);
            
            throw new NullReferenceException();
        }
        public PinnedUIServiceImpl()
        {
            this._controlList = new System.Collections.Generic.List<SRDebugger.UI.Controls.OptionsControlBase>();
            this._pinnedObjects = new System.Collections.Generic.Dictionary<SRDebugger.Internal.OptionDefinition, SRDebugger.UI.Controls.OptionsControlBase>();
        }
    
    }

}
