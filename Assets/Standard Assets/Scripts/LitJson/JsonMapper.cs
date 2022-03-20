using UnityEngine;

namespace LitJson
{
    public class JsonMapper
    {
        // Fields
        private static int max_nesting_depth;
        private static System.IFormatProvider datetime_format;
        private static System.Collections.Generic.IDictionary<System.Type, LitJson.ExporterFunc> base_exporters_table;
        private static System.Collections.Generic.IDictionary<System.Type, LitJson.ExporterFunc> custom_exporters_table;
        private static System.Collections.Generic.IDictionary<System.Type, System.Collections.Generic.IDictionary<System.Type, LitJson.ImporterFunc>> base_importers_table;
        private static System.Collections.Generic.IDictionary<System.Type, System.Collections.Generic.IDictionary<System.Type, LitJson.ImporterFunc>> custom_importers_table;
        private static System.Collections.Generic.IDictionary<System.Type, LitJson.ArrayMetadata> array_metadata;
        private static readonly object array_metadata_lock;
        private static System.Collections.Generic.IDictionary<System.Type, System.Collections.Generic.IDictionary<System.Type, System.Reflection.MethodInfo>> conv_ops;
        private static readonly object conv_ops_lock;
        private static System.Collections.Generic.IDictionary<System.Type, LitJson.ObjectMetadata> object_metadata;
        private static readonly object object_metadata_lock;
        private static System.Collections.Generic.IDictionary<System.Type, System.Collections.Generic.IList<LitJson.PropertyMetadata>> type_properties;
        private static readonly object type_properties_lock;
        private static LitJson.JsonWriter static_writer;
        private static readonly object static_writer_lock;
        
