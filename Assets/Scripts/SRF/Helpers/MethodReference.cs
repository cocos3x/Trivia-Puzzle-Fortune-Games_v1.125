using UnityEngine;

namespace SRF.Helpers
{
    public class MethodReference
    {
        // Fields
        private System.Reflection.MethodInfo _method;
        private object _target;
        
        // Properties
        public string MethodName { get; }
        
        // Methods
        public MethodReference(object target, System.Reflection.MethodInfo method)
        {
            SRDebugUtil.AssertNotNull(value:  target, message:  0, instance:  0);
            this._method = method;
            this._target = target;
        }
        public string get_MethodName()
        {
            if(this._method != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public object Invoke(object[] parameters)
        {
            if(this._method != null)
            {
                    return this._method.Invoke(obj:  this._target, parameters:  parameters);
            }
            
            throw new NullReferenceException();
        }
    
    }

}
