using UnityEngine;

namespace SRDebugger.Scripts
{
    public class DebuggerTabController : SRMonoBehaviourEx
    {
        // Fields
        private SRDebugger.UI.Other.SRTab _aboutTabInstance;
        private System.Nullable<SRDebugger.DefaultTabs> _activeTab;
        private bool _hasStarted;
        public SRDebugger.UI.Other.SRTab AboutTab;
        public SRDebugger.UI.Other.SRTabController TabController;
        
        // Properties
        public System.Nullable<SRDebugger.DefaultTabs> ActiveTab { get; }
        
        // Methods
        public System.Nullable<SRDebugger.DefaultTabs> get_ActiveTab()
        {
            string val_7;
            bool val_8;
            val_7 = this.TabController._activeTab._key;
            if((System.String.IsNullOrEmpty(value:  val_7)) != false)
            {
                    val_8 = 0;
                return (System.Nullable<SRDebugger.DefaultTabs>)val_8;
            }
            
            val_7 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_7);
            val_8 = 0;
            if((System.Enum.IsDefined(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_7)) == false)
            {
                    return (System.Nullable<SRDebugger.DefaultTabs>)val_8;
            }
            
            System.Nullable<SRDebugger.DefaultTabs> val_6 = new System.Nullable<SRDebugger.DefaultTabs>(value:  null);
            val_8 = val_6.HasValue;
            return (System.Nullable<SRDebugger.DefaultTabs>)val_8;
        }
        protected override void Start()
        {
            var val_21;
            T[] val_22;
            var val_23;
            System.Type val_24;
            var val_25;
            SRDebugger.DefaultTabs[] val_26;
            var val_27;
            var val_28;
            System.Nullable<SRDebugger.DefaultTabs> val_30;
            val_21 = this;
            this.Start();
            this._hasStarted = true;
            val_22 = UnityEngine.Resources.LoadAll<SRDebugger.UI.Other.SRTab>(path:  "SRDebugger/UI/Prefabs/Tabs");
            val_23 = 1152921505010839552;
            val_24 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            if(val_1.Length < 1)
            {
                goto label_6;
            }
            
            val_25 = 1152921505012490240;
            val_24 = System.Enum.GetNames(enumType:  val_24);
            var val_27 = 0;
            label_33:
            T val_22 = val_22[val_27];
            UnityEngine.Component val_5 = val_22.GetComponent(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
            if(X0 == false)
            {
                goto label_11;
            }
            
            var val_25 = X0;
            val_26 = X0;
            if((X0 + 294) == 0)
            {
                goto label_15;
            }
            
            var val_23 = X0 + 176;
            var val_24 = 0;
            val_23 = val_23 + 8;
            label_14:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_13;
            }
            
            val_24 = val_24 + 1;
            val_23 = val_23 + 16;
            if(val_24 < (X0 + 294))
            {
                goto label_14;
            }
            
            goto label_15;
            label_13:
            val_25 = val_25 + (((X0 + 176 + 8)) << 4);
            val_27 = val_25 + 304;
            label_15:
            if(val_26.IsEnabled == false)
            {
                goto label_31;
            }
            
            label_11:
            if((System.Linq.Enumerable.Contains<System.String>(source:  val_24, value:  val_1[0x0][0] + 136)) == false)
            {
                goto label_22;
            }
            
            val_28 = 0;
            if((System.Enum.IsDefined(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_1[0x0][0] + 136))) == false)
            {
                goto label_22;
            }
            
            SRDebugger.Settings val_12 = SRDebugger.Settings.Instance;
            val_26 = val_12._disabledTabs;
            var val_26 = 0;
            val_26 = val_26 + 1;
            val_28 = 4;
            val_23 = val_23;
            val_21 = val_21;
            val_24 = val_24;
            val_25 = val_25;
            val_22 = val_22;
            if((val_26.Contains(item:  null)) == true)
            {
                goto label_31;
            }
            
            label_22:
            val_26 = this.TabController;
            val_26.AddTab(tab:  SRInstantiate.Instantiate<SRDebugger.UI.Other.SRTab>(prefab:  val_22), visibleInSidebar:  true);
            label_31:
            val_27 = val_27 + 1;
            if(val_27 < (val_1 + 24))
            {
                goto label_33;
            }
            
            label_6:
            if(this.AboutTab != 0)
            {
                    SRDebugger.UI.Other.SRTab val_17 = SRInstantiate.Instantiate<SRDebugger.UI.Other.SRTab>(prefab:  this.AboutTab);
                this._aboutTabInstance = val_17;
                this.TabController.AddTab(tab:  val_17, visibleInSidebar:  false);
            }
            
            val_30 = this._activeTab;
            if(val_30 == 0)
            {
                    SRDebugger.Settings val_18 = SRDebugger.Settings.Instance;
                val_30 = val_18._defaultTab;
            }
            
            if((this.OpenTab(tab:  val_30)) != false)
            {
                    return;
            }
            
            this.TabController.ActiveTab = System.Linq.Enumerable.FirstOrDefault<SRDebugger.UI.Other.SRTab>(source:  this.TabController.Tabs);
        }
        public bool OpenTab(SRDebugger.DefaultTabs tab)
        {
            var val_11;
            SRDebugger.DefaultTabs val_12;
            var val_13;
            var val_15;
            var val_18;
            var val_19;
            val_12 = tab;
            val_13 = this;
            if(this._hasStarted != false)
            {
                    if(tab == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_12 = tab;
                if(this.TabController == null)
            {
                    throw new NullReferenceException();
            }
            
                System.Collections.Generic.IList<SRDebugger.UI.Other.SRTab> val_2 = this.TabController.Tabs;
                if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_12 = 0;
                val_12 = val_12 + 1;
            }
            else
            {
                    System.Nullable<SRDebugger.DefaultTabs> val_3 = new System.Nullable<SRDebugger.DefaultTabs>(value:  val_12);
                val_15 = 1;
                this._activeTab = val_3.HasValue;
                return (bool)val_15;
            }
            
            System.Collections.Generic.IEnumerator<T> val_5 = val_2.GetEnumerator();
            val_12 = val_5;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_21:
            var val_13 = 0;
            val_13 = val_13 + 1;
            if(val_12.MoveNext() == false)
            {
                goto label_15;
            }
            
            var val_14 = 0;
            val_14 = val_14 + 1;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  val_12, b:  tab.ToString())) == false)
            {
                goto label_21;
            }
            
            this.TabController.ActiveTab = val_12;
            val_18 = 0;
            val_13 = 0;
            val_19 = 1;
            goto label_23;
            label_15:
            val_18 = 0;
            val_13 = 0;
            val_19 = 0;
            label_23:
            val_11 = val_12;
            if(val_12 != null)
            {
                    var val_15 = 0;
                val_15 = val_15 + 1;
                val_11.Dispose();
            }
            
            if(val_13 != 0)
            {
                    throw val_13;
            }
            
            if(val_18 != 1)
            {
                    val_15 = val_19 & ((112 == 114) ? 1 : 0);
                return (bool)val_15;
            }
            
            val_15 = 0;
            return (bool)val_15;
        }
        public void ShowAboutTab()
        {
            if(this._aboutTabInstance == 0)
            {
                    return;
            }
            
            this.TabController.ActiveTab = this._aboutTabInstance;
        }
        public DebuggerTabController()
        {
        
        }
    
    }

}
