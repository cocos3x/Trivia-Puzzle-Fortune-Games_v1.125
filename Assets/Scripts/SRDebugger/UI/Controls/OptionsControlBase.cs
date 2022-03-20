using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public abstract class OptionsControlBase : SRMonoBehaviourEx
    {
        // Fields
        private bool _selectionModeEnabled;
        public UnityEngine.UI.Toggle SelectionModeToggle;
        public SRDebugger.Internal.OptionDefinition Option;
        
        // Properties
        public bool SelectionModeEnabled { get; set; }
        public bool IsSelected { get; set; }
        
        // Methods
        public bool get_SelectionModeEnabled()
        {
            return (bool)this._selectionModeEnabled;
        }
        public void set_SelectionModeEnabled(bool value)
        {
            var val_1 = (this._selectionModeEnabled == true) ? 1 : 0;
            val_1 = val_1 ^ value;
            if(val_1 == false)
            {
                    return;
            }
            
            this._selectionModeEnabled = value;
            this.SelectionModeToggle.gameObject.SetActive(value:  this._selectionModeEnabled);
            if(this.SelectionModeToggle.graphic == 0)
            {
                    return;
            }
            
            if(this.SelectionModeToggle.m_IsOn == false)
            {
                goto label_9;
            }
            
            var val_5 = (this._selectionModeEnabled == false) ? 0.2f : 1f;
            label_11:
            this = ???;
            goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_440;
            label_9:
            if(this.SelectionModeToggle.graphic != null)
            {
                goto label_11;
            }
            
            throw new NullReferenceException();
        }
        public bool get_IsSelected()
        {
            if(this.SelectionModeToggle != null)
            {
                    return (bool)this.SelectionModeToggle.m_IsOn;
            }
            
            throw new NullReferenceException();
        }
        public void set_IsSelected(bool value)
        {
            bool val_8 = value;
            value = val_8;
            this.SelectionModeToggle.isOn = value;
            if(this.SelectionModeToggle.graphic == 0)
            {
                    return;
            }
            
            if(val_8 != false)
            {
                    var val_2 = (this._selectionModeEnabled == false) ? 0.2f : 1f;
            }
            
            val_8 = ???;
            goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_440;
        }
        protected override void Awake()
        {
            this.Awake();
            this.IsSelected = false;
            this.SelectionModeToggle.gameObject.SetActive(value:  false);
        }
        protected override void OnEnable()
        {
            this.OnEnable();
            if(this.SelectionModeToggle.graphic == 0)
            {
                    return;
            }
            
            if(this.SelectionModeToggle.m_IsOn == false)
            {
                goto label_6;
            }
            
            var val_2 = (this._selectionModeEnabled == false) ? 0.2f : 1f;
            label_8:
            this = ???;
            goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_440;
            label_6:
            if(this.SelectionModeToggle.graphic != null)
            {
                goto label_8;
            }
            
            throw new NullReferenceException();
        }
        public virtual void Refresh()
        {
        
        }
        protected OptionsControlBase()
        {
        
        }
    
    }

}
