using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class CategoryGroup : SRMonoBehaviourEx
    {
        // Fields
        public UnityEngine.RectTransform Container;
        public UnityEngine.UI.Text Header;
        public UnityEngine.GameObject Background;
        public UnityEngine.UI.Toggle SelectionToggle;
        public UnityEngine.GameObject[] EnabledDuringSelectionMode;
        private bool _selectionModeEnabled;
        
        // Properties
        public bool IsSelected { get; set; }
        public bool SelectionModeEnabled { get; set; }
        
        // Methods
        public bool get_IsSelected()
        {
            if(this.SelectionToggle != null)
            {
                    return (bool)this.SelectionToggle.m_IsOn;
            }
            
            throw new NullReferenceException();
        }
        public void set_IsSelected(bool value)
        {
            bool val_8 = value;
            value = val_8;
            this.SelectionToggle.isOn = value;
            if(this.SelectionToggle.graphic == 0)
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
            var val_4 = 0;
            do
            {
                if(val_4 >= this.EnabledDuringSelectionMode.Length)
            {
                    return;
            }
            
                this.EnabledDuringSelectionMode[val_4].SetActive(value:  this._selectionModeEnabled);
                val_4 = val_4 + 1;
            }
            while(this.EnabledDuringSelectionMode != null);
            
            throw new NullReferenceException();
        }
        public CategoryGroup()
        {
            this.EnabledDuringSelectionMode = new UnityEngine.GameObject[0];
            this._selectionModeEnabled = true;
        }
    
    }

}
