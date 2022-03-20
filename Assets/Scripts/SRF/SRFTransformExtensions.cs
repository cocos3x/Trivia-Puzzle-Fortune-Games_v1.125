using UnityEngine;

namespace SRF
{
    public static class SRFTransformExtensions
    {
        // Methods
        public static System.Collections.Generic.IEnumerable<UnityEngine.Transform> GetChildren(UnityEngine.Transform t)
        {
            .<>1__state = -2;
            .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
            .<>3__t = t;
            return (System.Collections.Generic.IEnumerable<UnityEngine.Transform>)new SRFTransformExtensions.<GetChildren>d__0();
        }
        public static void ResetLocal(UnityEngine.Transform t)
        {
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            t.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
            UnityEngine.Quaternion val_2 = UnityEngine.Quaternion.identity;
            t.localRotation = new UnityEngine.Quaternion() {x = val_2.x, y = val_2.y, z = val_2.z, w = val_2.w};
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.one;
            t.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        }
        public static UnityEngine.GameObject CreateChild(UnityEngine.Transform t, string name)
        {
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  name);
            val_1.transform.parent = t;
            SRF.SRFTransformExtensions.ResetLocal(t:  val_1.transform);
            val_1.gameObject.layer = t.gameObject.layer;
            return val_1;
        }
        public static void SetParentMaintainLocals(UnityEngine.Transform t, UnityEngine.Transform parent)
        {
            if(t != null)
            {
                    t.SetParent(parent:  parent, worldPositionStays:  false);
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetLocals(UnityEngine.Transform t, UnityEngine.Transform from)
        {
            UnityEngine.Vector3 val_1 = from.localPosition;
            t.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
            UnityEngine.Quaternion val_2 = from.localRotation;
            t.localRotation = new UnityEngine.Quaternion() {x = val_2.x, y = val_2.y, z = val_2.z, w = val_2.w};
            UnityEngine.Vector3 val_3 = from.localScale;
            t.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        }
        public static void Match(UnityEngine.Transform t, UnityEngine.Transform from)
        {
            UnityEngine.Vector3 val_1 = from.position;
            t.position = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
            UnityEngine.Quaternion val_2 = from.rotation;
            t.rotation = new UnityEngine.Quaternion() {x = val_2.x, y = val_2.y, z = val_2.z, w = val_2.w};
        }
        public static void DestroyChildren(UnityEngine.Transform t)
        {
            var val_6;
            var val_7;
            var val_10;
            if(t == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = t.GetEnumerator();
            label_17:
            var val_7 = 0;
            val_7 = val_7 + 1;
            if(val_7.MoveNext() == false)
            {
                goto label_7;
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            object val_5 = val_7.Current;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_5.gameObject);
            goto label_17;
            label_7:
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
                    throw 41971712;
            }
        
        }
    
    }

}
