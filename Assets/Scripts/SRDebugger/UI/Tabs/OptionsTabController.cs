using UnityEngine;

namespace SRDebugger.UI.Tabs
{
    public class OptionsTabController : SRMonoBehaviourEx
    {
        // Fields
        private readonly System.Collections.Generic.List<SRDebugger.UI.Controls.OptionsControlBase> _controls;
        private readonly System.Collections.Generic.List<SRDebugger.UI.Tabs.OptionsTabController.CategoryInstance> _categories;
        private readonly System.Collections.Generic.Dictionary<SRDebugger.Internal.OptionDefinition, SRDebugger.UI.Controls.OptionsControlBase> _options;
        private bool _queueRefresh;
        private bool _selectionModeEnabled;
        private UnityEngine.Canvas _optionCanvas;
        public SRDebugger.UI.Controls.Data.ActionControl ActionControlPrefab;
        public SRDebugger.UI.Other.CategoryGroup CategoryGroupPrefab;
        public UnityEngine.RectTransform ContentContainer;
        public UnityEngine.GameObject NoOptionsNotice;
        public UnityEngine.UI.Toggle PinButton;
        public UnityEngine.GameObject PinPromptSpacer;
        public UnityEngine.GameObject PinPromptText;
        private bool _isTogglingCategory;
        
