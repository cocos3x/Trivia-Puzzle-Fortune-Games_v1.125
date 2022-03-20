using UnityEngine;
public class EasySaver<T>
{
    // Fields
    private System.Collections.Generic.Dictionary<HardSaved, System.Reflection.MemberInfo> hardSave;
    private System.Collections.Generic.Dictionary<SoftSaved, System.Reflection.MemberInfo> softSaveLite;
    private System.Collections.Generic.Dictionary<SoftSaved, System.Reflection.MemberInfo> softSaveFull;
    private T instance;
    
    // Methods
    public EasySaver<T>(T incInstance)
    {
        var val_27;
        System.Collections.Generic.Dictionary<TKey, TValue> val_28;
        var val_29;
        var val_30;
        var val_32;
        var val_33;
        string val_34;
        var val_35;
        var val_36;
        HardSaved val_37;
        SoftSaved val_38;
        SoftSaved val_39;
        System.Collections.Generic.IEnumerator<T> val_40;
        var val_41;
        var val_42;
        var val_43;
        System.Collections.Generic.IEnumerable<TSource> val_44;
        var val_45;
        var val_46;
        var val_49;
        HardSaved val_50;
        SoftSaved val_51;
        SoftSaved val_52;
        var val_53;
        var val_54;
        var val_55;
        val_27 = this;
        mem[1152921515600874176] = new System.Collections.Generic.Dictionary<HardSaved, System.Reflection.MemberInfo>();
        mem[1152921515600874184] = new System.Collections.Generic.Dictionary<SoftSaved, System.Reflection.MemberInfo>();
        System.Collections.Generic.Dictionary<SoftSaved, System.Reflection.MemberInfo> val_3 = null;
        val_28 = val_3;
        val_3 = new System.Collections.Generic.Dictionary<SoftSaved, System.Reflection.MemberInfo>();
        mem[1152921515600874192] = val_28;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921515600874200] = incInstance;
        if(incInstance == null)
        {
                throw new NullReferenceException();
        }
        
        System.Type val_4 = incInstance.GetType();
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
        val_29 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        if((val_29 & 1) == 0)
        {
                val_29 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
            val_29 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        }
        
