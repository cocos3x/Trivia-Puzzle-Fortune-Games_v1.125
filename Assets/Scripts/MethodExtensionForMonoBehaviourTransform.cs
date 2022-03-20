using UnityEngine;
public static class MethodExtensionForMonoBehaviourTransform
{
    // Methods
    public static T GetOrAddComponent<T>(UnityEngine.Component child)
    {
        var val_8;
        UnityEngine.Object val_9;
        val_8 = __RuntimeMethodHiddenParam;
        val_9 = child;
        if(val_9 != 0)
        {
                return (FrameSkipper)val_9;
        }
        
        UnityEngine.GameObject val_2 = child.gameObject;
        val_8 = ???;
        val_9 = ???;
        goto __RuntimeMethodHiddenParam + 48 + 16;
    }
    public static T GetOrAddComponent<T>(UnityEngine.GameObject gameObject)
    {
        var val_8;
        UnityEngine.Object val_9;
        val_8 = __RuntimeMethodHiddenParam;
        val_9 = gameObject;
        if(val_9 != 0)
        {
                return (FrameSkipper)val_9;
        }
        
        UnityEngine.GameObject val_2 = gameObject.gameObject;
        val_8 = ???;
        val_9 = ???;
        goto __RuntimeMethodHiddenParam + 48 + 16;
    }
    public static void DestroyChildren(UnityEngine.Transform t)
    {
        var val_8;
        var val_11;
        var val_12;
        System.Action<UnityEngine.GameObject> val_14;
        System.Collections.Generic.List<UnityEngine.GameObject> val_1 = new System.Collections.Generic.List<UnityEngine.GameObject>();
        if(t == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_2 = t.GetEnumerator();
        val_8 = 1152921504683417600;
        label_16:
        var val_9 = 0;
        val_9 = val_9 + 1;
        if(val_2.MoveNext() == false)
        {
            goto label_7;
        }
        
        var val_10 = 0;
        val_10 = val_10 + 1;
        object val_6 = val_2.Current;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_6.gameObject);
        goto label_16;
        label_7:
        val_8 = 0;
        if(X0 == false)
        {
            goto label_17;
        }
        
        var val_13 = X0;
        if((X0 + 294) == 0)
        {
            goto label_21;
        }
        
        var val_11 = X0 + 176;
        var val_12 = 0;
        val_11 = val_11 + 8;
        label_20:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_19;
        }
        
        val_12 = val_12 + 1;
        val_11 = val_11 + 16;
        if(val_12 < (X0 + 294))
        {
            goto label_20;
        }
        
        goto label_21;
        label_19:
        val_13 = val_13 + (((X0 + 176 + 8)) << 4);
        val_11 = val_13 + 304;
        label_21:
        X0.Dispose();
        label_17:
        if(val_8 != 0)
        {
                throw val_8;
        }
        
