using UnityEngine;

namespace SRF.Helpers
{
    public static class SRReflection
    {
        // Methods
        public static void SetPropertyValue(object obj, System.Reflection.PropertyInfo p, object value)
        {
            object[] val_2 = new object[1];
            val_2[0] = value;
            object val_3 = p.GetSetMethod().Invoke(obj:  obj, parameters:  val_2);
        }
        public static object GetPropertyValue(object obj, System.Reflection.PropertyInfo p)
        {
            return p.GetGetMethod().Invoke(obj:  obj, parameters:  0);
        }
        public static T GetAttribute<T>(System.Reflection.MemberInfo t)
        {
            var val_3;
            System.Attribute val_2 = System.Attribute.GetCustomAttribute(element:  t, attributeType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}));
            if(X0 != false)
            {
                    if(X0 == true)
            {
                    return (SRF.ImportAttribute)val_3;
            }
            
            }
            
            val_3 = 0;
            return (SRF.ImportAttribute)val_3;
        }
    
    }

}
