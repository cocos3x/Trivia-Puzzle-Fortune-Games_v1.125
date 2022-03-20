using UnityEngine;

namespace SRDebugger.UI.Controls.Data
{
    public class BoolControl : DataBoundControl
    {
        // Fields
        public UnityEngine.UI.Text Title;
        public UnityEngine.UI.Toggle Toggle;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            this.Refresh();
            mem[1152921519544829104] = 1;
            this.Toggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void SRDebugger.UI.Controls.Data.BoolControl::ToggleOnValueChanged(bool isOn)));
        }
        private void ToggleOnValueChanged(bool isOn)
        {
            this.UpdateValue(newValue:  isOn);
        }
        protected override void OnBind(string propertyName, System.Type t)
        {
            this.Toggle.interactable = (null == 0) ? 1 : 0;
        }
        protected override void OnValueUpdated(object newValue)
        {
            this.Toggle.isOn = false;
        }
        public override bool CanBind(System.Type type, bool isReadOnly)
        {
            return System.Type.op_Equality(left:  type, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        }
        public BoolControl()
        {
            val_1 = new SRF.SRMonoBehaviourEx();
        }
    
    }

}