        // Methods
        private static JsonMapper()
        {
            LitJson.JsonMapper.array_metadata_lock = new System.Object();
            LitJson.JsonMapper.conv_ops_lock = new System.Object();
            LitJson.JsonMapper.object_metadata_lock = new System.Object();
            LitJson.JsonMapper.type_properties_lock = new System.Object();
            LitJson.JsonMapper.static_writer_lock = new System.Object();
            LitJson.JsonMapper.max_nesting_depth = 100;
            LitJson.JsonMapper.array_metadata = new System.Collections.Generic.Dictionary<System.Type, LitJson.ArrayMetadata>();
            LitJson.JsonMapper.conv_ops = new System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IDictionary<System.Type, System.Reflection.MethodInfo>>();
            LitJson.JsonMapper.object_metadata = new System.Collections.Generic.Dictionary<System.Type, LitJson.ObjectMetadata>();
            LitJson.JsonMapper.type_properties = new System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IList<LitJson.PropertyMetadata>>();
            LitJson.JsonMapper.static_writer = new LitJson.JsonWriter();
            LitJson.JsonMapper.datetime_format = System.Globalization.DateTimeFormatInfo.InvariantInfo;
            LitJson.JsonMapper.base_exporters_table = new System.Collections.Generic.Dictionary<System.Type, LitJson.ExporterFunc>();
            LitJson.JsonMapper.custom_exporters_table = new System.Collections.Generic.Dictionary<System.Type, LitJson.ExporterFunc>();
            LitJson.JsonMapper.base_importers_table = new System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IDictionary<System.Type, LitJson.ImporterFunc>>();
            LitJson.JsonMapper.custom_importers_table = new System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.IDictionary<System.Type, LitJson.ImporterFunc>>();
            LitJson.JsonMapper.RegisterBaseExporters();
            LitJson.JsonMapper.RegisterBaseImporters();
        }
        private static void AddArrayMetadata(System.Type type)
        {
            var val_14;
            var val_15;
            var val_17;
            var val_18;
            var val_19;
            val_14 = type;
            val_15 = null;
            val_15 = null;
            if(LitJson.JsonMapper.array_metadata == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            if((LitJson.JsonMapper.array_metadata.ContainsKey(key:  null)) == true)
            {
                    return;
            }
            
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_4 = val_14.IsArray;
            System.Reflection.PropertyInfo[] val_9 = val_14.GetProperties();
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_9.Length >= 1)
            {
                    val_17 = 0;
                var val_17 = 0;
                do
            {
                System.Reflection.PropertyInfo val_16 = val_9[val_17];
                if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                if((System.String.op_Inequality(a:  val_16, b:  "Item")) != true)
            {
                    if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(null == 1)
            {
                    if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                if((System.Type.op_Equality(left:  val_16, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
            {
                    val_17 = val_16;
            }
            
            }
            
            }
            
                val_17 = val_17 + 1;
            }
            while(val_17 < val_9.Length);
            
            }
            else
            {
                    val_17 = 0;
            }
            
            val_18 = null;
            val_18 = null;
            bool val_13 = false;
            System.Threading.Monitor.Enter(obj:  LitJson.JsonMapper.array_metadata_lock, lockTaken: ref  val_13);
            val_19 = null;
            val_19 = null;
            var val_18 = 0;
            val_18 = val_18 + 1;
            LitJson.JsonMapper.array_metadata.Add(key:  ((System.Type.op_Inequality(left:  val_14.GetInterface(name:  "System.Collections.IList"), right:  0)) != true) ? (val_4 | 256) : (val_4), value:  null);
            val_14 = 0;
            if(val_13 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  LitJson.JsonMapper.array_metadata_lock);
            }
            
            if(val_14 != 0)
            {
                    throw val_14;
            }
        
        }
        private static void AddObjectMetadata(System.Type type)
        {
            var val_15;
            var val_16;
            var val_18;
            System.Type val_19;
            var val_21;
            var val_23;
            val_15 = type;
            val_16 = null;
            val_16 = null;
            if(LitJson.JsonMapper.object_metadata == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_16 = 0;
            val_16 = val_16 + 1;
            if((LitJson.JsonMapper.object_metadata.ContainsKey(key:  null)) == true)
            {
                    return;
            }
            
            if(val_15 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.Generic.Dictionary<System.String, LitJson.PropertyMetadata> val_5 = new System.Collections.Generic.Dictionary<System.String, LitJson.PropertyMetadata>();
            System.Reflection.PropertyInfo[] val_6 = val_15.GetProperties();
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_6.Length < 1)
            {
                goto label_13;
            }
            
            val_18 = "Item";
            var val_19 = 0;
            label_29:
            System.Reflection.PropertyInfo val_17 = val_6[val_19];
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  val_17, b:  "Item")) == false)
            {
                goto label_16;
            }
            
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(null != 1)
            {
                goto label_23;
            }
            
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_19 = val_17;
            if((System.Type.op_Equality(left:  val_19, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
            {
                goto label_23;
            }
            
            goto label_23;
            label_16:
            val_19 = val_17;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_18 = 0;
            val_18 = val_18 + 1;
            val_5.Add(key:  null, value:  null);
            label_23:
            val_19 = val_19 + 1;
            if(val_19 < val_6.Length)
            {
                goto label_29;
            }
            
            goto label_30;
            label_13:
            label_30:
            System.Reflection.FieldInfo[] val_11 = val_15.GetFields();
            if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_11.Length >= 1)
            {
                    var val_22 = 0;
                do
            {
                System.Reflection.FieldInfo val_20 = val_11[val_22];
                if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_19 = val_20;
                if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_21 = 0;
                val_21 = val_21 + 1;
                val_21 = val_5;
                val_5.Add(key:  null, value:  null);
                val_22 = val_22 + 1;
            }
            while(val_22 < val_11.Length);
            
            }
            
            if(((val_11.Length & 2) != 0) && (val_11.Length == 0))
            {
                    val_21 = null;
            }
            
            bool val_13 = false;
            System.Threading.Monitor.Enter(obj:  LitJson.JsonMapper.object_metadata_lock, lockTaken: ref  val_13);
            val_23 = null;
            val_23 = null;
            var val_23 = 0;
            val_23 = val_23 + 1;
            bool val_15 = System.Type.op_Inequality(left:  val_15.GetInterface(name:  "System.Collections.IDictionary"), right:  0);
            LitJson.JsonMapper.object_metadata.Add(key:  null, value:  null);
            val_15 = 0;
            if(val_13 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  LitJson.JsonMapper.object_metadata_lock);
            }
            
            if(val_15 != 0)
            {
                    throw val_15;
            }
        
        }
        private static void AddTypeProperties(System.Type type)
        {
            var val_10;
            var val_11;
            var val_13;
            var val_15;
            var val_17;
            var val_18;
            val_10 = type;
            val_11 = null;
            val_11 = null;
            if(LitJson.JsonMapper.type_properties == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            if((LitJson.JsonMapper.type_properties.ContainsKey(key:  null)) == true)
            {
                    return;
            }
            
            System.Collections.Generic.List<LitJson.PropertyMetadata> val_3 = new System.Collections.Generic.List<LitJson.PropertyMetadata>();
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Reflection.PropertyInfo[] val_4 = val_10.GetProperties();
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_4.Length >= 1)
            {
                    do
            {
                System.Reflection.PropertyInfo val_12 = val_4[0];
                if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
                if((System.String.op_Equality(a:  val_12, b:  "Item")) != true)
            {
                    if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_13 = 0;
                val_13 = val_13 + 1;
                val_3.Add(item:  null);
            }
            
                val_15 = 0 + 1;
            }
            while(val_15 < val_4.Length);
            
            }
            
            System.Reflection.FieldInfo[] val_7 = val_10.GetFields();
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_14 = val_7.Length;
            if(val_14 >= 1)
            {
                    val_15 = 1152921504687144960;
                var val_17 = 0;
                val_14 = val_14 & 4294967295;
                val_13 = 1;
                do
            {
                System.Reflection.FieldInfo val_15 = val_7[val_17];
                if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_16 = 0;
                val_16 = val_16 + 1;
                val_3.Add(item:  0);
                val_17 = val_17 + 1;
            }
            while(val_17 < (val_7.Length << ));
            
            }
            
            val_17 = null;
            val_17 = null;
            bool val_9 = false;
            System.Threading.Monitor.Enter(obj:  LitJson.JsonMapper.type_properties_lock, lockTaken: ref  val_9);
            val_18 = null;
            val_18 = null;
            var val_18 = 0;
            val_18 = val_18 + 1;
            LitJson.JsonMapper.type_properties.Add(key:  0, value:  0);
            val_10 = 0;
            if(val_9 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  LitJson.JsonMapper.type_properties_lock);
            }
            
            if(val_10 != 0)
            {
                    throw val_10;
            }
        
        }
        private static System.Reflection.MethodInfo GetConvOp(System.Type t1, System.Type t2)
        {
            System.Type val_18;
            var val_19;
            var val_20;
            var val_21;
            var val_22;
            var val_23;
            var val_24;
            var val_26;
            var val_27;
            var val_28;
            var val_30;
            var val_31;
            var val_32;
            var val_33;
            var val_35;
            var val_36;
            var val_37;
            var val_38;
            var val_39;
            var val_40;
            var val_42;
            var val_43;
            var val_44;
            var val_45;
            var val_47;
            var val_48;
            var val_49;
            var val_50;
            var val_51;
            val_18 = t2;
            val_19 = t1;
            val_20 = null;
            val_20 = null;
            bool val_1 = false;
            val_21 = 0;
            System.Threading.Monitor.Enter(obj:  LitJson.JsonMapper.conv_ops_lock, lockTaken: ref  val_1);
            val_22 = null;
            val_22 = null;
            if(LitJson.JsonMapper.conv_ops == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = 1152921504687251456;
            var val_22 = 0;
            val_22 = val_22 + 1;
            val_24 = 4;
            val_26 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((LitJson.JsonMapper.conv_ops.ContainsKey(key:  null)) != true)
            {
                    val_27 = null;
                val_27 = null;
                if(LitJson.JsonMapper.conv_ops == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_23 = 0;
                val_23 = val_23 + 1;
                val_26 = new System.Collections.Generic.Dictionary<System.Type, System.Reflection.MethodInfo>();
                LitJson.JsonMapper.conv_ops.Add(key:  null, value:  null);
            }
            
            val_30 = 0;
            if(val_1 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  LitJson.JsonMapper.conv_ops_lock);
            }
            
            if(0 != 0)
            {
                    throw 0;
            }
            
            if(val_30 != 1)
            {
                    var val_6 = (57 == 57) ? -1 : 0;
            }
            else
            {
                    val_31 = 0;
            }
            
            val_32 = null;
            val_32 = null;
            if(LitJson.JsonMapper.conv_ops == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_24 = 0;
            val_24 = val_24 + 1;
            val_33 = 0;
            val_35 = public TValue System.Collections.Generic.IDictionary<TKey, TValue>::get_Item(TKey key);
            TValue val_8 = LitJson.JsonMapper.conv_ops.Item[57];
            if(val_8 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_28 = val_8;
            val_23 = 1152921504687251456;
            if((val_8 + 294) == 0)
            {
                goto label_30;
            }
            
            var val_25 = val_8 + 176;
            var val_26 = 0;
            val_25 = val_25 + 8;
            label_32:
            if(((val_8 + 176 + 8) + -8) == null)
            {
                goto label_31;
            }
            
            val_26 = val_26 + 1;
            val_25 = val_25 + 16;
            if(val_26 < (val_8 + 294))
            {
                goto label_32;
            }
            
            label_30:
            val_36 = 4;
            goto label_33;
            label_31:
            var val_27 = val_25;
            val_27 = val_27 + 4;
            val_28 = val_28 + val_27;
            val_37 = val_28 + 304;
            label_33:
            val_38 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((val_8.ContainsKey(key:  57)) == false)
            {
                goto label_34;
            }
            
            val_39 = null;
            val_39 = null;
            if(LitJson.JsonMapper.conv_ops == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_29 = 0;
            val_29 = val_29 + 1;
            val_40 = 0;
            goto label_41;
            label_34:
            System.Type[] val_10 = new System.Type[1];
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10[0] = val_18;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_42 = null;
            val_43 = val_19.GetMethod(name:  "op_Implicit", types:  val_10);
            val_42 = null;
            bool val_12 = false;
            val_44 = 0;
            System.Threading.Monitor.Enter(obj:  LitJson.JsonMapper.conv_ops_lock, lockTaken: ref  val_12);
            val_28 = null;
            val_28 = null;
            if(LitJson.JsonMapper.conv_ops == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_30 = 0;
            val_30 = val_30 + 1;
            val_45 = 0;
            goto label_55;
            label_41:
            val_47 = public TValue System.Collections.Generic.IDictionary<TKey, TValue>::get_Item(TKey key);
            TValue val_14 = LitJson.JsonMapper.conv_ops.Item[57];
            if(val_14 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_33 = val_14;
            if((val_14 + 294) == 0)
            {
                goto label_57;
            }
            
            var val_31 = val_14 + 176;
            var val_32 = 0;
            val_31 = val_31 + 8;
            label_59:
            if(((val_14 + 176 + 8) + -8) == null)
            {
                goto label_58;
            }
            
            val_32 = val_32 + 1;
            val_31 = val_31 + 16;
            if(val_32 < (val_14 + 294))
            {
                goto label_59;
            }
            
            label_57:
            val_48 = 0;
            goto label_60;
            label_58:
            val_33 = val_33 + (((val_14 + 176 + 8)) << 4);
            val_49 = val_33 + 304;
            label_60:
            val_43 = val_14.Item[57];
            return (System.Reflection.MethodInfo)(183 == 185) ? (val_18) : (val_43);
            label_55:
            val_50 = public TValue System.Collections.Generic.IDictionary<TKey, TValue>::get_Item(TKey key);
            val_28 = LitJson.JsonMapper.conv_ops;
            TValue val_17 = val_28.Item[57];
            val_30 = val_17;
            if(val_17 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_37 = val_30;
            if((val_17 + 294) == 0)
            {
                goto label_66;
            }
            
            var val_34 = val_17 + 176;
            var val_35 = 0;
            val_34 = val_34 + 8;
            label_65:
            if(((val_17 + 176 + 8) + -8) == null)
            {
                goto label_64;
            }
            
            val_35 = val_35 + 1;
            val_34 = val_34 + 16;
            if(val_35 < (val_17 + 294))
            {
                goto label_65;
            }
            
            goto label_66;
            label_64:
            var val_36 = val_34;
            val_36 = val_36 + 5;
            val_37 = val_37 + val_36;
            val_51 = val_37 + 304;
            label_66:
            val_50 = val_43;
            val_30.Add(key:  57, value:  null);
            val_31 = 1;
            val_19 = 0;
            val_18 = 0;
            if(val_12 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  LitJson.JsonMapper.conv_ops_lock);
            }
            
            if(val_19 == 0)
            {
                    if(val_31 == 1)
            {
                    return (System.Reflection.MethodInfo)(183 == 185) ? (val_18) : (val_43);
            }
            
                if(183 == 183)
            {
                    return (System.Reflection.MethodInfo)(183 == 185) ? (val_18) : (val_43);
            }
            
                return (System.Reflection.MethodInfo)(183 == 185) ? (val_18) : (val_43);
            }
            
            val_28 = val_19;
            throw val_28;
        }
        private static object ReadValue(System.Type inst_type, LitJson.JsonReader reader)
        {
            object val_16;
            var val_17;
            var val_23;
            LitJson.JsonReader val_43;
            object val_44;
            object val_46;
            var val_61;
            var val_62;
            var val_63;
            var val_64;
            var val_65;
            var val_66;
            var val_68;
            var val_69;
            var val_71;
            var val_72;
            System.Type val_76;
            var val_78;
            object val_80;
            var val_81;
            var val_82;
            var val_83;
            var val_84;
            var val_85;
            var val_86;
            var val_87;
            var val_88;
            var val_89;
            var val_90;
            var val_93;
            var val_94;
            var val_95;
            var val_96;
            var val_97;
            var val_98;
            var val_99;
            var val_100;
            var val_101;
            var val_102;
            val_43 = reader;
            bool val_1 = val_43.Read();
            LitJson.JsonToken val_48 = reader.token;
            val_44 = 0;
            val_48 = val_48 - 1;
            if(val_48 > 10)
            {
                    return (object)val_44;
            }
            
            var val_49 = 32562924 + ((reader.token - 1)) << 2;
            val_49 = val_49 + 32562924;
            goto (32562924 + ((reader.token - 1)) << 2 + 32562924);
            label_42:
            if(((val_7 + 176 + 8) + -8) == null)
            {
                goto label_41;
            }
            
             =  + 1;
             =  + 16;
            if( < (val_7 + 294))
            {
                goto label_42;
            }
            
            val_61 = 4;
            goto label_43;
            label_41:
            var val_56 = ;
            val_56 = val_56 + 4;
             =  + val_56;
            val_63 =  + 304;
            label_43:
            val_64 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((ContainsKey(key:  null)) == false)
            {
                goto label_44;
            }
            
            val_65 = null;
            val_65 = null;
            var val_58 = 0;
            val_58 = val_58 + 1;
            val_66 = 0;
            goto label_51;
            label_44:
            val_68 = null;
            val_68 = null;
            var val_59 = 0;
            val_59 = val_59 + 1;
            val_69 = 4;
            val_71 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((LitJson.JsonMapper.base_importers_table.ContainsKey(key:  null)) == false)
            {
                goto label_129;
            }
            
            val_72 = null;
            val_72 = null;
            var val_60 = 0;
            val_60 = val_60 + 1;
            val_71 = 0;
            goto label_66;
            label_122:
            val_80 = reader.token_value;
            if(val_80 != null)
            {
                    if(null != null)
            {
                goto label_112;
            }
            
            }
            
            val_46 = val_16;
            var val_64 = val_46;
            if((val_16 + 294) == 0)
            {
                goto label_77;
            }
            
            var val_61 = val_16 + 176;
            var val_62 = 0;
            val_61 = val_61 + 8;
            label_79:
            if(((val_16 + 176 + 8) + -8) == null)
            {
                goto label_78;
            }
            
            val_62 = val_62 + 1;
            val_61 = val_61 + 16;
            if(val_62 < (val_16 + 294))
            {
                goto label_79;
            }
            
            label_77:
            val_78 = 4;
            goto label_80;
            label_78:
            var val_63 = val_61;
            val_63 = val_63 + 4;
            val_64 = val_64 + val_63;
            val_81 = val_64 + 304;
            label_80:
            val_82 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((val_46.ContainsKey(key:  null)) == false)
            {
                goto label_81;
            }
            
            var val_69 = val_16;
            if((val_16 + 294) == 0)
            {
                goto label_83;
            }
            
            var val_65 = val_16 + 176;
            var val_66 = 0;
            val_65 = val_65 + 8;
            label_85:
            if(((val_16 + 176 + 8) + -8) == null)
            {
                goto label_84;
            }
            
            val_66 = val_66 + 1;
            val_65 = val_65 + 16;
            if(val_66 < (val_16 + 294))
            {
                goto label_85;
            }
            
            label_83:
            val_82 = 0;
            goto label_86;
            label_81:
            if(val_17 == 0)
            {
                goto label_87;
            }
            
            val_84 = null;
            val_46 = val_17.ElementType;
            if(X0 == false)
            {
                goto label_92;
            }
            
            val_85 = null;
            if(X0 == false)
            {
                goto label_93;
            }
            
            var val_71 = X0;
            if((X0 + 294) == 0)
            {
                goto label_97;
            }
            
            var val_67 = X0 + 176;
            var val_68 = 0;
            val_67 = val_67 + 8;
            label_96:
            if(((X0 + 176 + 8) + -8) == val_85)
            {
                goto label_95;
            }
            
            val_68 = val_68 + 1;
            val_67 = val_67 + 16;
            if(val_68 < (X0 + 294))
            {
                goto label_96;
            }
            
            goto label_97;
            label_87:
            if(reader.skip_non_members == false)
            {
                goto label_98;
            }
            
            LitJson.JsonMapper.ReadSkip(reader:  val_43);
            goto label_118;
            label_84:
            val_69 = val_69 + (((val_16 + 176 + 8)) << 4);
            val_83 = val_69 + 304;
            label_86:
            TValue val_22 = val_16.Item[null];
            val_80 = val_17;
            val_46 = val_16;
            if(val_23 == false)
            {
                goto label_102;
            }
            
            val_80.SetValue(obj:  null, value:  val_46);
            goto label_118;
            label_102:
            if((val_80 & 1) == 0)
            {
                goto label_113;
            }
            
            if((((X26 + 302) & 512) == 0) || ((X26 + 224) != 0))
            {
                goto label_118;
            }
            
            goto label_118;
            label_95:
            var val_70 = val_67;
            val_70 = val_70 + 5;
            val_71 = val_71 + val_70;
            val_86 = val_71 + 304;
            label_97:
            X0.Add(key:  val_80, value:  val_46);
            val_62 = ;
            goto label_118;
            label_113:
            label_118:
            bool val_24 = val_43.Read();
            if(reader.token != 3)
            {
                goto label_122;
            }
            
            return (object)val_44;
            label_66:
            val_87 = public TValue System.Collections.Generic.IDictionary<TKey, TValue>::get_Item(TKey key);
            TValue val_26 = LitJson.JsonMapper.base_importers_table.Item[null];
            var val_75 = val_26;
            val_62 = 1152921504687251456;
            if((val_26 + 294) == 0)
            {
                goto label_125;
            }
            
            var val_72 = val_26 + 176;
            var val_73 = 0;
            val_72 = val_72 + 8;
            label_127:
            if(((val_26 + 176 + 8) + -8) == null)
            {
                goto label_126;
            }
            
            val_73 = val_73 + 1;
            val_72 = val_72 + 16;
            if(val_73 < (val_26 + 294))
            {
                goto label_127;
            }
            
            label_125:
            val_87 = 4;
            goto label_128;
            label_126:
            var val_74 = val_72;
            val_74 = val_74 + 4;
            val_75 = val_75 + val_74;
            val_88 = val_75 + 304;
            label_128:
            val_89 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((val_26.ContainsKey(key:  null)) == false)
            {
                goto label_129;
            }
            
            val_90 = null;
            val_90 = null;
            var val_76 = 0;
            val_76 = val_76 + 1;
            val_89 = 0;
            goto label_136;
            label_129:
            if((inst_type & 1) == 0)
            {
                goto label_137;
            }
            
            val_43 = reader.token_value;
            object val_28 = System.Enum.ToObject(enumType:  inst_type, value:  val_43);
            goto label_149;
            label_137:
            System.Reflection.MethodInfo val_29 = LitJson.JsonMapper.GetConvOp(t1:  inst_type, t2:  null);
            if((System.Reflection.MethodInfo.op_Inequality(left:  val_29, right:  0)) == false)
            {
                goto label_143;
            }
            
            object[] val_31 = new object[1];
            val_43 = reader.token_value;
            val_31[0] = val_43;
            object val_32 = val_29.Invoke(obj:  0, parameters:  val_31);
            goto label_149;
            label_51:
            val_93 = public TValue System.Collections.Generic.IDictionary<TKey, TValue>::get_Item(TKey key);
            TValue val_34 = LitJson.JsonMapper.custom_importers_table.Item[null];
            val_94 = mem[val_34];
            val_94 = val_34;
            val_95 = null;
            val_96 = val_34;
            if((val_34 + 294) == 0)
            {
                goto label_156;
            }
            
            var val_77 = 0;
            val_97 = (val_34 + 176) + 8;
            label_153:
            if(((val_34 + 176 + 8) + -8) == val_95)
            {
                goto label_157;
            }
            
            val_77 = val_77 + 1;
            val_97 = val_97 + 16;
            if(val_77 < (val_34 + 294))
            {
                goto label_153;
            }
            
            goto label_156;
            label_136:
            val_93 = public TValue System.Collections.Generic.IDictionary<TKey, TValue>::get_Item(TKey key);
            TValue val_36 = LitJson.JsonMapper.base_importers_table.Item[null];
            val_94 = mem[val_36];
            val_94 = val_36;
            val_95 = null;
            val_96 = val_36;
            if((val_36 + 294) == 0)
            {
                goto label_156;
            }
            
            var val_78 = 0;
            val_97 = (val_36 + 176) + 8;
            label_158:
            if(((val_36 + 176 + 8) + -8) == val_95)
            {
                goto label_157;
            }
            
            val_78 = val_78 + 1;
            val_97 = val_97 + 16;
            if(val_78 < (val_36 + 294))
            {
                goto label_158;
            }
            
            label_156:
            val_93 = 0;
            goto label_159;
            label_157:
            val_94 = val_94 + (((val_34 + 176 + 8)) << 4);
            val_98 = val_94 + 304;
            label_159:
            label_149:
            val_44 = val_96.Item[null].Invoke(input:  reader.token_value);
            return (object)val_44;
            label_171:
            var val_82 = 1179403647;
            if(mem[282584257676965] == 0)
            {
                goto label_166;
            }
            
            var val_79 = mem[282584257676847];
            var val_80 = 0;
            val_79 = val_79 + 8;
            label_165:
            if(((mem[282584257676847] + 8) + -8) == null)
            {
                goto label_164;
            }
            
            val_80 = val_80 + 1;
            val_79 = val_79 + 16;
            if(val_80 < mem[282584257676965])
            {
                goto label_165;
            }
            
            goto label_166;
            label_164:
            var val_81 = val_79;
            val_81 = val_81 + 2;
            val_82 = val_82 + val_81;
            val_99 = val_82 + 304;
            label_166:
            int val_40 = val_74.Add(value:  null);
            if(( != null) || (reader.token != 5))
            {
                goto label_171;
            }
            
            if((inst_type & 255) != 0)
            {
                    return (object)val_44;
            }
            
            var val_86 = 1179403647;
            if(mem[282584257676965] == 0)
            {
                goto label_177;
            }
            
            var val_83 = mem[282584257676847];
            var val_84 = 0;
            val_83 = val_83 + 8;
            label_176:
            if(((mem[282584257676847] + 8) + -8) == null)
            {
                goto label_175;
            }
            
            val_84 = val_84 + 1;
            val_83 = val_83 + 16;
            if(val_84 < mem[282584257676965])
            {
                goto label_176;
            }
            
            goto label_177;
            label_175:
            var val_85 = val_83;
            val_85 = val_85 + 1;
            val_86 = val_86 + val_85;
            val_100 = val_86 + 304;
            label_177:
            int val_41 = val_74.Count;
            val_101 = 0;
            val_76 = System.Array.CreateInstance(elementType:  null, length:  val_41);
            if(val_41 < 1)
            {
                    return (object)val_44;
            }
            
            val_80 = 0;
            label_186:
            var val_89 = 1179403647;
            if(mem[282584257676965] == 0)
            {
                goto label_179;
            }
            
            var val_87 = mem[282584257676847];
            var val_88 = 0;
            val_87 = val_87 + 8;
            label_181:
            if(((mem[282584257676847] + 8) + -8) == null)
            {
                goto label_180;
            }
            
            val_88 = val_88 + 1;
            val_87 = val_87 + 16;
            if(val_88 < mem[282584257676965])
            {
                goto label_181;
            }
            
            label_179:
            val_101 = 0;
            goto label_182;
            label_180:
            val_89 = val_89 + (((mem[282584257676847] + 8)) << 4);
            val_102 = val_89 + 304;
            label_182:
            val_76.SetValue(value:  val_74.Item[0], index:  0);
            val_80 = val_80 + 1;
            if(val_80 < val_41)
            {
                goto label_186;
            }
            
            return (object)val_44;
            label_112:
            label_92:
            label_93:
            label_98:
            string val_44 = System.String.Format(format:  "The type {0} doesn\'t have the property \'{1}\'", arg0:  null, arg1:  val_80);
            throw new LitJson.JsonException(message:  System.String.Format(format:  null, arg0:  inst_type));
            label_143:
            string val_45 = System.String.Format(format:  "Can\'t assign value \'{0}\' (type {1}) to type {2}", arg0:  reader.token_value, arg1:  null, arg2:  inst_type);
            throw new LitJson.JsonException(message:  System.String.Format(format:  null, arg0:  inst_type));
        }
        private static LitJson.IJsonWrapper ReadValue(LitJson.WrapperFactory factory, LitJson.JsonReader reader)
        {
            bool val_1 = reader.Read();
            if(reader.token == 5)
            {
                    return 0;
            }
            
            if(reader.token == 11)
            {
                    return 0;
            }
            
            LitJson.IJsonWrapper val_2 = factory.Invoke();
            LitJson.JsonToken val_15 = reader.token;
            val_15 = val_15 - 1;
            if(val_15 > 9)
            {
                    return 0;
            }
            
            var val_16 = 32562968 + ((reader.token - 1)) << 2;
            val_16 = val_16 + 32562968;
            goto (32562968 + ((reader.token - 1)) << 2 + 32562968);
        }
        private static void ReadSkip(LitJson.JsonReader reader)
        {
            var val_3;
            LitJson.WrapperFactory val_5;
            val_3 = null;
            val_3 = null;
            val_5 = JsonMapper.<>c.<>9__23_0;
            if(val_5 == null)
            {
                    LitJson.WrapperFactory val_1 = null;
                val_5 = val_1;
                val_1 = new LitJson.WrapperFactory(object:  JsonMapper.<>c.__il2cppRuntimeField_static_fields, method:  LitJson.IJsonWrapper JsonMapper.<>c::<ReadSkip>b__23_0());
                JsonMapper.<>c.<>9__23_0 = val_5;
            }
            
            LitJson.IJsonWrapper val_2 = LitJson.JsonMapper.ToWrapper(factory:  val_1, reader:  reader);
        }
        private static void RegisterBaseExporters()
        {
            var val_19;
            var val_20;
            var val_21;
            LitJson.ExporterFunc val_23;
            var val_25;
            var val_26;
            LitJson.ExporterFunc val_28;
            var val_30;
            var val_31;
            LitJson.ExporterFunc val_33;
            var val_35;
            var val_36;
            LitJson.ExporterFunc val_38;
            var val_40;
            var val_41;
            LitJson.ExporterFunc val_43;
            var val_45;
            var val_46;
            LitJson.ExporterFunc val_48;
            var val_50;
            var val_51;
            LitJson.ExporterFunc val_53;
            var val_55;
            var val_56;
            LitJson.ExporterFunc val_58;
            var val_60;
            var val_61;
            LitJson.ExporterFunc val_63;
            val_19 = 1152921504870690816;
            val_20 = null;
            val_20 = null;
            System.Type val_1 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_21 = null;
            val_21 = null;
            val_23 = JsonMapper.<>c.<>9__24_0;
            if(val_23 == null)
            {
                    val_23 = new LitJson.ExporterFunc();
                mem[1152921513341325328] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341325336] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_0(object obj, LitJson.JsonWriter writer);
                mem[1152921513341325312] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_0(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_0 = new LitJson.ExporterFunc();
            }
            
            var val_19 = 0;
            val_19 = val_19 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_25 = null;
            val_25 = null;
            System.Type val_3 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_26 = null;
            val_26 = null;
            val_28 = JsonMapper.<>c.<>9__24_1;
            if(val_28 == null)
            {
                    val_28 = new LitJson.ExporterFunc();
                mem[1152921513341333536] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341333544] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_1(object obj, LitJson.JsonWriter writer);
                mem[1152921513341333520] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_1(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_1 = new LitJson.ExporterFunc();
            }
            
            var val_20 = 0;
            val_20 = val_20 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_30 = null;
            val_30 = null;
            System.Type val_5 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_31 = null;
            val_31 = null;
            val_33 = JsonMapper.<>c.<>9__24_2;
            if(val_33 == null)
            {
                    val_33 = new LitJson.ExporterFunc();
                mem[1152921513341341744] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341341752] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_2(object obj, LitJson.JsonWriter writer);
                mem[1152921513341341728] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_2(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_2 = new LitJson.ExporterFunc();
            }
            
            var val_21 = 0;
            val_21 = val_21 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_35 = null;
            val_35 = null;
            System.Type val_7 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_36 = null;
            val_36 = null;
            val_38 = JsonMapper.<>c.<>9__24_3;
            if(val_38 == null)
            {
                    val_38 = new LitJson.ExporterFunc();
                mem[1152921513341349952] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341349960] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_3(object obj, LitJson.JsonWriter writer);
                mem[1152921513341349936] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_3(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_3 = new LitJson.ExporterFunc();
            }
            
            var val_22 = 0;
            val_22 = val_22 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_40 = null;
            val_40 = null;
            System.Type val_9 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_41 = null;
            val_41 = null;
            val_43 = JsonMapper.<>c.<>9__24_4;
            if(val_43 == null)
            {
                    val_43 = new LitJson.ExporterFunc();
                mem[1152921513341358160] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341358168] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_4(object obj, LitJson.JsonWriter writer);
                mem[1152921513341358144] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_4(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_4 = new LitJson.ExporterFunc();
            }
            
            var val_23 = 0;
            val_23 = val_23 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_45 = null;
            val_45 = null;
            System.Type val_11 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_46 = null;
            val_46 = null;
            val_48 = JsonMapper.<>c.<>9__24_5;
            if(val_48 == null)
            {
                    val_48 = new LitJson.ExporterFunc();
                mem[1152921513341366368] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341366376] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_5(object obj, LitJson.JsonWriter writer);
                mem[1152921513341366352] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_5(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_5 = new LitJson.ExporterFunc();
            }
            
            var val_24 = 0;
            val_24 = val_24 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_50 = null;
            val_50 = null;
            System.Type val_13 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_51 = null;
            val_51 = null;
            val_53 = JsonMapper.<>c.<>9__24_6;
            if(val_53 == null)
            {
                    val_53 = new LitJson.ExporterFunc();
                mem[1152921513341374576] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341374584] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_6(object obj, LitJson.JsonWriter writer);
                mem[1152921513341374560] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_6(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_6 = new LitJson.ExporterFunc();
            }
            
            var val_25 = 0;
            val_25 = val_25 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_55 = null;
            val_55 = null;
            System.Type val_15 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_56 = null;
            val_56 = null;
            val_58 = JsonMapper.<>c.<>9__24_7;
            if(val_58 == null)
            {
                    val_58 = new LitJson.ExporterFunc();
                mem[1152921513341382784] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341382792] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_7(object obj, LitJson.JsonWriter writer);
                mem[1152921513341382768] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_7(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_7 = new LitJson.ExporterFunc();
            }
            
            var val_26 = 0;
            val_26 = val_26 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  ???, value:  ???);
            val_60 = null;
            val_60 = null;
            System.Type val_17 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_61 = null;
            val_61 = null;
            val_63 = JsonMapper.<>c.<>9__24_8;
            if(val_63 == null)
            {
                    val_63 = new LitJson.ExporterFunc();
                mem[1152921513341390992] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341391000] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_8(object obj, LitJson.JsonWriter writer);
                mem[1152921513341390976] = System.Void JsonMapper.<>c::<RegisterBaseExporters>b__24_8(object obj, LitJson.JsonWriter writer);
                JsonMapper.<>c.<>9__24_8 = new LitJson.ExporterFunc();
            }
            
            var val_27 = 0;
            val_27 = val_27 + 1;
            LitJson.JsonMapper.base_exporters_table.set_Item(key:  null, value:  null);
        }
        private static void RegisterBaseImporters()
        {
            var val_25;
            LitJson.ImporterFunc val_27;
            var val_28;
            var val_29;
            LitJson.ImporterFunc val_31;
            var val_32;
            var val_33;
            LitJson.ImporterFunc val_35;
            var val_36;
            var val_37;
            LitJson.ImporterFunc val_39;
            var val_40;
            var val_41;
            LitJson.ImporterFunc val_43;
            var val_44;
            var val_45;
            LitJson.ImporterFunc val_47;
            var val_48;
            var val_49;
            LitJson.ImporterFunc val_51;
            var val_52;
            var val_53;
            LitJson.ImporterFunc val_55;
            var val_56;
            var val_57;
            LitJson.ImporterFunc val_59;
            var val_60;
            var val_61;
            LitJson.ImporterFunc val_63;
            var val_64;
            var val_65;
            LitJson.ImporterFunc val_67;
            var val_68;
            var val_69;
            LitJson.ImporterFunc val_71;
            var val_72;
            val_25 = null;
            val_25 = null;
            val_27 = JsonMapper.<>c.<>9__25_0;
            if(val_27 == null)
            {
                    val_27 = new LitJson.ImporterFunc();
                mem[1152921513341666848] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341666856] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_0(object input);
                mem[1152921513341666832] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_0(object input);
                JsonMapper.<>c.<>9__25_0 = new LitJson.ImporterFunc();
            }
            
            val_28 = null;
            val_28 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_29 = null;
            val_29 = null;
            val_31 = JsonMapper.<>c.<>9__25_1;
            if(val_31 == null)
            {
                    val_31 = new LitJson.ImporterFunc();
                mem[1152921513341679136] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341679144] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_1(object input);
                mem[1152921513341679120] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_1(object input);
                JsonMapper.<>c.<>9__25_1 = new LitJson.ImporterFunc();
            }
            
            val_32 = null;
            val_32 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_33 = null;
            val_33 = null;
            val_35 = JsonMapper.<>c.<>9__25_2;
            if(val_35 == null)
            {
                    val_35 = new LitJson.ImporterFunc();
                mem[1152921513341691424] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341691432] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_2(object input);
                mem[1152921513341691408] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_2(object input);
                JsonMapper.<>c.<>9__25_2 = new LitJson.ImporterFunc();
            }
            
            val_36 = null;
            val_36 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_37 = null;
            val_37 = null;
            val_39 = JsonMapper.<>c.<>9__25_3;
            if(val_39 == null)
            {
                    val_39 = new LitJson.ImporterFunc();
                mem[1152921513341703712] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341703720] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_3(object input);
                mem[1152921513341703696] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_3(object input);
                JsonMapper.<>c.<>9__25_3 = new LitJson.ImporterFunc();
            }
            
            val_40 = null;
            val_40 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_41 = null;
            val_41 = null;
            val_43 = JsonMapper.<>c.<>9__25_4;
            if(val_43 == null)
            {
                    val_43 = new LitJson.ImporterFunc();
                mem[1152921513341716000] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341716008] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_4(object input);
                mem[1152921513341715984] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_4(object input);
                JsonMapper.<>c.<>9__25_4 = new LitJson.ImporterFunc();
            }
            
