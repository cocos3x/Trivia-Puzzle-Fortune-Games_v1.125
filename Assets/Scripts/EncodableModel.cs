using UnityEngine;
public class EncodableModel
{
    // Methods
    public virtual System.Collections.Generic.Dictionary<string, object> Encode(EncodableModel.TemplateModel destination = 0)
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Object>)new System.Collections.Generic.Dictionary<System.String, System.Object>();
    }
    public virtual void EncodeIntoDictionary(ref System.Collections.Generic.Dictionary<string, object> source, EncodableModel.TemplateModel destination = 0)
    {
        System.Collections.Generic.IEnumerable<TSource> val_12;
        var val_13;
        var val_14;
        System.Func<System.Reflection.FieldInfo, System.Boolean> val_16;
        string val_20;
        val_13 = 1152921515774573248;
        System.Type val_1 = this.GetType();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12 = val_1;
        val_14 = null;
        val_14 = null;
        val_16 = EncodableModel.<>c.<>9__2_0;
        if(val_16 == null)
        {
                System.Func<System.Reflection.FieldInfo, System.Boolean> val_2 = null;
            val_16 = val_2;
            val_2 = new System.Func<System.Reflection.FieldInfo, System.Boolean>(object:  EncodableModel.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean EncodableModel.<>c::<EncodeIntoDictionary>b__2_0(System.Reflection.FieldInfo field));
            EncodableModel.<>c.<>9__2_0 = val_16;
        }
        
        System.Collections.Generic.IEnumerable<TSource> val_3 = System.Linq.Enumerable.Where<System.Reflection.FieldInfo>(source:  val_12, predicate:  val_2);
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_15 = 0;
        val_15 = val_15 + 1;
        val_12 = val_3.GetEnumerator();
        label_41:
        var val_16 = 0;
        val_16 = val_16 + 1;
        if(val_12.MoveNext() == false)
        {
            goto label_17;
        }
        
        var val_17 = 0;
        val_17 = val_17 + 1;
        T val_9 = val_12.Current;
        if(destination != 0)
        {
                System.Type val_10 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
            if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
            if((val_9 + 24) == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
            if((val_9 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
            val_20 = ((((val_9 + 32 + 200 + (EncodeToSource.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_9 + 32) : 0) + 24;
        }
        else
        {
                System.Type val_12 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
            if(val_9 == 0)
        {
                throw new NullReferenceException();
        }
        
            if((val_9 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
            val_20 = ((((val_9 + 32 + 200 + (EncodeToSource.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_9 + 32) : 0) + 16;
        }
        
        if(source == null)
        {
                throw new NullReferenceException();
        }
        
        source.Add(key:  val_20, value:  val_9);
        goto label_41;
        label_17:
        val_13 = 0;
        if(val_12 != null)
        {
                var val_18 = 0;
            val_18 = val_18 + 1;
            val_12.Dispose();
        }
        
        if(val_13 != 0)
        {
                throw val_13;
        }
    
    }
    public virtual void Decode(System.Collections.Generic.Dictionary<string, object> jasonObject, EncodableModel.TemplateModel sourceModel = 0)
    {
        System.Collections.Generic.IEnumerable<TSource> val_35;
        object val_36;
        var val_37;
        System.Func<System.Reflection.FieldInfo, System.Boolean> val_39;
        System.Type val_40;
        string val_44;
        var val_45;
        int val_46;
        int val_47;
        var val_52;
        val_36 = jasonObject;
        System.Type val_1 = this.GetType();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = val_1;
        val_37 = null;
        val_37 = null;
        val_39 = EncodableModel.<>c.<>9__3_0;
        if(val_39 == null)
        {
                System.Func<System.Reflection.FieldInfo, System.Boolean> val_2 = null;
            val_39 = val_2;
            val_2 = new System.Func<System.Reflection.FieldInfo, System.Boolean>(object:  EncodableModel.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean EncodableModel.<>c::<Decode>b__3_0(System.Reflection.FieldInfo field));
            EncodableModel.<>c.<>9__3_0 = val_39;
        }
        
        System.Collections.Generic.IEnumerable<TSource> val_3 = System.Linq.Enumerable.Where<System.Reflection.FieldInfo>(source:  val_35, predicate:  val_2);
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_38 = 0;
        val_38 = val_38 + 1;
        val_35 = val_3.GetEnumerator();
        label_123:
        var val_39 = 0;
        val_39 = val_39 + 1;
        if(val_35.MoveNext() == false)
        {
            goto label_17;
        }
        
        var val_40 = 0;
        val_40 = val_40 + 1;
        val_40 = val_35.Current;
        if(sourceModel == 0)
        {
            goto label_22;
        }
        
        System.Type val_10 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_9 + 24) == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        if((val_9 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_44 = ((((val_9 + 32 + 200 + (EncodeToSource.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_9 + 32) : 0) + 24;
        if(val_36 != null)
        {
            goto label_31;
        }
        
        throw new NullReferenceException();
        label_22:
        System.Type val_12 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_9 + 24) == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        if((val_9 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_44 = ((((val_9 + 32 + 200 + (EncodeToSource.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (val_9 + 32) : 0) + 16;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        label_31:
        if((val_36.ContainsKey(key:  val_44)) == false)
        {
            goto label_42;
        }
        
        if((System.Type.op_Equality(left:  val_40, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_45;
        }
        
        object val_17 = val_36.Item[val_44];
        val_40.SetValue(obj:  this, value:  X0);
        goto label_123;
        label_42:
        val_45 = null;
        val_45 = null;
        if(Logger.EncodableModel == false)
        {
            goto label_123;
        }
        
        string[] val_18 = new string[6];
        val_40 = val_18;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_46 = val_18.Length;
        if(val_46 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_40[0] = "DECODE WARNING: ";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_46 = val_18.Length;
        if(val_46 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_40[1] = val_44;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_46 = val_18.Length;
        if(val_46 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_40[2] = " doesn\'t exist in ";
        if(sourceModel == 0)
        {
                throw new NullReferenceException();
        }
        
        string val_19 = sourceModel.ToString();
        if(val_19 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_47 = val_18.Length;
        if(val_47 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_40[3] = val_19;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_47 = val_18.Length;
        if(val_47 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_40[4] = " JsonObject: ";
        string val_20 = PrettyPrint.printJSON(obj:  val_36, types:  false, singleLineOutput:  false);
        if(val_20 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_18.Length <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_40[5] = val_20;
        UnityEngine.Debug.LogWarning(message:  +val_18);
        goto label_123;
        label_45:
        if((System.Type.op_Equality(left:  val_40, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
        {
            goto label_77;
        }
        
        object val_24 = val_36.Item[val_44];
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((val_24.IndexOf(value:  '.')) & 2147483648) != 0)
        {
            goto label_80;
        }
        
        decimal val_29 = System.Convert.ToDecimal(value:  System.Single.Parse(s:  val_24, provider:  System.Globalization.CultureInfo.InvariantCulture), provider:  System.Globalization.CultureInfo.InvariantCulture);
        val_40.SetValue(obj:  this, value:  val_29);
        goto label_123;
        label_77:
        val_40.SetValue(obj:  this, value:  val_36.Item[val_44]);
        goto label_123;
        label_80:
        object val_31 = val_36.Item[val_44];
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        decimal val_33 = System.Decimal.Parse(s:  val_31, provider:  System.Globalization.CultureInfo.InvariantCulture);
        val_40.SetValue(obj:  this, value:  val_33);
        goto label_123;
        label_17:
        val_36 = 0;
        if(val_35 != null)
        {
                var val_41 = 0;
            val_41 = val_41 + 1;
            val_35.Dispose();
        }
        
        if(val_36 == 0)
        {
                return;
        }
        
        val_52 = 0;
        throw val_36;
    }
    public virtual void Merge(EncodableModel model)
    {
        System.Collections.Generic.IEnumerable<TSource> val_14;
        var val_15;
        var val_16;
        System.Func<System.Reflection.FieldInfo, System.Boolean> val_18;
        val_15 = model;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = this.GetType();
        System.Type val_2 = val_15.GetType();
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_14 & 1) == 0)
        {
                return;
        }
        
        val_14 = val_15.GetType();
        System.Type val_4 = this.GetType();
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_14 & 1) == 0)
        {
                return;
        }
        
        System.Type val_5 = this.GetType();
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = val_5;
        val_16 = null;
        val_16 = null;
        val_18 = EncodableModel.<>c.<>9__4_0;
        if(val_18 == null)
        {
                System.Func<System.Reflection.FieldInfo, System.Boolean> val_6 = null;
            val_18 = val_6;
            val_6 = new System.Func<System.Reflection.FieldInfo, System.Boolean>(object:  EncodableModel.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean EncodableModel.<>c::<Merge>b__4_0(System.Reflection.FieldInfo field));
            EncodableModel.<>c.<>9__4_0 = val_18;
        }
        
        System.Collections.Generic.IEnumerable<TSource> val_7 = System.Linq.Enumerable.Where<System.Reflection.FieldInfo>(source:  val_14, predicate:  val_6);
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_14 = val_7.GetEnumerator();
        label_30:
        var val_18 = 0;
        val_18 = val_18 + 1;
        if(val_14.MoveNext() == false)
        {
            goto label_22;
        }
        
        var val_19 = 0;
        val_19 = val_19 + 1;
        T val_13 = val_14.Current;
        System.Type val_14 = val_15.GetType();
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Reflection.FieldInfo val_15 = val_14.GetField(name:  val_13);
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13.SetValue(obj:  this, value:  val_15);
        goto label_30;
        label_22:
        val_15 = 0;
        if(val_14 != null)
        {
                var val_20 = 0;
            val_20 = val_20 + 1;
            val_14.Dispose();
        }
        
        if(val_15 != 0)
        {
                throw val_15;
        }
    
    }
    public EncodableModel()
    {
    
    }

}
