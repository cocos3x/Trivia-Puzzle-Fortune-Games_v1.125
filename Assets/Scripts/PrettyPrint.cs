using UnityEngine;
public class PrettyPrint
{
    // Fields
    private static System.Text.StringBuilder builder;
    private static bool dispTypes;
    private static string separator;
    private static string tab;
    
    // Methods
    public static string printJSON(object obj, bool types = False, bool singleLineOutput = False)
    {
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        val_5 = null;
        val_5 = null;
        PrettyPrint.builder = new System.Text.StringBuilder();
        val_6 = null;
        val_7 = val_6;
        PrettyPrint.dispTypes = types;
        val_8 = " ";
        val_6 = null;
        val_8 = " ";
        val_7 = 1152921504893427896;
        PrettyPrint.separator = (singleLineOutput != true) ? (val_8) : "\n";
        val_7 = 1152921504893427896;
        PrettyPrint.tab = (singleLineOutput != true) ? (val_8) : "\t";
        PrettyPrint.append(obj:  obj, level:  0);
        PrettyPrint.builder = 0;
        return (string)PrettyPrint.builder;
    }
    private static void append(object obj, int level = 0)
    {
        var val_10;
        var val_12;
        var val_13;
        if(obj == null)
        {
            goto label_1;
        }
        
        if(X0 == false)
        {
            goto label_2;
        }
        
        PrettyPrint.appendList(list:  X0, level:  level);
        return;
        label_1:
        val_10 = null;
        val_10 = null;
        label_22:
        System.Text.StringBuilder val_1 = PrettyPrint.builder.Append(value:  "null");
        return;
        label_2:
        if(X0 != false)
        {
                PrettyPrint.appendObject(dict:  X0, level:  level);
            return;
        }
        
        val_12 = null;
        string val_4 = (null == null) ? "\'" : ((null == null) ? "\"" : "");
        val_12 = null;
        System.Text.StringBuilder val_6 = PrettyPrint.builder.Append(value:  val_4 + obj + val_4);
        if(PrettyPrint.dispTypes == false)
        {
                return;
        }
        
        if((System.String.op_Equality(a:  val_4, b:  "")) == false)
        {
                return;
        }
        
        val_13 = null;
        val_13 = null;
        string val_9 = " (" + obj.GetType() + ")";
        goto label_22;
    }
    private static void appendList(System.Collections.IList list, int level)
    {
        var val_15;
        var val_16;
        var val_19;
        var val_20;
        var val_22;
        var val_23;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        var val_30;
        val_16 = null;
        val_16 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_1 = PrettyPrint.builder.Append(value:  "[");
        if(list == null)
        {
                throw new NullReferenceException();
        }
        
        var val_17 = 0;
        val_17 = val_17 + 1;
        System.Collections.IEnumerator val_3 = list.GetEnumerator();
        int val_4 = level + 1;
        goto label_10;
        label_29:
        var val_18 = 0;
        val_18 = val_18 + 1;
        val_19 = null;
        val_19 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_8 = PrettyPrint.builder.Append(value:  "" + PrettyPrint.separator);
        val_20 = null;
        var val_9 = ((PrettyPrint.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        if((level & 2147483648) == 0)
        {
                var val_19 = 0;
            do
        {
            val_22 = null;
            if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_10 = PrettyPrint.builder.Append(value:  PrettyPrint.tab);
            val_23 = null;
            val_19 = val_19 + 1;
            var val_11 = ((PrettyPrint.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        }
        while(val_19 <= level);
        
        }
        
        PrettyPrint.append(obj:  val_3.Current, level:  val_4);
        label_10:
        var val_20 = 0;
        val_20 = val_20 + 1;
        if(val_3.MoveNext() == true)
        {
            goto label_29;
        }
        
        val_15 = 0;
        if(X0 == false)
        {
            goto label_30;
        }
        
        var val_23 = X0;
        if((X0 + 294) == 0)
        {
            goto label_34;
        }
        
        var val_21 = X0 + 176;
        var val_22 = 0;
        val_21 = val_21 + 8;
        label_33:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_32;
        }
        
        val_22 = val_22 + 1;
        val_21 = val_21 + 16;
        if(val_22 < (X0 + 294))
        {
            goto label_33;
        }
        
        goto label_34;
        label_32:
        val_23 = val_23 + (((X0 + 176 + 8)) << 4);
        val_25 = val_23 + 304;
        label_34:
        X0.Dispose();
        label_30:
        if(val_15 != 0)
        {
                throw val_4;
        }
        
        val_26 = null;
        val_26 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_14 = PrettyPrint.builder.Append(value:  PrettyPrint.separator);
        val_27 = null;
        val_28 = (uint)(((uint)((PrettyPrint.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
        if(level >= 1)
        {
                var val_24 = 0;
            do
        {
            val_29 = null;
            if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_15 = PrettyPrint.builder.Append(value:  PrettyPrint.tab);
            val_30 = null;
            val_24 = val_24 + 1;
            val_28 = (uint)(((uint)((PrettyPrint.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
        }
        while(val_24 < level);
        
        }
        
        val_30 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_16 = PrettyPrint.builder.Append(value:  "]");
    }
    private static void appendObject(System.Collections.IDictionary dict, int level)
    {
        var val_18;
        var val_19;
        string val_20;
        var val_23;
        var val_25;
        var val_26;
        var val_28;
        var val_29;
        var val_30;
        var val_33;
        var val_34;
        var val_35;
        var val_36;
        var val_37;
        var val_38;
        val_18 = dict;
        val_19 = null;
        val_19 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_1 = PrettyPrint.builder.Append(value:  "{");
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = "";
        var val_22 = 0;
        val_22 = val_22 + 1;
        System.Collections.ICollection val_3 = val_18.Keys;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_23 = 0;
        val_23 = val_23 + 1;
        val_23 = val_3.GetEnumerator();
        int val_6 = level + 1;
        goto label_15;
        label_39:
        var val_24 = 0;
        val_24 = val_24 + 1;
        object val_8 = val_23.Current;
        val_25 = null;
        val_25 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_10 = PrettyPrint.builder.Append(value:  val_20 + PrettyPrint.separator);
        val_26 = null;
        var val_11 = ((PrettyPrint.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        if((level & 2147483648) == 0)
        {
                var val_25 = 0;
            do
        {
            val_28 = null;
            if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_12 = PrettyPrint.builder.Append(value:  PrettyPrint.tab);
            val_29 = null;
            val_25 = val_25 + 1;
            var val_13 = ((PrettyPrint.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        }
        while(val_25 <= level);
        
        }
        
        PrettyPrint.append(obj:  val_8, level:  val_6);
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        val_30 = 0;
        System.Text.StringBuilder val_14 = PrettyPrint.builder.Append(value:  " : ");
        var val_26 = 0;
        val_26 = val_26 + 1;
        val_30 = 0;
        PrettyPrint.append(obj:  val_18.Item[val_8], level:  val_6);
        val_20 = ",";
        label_15:
        var val_27 = 0;
        val_27 = val_27 + 1;
        if(val_23.MoveNext() == true)
        {
            goto label_39;
        }
        
        val_18 = 0;
        if(X0 == false)
        {
            goto label_40;
        }
        
        var val_30 = X0;
        val_23 = X0;
        if((X0 + 294) == 0)
        {
            goto label_44;
        }
        
        var val_28 = X0 + 176;
        var val_29 = 0;
        val_28 = val_28 + 8;
        label_43:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_42;
        }
        
        val_29 = val_29 + 1;
        val_28 = val_28 + 16;
        if(val_29 < (X0 + 294))
        {
            goto label_43;
        }
        
        goto label_44;
        label_42:
        val_30 = val_30 + (((X0 + 176 + 8)) << 4);
        val_33 = val_30 + 304;
        label_44:
        val_23.Dispose();
        label_40:
        if(val_18 != 0)
        {
                throw val_18;
        }
        
        val_34 = null;
        val_34 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_19 = PrettyPrint.builder.Append(value:  PrettyPrint.separator);
        val_35 = null;
        val_36 = (uint)(((uint)((PrettyPrint.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
        if(level >= 1)
        {
                val_18 = 0;
            do
        {
            val_37 = null;
            if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_20 = PrettyPrint.builder.Append(value:  PrettyPrint.tab);
            val_38 = null;
            val_18 = val_18 + 1;
            val_36 = (uint)(((uint)((PrettyPrint.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
        }
        while(val_18 < level);
        
        }
        
        val_38 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_21 = PrettyPrint.builder.Append(value:  "}");
    }
    private static void appendArray(System.Array array, int level)
    {
        var val_15;
        var val_16;
        var val_18;
        var val_19;
        var val_21;
        var val_22;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        var val_29;
        val_16 = null;
        val_16 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_1 = PrettyPrint.builder.Append(value:  "[");
        if(array == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_2 = array.GetEnumerator();
        int val_3 = level + 1;
        goto label_6;
        label_25:
        var val_16 = 0;
        val_16 = val_16 + 1;
        val_18 = null;
        val_18 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_7 = PrettyPrint.builder.Append(value:  "" + PrettyPrint.separator);
        val_19 = null;
        var val_8 = ((PrettyPrint.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        if((level & 2147483648) == 0)
        {
                var val_17 = 0;
            do
        {
            val_21 = null;
            if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_9 = PrettyPrint.builder.Append(value:  PrettyPrint.tab);
            val_22 = null;
            val_17 = val_17 + 1;
            var val_10 = ((PrettyPrint.__il2cppRuntimeField_12F & 2) != 0) ? 1 : 0;
        }
        while(val_17 <= level);
        
        }
        
        PrettyPrint.append(obj:  val_2.Current, level:  val_3);
        label_6:
        var val_18 = 0;
        val_18 = val_18 + 1;
        if(val_2.MoveNext() == true)
        {
            goto label_25;
        }
        
        val_15 = 0;
        if(X0 == false)
        {
            goto label_26;
        }
        
        var val_21 = X0;
        if((X0 + 294) == 0)
        {
            goto label_30;
        }
        
        var val_19 = X0 + 176;
        var val_20 = 0;
        val_19 = val_19 + 8;
        label_29:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_28;
        }
        
        val_20 = val_20 + 1;
        val_19 = val_19 + 16;
        if(val_20 < (X0 + 294))
        {
            goto label_29;
        }
        
        goto label_30;
        label_28:
        val_21 = val_21 + (((X0 + 176 + 8)) << 4);
        val_24 = val_21 + 304;
        label_30:
        X0.Dispose();
        label_26:
        if(val_15 != 0)
        {
                throw val_3;
        }
        
        val_25 = null;
        val_25 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_13 = PrettyPrint.builder.Append(value:  PrettyPrint.separator);
        val_26 = null;
        val_27 = (uint)(((uint)((PrettyPrint.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
        if(level >= 1)
        {
                var val_22 = 0;
            do
        {
            val_28 = null;
            if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_14 = PrettyPrint.builder.Append(value:  PrettyPrint.tab);
            val_29 = null;
            val_22 = val_22 + 1;
            val_27 = (uint)(((uint)((PrettyPrint.__il2cppRuntimeField_12F>>1) & 0x1)) >> 1) & 1;
        }
        while(val_22 < level);
        
        }
        
        val_29 = null;
        if(PrettyPrint.builder == null)
        {
                throw new NullReferenceException();
        }
        
        System.Text.StringBuilder val_15 = PrettyPrint.builder.Append(value:  "]");
    }
    public PrettyPrint()
    {
    
    }
    private static PrettyPrint()
    {
        PrettyPrint.separator = "\n";
        PrettyPrint.tab = "\t";
    }

}
