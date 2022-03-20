using UnityEngine;

namespace SRF.UI
{
    [Serializable]
    public class StyleSheet : ScriptableObject
    {
        // Fields
        private System.Collections.Generic.List<string> _keys;
        private System.Collections.Generic.List<SRF.UI.Style> _styles;
        public SRF.UI.StyleSheet Parent;
        
        // Methods
        public SRF.UI.Style GetStyle(string key, bool searchParent = True)
        {
            System.Collections.Generic.List<SRF.UI.Style> val_3;
            var val_4;
            val_3 = this;
            label_7:
            bool val_3 = static_value_02807244;
            int val_1 = this._keys.IndexOf(item:  key);
            if((val_1 & 2147483648) != 0)
            {
                    if(searchParent != false)
            {
                    if(this.Parent != 0)
            {
                    if(this.Parent != null)
            {
                goto label_7;
            }
            
            }
            
            }
            
                val_4 = 0;
                return (SRF.UI.Style)val_4;
            }
            
            val_3 = this._styles;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = val_3 + (val_1 << 3);
            val_4 = mem[(static_value_02807244 + (val_1) << 3) + 32];
            val_4 = (static_value_02807244 + (val_1) << 3) + 32;
            return (SRF.UI.Style)val_4;
        }
        public StyleSheet()
        {
            this._keys = new System.Collections.Generic.List<System.String>();
            this._styles = new System.Collections.Generic.List<SRF.UI.Style>();
        }
    
    }

}
