using UnityEngine;
private sealed class Json.Serializer
{
    // Fields
    private System.Text.StringBuilder builder;
    
    // Methods
    private Json.Serializer()
    {
        this.builder = new System.Text.StringBuilder();
    }
    public static string Serialize(object obj)
    {
        new Json.Serializer().SerializeValue(value:  obj);
        goto typeof(System.Text.StringBuilder).__il2cppRuntimeField_160;
    }
    private void SerializeValue(object value)
    {
        System.Text.StringBuilder val_3;
        string val_4;
        val_3 = this;
        if(value == null)
        {
            goto label_1;
        }
        
        if(null == null)
        {
            goto label_2;
        }
        
        if(null == null)
        {
            goto label_3;
        }
        
        if(X0 == false)
        {
            goto label_4;
        }
        
        this.SerializeArray(anArray:  X0);
        return;
        label_1:
        val_4 = "null";
        goto label_6;
        label_2:
        label_11:
        this.SerializeString(str:  value);
        return;
        label_3:
        val_3 = this.builder;
        val_4 = value.ToLower();
        label_6:
        System.Text.StringBuilder val_2 = val_3.Append(value:  val_4);
        return;
        label_4:
        if(X0 != false)
        {
                this.SerializeObject(obj:  X0);
            return;
        }
        
        if(null == null)
        {
            goto label_11;
        }
        
        this.SerializeOther(value:  value);
    }
    private void SerializeObject(System.Collections.IDictionary obj)
    {
        var val_11;
        var val_14;
        var val_17;
        var val_18;
        var val_20;
        val_11 = obj;
        if(this.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_1 = this.builder.Append(value:  '{');
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_15 = 0;
        val_15 = val_15 + 1;
        System.Collections.ICollection val_3 = val_11.Keys;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_14 = val_3.GetEnumerator();
        label_30:
        var val_17 = 0;
        val_17 = val_17 + 1;
        if(val_14.MoveNext() == false)
        {
            goto label_17;
        }
        
        var val_18 = 0;
        val_18 = val_18 + 1;
        val_17 = public System.Object System.Collections.IEnumerator::get_Current();
        object val_9 = val_14.Current;
        if((1 & 1) == 0)
        {
                if(this.builder == null)
        {
                throw new NullReferenceException();
        }
        
            val_17 = 44;
            System.Text.StringBuilder val_10 = this.builder.Append(value:  ',');
        }
        
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        this.SerializeString(str:  val_9);
        if(this.builder == null)
        {
                throw new NullReferenceException();
        }
        
        val_18 = 0;
        System.Text.StringBuilder val_11 = this.builder.Append(value:  ':');
        var val_19 = 0;
        val_19 = val_19 + 1;
        val_18 = 0;
        this.SerializeValue(value:  val_11.Item[val_9]);
        goto label_30;
        label_17:
        val_11 = 0;
        if(X0 == false)
        {
            goto label_31;
        }
        
        var val_22 = X0;
        val_14 = X0;
        if((X0 + 294) == 0)
        {
            goto label_35;
        }
        
        var val_20 = X0 + 176;
        var val_21 = 0;
        val_20 = val_20 + 8;
        label_34:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_33;
        }
        
        val_21 = val_21 + 1;
        val_20 = val_20 + 16;
        if(val_21 < (X0 + 294))
        {
            goto label_34;
        }
        
        goto label_35;
        label_33:
        val_22 = val_22 + (((X0 + 176 + 8)) << 4);
        val_20 = val_22 + 304;
        label_35:
        val_14.Dispose();
        label_31:
        if(val_11 != 0)
        {
                throw val_11;
        }
        
        if(this.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_14 = this.builder.Append(value:  '}');
    }
    private void SerializeArray(System.Collections.IList anArray)
    {
        object val_8;
        var val_12;
        if(this.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_1 = this.builder.Append(value:  '[');
        if(anArray == null)
        {
                throw new NullReferenceException();
        }
        
        var val_10 = 0;
        val_10 = val_10 + 1;
        System.Collections.IEnumerator val_3 = anArray.GetEnumerator();
        label_19:
        var val_11 = 0;
        val_11 = val_11 + 1;
        if(val_3.MoveNext() == false)
        {
            goto label_12;
        }
        
        var val_12 = 0;
        val_12 = val_12 + 1;
        val_8 = val_3.Current;
        if((1 & 1) == 0)
        {
                if(this.builder == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_8 = this.builder.Append(value:  ',');
        }
        
        this.SerializeValue(value:  val_8);
        goto label_19;
        label_12:
        val_8 = 0;
        if(X0 == false)
        {
            goto label_20;
        }
        
        var val_15 = X0;
        if((X0 + 294) == 0)
        {
            goto label_24;
        }
        
        var val_13 = X0 + 176;
        var val_14 = 0;
        val_13 = val_13 + 8;
        label_23:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_22;
        }
        
        val_14 = val_14 + 1;
        val_13 = val_13 + 16;
        if(val_14 < (X0 + 294))
        {
            goto label_23;
        }
        
        goto label_24;
        label_22:
        val_15 = val_15 + (((X0 + 176 + 8)) << 4);
        val_12 = val_15 + 304;
        label_24:
        X0.Dispose();
        label_20:
        if(val_8 != 0)
        {
                throw val_8;
        }
        
        if(this.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_9 = this.builder.Append(value:  ']');
    }
    private void SerializeString(string str)
    {
        var val_6;
        string val_8;
        System.Text.StringBuilder val_1 = this.builder.Append(value:  '"');
        int val_6 = val_2.Length;
        if(val_6 < 1)
        {
            goto label_4;
        }
        
        val_6 = val_6 & 4294967295;
        label_24:
        if(1152921505060011496 > 5)
        {
            goto label_6;
        }
        
        var val_7 = mem[4611686020272544672];
        val_7 = val_7 + 32498688;
        goto (mem[4611686020272544672] + 32498688);
        label_6:
        if(null == 92)
        {
            goto label_9;
        }
        
        if(null != 34)
        {
            goto label_10;
        }
        
        val_8 = "\\\"";
        goto label_12;
        label_10:
        System.Text.StringBuilder val_3 = this.builder.Append(value:  '뷰');
        goto label_14;
        label_9:
        val_8 = "\\\\";
        label_12:
        System.Text.StringBuilder val_4 = this.builder.Append(value:  val_8);
        label_14:
        val_6 = 0 + 1;
        if(val_6 < (val_2.Length << ))
        {
            goto label_24;
        }
        
        label_4:
        System.Text.StringBuilder val_5 = this.builder.Append(value:  '"');
    }
    private void SerializeOther(object value)
    {
        if(null == null)
        {
            goto label_2;
        }
        
        if(null == null)
        {
            goto label_3;
        }
        
        if(((((((((null == null) || (null == null)) || (null == null)) || (null == null)) || (null == null)) || (null == null)) || (null == null)) || (null == null)) || (null == null))
        {
            goto label_12;
        }
        
        this.SerializeString(str:  value);
        return;
        label_2:
        label_20:
        System.Text.StringBuilder val_3 = this.builder.Append(value:  null.ToString(provider:  System.Globalization.CultureInfo.InvariantCulture));
        return;
        label_3:
        this = this.builder;
        string val_5 = null.ToString(provider:  System.Globalization.CultureInfo.InvariantCulture);
        if(this != null)
        {
            goto label_20;
        }
        
        throw new NullReferenceException();
        label_12:
        if(this.builder.m_ChunkChars != null)
        {
            goto label_20;
        }
    
    }

}
