using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public abstract class DataBoundControl : OptionsControlBase
    {
        // Fields
        private bool _hasStarted;
        private bool _isReadOnly;
        private object _prevValue;
        private SRF.Helpers.PropertyReference _prop;
        private string <PropertyName>k__BackingField;
        
        // Properties
        public SRF.Helpers.PropertyReference Property { get; }
        public bool IsReadOnly { get; }
        public string PropertyName { get; set; }
        
        // Methods
        public SRF.Helpers.PropertyReference get_Property()
        {
            return (SRF.Helpers.PropertyReference)this._prop;
        }
        public bool get_IsReadOnly()
        {
            return (bool)this._isReadOnly;
        }
        public string get_PropertyName()
        {
            return (string)this.<PropertyName>k__BackingField;
        }
        private void set_PropertyName(string value)
        {
            this.<PropertyName>k__BackingField = value;
        }
        public void Bind(string propertyName, SRF.Helpers.PropertyReference prop)
        {
            this._prop = prop;
            this.<PropertyName>k__BackingField = propertyName;
            bool val_2 = ~prop.CanWrite;
            val_2 = val_2 & 1;
            this._isReadOnly = val_2;
            goto typeof(SRDebugger.UI.Controls.DataBoundControl).__il2cppRuntimeField_1E0;
        }
        protected void UpdateValue(object newValue)
        {
            if(this._prevValue == newValue)
            {
                    return;
            }
            
            if(this._isReadOnly == true)
            {
                    return;
            }
            
            this._prop.SetValue(value:  newValue);
            this._prevValue = newValue;
        }
        public override void Refresh()
        {
            if(this._prop == null)
            {
                    return;
            }
            
            this._prevValue = this._prop.GetValue();
        }
        protected virtual void OnBind(string propertyName, System.Type t)
        {
        
        }
        protected abstract void OnValueUpdated(object newValue); // 0
        public abstract bool CanBind(System.Type type, bool isReadOnly); // 0
        protected override void Start()
        {
            this.Start();
            this._hasStarted = true;
        }
        protected override void OnEnable()
        {
            this.OnEnable();
            if(this._hasStarted == false)
            {
                    return;
            }
            
            goto typeof(SRDebugger.UI.Controls.DataBoundControl).__il2cppRuntimeField_1E0;
        }
        protected DataBoundControl()
        {
            val_1 = new SRF.SRMonoBehaviourEx();
        }
    
    }

}
