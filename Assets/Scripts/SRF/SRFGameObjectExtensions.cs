using UnityEngine;

namespace SRF
{
    public static class SRFGameObjectExtensions
    {
        // Methods
        public static T GetIComponent<T>(UnityEngine.GameObject t)
        {
            var val_3;
            UnityEngine.Component val_2 = t.GetComponent(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}));
            if(X0 != false)
            {
                    if(X0 == true)
            {
                    return (object)val_3;
            }
            
            }
            
            val_3 = 0;
            return (object)val_3;
        }
        public static T GetComponentOrAdd<T>(UnityEngine.GameObject obj)
        {
            var val_7;
            UnityEngine.Object val_8;
            val_7 = __RuntimeMethodHiddenParam;
            val_8 = obj;
            if(val_8 != 0)
            {
                    return (SRF.UI.StyleRoot)val_8;
            }
            
            val_7 = ???;
            val_8 = ???;
            goto __RuntimeMethodHiddenParam + 48 + 16;
        }
        public static void RemoveComponentIfExists<T>(UnityEngine.GameObject obj)
        {
            if(obj == 0)
            {
                    return;
            }
            
            UnityEngine.Object.Destroy(obj:  obj);
        }
        public static void RemoveComponentsIfExists<T>(UnityEngine.GameObject obj)
        {
            var val_2;
            var val_2 = __RuntimeMethodHiddenParam + 48;
            if(val_2 < 1)
            {
                    return;
            }
            
            val_2 = val_2 & 4294967295;
            UnityEngine.GameObject val_1 = obj + 32;
            UnityEngine.Object.Destroy(obj:  1152921504764567552);
            val_2 = 0 + 1;
        }
        public static bool EnableComponentIfExists<T>(UnityEngine.GameObject obj, bool enable = True)
        {
            var val_3;
            if(obj == 0)
            {
                    val_3 = 0;
                return (bool)val_3;
            }
            
            obj.enabled = enable;
            val_3 = 1;
            return (bool)val_3;
        }
        public static void SetLayerRecursive(UnityEngine.GameObject o, int layer)
        {
            SRF.SRFGameObjectExtensions.SetLayerInternal(t:  o.transform, layer:  layer);
        }
        private static void SetLayerInternal(UnityEngine.Transform t, int layer)
        {
            int val_6;
            var val_7;
            var val_10;
            val_6 = layer;
            if(t == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.GameObject val_1 = t.gameObject;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.layer = val_6;
            val_7 = t.GetEnumerator();
            label_17:
            var val_7 = 0;
            val_7 = val_7 + 1;
            if(val_7.MoveNext() == false)
            {
                goto label_8;
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            if(val_7.Current == null)
            {
                goto label_17;
            }
            
            goto label_17;
            label_8:
            val_6 = 0;
            if(X0 == false)
            {
                goto label_18;
            }
            
            var val_11 = X0;
            val_7 = X0;
            if((X0 + 294) == 0)
            {
                goto label_22;
            }
            
            var val_9 = X0 + 176;
            var val_10 = 0;
            val_9 = val_9 + 8;
            label_21:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_20;
            }
            
            val_10 = val_10 + 1;
            val_9 = val_9 + 16;
            if(val_10 < (X0 + 294))
            {
                goto label_21;
            }
            
            goto label_22;
            label_20:
            val_11 = val_11 + (((X0 + 176 + 8)) << 4);
            val_10 = val_11 + 304;
            label_22:
            val_7.Dispose();
            label_18:
            if(val_6 != 0)
            {
                    throw val_6;
            }
        
        }
    
    }

}