            val_44 = null;
            val_44 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_45 = null;
            val_45 = null;
            val_47 = JsonMapper.<>c.<>9__25_5;
            if(val_47 == null)
            {
                    val_47 = new LitJson.ImporterFunc();
                mem[1152921513341728288] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341728296] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_5(object input);
                mem[1152921513341728272] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_5(object input);
                JsonMapper.<>c.<>9__25_5 = new LitJson.ImporterFunc();
            }
            
            val_48 = null;
            val_48 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_49 = null;
            val_49 = null;
            val_51 = JsonMapper.<>c.<>9__25_6;
            if(val_51 == null)
            {
                    val_51 = new LitJson.ImporterFunc();
                mem[1152921513341740576] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341740584] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_6(object input);
                mem[1152921513341740560] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_6(object input);
                JsonMapper.<>c.<>9__25_6 = new LitJson.ImporterFunc();
            }
            
            val_52 = null;
            val_52 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_53 = null;
            val_53 = null;
            val_55 = JsonMapper.<>c.<>9__25_7;
            if(val_55 == null)
            {
                    val_55 = new LitJson.ImporterFunc();
                mem[1152921513341752864] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341752872] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_7(object input);
                mem[1152921513341752848] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_7(object input);
                JsonMapper.<>c.<>9__25_7 = new LitJson.ImporterFunc();
            }
            
            val_56 = null;
            val_56 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_57 = null;
            val_57 = null;
            val_59 = JsonMapper.<>c.<>9__25_8;
            if(val_59 == null)
            {
                    val_59 = new LitJson.ImporterFunc();
                mem[1152921513341765152] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341765160] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_8(object input);
                mem[1152921513341765136] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_8(object input);
                JsonMapper.<>c.<>9__25_8 = new LitJson.ImporterFunc();
            }
            
            val_60 = null;
            val_60 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_61 = null;
            val_61 = null;
            val_63 = JsonMapper.<>c.<>9__25_9;
            if(val_63 == null)
            {
                    val_63 = new LitJson.ImporterFunc();
                mem[1152921513341777440] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341777448] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_9(object input);
                mem[1152921513341777424] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_9(object input);
                JsonMapper.<>c.<>9__25_9 = new LitJson.ImporterFunc();
            }
            
            val_64 = null;
            val_64 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_65 = null;
            val_65 = null;
            val_67 = JsonMapper.<>c.<>9__25_10;
            if(val_67 == null)
            {
                    val_67 = new LitJson.ImporterFunc();
                mem[1152921513341789728] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341789736] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_10(object input);
                mem[1152921513341789712] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_10(object input);
                JsonMapper.<>c.<>9__25_10 = new LitJson.ImporterFunc();
            }
            
            val_68 = null;
            val_68 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
            val_69 = null;
            val_69 = null;
            val_71 = JsonMapper.<>c.<>9__25_11;
            if(val_71 == null)
            {
                    val_71 = new LitJson.ImporterFunc();
                mem[1152921513341802016] = JsonMapper.<>c.__il2cppRuntimeField_static_fields;
                mem[1152921513341802024] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_11(object input);
                mem[1152921513341802000] = System.Object JsonMapper.<>c::<RegisterBaseImporters>b__25_11(object input);
                JsonMapper.<>c.<>9__25_11 = new LitJson.ImporterFunc();
            }
            
            val_72 = null;
            val_72 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.base_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), importer:  new LitJson.ImporterFunc());
        }
        private static void RegisterImporter(System.Collections.Generic.IDictionary<System.Type, System.Collections.Generic.IDictionary<System.Type, LitJson.ImporterFunc>> table, System.Type json_type, System.Type value_type, LitJson.ImporterFunc importer)
        {
            var val_6;
            var val_8;
            var val_11;
            var val_7 = 0;
            val_7 = val_7 + 1;
            val_8 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((table.ContainsKey(key:  ???)) != true)
            {
                    System.Collections.Generic.Dictionary<System.Type, LitJson.ImporterFunc> val_3 = null;
                val_6 = val_3;
                val_3 = new System.Collections.Generic.Dictionary<System.Type, LitJson.ImporterFunc>();
                var val_8 = 0;
                val_8 = val_8 + 1;
                val_8 = val_6;
                table.Add(key:  ???, value:  ???);
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_8 = 0;
            TValue val_6 = table.Item[???];
            var val_13 = val_6;
            if((val_6 + 294) == 0)
            {
                goto label_19;
            }
            
            var val_10 = val_6 + 176;
            var val_11 = 0;
            val_10 = val_10 + 8;
            label_18:
            if(((val_6 + 176 + 8) + -8) == null)
            {
                goto label_17;
            }
            
            val_11 = val_11 + 1;
            val_10 = val_10 + 16;
            if(val_11 < (val_6 + 294))
            {
                goto label_18;
            }
            
            goto label_19;
            label_17:
            var val_12 = val_10;
            val_12 = val_12 + 1;
            val_13 = val_13 + val_12;
            val_11 = val_13 + 304;
            label_19:
            val_6.set_Item(key:  null, value:  null);
        }
        private static void WriteValue(object obj, LitJson.JsonWriter writer, bool writer_is_private, int depth)
        {
            var val_43;
            string val_44;
            System.Type val_49;
            IntPtr val_50;
            var val_51;
            LitJson.JsonWriter val_52;
            double val_53;
            var val_54;
            int val_55;
            System.IO.TextWriter val_56;
            var val_57;
            var val_58;
            var val_59;
            var val_60;
            System.Collections.Generic.IDictionary<System.Type, LitJson.ExporterFunc> val_61;
            var val_62;
            var val_63;
            var val_64;
            var val_65;
            var val_66;
            var val_67;
            var val_68;
            var val_69;
            var val_70;
            var val_74;
            var val_75;
            var val_76;
            var val_77;
            var val_80;
            var val_81;
            var val_85;
            var val_86;
            var val_87;
            var val_88;
            var val_89;
            System.Collections.Generic.IDictionary<System.Type, LitJson.ExporterFunc> val_90;
            var val_92;
            var val_93;
            var val_94;
            var val_95;
            var val_97;
            var val_98;
            var val_99;
            var val_101;
            var val_103;
            val_50 = depth;
            val_51 = writer_is_private;
            val_52 = writer;
            val_53 = obj;
            val_54 = null;
            val_54 = null;
            val_55 = LitJson.JsonMapper.max_nesting_depth;
            if(val_55 < val_50)
            {
                goto label_3;
            }
            
            if(val_53 == null)
            {
                goto label_4;
            }
            
            val_49 = 1152921504870051840;
            if(X0 == false)
            {
                goto label_5;
            }
            
            if(val_51 == false)
            {
                goto label_6;
            }
            
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_51 = null;
            val_56 = writer.writer;
            if(X0 == false)
            {
                goto label_30;
            }
            
            val_50 = null;
            val_57 = val_50;
            if(X0 == false)
            {
                goto label_31;
            }
            
            var val_68 = X0;
            if((X0 + 294) == 0)
            {
                goto label_10;
            }
            
            var val_59 = X0 + 176;
            var val_60 = 0;
            val_59 = val_59 + 8;
            label_12:
            if(((X0 + 176 + 8) + -8) == val_50)
            {
                goto label_11;
            }
            
            val_60 = val_60 + 1;
            val_59 = val_59 + 16;
            if(val_60 < (X0 + 294))
            {
                goto label_12;
            }
            
            label_10:
            val_57 = val_50;
            goto label_13;
            label_4:
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_37:
            val_52.Write(str:  0);
            return;
            label_5:
            val_59 = 1152921504622235648;
            if(null == null)
            {
                goto label_15;
            }
            
            if(null == null)
            {
                goto label_16;
            }
            
            val_60 = 1152921504619999232;
            if(null == null)
            {
                goto label_17;
            }
            
            if(null == null)
            {
                goto label_18;
            }
            
            if(null == 1152921504620052480)
            {
                goto label_19;
            }
            
            val_49 = 1152921504613076992;
            if(X0 == false)
            {
                goto label_22;
            }
            
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_52.WriteArrayStart();
            val_49 = null;
            if(X0 == false)
            {
                    throw new NullReferenceException();
            }
            
            val_60 = null;
            val_61 = null;
            val_62 = val_60;
            if(X0 == false)
            {
                    throw new NullReferenceException();
            }
            
            var val_74 = X0;
            val_49 = X0;
            if((X0 + 294) == 0)
            {
                goto label_26;
            }
            
            var val_61 = X0 + 176;
            var val_62 = 0;
            val_61 = val_61 + 8;
            label_28:
            if(((X0 + 176 + 8) + -8) == val_61)
            {
                goto label_27;
            }
            
            val_62 = val_62 + 1;
            val_61 = val_61 + 16;
            if(val_62 < (X0 + 294))
            {
                goto label_28;
            }
            
            label_26:
            val_62 = val_61;
            goto label_29;
            label_6:
            val_51 = null;
            if(X0 == false)
            {
                goto label_30;
            }
            
            val_50 = null;
            if(X0 == false)
            {
                goto label_31;
            }
            
            var val_66 = X0;
            if((X0 + 294) == 0)
            {
                goto label_35;
            }
            
            var val_63 = X0 + 176;
            var val_64 = 0;
            val_63 = val_63 + 8;
            label_34:
            if(((X0 + 176 + 8) + -8) == val_50)
            {
                goto label_33;
            }
            
            val_64 = val_64 + 1;
            val_63 = val_63 + 16;
            if(val_64 < (X0 + 294))
            {
                goto label_34;
            }
            
            goto label_35;
            label_15:
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_37;
            label_33:
            var val_65 = val_63;
            val_65 = val_65 + 20;
            val_66 = val_66 + val_65;
            val_64 = val_66 + 304;
            label_35:
            val_65 = public System.Void LitJson.IJsonWrapper::ToJson(LitJson.JsonWriter writer);
            goto label_38;
            label_11:
            var val_67 = val_59;
            val_67 = val_67 + 19;
            val_68 = val_68 + val_67;
            val_58 = val_68 + 304;
            label_13:
            string val_1 = X0.ToJson();
            if(val_56 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_38:
            val_66 = ???;
            val_50 = ???;
            val_53 = ???;
            val_61 = ???;
            val_49 = ???;
            val_60 = ???;
            val_59 = ???;
            goto typeof(System.IO.TextWriter).__il2cppRuntimeField_210;
            label_16:
            if(val_66 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_66.Write(number:  val_53);
            return;
            label_17:
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_52.Write(number:  19914752);
            return;
            label_18:
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_52.Write(boolean:  false);
            return;
            label_19:
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_52.Write(number:  null);
            return;
            label_22:
            val_61 = 1152921504683257856;
            if(X0 == false)
            {
                goto label_44;
            }
            
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_52.WriteObjectStart();
            val_49 = null;
            if(X0 == false)
            {
                    throw new NullReferenceException();
            }
            
            val_61 = null;
            val_67 = val_61;
            if(X0 == false)
            {
                goto label_47;
            }
            
            var val_80 = X0;
            val_49 = X0;
            if((X0 + 294) == 0)
            {
                goto label_48;
            }
            
            var val_69 = X0 + 176;
            var val_70 = 0;
            val_69 = val_69 + 8;
            label_50:
            if(((X0 + 176 + 8) + -8) == val_61)
            {
                goto label_49;
            }
            
            val_70 = val_70 + 1;
            val_69 = val_69 + 16;
            if(val_70 < (X0 + 294))
            {
                goto label_50;
            }
            
            label_48:
            val_67 = val_61;
            goto label_51;
            label_68:
            var val_71 = 0;
            val_71 = val_71 + 1;
            if(MoveNext() == false)
            {
                goto label_60;
            }
            
            var val_72 = 0;
            val_72 = val_72 + 1;
            object val_18 = Current;
            writer_is_private = val_51;
            goto label_68;
            label_60:
            val_51 = 0;
            if(X0 == false)
            {
                goto label_88;
            }
            
            val_74 = mem[X0];
            val_74 = X0;
            val_75 = null;
            val_76 = X0;
            if((X0 + 294) == 0)
            {
                goto label_92;
            }
            
            var val_73 = 0;
            val_77 = (X0 + 176) + 8;
            label_72:
            if(((X0 + 176 + 8) + -8) == val_75)
            {
                goto label_90;
            }
            
            val_73 = val_73 + 1;
            val_77 = val_77 + 16;
            if(val_73 < (X0 + 294))
            {
                goto label_72;
            }
            
            goto label_92;
            label_27:
            val_74 = val_74 + (((X0 + 176 + 8)) << 4);
            val_63 = val_74 + 304;
            label_29:
            System.Collections.IEnumerator val_19 = val_49.GetEnumerator();
            val_76 = val_19;
            if(val_19 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_61 = 1152921504683417600;
            val_50 = val_50 + 1;
            label_87:
            var val_75 = 0;
            val_75 = val_75 + 1;
            if(val_76.MoveNext() == false)
            {
                goto label_79;
            }
            
            var val_76 = 0;
            val_76 = val_76 + 1;
            object val_23 = val_76.Current;
            writer_is_private = val_51;
            goto label_87;
            label_79:
            val_51 = 0;
            if(X0 == false)
            {
                goto label_88;
            }
            
            val_74 = mem[X0];
            val_74 = X0;
            val_75 = null;
            val_76 = X0;
            if((X0 + 294) == 0)
            {
                goto label_92;
            }
            
            var val_77 = 0;
            val_77 = (X0 + 176) + 8;
            label_91:
            if(((X0 + 176 + 8) + -8) == val_75)
            {
                goto label_90;
            }
            
            val_77 = val_77 + 1;
            val_77 = val_77 + 16;
            if(val_77 < (X0 + 294))
            {
                goto label_91;
            }
            
            goto label_92;
            label_90:
            val_74 = val_74 + (((X0 + 176 + 8)) << 4);
            val_80 = val_74 + 304;
            label_92:
            val_76.Dispose();
            label_88:
            if(val_51 != 0)
            {
                    throw val_51 = val_58;
            }
            
            val_52.WriteArrayEnd();
            return;
            label_44:
            val_81 = null;
            val_49 = val_53.GetType();
            val_81 = null;
            val_61 = LitJson.JsonMapper.custom_exporters_table;
            if(val_61 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_78 = 0;
            val_78 = val_78 + 1;
            goto label_100;
            label_49:
            var val_79 = val_69;
            val_79 = val_79 + 9;
            val_80 = val_80 + val_79;
            val_68 = val_80 + 304;
            label_51:
            val_69 = public System.Collections.IDictionaryEnumerator System.Collections.IDictionary::GetEnumerator();
            val_70 = val_49;
            System.Collections.IDictionaryEnumerator val_25 = val_70.GetEnumerator();
            val_53 = val_25;
            if(val_25 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_61 = 1152921504683417600;
            val_60 = 1152921504681820160;
            val_50 = val_50 + 1;
            label_118:
            var val_81 = 0;
            val_81 = val_81 + 1;
            if(val_53.MoveNext() == false)
            {
                goto label_106;
            }
            
            var val_82 = 0;
            val_82 = val_82 + 1;
            val_85 = public System.Object System.Collections.IEnumerator::get_Current();
            if(val_53.Current == null)
            {
                    throw new NullReferenceException();
            }
            
            val_85 = null;
            if(null != null)
            {
                    val_55 = null;
                if(null != val_55)
            {
                    throw val_51;
            }
            
            }
            
            val_52.WritePropertyName(property_name:  null);
            writer_is_private = val_51;
            goto label_118;
            label_106:
            val_51 = 0;
            if(X0 == false)
            {
                goto label_119;
            }
            
            var val_85 = X0;
            val_53 = X0;
            if((X0 + 294) == 0)
            {
                goto label_123;
            }
            
            var val_83 = X0 + 176;
            var val_84 = 0;
            val_83 = val_83 + 8;
            label_122:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_121;
            }
            
            val_84 = val_84 + 1;
            val_83 = val_83 + 16;
            if(val_84 < (X0 + 294))
            {
                goto label_122;
            }
            
            goto label_123;
            label_121:
            val_85 = val_85 + (((X0 + 176 + 8)) << 4);
            val_86 = val_85 + 304;
            label_123:
            val_53.Dispose();
            label_119:
            if(val_51 != 0)
            {
                    throw val_51;
            }
            
            val_52.WriteObjectEnd();
            return;
            label_100:
            val_87 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            val_88 = null;
            if((val_61.ContainsKey(key:  null)) == false)
            {
                goto label_125;
            }
            
            val_89 = null;
            val_90 = LitJson.JsonMapper.custom_exporters_table;
            if(val_90 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_92 = null;
            var val_86 = 0;
            val_93 = 1152921504687288328;
            val_86 = val_86 + 1;
            goto label_144;
            label_125:
            val_94 = null;
            val_61 = LitJson.JsonMapper.base_exporters_table;
            if(val_61 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_87 = 0;
            val_87 = val_87 + 1;
            val_95 = 4;
            val_97 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            if((val_61.ContainsKey(key:  null)) == false)
            {
                goto label_140;
            }
            
            val_98 = null;
            val_98 = null;
            val_90 = LitJson.JsonMapper.base_exporters_table;
            if(val_90 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_92 = null;
            var val_88 = 0;
            val_93 = 1152921504687288328;
            val_88 = val_88 + 1;
            label_144:
            val_99 = 0;
            goto label_147;
            label_140:
            LitJson.JsonMapper.AddTypeProperties(type:  val_49);
            val_61 = LitJson.JsonMapper.type_properties;
            if(val_61 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_89 = 0;
            val_89 = val_89 + 1;
            val_101 = 0;
            goto label_156;
            label_147:
            TValue val_35 = val_90.Item[null];
            if(val_35 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_35.Invoke(obj:  val_53, writer:  val_52);
            return;
            label_156:
            if(val_52 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_49 = val_61.Item[null];
            val_52.WriteObjectStart();
            if(val_49 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_92 = val_49;
            if((val_37 + 294) == 0)
            {
                goto label_163;
            }
            
            var val_90 = val_37 + 176;
            var val_91 = 0;
            val_90 = val_90 + 8;
            label_162:
            if(((val_37 + 176 + 8) + -8) == null)
            {
                goto label_161;
            }
            
            val_91 = val_91 + 1;
            val_90 = val_90 + 16;
            if(val_91 < (val_37 + 294))
            {
                goto label_162;
            }
            
            goto label_163;
            label_161:
            val_92 = val_92 + (((val_37 + 176 + 8)) << 4);
            val_103 = val_92 + 304;
            label_163:
            val_49 = val_49.GetEnumerator();
            val_60 = 1152921504683417600;
            val_50 = val_50 + 1;
            label_189:
            var val_93 = 0;
            val_93 = val_93 + 1;
            if(val_49.MoveNext() == false)
            {
                goto label_169;
            }
            
            var val_94 = 0;
            val_94 = val_94 + 1;
            T val_42 = val_49.Current;
            val_61 = val_44;
            if(val_43 == false)
            {
                goto label_174;
            }
            
            if(val_61 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_52.WritePropertyName(property_name:  val_61);
            bool val_46 = val_51;
            goto label_189;
            label_174:
            if(val_61 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_61 & 1) == 0)
            {
                goto label_189;
            }
            
            val_52.WritePropertyName(property_name:  val_61);
            bool val_47 = val_51;
            goto label_189;
            label_169:
            val_51 = 0;
            if(val_49 != null)
            {
                    var val_95 = 0;
                val_95 = val_95 + 1;
                val_49.Dispose();
            }
            
            if(val_51 != 0)
            {
                    throw val_51;
            }
            
            val_52.WriteObjectEnd();
            return;
            label_3:
            LitJson.JsonException val_58 = null;
            val_58 = new LitJson.JsonException(message:  System.String.Format(format:  "Max allowed object depth reached while trying to export from type {0}", arg0:  val_53.GetType()));
            val_55 = 1152921513342074064;
            throw val_51;
            label_30:
            label_31:
            val_85 = ;
            throw new NullReferenceException();
            label_47:
            val_70 = val_53;
            val_69 = val_61;
            throw new NullReferenceException();
        }
        public static string ToJson(object obj)
        {
            var val_2;
            var val_3;
            var val_4;
            LitJson.JsonWriter val_5;
            val_2 = null;
            val_2 = null;
            bool val_1 = false;
            System.Threading.Monitor.Enter(obj:  LitJson.JsonMapper.static_writer_lock, lockTaken: ref  val_1);
            val_4 = null;
            val_4 = null;
            val_5 = LitJson.JsonMapper.static_writer;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_5.Reset();
            LitJson.JsonMapper.WriteValue(obj:  obj, writer:  LitJson.JsonMapper.static_writer, writer_is_private:  true, depth:  0);
            if(val_1 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  LitJson.JsonMapper.static_writer_lock);
            }
            
            if(0 == 0)
            {
                    return (string)LitJson.JsonMapper.static_writer;
            }
            
            val_5 = 0;
            val_3 = 0;
            throw val_5;
        }
        public static void ToJson(object obj, LitJson.JsonWriter writer)
        {
            LitJson.JsonMapper.WriteValue(obj:  obj, writer:  writer, writer_is_private:  false, depth:  0);
        }
        public static LitJson.JsonData ToObject(LitJson.JsonReader reader)
        {
            var val_3;
            LitJson.WrapperFactory val_5;
            val_3 = null;
            val_3 = null;
            val_5 = JsonMapper.<>c.<>9__30_0;
            if(val_5 == null)
            {
                    LitJson.WrapperFactory val_1 = null;
                val_5 = val_1;
                val_1 = new LitJson.WrapperFactory(object:  JsonMapper.<>c.__il2cppRuntimeField_static_fields, method:  LitJson.IJsonWrapper JsonMapper.<>c::<ToObject>b__30_0());
                JsonMapper.<>c.<>9__30_0 = val_5;
            }
            
            LitJson.IJsonWrapper val_2 = LitJson.JsonMapper.ToWrapper(factory:  val_1, reader:  reader);
            if(val_2 == null)
            {
                    return (LitJson.JsonData)val_2;
            }
            
            return (LitJson.JsonData)val_2;
        }
        public static LitJson.JsonData ToObject(System.IO.TextReader reader)
        {
            var val_4;
            LitJson.WrapperFactory val_6;
            val_4 = null;
            val_4 = null;
            val_6 = JsonMapper.<>c.<>9__31_0;
            if(val_6 == null)
            {
                    LitJson.WrapperFactory val_2 = null;
                val_6 = val_2;
                val_2 = new LitJson.WrapperFactory(object:  JsonMapper.<>c.__il2cppRuntimeField_static_fields, method:  LitJson.IJsonWrapper JsonMapper.<>c::<ToObject>b__31_0());
                JsonMapper.<>c.<>9__31_0 = val_6;
            }
            
            LitJson.IJsonWrapper val_3 = LitJson.JsonMapper.ToWrapper(factory:  val_2, reader:  new LitJson.JsonReader(reader:  reader, owned:  false));
            if(val_3 == null)
            {
                    return (LitJson.JsonData)val_3;
            }
            
            return (LitJson.JsonData)val_3;
        }
        public static LitJson.JsonData ToObject(string json)
        {
            var val_3;
            LitJson.WrapperFactory val_5;
            val_3 = null;
            val_3 = null;
            val_5 = JsonMapper.<>c.<>9__32_0;
            if(val_5 == null)
            {
                    LitJson.WrapperFactory val_1 = null;
                val_5 = val_1;
                val_1 = new LitJson.WrapperFactory(object:  JsonMapper.<>c.__il2cppRuntimeField_static_fields, method:  LitJson.IJsonWrapper JsonMapper.<>c::<ToObject>b__32_0());
                JsonMapper.<>c.<>9__32_0 = val_5;
            }
            
            LitJson.IJsonWrapper val_2 = LitJson.JsonMapper.ToWrapper(factory:  val_1, json:  json);
            if(val_2 == null)
            {
                    return (LitJson.JsonData)val_2;
            }
            
            return (LitJson.JsonData)val_2;
        }
        public static T ToObject<T>(LitJson.JsonReader reader)
        {
            var val_3;
            if((LitJson.JsonMapper.ReadValue(inst_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}), reader:  reader)) != null)
            {
                    if(X0 == true)
            {
                    return (object)val_3;
            }
            
            }
            
            val_3 = 0;
            return (object)val_3;
        }
        public static T ToObject<T>(System.IO.TextReader reader)
        {
            var val_4;
            if((LitJson.JsonMapper.ReadValue(inst_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}), reader:  new LitJson.JsonReader(reader:  reader))) != null)
            {
                    if(X0 == true)
            {
                    return (object)val_4;
            }
            
            }
            
            val_4 = 0;
            return (object)val_4;
        }
        public static T ToObject<T>(string json)
        {
            var val_4;
            if((LitJson.JsonMapper.ReadValue(inst_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}), reader:  new LitJson.JsonReader(json_text:  json))) != null)
            {
                    if(X0 == true)
            {
                    return (object)val_4;
            }
            
            }
            
            val_4 = 0;
            return (object)val_4;
        }
        public static LitJson.IJsonWrapper ToWrapper(LitJson.WrapperFactory factory, LitJson.JsonReader reader)
        {
            return LitJson.JsonMapper.ReadValue(factory:  factory, reader:  reader);
        }
        public static LitJson.IJsonWrapper ToWrapper(LitJson.WrapperFactory factory, string json)
        {
            return LitJson.JsonMapper.ReadValue(factory:  factory, reader:  new LitJson.JsonReader(json_text:  json));
        }
        public static void RegisterExporter<T>(LitJson.ExporterFunc<T> exporter)
        {
            var val_4;
            mem2[0] = exporter;
            LitJson.ExporterFunc val_1 = new LitJson.ExporterFunc(object:  __RuntimeMethodHiddenParam + 48, method:  __RuntimeMethodHiddenParam + 48 + 16);
            val_4 = null;
            val_4 = null;
            System.Type val_2 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 24});
            var val_4 = 0;
            val_4 = val_4 + 1;
            LitJson.JsonMapper.custom_exporters_table.set_Item(key:  null, value:  null);
        }
        public static void RegisterImporter<TJson, TValue>(LitJson.ImporterFunc<TJson, TValue> importer)
        {
            var val_4;
            mem2[0] = importer;
            val_4 = null;
            val_4 = null;
            LitJson.JsonMapper.RegisterImporter(table:  LitJson.JsonMapper.custom_importers_table, json_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 24}), value_type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48 + 32}), importer:  new LitJson.ImporterFunc(object:  __RuntimeMethodHiddenParam + 48, method:  __RuntimeMethodHiddenParam + 48 + 16));
        }
        public static void UnregisterExporters()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            LitJson.JsonMapper.custom_exporters_table.Clear();
        }
        public static void UnregisterImporters()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            LitJson.JsonMapper.custom_importers_table.Clear();
        }
        public JsonMapper()
        {
        
        }
    
    }

}
