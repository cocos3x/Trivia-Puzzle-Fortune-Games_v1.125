using UnityEngine;

namespace SRDebugger.UI.Controls.Data
{
    public class StringControl : DataBoundControl
    {
        // Fields
        public UnityEngine.UI.InputField InputField;
        public UnityEngine.UI.Text Title;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            this.Refresh();
            mem[1152921519549320480] = 1;
            this.InputField.m_OnValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void SRDebugger.UI.Controls.Data.StringControl::OnValueChanged(string newValue)));
        }
        private void OnValueChanged(string newValue)
        {
            this.UpdateValue(newValue:  newValue);
        }
        protected override void OnBind(string propertyName, System.Type t)
        {
            this.InputField.text = "";
            this.InputField.interactable = ("" == 0) ? 1 : 0;
        }
        protected override void OnValueUpdated(object newValue)
        {
            object val_1 = newValue;
            if(val_1 != null)
            {
                    if(null == null)
            {
                goto label_2;
            }
            
            }
            
            val_1 = "";
            label_2:
            this.InputField.text = val_1;
        }
        public override bool CanBind(System.Type type, bool isReadOnly)
        {
            bool val_2 = System.Type.op_Equality(left:  type, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
            val_2 = val_2 & (~isReadOnly);
            return (bool)val_2;
        }
        public StringControl()
        {
            val_1 = new SRF.SRMonoBehaviourEx();
        }
    
    }

}
