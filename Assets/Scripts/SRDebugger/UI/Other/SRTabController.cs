using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class SRTabController : SRMonoBehaviourEx
    {
        // Fields
        private readonly SRF.SRList<SRDebugger.UI.Other.SRTab> _tabs;
        private SRDebugger.UI.Other.SRTab _activeTab;
        public UnityEngine.RectTransform TabButtonContainer;
        public SRDebugger.UI.Controls.SRTabButton TabButtonPrefab;
        public UnityEngine.RectTransform TabContentsContainer;
        public UnityEngine.RectTransform TabHeaderContentContainer;
        public UnityEngine.UI.Text TabHeaderText;
        private System.Action<SRDebugger.UI.Other.SRTabController, SRDebugger.UI.Other.SRTab> ActiveTabChanged;
        
        // Properties
        public SRDebugger.UI.Other.SRTab ActiveTab { get; set; }
        public System.Collections.Generic.IList<SRDebugger.UI.Other.SRTab> Tabs { get; }
        
        // Methods
        public SRDebugger.UI.Other.SRTab get_ActiveTab()
        {
            return (SRDebugger.UI.Other.SRTab)this._activeTab;
        }
        public void set_ActiveTab(SRDebugger.UI.Other.SRTab value)
        {
            this.MakeActive(tab:  value);
        }
        public System.Collections.Generic.IList<SRDebugger.UI.Other.SRTab> get_Tabs()
        {
            return this._tabs.AsReadOnly();
        }
        public void add_ActiveTabChanged(System.Action<SRDebugger.UI.Other.SRTabController, SRDebugger.UI.Other.SRTab> value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.ActiveTabChanged, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.ActiveTabChanged != 1152921519525533072);
            
            return;
            label_2:
        }
        public void remove_ActiveTabChanged(System.Action<SRDebugger.UI.Other.SRTabController, SRDebugger.UI.Other.SRTab> value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.ActiveTabChanged, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.ActiveTabChanged != 1152921519525669648);
            
            return;
            label_2:
        }
        public void AddTab(SRDebugger.UI.Other.SRTab tab, bool visibleInSidebar = True)
        {
            bool val_10 = visibleInSidebar;
            .<>4__this = this;
            .tab = tab;
            tab.CachedTransform.SetParent(parent:  this.TabContentsContainer, worldPositionStays:  false);
            (SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab.CachedGameObject.SetActive(value:  false);
            if(val_10 != false)
            {
                    SRDebugger.UI.Controls.SRTabButton val_4 = SRInstantiate.Instantiate<SRDebugger.UI.Controls.SRTabButton>(prefab:  this.TabButtonPrefab);
                val_10 = val_4;
                val_4.CachedTransform.SetParent(parent:  this.TabButtonContainer, worldPositionStays:  false);
                string val_6 = (SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab._title.ToUpper();
                if(((SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab.IconExtraContent) != 0)
            {
                    SRInstantiate.Instantiate<UnityEngine.RectTransform>(prefab:  (SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab.IconExtraContent).SetParent(parent:  val_4.ExtraContentContainer, worldPositionStays:  false);
            }
            
                val_4.IconStyleComponent.StyleKey = (SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab.IconStyleKey;
                val_4.ActiveToggle.enabled = false;
                val_4.Button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new SRTabController.<>c__DisplayClass15_0(), method:  System.Void SRTabController.<>c__DisplayClass15_0::<AddTab>b__0()));
                (SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab.TabButton = val_10;
            }
            
            this._tabs.Add(item:  (SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab);
            this.SortTabs();
            if(this._tabs != 1)
            {
                    return;
            }
            
            this.MakeActive(tab:  (SRTabController.<>c__DisplayClass15_0)[1152921519525964048].tab);
        }
        private void MakeActive(SRDebugger.UI.Other.SRTab tab)
        {
            SRDebugger.UI.Other.SRTab val_15;
            if((this._tabs.Contains(item:  tab)) == false)
            {
                    throw new System.ArgumentException(message:  "tab is not a member of this tab controller", paramName:  "tab");
            }
            
            val_15 = this._activeTab;
            if(val_15 != 0)
            {
                    this._activeTab.CachedGameObject.SetActive(value:  false);
                if(this._activeTab.TabButton != 0)
            {
                    this._activeTab.TabButton.ActiveToggle.enabled = false;
            }
            
                val_15 = this._activeTab.HeaderExtraContent;
                if(val_15 != 0)
            {
                    this._activeTab.HeaderExtraContent.gameObject.SetActive(value:  false);
            }
            
            }
            
            this._activeTab = tab;
            if(tab != 0)
            {
                    this._activeTab.CachedGameObject.SetActive(value:  true);
                val_15 = this._activeTab;
                var val_10 = ((System.String.IsNullOrEmpty(value:  this._activeTab._longTitle)) != true) ? 120 : 128;
                if(this._activeTab.TabButton != 0)
            {
                    this._activeTab.TabButton.ActiveToggle.enabled = true;
            }
            
                if(this._activeTab.HeaderExtraContent != 0)
            {
                    this._activeTab.HeaderExtraContent.SetParent(parent:  this.TabHeaderContentContainer, worldPositionStays:  false);
                this._activeTab.HeaderExtraContent.gameObject.SetActive(value:  true);
            }
            
            }
            
            if(this.ActiveTabChanged == null)
            {
                    return;
            }
            
            this.ActiveTabChanged.Invoke(arg1:  this, arg2:  this._activeTab);
        }
        private void SortTabs()
        {
            var val_6;
            System.Comparison<SRDebugger.UI.Other.SRTab> val_8;
            val_6 = null;
            val_6 = null;
            val_8 = SRTabController.<>c.<>9__17_0;
            if(val_8 == null)
            {
                    System.Comparison<SRDebugger.UI.Other.SRTab> val_1 = null;
                val_8 = val_1;
                val_1 = new System.Comparison<SRDebugger.UI.Other.SRTab>(object:  SRTabController.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 SRTabController.<>c::<SortTabs>b__17_0(SRDebugger.UI.Other.SRTab t1, SRDebugger.UI.Other.SRTab t2));
                SRTabController.<>c.<>9__17_0 = val_8;
            }
            
            this._tabs.Sort(comparer:  val_1);
            var val_6 = 0;
            do
            {
                if(val_6 >= 1152921519526567488)
            {
                    return;
            }
            
                SRDebugger.UI.Other.SRTab val_2 = this._tabs.Item[0];
                val_8 = val_2.TabButton;
                if(val_8 != 0)
            {
                    SRDebugger.UI.Other.SRTab val_4 = this._tabs.Item[0];
                val_4.TabButton.CachedTransform.SetSiblingIndex(index:  0);
            }
            
                val_6 = val_6 + 1;
            }
            while(this._tabs != null);
            
            throw new NullReferenceException();
        }
        public SRTabController()
        {
            this._tabs = new SRF.SRList<SRDebugger.UI.Other.SRTab>();
        }
    
    }

}