        val_12 = null;
        val_12 = null;
        val_14 = MethodExtensionForMonoBehaviourTransform.<>c.<>9__2_0;
        if(val_14 == null)
        {
                System.Action<UnityEngine.GameObject> val_8 = null;
            val_14 = val_8;
            val_8 = new System.Action<UnityEngine.GameObject>(object:  MethodExtensionForMonoBehaviourTransform.<>c.__il2cppRuntimeField_static_fields, method:  System.Void MethodExtensionForMonoBehaviourTransform.<>c::<DestroyChildren>b__2_0(UnityEngine.GameObject child));
            MethodExtensionForMonoBehaviourTransform.<>c.<>9__2_0 = val_14;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.ForEach(action:  val_8);
    }
    public static void DestroyChildrenImmediate(UnityEngine.Transform t)
    {
        var val_8;
        var val_11;
        var val_12;
        System.Action<UnityEngine.GameObject> val_14;
        System.Collections.Generic.List<UnityEngine.GameObject> val_1 = new System.Collections.Generic.List<UnityEngine.GameObject>();
        if(t == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_2 = t.GetEnumerator();
        val_8 = 1152921504683417600;
        label_16:
        var val_9 = 0;
        val_9 = val_9 + 1;
        if(val_2.MoveNext() == false)
        {
            goto label_7;
        }
        
        var val_10 = 0;
        val_10 = val_10 + 1;
        object val_6 = val_2.Current;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(item:  val_6.gameObject);
        goto label_16;
        label_7:
        val_8 = 0;
        if(X0 == false)
        {
            goto label_17;
        }
        
        var val_13 = X0;
        if((X0 + 294) == 0)
        {
            goto label_21;
        }
        
        var val_11 = X0 + 176;
        var val_12 = 0;
        val_11 = val_11 + 8;
        label_20:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_19;
        }
        
        val_12 = val_12 + 1;
        val_11 = val_11 + 16;
        if(val_12 < (X0 + 294))
        {
            goto label_20;
        }
        
        goto label_21;
        label_19:
        val_13 = val_13 + (((X0 + 176 + 8)) << 4);
        val_11 = val_13 + 304;
        label_21:
        X0.Dispose();
        label_17:
        if(val_8 != 0)
        {
                throw val_8;
        }
        
        val_12 = null;
        val_12 = null;
        val_14 = MethodExtensionForMonoBehaviourTransform.<>c.<>9__3_0;
        if(val_14 == null)
        {
                System.Action<UnityEngine.GameObject> val_8 = null;
            val_14 = val_8;
            val_8 = new System.Action<UnityEngine.GameObject>(object:  MethodExtensionForMonoBehaviourTransform.<>c.__il2cppRuntimeField_static_fields, method:  System.Void MethodExtensionForMonoBehaviourTransform.<>c::<DestroyChildrenImmediate>b__3_0(UnityEngine.GameObject child));
            MethodExtensionForMonoBehaviourTransform.<>c.<>9__3_0 = val_14;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.ForEach(action:  val_8);
    }
    public static void SetActiveChildren(UnityEngine.Transform t, bool state)
    {
        bool val_7;
        var val_8;
        var val_11;
        val_7 = state;
        if(t == null)
        {
                throw new NullReferenceException();
        }
        
        val_8 = t.GetEnumerator();
        val_7 = val_7;
        label_17:
        var val_7 = 0;
        val_7 = val_7 + 1;
        if(val_8.MoveNext() == false)
        {
            goto label_7;
        }
        
        var val_8 = 0;
        val_8 = val_8 + 1;
        object val_5 = val_8.Current;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        NGUITools.SetActiveSelf(go:  val_5.gameObject, state:  val_7);
        goto label_17;
        label_7:
        val_7 = 0;
        if(X0 == false)
        {
            goto label_18;
        }
        
        var val_11 = X0;
        val_8 = X0;
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
        val_11 = val_11 + 304;
        label_22:
        val_8.Dispose();
        label_18:
        if(val_7 != 0)
        {
                throw val_7;
        }
    
    }
    public static int GetChildCountRecursively(UnityEngine.Transform transform)
    {
        var val_6;
        var val_9;
        if(transform == null)
        {
                throw new NullReferenceException();
        }
        
        val_6 = transform.childCount;
        System.Collections.IEnumerator val_2 = transform.GetEnumerator();
        goto label_3;
        label_16:
        var val_7 = 0;
        val_7 = val_7 + 1;
        val_6 = val_2.Current + val_6;
        label_3:
        var val_8 = 0;
        val_8 = val_8 + 1;
        if(val_2.MoveNext() == true)
        {
            goto label_16;
        }
        
        if(X0 == false)
        {
            goto label_17;
        }
        
        var val_11 = X0;
        if((X0 + 294) == 0)
        {
            goto label_21;
        }
        
        var val_9 = X0 + 176;
        var val_10 = 0;
        val_9 = val_9 + 8;
        label_20:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_19;
        }
        
        val_10 = val_10 + 1;
        val_9 = val_9 + 16;
        if(val_10 < (X0 + 294))
        {
            goto label_20;
        }
        
        goto label_21;
        label_19:
        val_11 = val_11 + (((X0 + 176 + 8)) << 4);
        val_9 = val_11 + 304;
        label_21:
        X0.Dispose();
        label_17:
        if(0 != 0)
        {
                throw 1152921504683417600;
        }
        
        return (int)val_6;
    }
    public static void SetX(UnityEngine.Vector3 v, float x)
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  x, y:  v.y, z:  v.z);
    }
    public static void SetY(UnityEngine.Vector3 v, float y)
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  v.x, y:  y, z:  v.z);
    }
    public static void SetZ(UnityEngine.Vector3 v, float z)
    {
        UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  v.x, y:  v.y, z:  z);
    }
    public static UnityEngine.Vector3 Parse(UnityEngine.Vector3 v, string s)
    {
        char[] val_4 = new char[1];
        val_4[0] = ',';
        System.String[] val_5 = s.Remove(startIndex:  0, count:  1).Remove(startIndex:  val_1.m_stringLength - 1, count:  1).Split(separator:  val_4, options:  0);
        UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  System.Single.Parse(s:  val_5[0]), y:  System.Single.Parse(s:  val_5[1]), z:  System.Single.Parse(s:  val_5[2]));
        return new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
    }
    public static UnityEngine.Vector2 Parse(UnityEngine.Vector2 v, string s)
    {
        char[] val_4 = new char[1];
        val_4[0] = ',';
        System.String[] val_5 = s.Remove(startIndex:  0, count:  1).Remove(startIndex:  val_1.m_stringLength - 1, count:  1).Split(separator:  val_4, options:  0);
        UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  System.Single.Parse(s:  val_5[0]), y:  System.Single.Parse(s:  val_5[1]));
        return new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
    }
    public static UnityEngine.Vector4 Parse(UnityEngine.Vector4 v, string s)
    {
        char[] val_4 = new char[1];
        val_4[0] = ',';
        System.String[] val_5 = s.Remove(startIndex:  0, count:  1).Remove(startIndex:  val_1.m_stringLength - 1, count:  1).Split(separator:  val_4, options:  0);
        UnityEngine.Vector4 val_10 = new UnityEngine.Vector4(x:  System.Single.Parse(s:  val_5[0]), y:  System.Single.Parse(s:  val_5[1]), z:  System.Single.Parse(s:  val_5[2]), w:  System.Single.Parse(s:  val_5[3]));
        return new UnityEngine.Vector4() {x = val_10.x, y = val_10.y, z = val_10.z, w = val_10.w};
    }
    public static UnityEngine.Color Parse(UnityEngine.Color c, string s)
    {
        char[] val_6 = new char[1];
        val_6[0] = ',';
        System.String[] val_7 = s.Remove(startIndex:  0, count:  (s.IndexOf(value:  '(')) + 1).Remove(startIndex:  val_3.m_stringLength - 1, count:  1).Split(separator:  val_6, options:  0);
        UnityEngine.Color val_12 = new UnityEngine.Color(r:  System.Single.Parse(s:  val_7[0]), g:  System.Single.Parse(s:  val_7[1]), b:  System.Single.Parse(s:  val_7[2]), a:  System.Single.Parse(s:  val_7[3]));
        return new UnityEngine.Color() {r = val_12.r, g = val_12.g, b = val_12.b, a = val_12.a};
    }

}
