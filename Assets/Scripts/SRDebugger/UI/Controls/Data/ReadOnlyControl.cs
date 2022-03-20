using UnityEngine;

namespace SRDebugger.UI.Controls.Data
{
    public class ReadOnlyControl : DataBoundControl
    {
        // Fields
        public UnityEngine.UI.Text ValueText;
        public UnityEngine.UI.Text Title;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            this.Refresh();
            mem[1152921519548681632] = 1;
        }
        protected override void OnBind(string propertyName, System.Type t)
        {
            if(this.Title != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected override void OnValueUpdated(object newValue)
        {
            string val_1 = System.Convert.ToString(value:  newValue);
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        public override bool CanBind(System.Type type, bool isReadOnly)
        {
            bool val_2 = System.Type.op_Equality(left:  type, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
            val_2 = val_2 & isReadOnly;
            return (bool)val_2;
        }
        public ReadOnlyControl()
        {
            val_1 = new SRF.SRMonoBehaviourEx();
        }
    
    }

}
