using UnityEngine;

namespace SRDebugger.UI.Controls.Data
{
    public class EnumControl : DataBoundControl
    {
        // Fields
        private object _lastValue;
        private string[] _names;
        private System.Array _values;
        public UnityEngine.UI.LayoutElement ContentLayoutElement;
        public UnityEngine.GameObject[] DisableOnReadOnly;
        public SRF.UI.SRSpinner Spinner;
        public UnityEngine.UI.Text Title;
        public UnityEngine.UI.Text Value;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            this.Refresh();
            mem[1152921519545587120] = 1;
        }
        protected override void OnBind(string propertyName, System.Type t)
        {
            UnityEngine.GameObject[] val_10;
            var val_11;
            this.Spinner.interactable = (null == 0) ? 1 : 0;
            val_10 = this.DisableOnReadOnly;
            if((val_10 != null) && (this.DisableOnReadOnly.Length >= 1))
            {
                    var val_10 = 0;
                do
            {
                1152921507144892032.SetActive(value:  (this.DisableOnReadOnly.Length == 0) ? 1 : 0);
                val_10 = val_10 + 1;
            }
            while(val_10 < this.DisableOnReadOnly.Length);
            
            }
            
            this._names = System.Enum.GetNames(enumType:  t);
            this._values = System.Enum.GetValues(enumType:  t);
            val_11 = "";
            if(this._names.Length >= 1)
            {
                    var val_12 = 0;
                do
            {
                val_12 = val_12 + 1;
            }
            while(val_12 < this._names.Length);
            
            }
            
            if(this._names.Length == 0)
            {
                    return;
            }
            
            val_10 = this.Value.cachedTextGeneratorForLayout;
            UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  3.402823E+38f, y:  V0.16B);
            UnityEngine.TextGenerationSettings val_8 = this.Value.GetGenerationSettings(extents:  new UnityEngine.Vector2() {x = val_7.x, y = val_7.y});
            float val_9 = val_10.GetPreferredWidth(str:  (this._names[0x0][0].m_stringLength > "".__il2cppRuntimeField_10) ? (this._names[val_12]) : (val_11), settings:  new UnityEngine.TextGenerationSettings() {color = new UnityEngine.Color(), richText = false, alignByGeometry = false, resizeTextForBestFit = false, updateBounds = false, generationExtents = new UnityEngine.Vector2(), pivot = new UnityEngine.Vector2(), generateOutOfBounds = false});
        }
        protected override void OnValueUpdated(object newValue)
        {
            this._lastValue = newValue;
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        public override bool CanBind(System.Type type, bool isReadOnly)
        {
            if(type != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        private void SetIndex(int i)
        {
            this.UpdateValue(newValue:  this._values.GetValue(index:  i));
            this.Refresh();
        }
        public void GoToNext()
        {
            this.SetIndex(i:  SRMath.Wrap(max:  this._values.Length, value:  (System.Array.IndexOf(array:  this._values, value:  this._lastValue)) + 1));
        }
        public void GoToPrevious()
        {
            this.SetIndex(i:  SRMath.Wrap(max:  this._values.Length, value:  (System.Array.IndexOf(array:  this._values, value:  this._lastValue)) - 1));
        }
        public EnumControl()
        {
            val_1 = new SRF.SRMonoBehaviourEx();
        }
    
    }

}
