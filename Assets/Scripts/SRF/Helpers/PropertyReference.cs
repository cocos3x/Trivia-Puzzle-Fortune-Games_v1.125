using UnityEngine;

namespace SRF.Helpers
{
    public class PropertyReference
    {
        // Fields
        private readonly System.Reflection.PropertyInfo _property;
        private readonly object _target;
        
        // Properties
        public string PropertyName { get; }
        public System.Type PropertyType { get; }
        public bool CanRead { get; }
        public bool CanWrite { get; }
        
        // Methods
        public PropertyReference(object target, System.Reflection.PropertyInfo property)
        {
            val_1 = new System.Object();
            SRDebugUtil.AssertNotNull(value:  target, message:  0, instance:  0);
            this._property = val_1;
            this._target = target;
        }
        public string get_PropertyName()
        {
            if(this._property != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public System.Type get_PropertyType()
        {
            if(this._property != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public bool get_CanRead()
        {
            return System.Reflection.MethodInfo.op_Inequality(left:  this._property.GetGetMethod(), right:  0);
        }
        public bool get_CanWrite()
        {
            return System.Reflection.MethodInfo.op_Inequality(left:  this._property.GetSetMethod(), right:  0);
        }
        public object GetValue()
        {
            if((this._property & 1) == 0)
            {
                    return 0;
            }
            
            return SRF.Helpers.SRReflection.GetPropertyValue(obj:  this._target, p:  this._property);
        }
        public void SetValue(object value)
        {
            if((this._property & 1) == 0)
            {
                    throw new System.InvalidOperationException(message:  "Can not write to property");
            }
            
            SRF.Helpers.SRReflection.SetPropertyValue(obj:  this._target, p:  this._property, value:  value);
        }
        public T GetAttribute<T>()
        {
            var val_3;
            System.Type val_1 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48});
            object val_2 = System.Linq.Enumerable.FirstOrDefault<System.Object>(source:  this._property);
            if(X0 != false)
            {
                    if(X0 == true)
            {
                    return (SROptions.IncrementAttribute)val_3;
            }
            
            }
            
            val_3 = 0;
            return (SROptions.IncrementAttribute)val_3;
        }
    
    }

}