        // Methods
        protected override void Start()
        {
            IntPtr val_12;
            IntPtr val_14;
            IntPtr val_16;
            this.Start();
            this.PinButton.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  public System.Void SRDebugger.UI.Tabs.OptionsTabController::SetSelectionModeEnabled(bool isEnabled)));
            this.PinPromptText.SetActive(value:  false);
            this.Populate();
            this._optionCanvas = this.GetComponent<UnityEngine.Canvas>();
            System.EventHandler val_4 = null;
            val_12 = System.Void SRDebugger.UI.Tabs.OptionsTabController::OnOptionsUpdated(object sender, System.EventArgs eventArgs);
            val_4 = new System.EventHandler(object:  this, method:  val_12);
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_12 = 0;
            SRDebugger.Internal.Service.Options.add_OptionsUpdated(value:  val_4);
            System.EventHandler<System.ComponentModel.PropertyChangedEventArgs> val_7 = null;
            val_14 = System.Void SRDebugger.UI.Tabs.OptionsTabController::OnOptionsValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs);
            val_7 = new System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(object:  this, method:  val_14);
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_14 = 2;
            SRDebugger.Internal.Service.Options.add_OptionsValueUpdated(value:  val_7);
            System.Action<SRDebugger.Internal.OptionDefinition, System.Boolean> val_10 = null;
            val_16 = System.Void SRDebugger.UI.Tabs.OptionsTabController::OnOptionPinnedStateChanged(SRDebugger.Internal.OptionDefinition optionDefinition, bool isPinned);
            val_10 = new System.Action<SRDebugger.Internal.OptionDefinition, System.Boolean>(object:  this, method:  val_16);
            var val_14 = 0;
            val_14 = val_14 + 1;
            val_16 = 0;
            SRDebugger.Internal.Service.PinnedUI.add_OptionPinStateChanged(value:  val_10);
        }
        private void OnOptionPinnedStateChanged(SRDebugger.Internal.OptionDefinition optionDefinition, bool isPinned)
        {
            if((this._options.ContainsKey(key:  optionDefinition)) == false)
            {
                    return;
            }
            
            this._options.Item[optionDefinition].IsSelected = isPinned;
        }
        private void OnOptionsUpdated(object sender, System.EventArgs eventArgs)
        {
            this.Clear();
            this.Populate();
        }
        private void OnOptionsValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs)
        {
            this._queueRefresh = true;
        }
        protected override void OnEnable()
        {
            IntPtr val_4;
            this.OnEnable();
            System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean> val_2 = null;
            val_4 = System.Void SRDebugger.UI.Tabs.OptionsTabController::PanelOnVisibilityChanged(SRDebugger.Services.IDebugPanelService debugPanelService, bool b);
            val_2 = new System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean>(object:  this, method:  val_4);
            var val_4 = 0;
            val_4 = val_4 + 1;
            val_4 = 4;
            SRDebugger.Internal.Service.Panel.add_VisibilityChanged(value:  val_2);
        }
        protected override void OnDisable()
        {
            IntPtr val_5;
            this.SetSelectionModeEnabled(isEnabled:  false);
            if(SRDebugger.Internal.Service.Panel != null)
            {
                    System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean> val_3 = null;
                val_5 = System.Void SRDebugger.UI.Tabs.OptionsTabController::PanelOnVisibilityChanged(SRDebugger.Services.IDebugPanelService debugPanelService, bool b);
                val_3 = new System.Action<SRDebugger.Services.IDebugPanelService, System.Boolean>(object:  this, method:  val_5);
                var val_5 = 0;
                val_5 = val_5 + 1;
                val_5 = 5;
                SRDebugger.Internal.Service.Panel.remove_VisibilityChanged(value:  val_3);
            }
            
            this.OnDisable();
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
        private void PanelOnVisibilityChanged(SRDebugger.Services.IDebugPanelService debugPanelService, bool b)
        {
            if(b == false)
            {
                goto label_1;
            }
            
            if(this.CachedGameObject.activeInHierarchy == true)
            {
                goto label_3;
            }
            
            goto label_4;
            label_1:
            this.SetSelectionModeEnabled(isEnabled:  false);
            label_3:
            this.Refresh();
            label_4:
            if(this._optionCanvas == 0)
            {
                    return;
            }
            
            this._optionCanvas.enabled = b;
        }
        public void SetSelectionModeEnabled(bool isEnabled)
        {
            var val_5;
            SRDebugger.Internal.OptionDefinition val_6;
            var val_16;
            var val_17;
            bool val_18;
            var val_19;
            var val_1 = (this._selectionModeEnabled == true) ? 1 : 0;
            val_1 = val_1 ^ isEnabled;
            if(val_1 == false)
            {
                    return;
            }
            
            isEnabled = isEnabled;
            this._selectionModeEnabled = isEnabled;
            this.PinButton.isOn = isEnabled;
            val_17 = 0;
            this.PinPromptText.SetActive(value:  isEnabled);
            Dictionary.Enumerator<TKey, TValue> val_3 = this._options.GetEnumerator();
            label_13:
            val_18 = public System.Boolean Dictionary.Enumerator<SRDebugger.Internal.OptionDefinition, SRDebugger.UI.Controls.OptionsControlBase>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_5;
            }
            
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_18 = isEnabled;
            val_6.SelectionModeEnabled = val_18;
            if(isEnabled == false)
            {
                goto label_13;
            }
            
            SRDebugger.Services.IPinnedUIService val_8 = SRDebugger.Internal.Service.PinnedUI;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_14 = 0;
            val_14 = val_14 + 1;
            val_17 = 7;
            SRDebugger.Internal.OptionDefinition val_15 = val_6;
            val_15 = val_8.HasPinned(option:  val_15);
            val_6.IsSelected = val_15;
            goto label_13;
            label_5:
            val_5.Dispose();
            List.Enumerator<T> val_11 = this._categories.GetEnumerator();
            val_16 = 1152921519512425264;
            label_18:
            val_18 = public System.Boolean List.Enumerator<CategoryInstance>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_15;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = 11993091;
            if(val_19 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_19.SelectionModeEnabled = isEnabled;
            goto label_18;
            label_15:
            0.Dispose();
            this.RefreshCategorySelection();
        }
        private void Refresh()
        {
            var val_5;
            bool val_5 = true;
            val_5 = 0;
            do
            {
                if(val_5 >= this._options.Count)
            {
                    return;
            }
            
                if(val_5 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = val_5 + 0;
                var val_6 = (true + 0) + 32;
                if(val_6 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_6 = val_6 + 0;
                if(val_6 <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_6 = val_6 + 0;
                var val_7 = 0;
                val_7 = val_7 + 1;
                SRDebugger.Internal.OptionDefinition val_8 = (((true + 0) + 32 + 0) + 0) + 32 + 88;
                val_8 = SRDebugger.Internal.Service.PinnedUI.HasPinned(option:  val_8);
                ((true + 0) + 32 + 0) + 32.IsSelected = val_8;
                val_5 = val_5 + 1;
            }
            while(this._options != null);
            
            throw new NullReferenceException();
        }
        private void CommitPinnedOptions()
        {
            SRDebugger.Internal.OptionDefinition val_3;
            var val_4;
            SRDebugger.Internal.OptionDefinition val_14;
            var val_15;
            var val_16;
            var val_18;
            var val_21;
            Dictionary.Enumerator<TKey, TValue> val_1 = this._options.GetEnumerator();
            label_31:
            val_14 = public System.Boolean Dictionary.Enumerator<SRDebugger.Internal.OptionDefinition, SRDebugger.UI.Controls.OptionsControlBase>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_16 = mem[val_3 + 80];
            val_16 = val_3 + 80;
            if(val_16 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_3 + 80 + 280) == 0)
            {
                goto label_5;
            }
            
            SRDebugger.Services.IPinnedUIService val_6 = SRDebugger.Internal.Service.PinnedUI;
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = 0;
            val_16 = val_16 + 1;
            val_18 = public System.Boolean SRDebugger.Services.IPinnedUIService::HasPinned(SRDebugger.Internal.OptionDefinition option);
            val_15 = val_6;
            val_14 = val_3;
            if((val_15.HasPinned(option:  val_14)) == false)
            {
                goto label_11;
            }
            
            val_16 = mem[val_3 + 80];
            val_16 = val_3 + 80;
            if(val_16 == 0)
            {
                    throw new NullReferenceException();
            }
            
            label_5:
            if((val_3 + 80 + 280) != 0)
            {
                goto label_31;
            }
            
            SRDebugger.Services.IPinnedUIService val_9 = SRDebugger.Internal.Service.PinnedUI;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_17 = 0;
            val_17 = val_17 + 1;
            val_18 = 7;
            goto label_18;
            label_11:
            SRDebugger.Services.IPinnedUIService val_10 = SRDebugger.Internal.Service.PinnedUI;
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_18 = 0;
            val_18 = val_18 + 1;
            goto label_23;
            label_18:
            val_21 = public System.Boolean SRDebugger.Services.IPinnedUIService::HasPinned(SRDebugger.Internal.OptionDefinition option);
            val_14 = val_3;
            if((val_9.HasPinned(option:  val_14)) == false)
            {
                goto label_31;
            }
            
            SRDebugger.Services.IPinnedUIService val_13 = SRDebugger.Internal.Service.PinnedUI;
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_19 = 0;
            val_19 = val_19 + 1;
            val_21 = 5;
            goto label_29;
            label_23:
            val_10.Pin(option:  val_3, order:  0);
            goto label_31;
            label_29:
            val_13.Unpin(option:  val_3);
            goto label_31;
            label_2:
            val_4.Dispose();
        }
        private void RefreshCategorySelection()
        {
            var val_2;
            var val_3;
            var val_5;
            var val_6;
            this._isTogglingCategory = true;
            List.Enumerator<T> val_1 = this._categories.GetEnumerator();
            label_14:
            val_5 = public System.Boolean List.Enumerator<CategoryInstance>::MoveNext();
            if(val_3.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_2 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_2 + 24) == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_6 = 0;
            label_10:
            if(val_6 >= (val_2 + 24 + 24))
            {
                goto label_5;
            }
            
            if((val_2 + 24 + 24) <= val_6)
            {
                    val_6 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_5 = val_2 + 24 + 16;
            val_5 = val_5 + 0;
            if(((val_2 + 24 + 16 + 0) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(((val_2 + 24 + 16 + 0) + 32 + 80) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(((val_2 + 24 + 16 + 0) + 32 + 80 + 280) == 0)
            {
                goto label_9;
            }
            
            val_6 = val_6 + 1;
            if((val_2 + 24) != 0)
            {
                goto label_10;
            }
            
            throw new NullReferenceException();
            label_5:
            val_5 = 1;
            goto label_12;
            label_9:
            val_5 = 0;
            label_12:
            val_6 = mem[val_2 + 16];
            val_6 = val_2 + 16;
            if(val_6 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_6.IsSelected = false;
            goto label_14;
            label_2:
            val_3.Dispose();
            this._isTogglingCategory = false;
        }
        private void OnOptionSelectionToggle(bool selected)
        {
            if(this._isTogglingCategory != false)
            {
                    return;
            }
            
            this.RefreshCategorySelection();
            this.CommitPinnedOptions();
        }
        private void OnCategorySelectionToggle(SRDebugger.UI.Tabs.OptionsTabController.CategoryInstance category, bool selected)
        {
            bool val_2 = true;
            this._isTogglingCategory = val_2;
            var val_3 = 0;
            label_6:
            if(val_3 >= val_2)
            {
                goto label_3;
            }
            
            if(val_2 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + 0;
            (true + 0) + 32.IsSelected = selected;
            val_3 = val_3 + 1;
            if(category.Options != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_3:
            this._isTogglingCategory = false;
            this.CommitPinnedOptions();
        }
        protected void Populate()
        {
            SRDebugger.UI.Tabs.OptionsTabController val_15;
            var val_16;
            System.Collections.Generic.List<T> val_21;
            var val_23;
            var val_24;
            val_15 = this;
            System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition>> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition>>();
            SRDebugger.Services.IOptionsService val_2 = SRDebugger.Internal.Service.Options;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_16 = val_2;
            var val_19 = 0;
            val_19 = val_19 + 1;
            System.Collections.Generic.ICollection<SRDebugger.Internal.OptionDefinition> val_4 = val_16.Options;
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_20 = 0;
            val_20 = val_20 + 1;
            val_16 = val_4.GetEnumerator();
            label_25:
            var val_21 = 0;
            val_21 = val_21 + 1;
            if(val_16.MoveNext() == false)
            {
                goto label_16;
            }
            
            var val_22 = 0;
            val_22 = val_22 + 1;
            T val_10 = val_16.Current;
            val_15 = val_10;
            if(val_10 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_1.TryGetValue(key:  val_10 + 24, value: out  0)) != true)
            {
                    System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition> val_13 = null;
                val_21 = val_13;
                val_13 = new System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition>();
                val_1.Add(key:  val_10 + 24, value:  val_13);
            }
            
            if(val_21 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_13.Add(item:  val_15);
            goto label_25;
            label_16:
            val_21 = val_15;
            val_15 = 0;
            if(val_16 != null)
            {
                    var val_23 = 0;
                val_23 = val_23 + 1;
                val_16.Dispose();
            }
            
            if(val_15 != 0)
            {
                goto label_31;
            }
            
            if(0 == 1)
            {
                goto label_32;
            }
            
            var val_15 = (96 == 96) ? 1 : 0;
            val_15 = ((0 >= 0) ? 1 : 0) & val_15;
            val_15 = 0 - val_15;
            val_15 = val_15 + 1;
            val_16 = (long)val_15;
            if(val_1 != null)
            {
                goto label_33;
            }
            
            throw new NullReferenceException();
            label_32:
            val_16 = 0;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_33:
            Dictionary.Enumerator<TKey, TValue> val_17 = val_1.GetEnumerator();
            label_39:
            if(0.MoveNext() == false)
            {
                goto label_36;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(9733424 == 0)
            {
                goto label_39;
            }
            
            this.CreateCategory(title:  0, options:  0);
            goto label_39;
            label_36:
            0.Dispose();
            if((0 & 1) == 0)
            {
                    return;
            }
            
            if(mem[1152921519513288568] == 0)
            {
                    throw new NullReferenceException();
            }
            
            mem[1152921519513288568].SetActive(value:  false);
            return;
            label_31:
            val_23 = val_15;
            val_24 = 0;
            throw val_23;
        }
        protected void CreateCategory(string title, System.Collections.Generic.List<SRDebugger.Internal.OptionDefinition> options)
        {
            SRDebugger.Internal.OptionDefinition val_8;
            var val_9;
            var val_20;
            System.Comparison<SRDebugger.Internal.OptionDefinition> val_22;
            UnityEngine.Object val_23;
            var val_24;
            .<>4__this = this;
            val_20 = null;
            val_20 = null;
            val_22 = OptionsTabController.<>c.<>9__30_0;
            if(val_22 == null)
            {
                    System.Comparison<SRDebugger.Internal.OptionDefinition> val_2 = null;
                val_22 = val_2;
                val_2 = new System.Comparison<SRDebugger.Internal.OptionDefinition>(object:  OptionsTabController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 OptionsTabController.<>c::<CreateCategory>b__30_0(SRDebugger.Internal.OptionDefinition d1, SRDebugger.Internal.OptionDefinition d2));
                OptionsTabController.<>c.<>9__30_0 = val_22;
            }
            
            options.Sort(comparison:  val_2);
            SRDebugger.UI.Other.CategoryGroup val_3 = SRInstantiate.Instantiate<SRDebugger.UI.Other.CategoryGroup>(prefab:  mem[1152921519513530920]);
            OptionsTabController.CategoryInstance val_4 = new OptionsTabController.CategoryInstance(group:  val_3);
            .categoryInstance = val_4;
            mem[1152921519513530880].Add(item:  val_4);
            val_3.CachedTransform.SetParent(parent:  mem[1152921519513530928], worldPositionStays:  false);
            val_3.SelectionModeEnabled = false;
            (OptionsTabController.<>c__DisplayClass30_0)[1152921519513570992].categoryInstance.<CategoryGroup>k__BackingField.SelectionToggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  new OptionsTabController.<>c__DisplayClass30_0(), method:  System.Void OptionsTabController.<>c__DisplayClass30_0::<CreateCategory>b__1(bool b)));
            List.Enumerator<T> val_7 = options.GetEnumerator();
            label_41:
            if(val_9.MoveNext() == false)
            {
                goto label_16;
            }
            
            SRDebugger.UI.Controls.OptionsControlBase val_11 = SRDebugger.Internal.OptionControlFactory.CreateControl(from:  val_8, categoryPrefix:  title);
            val_23 = val_11;
            if(val_23 != 0)
            {
                goto label_19;
            }
            
            object[] val_13 = new object[1];
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_13[0] = val_8 + 16;
            UnityEngine.Debug.LogError(message:  System.String.Format(format:  "[SRDebugger.OptionsTab] Failed to create option control for {0}", args:  val_13));
            goto label_41;
            label_19:
            if(((OptionsTabController.<>c__DisplayClass30_0)[1152921519513570992].categoryInstance) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = (OptionsTabController.<>c__DisplayClass30_0)[1152921519513570992].categoryInstance.Options;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23.Add(item:  val_11);
            if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_15 = val_11.CachedTransform;
            if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            val_15.SetParent(parent:  val_3.Container, worldPositionStays:  false);
            SRDebugger.Services.IPinnedUIService val_16 = SRDebugger.Internal.Service.PinnedUI;
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_20 = 0;
            val_20 = val_20 + 1;
            val_24 = 7;
            SRDebugger.Internal.OptionDefinition val_21 = val_8;
            val_21 = val_16.HasPinned(option:  val_21);
            val_11.IsSelected = val_21;
            val_23 = val_11;
            val_23.SelectionModeEnabled = false;
            if(val_11.SelectionModeToggle == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_11.SelectionModeToggle.onValueChanged == null)
            {
                    throw new NullReferenceException();
            }
            
            val_11.SelectionModeToggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SRDebugger.UI.Tabs.OptionsTabController::OnOptionSelectionToggle(bool selected)));
            val_23 = mem[1152921519513530888];
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_23.Add(key:  val_8, value:  val_11);
            val_23 = mem[1152921519513530872];
            if(val_23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_23.Add(item:  val_11);
            goto label_41;
            label_16:
            val_9.Dispose();
        }
        private void Clear()
        {
            var val_4;
            List.Enumerator<T> val_1 = this._categories.GetEnumerator();
            label_7:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_4 = 11993091;
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_4.CachedGameObject);
            goto label_7;
            label_2:
            0.Dispose();
            this._categories.Clear();
            this._controls.Clear();
            this._options.Clear();
        }
        public OptionsTabController()
        {
            this._controls = new System.Collections.Generic.List<SRDebugger.UI.Controls.OptionsControlBase>();
            this._categories = new System.Collections.Generic.List<CategoryInstance>();
            this._options = new System.Collections.Generic.Dictionary<SRDebugger.Internal.OptionDefinition, SRDebugger.UI.Controls.OptionsControlBase>();
        }
    
    }

}