        val_28 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 184 + 8];
        val_28 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 184 + 8;
        if(val_28 == 0)
        {
                val_30 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
            val_30 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
            if((val_30 & 1) == 0)
        {
                val_30 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
            val_30 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        }
        
            System.Func<System.Reflection.FieldInfo, System.Boolean> val_5 = null;
            val_28 = val_5;
            val_5 = new System.Func<System.Reflection.FieldInfo, System.Boolean>(object:  __RuntimeMethodHiddenParam + 24 + 192 + 8 + 184, method:  __RuntimeMethodHiddenParam + 24 + 192 + 16);
            mem2[0] = val_28;
        }
        
        System.Collections.Generic.IEnumerable<TSource> val_6 = System.Linq.Enumerable.Where<System.Reflection.FieldInfo>(source:  val_4, predicate:  val_5);
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_27 = 0;
        val_27 = val_27 + 1;
        System.Collections.Generic.IEnumerator<T> val_8 = val_6.GetEnumerator();
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        goto label_31;
        label_61:
        var val_30 = __RuntimeMethodHiddenParam + 24 + 192 + 8;
        if((__RuntimeMethodHiddenParam + 24 + 192 + 8 + 294) == 0)
        {
            goto label_28;
        }
        
        var val_28 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 176;
        var val_29 = 0;
        val_28 = val_28 + 8;
        label_27:
        if(((__RuntimeMethodHiddenParam + 24 + 192 + 8 + 176 + 8) + -8) == null)
        {
            goto label_26;
        }
        
        val_29 = val_29 + 1;
        val_28 = val_28 + 16;
        if(val_29 < (__RuntimeMethodHiddenParam + 24 + 192 + 8 + 294))
        {
            goto label_27;
        }
        
        goto label_28;
        label_26:
        val_30 = val_30 + (((__RuntimeMethodHiddenParam + 24 + 192 + 8 + 176 + 8)) << 4);
        val_32 = val_30 + 304;
        label_28:
        T val_9 = __RuntimeMethodHiddenParam + 24 + 192 + 8.Current;
        val_28 = val_9;
        if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_28 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_9 + 24) < 1)
        {
            goto label_31;
        }
        
        var val_31 = 0;
        label_56:
        if(val_31 >= (val_9 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        val_33 = val_28 + 0;
        if(((val_9 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Type val_10 = (val_9 + 0) + 32.GetType();
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = val_10;
        if((System.String.op_Equality(a:  val_10, b:  "HardSaved")) == false)
        {
            goto label_35;
        }
        
        if(val_31 >= (val_9 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = mem[(val_9 + 0) + 32];
        val_35 = (val_9 + 0) + 32;
        if(val_35 == 0)
        {
            goto label_38;
        }
        
        val_36 = null;
        val_37 = X0;
        if(val_37 == true)
        {
            goto label_39;
        }
        
        throw new IndexOutOfRangeException();
        label_35:
        if((System.String.op_Equality(a:  val_34, b:  "SoftSaved")) == false)
        {
            goto label_50;
        }
        
        if(val_31 >= (val_9 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        val_34 = mem[(val_9 + 0) + 32];
        val_34 = (val_9 + 0) + 32;
        if(X0 == false)
        {
                throw new NullReferenceException();
        }
        
        if((X0 + 24) == 0)
        {
            goto label_44;
        }
        
        if(val_31 >= (val_9 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        if(val_34 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_35 = mem[(val_9 + 0) + 32];
        val_35 = (val_9 + 0) + 32;
        if(val_35 == 0)
        {
            goto label_47;
        }
        
        val_36 = null;
        val_38 = X0;
        if(val_38 == true)
        {
            goto label_48;
        }
        
        throw new NullReferenceException();
        label_38:
        val_37 = 0;
        label_39:
        val_34.Add(key:  val_37, value:  val_28);
        goto label_50;
        label_47:
        val_38 = 0;
        label_48:
        val_34.Add(key:  val_38, value:  val_28);
        label_44:
        if(val_31 >= (val_9 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        if(val_34 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_35 = mem[(val_9 + 0) + 32];
        val_35 = (val_9 + 0) + 32;
        if(val_35 == 0)
        {
            goto label_53;
        }
        
        val_36 = null;
        val_39 = X0;
        if(val_39 == true)
        {
            goto label_54;
        }
        
        throw new NullReferenceException();
        label_53:
        val_39 = 0;
        label_54:
        val_34.Add(key:  val_39, value:  val_28);
        label_50:
        val_31 = val_31 + 1;
        if(val_31 < (val_9 + 24))
        {
            goto label_56;
        }
        
        label_31:
        val_40 = val_8;
        var val_34 = val_40;
        if((val_8 + 294) == 0)
        {
            goto label_60;
        }
        
        var val_32 = val_8 + 176;
        var val_33 = 0;
        val_32 = val_32 + 8;
        label_59:
        if(((val_8 + 176 + 8) + -8) == null)
        {
            goto label_58;
        }
        
        val_33 = val_33 + 1;
        val_32 = val_32 + 16;
        if(val_33 < (val_8 + 294))
        {
            goto label_59;
        }
        
        goto label_60;
        label_58:
        val_34 = val_34 + (((val_8 + 176 + 8)) << 4);
        val_41 = val_34 + 304;
        label_60:
        if(val_40.MoveNext() == true)
        {
            goto label_61;
        }
        
        val_28 = 0;
        if(val_40 == 0)
        {
            goto label_62;
        }
        
        var val_37 = val_40;
        if((val_8 + 294) == 0)
        {
            goto label_66;
        }
        
        var val_35 = val_8 + 176;
        var val_36 = 0;
        val_35 = val_35 + 8;
        label_65:
        if(((val_8 + 176 + 8) + -8) == null)
        {
            goto label_64;
        }
        
        val_36 = val_36 + 1;
        val_35 = val_35 + 16;
        if(val_36 < (val_8 + 294))
        {
            goto label_65;
        }
        
        goto label_66;
        label_64:
        val_37 = val_37 + (((val_8 + 176 + 8)) << 4);
        val_42 = val_37 + 304;
        label_66:
        val_40.Dispose();
        label_62:
        if(val_28 != 0)
        {
                throw val_28;
        }
        
        if(0 != 1)
        {
                var val_14 = (294 == 294) ? 1 : 0;
            val_14 = ((0 >= 0) ? 1 : 0) & val_14;
            val_14 = 0 - val_14;
            val_14 = val_14 + 1;
            val_43 = (long)val_14;
        }
        else
        {
                val_43 = 0;
        }
        
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Type val_16 = val_40.GetType();
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44 = val_16;
        val_45 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
        val_45 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        if((val_45 & 1) == 0)
        {
                val_45 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
            val_45 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        }
        
        val_28 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 184 + 16];
        val_28 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 184 + 16;
        if(val_28 == 0)
        {
                val_46 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
            val_46 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
            if((val_46 & 1) == 0)
        {
                val_46 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 302];
            val_46 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 302;
        }
        
            val_40 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 8 + 184];
            val_40 = __RuntimeMethodHiddenParam + 24 + 192 + 8 + 184;
            System.Func<System.Reflection.PropertyInfo, System.Boolean> val_17 = null;
            val_28 = val_17;
            val_17 = new System.Func<System.Reflection.PropertyInfo, System.Boolean>(object:  val_40, method:  __RuntimeMethodHiddenParam + 24 + 192 + 24);
            mem2[0] = val_28;
        }
        
        System.Collections.Generic.IEnumerable<TSource> val_18 = System.Linq.Enumerable.Where<System.Reflection.PropertyInfo>(source:  val_44, predicate:  val_17);
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_38 = 0;
        val_38 = val_38 + 1;
        System.Collections.Generic.IEnumerator<T> val_20 = val_18.GetEnumerator();
        goto label_99;
        label_129:
        var val_39 = 0;
        val_39 = val_39 + 1;
        T val_22 = val_17.Current;
        val_44 = val_22;
        if(val_22 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_28 = val_44;
        if(val_44 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_22 + 24) < 1)
        {
            goto label_99;
        }
        
        var val_40 = 0;
        label_124:
        if(val_40 >= (val_22 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        val_33 = val_28 + 0;
        if(((val_22 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        System.Type val_23 = (val_22 + 0) + 32.GetType();
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_40 = val_23;
        if((System.String.op_Equality(a:  val_23, b:  "HardSaved")) == false)
        {
            goto label_103;
        }
        
        if(val_40 >= (val_22 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = mem[(val_22 + 0) + 32];
        val_34 = (val_22 + 0) + 32;
        if(val_34 == 0)
        {
            goto label_106;
        }
        
        val_49 = null;
        val_50 = X0;
        if(val_50 == true)
        {
            goto label_107;
        }
        
        throw new IndexOutOfRangeException();
        label_103:
        if((System.String.op_Equality(a:  val_40, b:  "SoftSaved")) == false)
        {
            goto label_118;
        }
        
        if(val_40 >= (val_22 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        if(X0 == false)
        {
                throw new NullReferenceException();
        }
        
        if((X0 + 24) == 0)
        {
            goto label_112;
        }
        
        if(((val_22 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_34 = mem[(val_22 + 0) + 32];
        val_34 = (val_22 + 0) + 32;
        if(val_34 == 0)
        {
            goto label_115;
        }
        
        val_49 = null;
        val_51 = X0;
        if(val_51 == true)
        {
            goto label_116;
        }
        
        throw new NullReferenceException();
        label_106:
        val_50 = 0;
        label_107:
        val_40.Add(key:  val_50, value:  val_44);
        goto label_118;
        label_115:
        val_51 = 0;
        label_116:
        (val_22 + 0) + 32.Add(key:  val_51, value:  val_44);
        label_112:
        if(val_40 >= (val_22 + 24))
        {
                throw new IndexOutOfRangeException();
        }
        
        if(((val_22 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_34 = mem[(val_22 + 0) + 32];
        val_34 = (val_22 + 0) + 32;
        if(val_34 == 0)
        {
            goto label_121;
        }
        
        val_49 = null;
        val_52 = X0;
        if(val_52 == true)
        {
            goto label_122;
        }
        
        throw new IndexOutOfRangeException();
        label_121:
        val_52 = 0;
        label_122:
        (val_22 + 0) + 32.Add(key:  val_52, value:  val_44);
        label_118:
        val_40 = val_40 + 1;
        if(val_40 < (val_22 + 24))
        {
            goto label_124;
        }
        
        label_99:
        var val_43 = val_20;
        val_53 = mem[val_20 + 294];
        val_53 = val_20 + 294;
        if(val_53 == 0)
        {
            goto label_128;
        }
        
        var val_41 = val_20 + 176;
        var val_42 = 0;
        val_41 = val_41 + 8;
        label_127:
        if(((val_20 + 176 + 8) + -8) == null)
        {
            goto label_126;
        }
        
        val_42 = val_42 + 1;
        val_41 = val_41 + 16;
        if(val_42 < val_53)
        {
            goto label_127;
        }
        
        goto label_128;
        label_126:
        val_53 = mem[(val_20 + 176 + 8)];
        val_53 = val_41;
        val_43 = val_43 + (((val_20 + 176 + 8)) << 4);
        val_54 = val_43 + 304;
        label_128:
        if(val_20.MoveNext() == true)
        {
            goto label_129;
        }
        
        val_27 = 0;
        if(val_20 == 0)
        {
            goto label_182;
        }
        
        var val_46 = val_20;
        if((val_20 + 294) == 0)
        {
            goto label_134;
        }
        
        var val_44 = val_20 + 176;
        var val_45 = 0;
        val_44 = val_44 + 8;
        label_133:
        if(((val_20 + 176 + 8) + -8) == null)
        {
            goto label_132;
        }
        
        val_45 = val_45 + 1;
        val_44 = val_44 + 16;
        if(val_45 < (val_20 + 294))
        {
            goto label_133;
        }
        
        goto label_134;
        label_132:
        val_46 = val_46 + (((val_20 + 176 + 8)) << 4);
        val_55 = val_46 + 304;
        label_134:
        val_20.Dispose();
        label_182:
        if(val_27 != 0)
        {
                throw val_27;
        }
    
    }
    public void AddHardSavesToDictionary(ref System.Collections.Generic.Dictionary<string, object> refdic)
    {
        HardSaved val_3;
        var val_4;
        var val_13 = __RuntimeMethodHiddenParam;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = 9619.Keys.GetEnumerator();
        label_17:
        bool val_5 = val_4.MoveNext();
        if(val_5 == false)
        {
            goto label_3;
        }
        
        if(val_5 == false)
        {
                throw new NullReferenceException();
        }
        
        System.Reflection.MemberInfo val_6 = val_5.Item[val_3];
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        System.Type val_7 = this.GetType();
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Linq.Enumerable.Contains<System.Type>(source:  val_7, value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_9;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(refdic == null)
        {
                throw new NullReferenceException();
        }
        
        refdic.Add(key:  val_3 + 16, value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        goto label_17;
        label_9:
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(refdic == null)
        {
                throw new NullReferenceException();
        }
        
        refdic.Add(key:  val_3 + 16, value:  this.ToString());
        goto label_17;
        label_3:
        val_13 = 0;
        val_3 = val_4;
        val_4 = null;
        var val_12 = 0;
        val_12 = val_12 + 1;
        val_4.Dispose();
        if(val_13 != 0)
        {
                throw val_13 = __RuntimeMethodHiddenParam;
        }
    
    }
    public void SoftSaveLite()
    {
        if(this != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void SoftSaveFull()
    {
        if(this != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    private void DoSoftSave(System.Collections.Generic.Dictionary<SoftSaved, System.Reflection.MemberInfo> softSavedItems)
    {
        SoftSaved val_3;
        var val_4;
        object val_19;
        var val_20 = __RuntimeMethodHiddenParam;
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = softSavedItems.Keys.GetEnumerator();
        label_27:
        if(val_4.MoveNext() == false)
        {
            goto label_3;
        }
        
        System.Reflection.MemberInfo val_6 = softSavedItems.Item[val_3];
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = this;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Type.op_Equality(left:  this.GetType(), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_8;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.PlayerPrefs.SetInt(key:  val_3 + 16, value:  278859776);
        goto label_27;
        label_8:
        if((System.Type.op_Equality(left:  this.GetType(), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_14;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.PlayerPrefs.SetFloat(key:  val_3 + 16, value:  6.273909E-29f);
        goto label_27;
        label_14:
        System.Type val_13 = this.GetType();
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Linq.Enumerable.Contains<System.Type>(source:  val_13, value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_21;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  val_3 + 16, value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  this));
        goto label_27;
        label_21:
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  val_3 + 16, value:  this.ToString());
        goto label_27;
        label_3:
        val_20 = 0;
        val_3 = val_4;
        val_4 = null;
        var val_18 = 0;
        val_18 = val_18 + 1;
        val_4.Dispose();
        if(val_20 != 0)
        {
                throw val_20 = __RuntimeMethodHiddenParam;
        }
    
    }
    public object GetMemberValue(System.Reflection.MemberInfo memberInfo, T instance)
    {
        var val_4;
        var val_6;
        System.Func<TElement, TKey> val_14;
        var val_15;
        var val_16;
        val_14 = instance;
        val_15 = memberInfo;
        if((System.Reflection.FieldInfo.op_Inequality(left:  X0, right:  0)) != false)
        {
                val_16 = ???;
            val_15 = ???;
            val_14 = ???;
        }
        else
        {
                if((System.Reflection.PropertyInfo.op_Inequality(left:  X0, right:  0)) == false)
        {
                return (object)0;
        }
        
            val_16 = val_4;
            val_14 = val_6;
        }
    
    }

}
