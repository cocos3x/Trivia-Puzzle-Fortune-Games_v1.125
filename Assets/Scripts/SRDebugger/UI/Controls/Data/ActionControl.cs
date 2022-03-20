using UnityEngine;

namespace SRDebugger.UI.Controls.Data
{
    public class ActionControl : OptionsControlBase
    {
        // Fields
        private SRF.Helpers.MethodReference _method;
        public UnityEngine.UI.Button Button;
        public UnityEngine.UI.Text Title;
        
        // Properties
        public SRF.Helpers.MethodReference Method { get; }
        
        // Methods
        public SRF.Helpers.MethodReference get_Method()
        {
            return (SRF.Helpers.MethodReference)this._method;
        }
        protected override void Start()
        {
            this.Start();
            this.Button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SRDebugger.UI.Controls.Data.ActionControl::ButtonOnClick()));
        }
        private void ButtonOnClick()
        {
            if(this._method != null)
            {
                    object val_1 = this._method.Invoke(parameters:  0);
                return;
            }
            
            UnityEngine.Debug.LogWarning(message:  "[SRDebugger.Options] No method set for action control", context:  this);
        }
        public void SetMethod(string methodName, SRF.Helpers.MethodReference method)
        {
            this._method = method;
            if(this.Title != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public ActionControl()
        {
            val_1 = new SRF.SRMonoBehaviourEx();
        }
    
    }

}
