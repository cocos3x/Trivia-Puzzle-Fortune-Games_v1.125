using UnityEngine;

namespace LitJson
{
    public class JsonData : IJsonWrapper, IList, ICollection, IEnumerable, IOrderedDictionary, IDictionary, IEquatable<LitJson.JsonData>
    {
        // Fields
        private System.Collections.Generic.IList<LitJson.JsonData> inst_array;
        private bool inst_boolean;
        private double inst_double;
        private int inst_int;
        private long inst_long;
        private System.Collections.Generic.IDictionary<string, LitJson.JsonData> inst_object;
        private string inst_string;
        private string json;
        private LitJson.JsonType type;
        private System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, LitJson.JsonData>> object_list;
        
        // Properties
        public int Count { get; }
        public bool IsArray { get; }
        public bool IsBoolean { get; }
        public bool IsDouble { get; }
        public bool IsInt { get; }
        public bool IsLong { get; }
        public bool IsObject { get; }
        public bool IsString { get; }
        private int System.Collections.ICollection.Count { get; }
        private bool System.Collections.ICollection.IsSynchronized { get; }
        private object System.Collections.ICollection.SyncRoot { get; }
        private bool System.Collections.IDictionary.IsFixedSize { get; }
        private bool System.Collections.IDictionary.IsReadOnly { get; }
        private System.Collections.ICollection System.Collections.IDictionary.Keys { get; }
        private System.Collections.ICollection System.Collections.IDictionary.Values { get; }
        private bool LitJson.IJsonWrapper.IsArray { get; }
        private bool LitJson.IJsonWrapper.IsBoolean { get; }
        private bool LitJson.IJsonWrapper.IsDouble { get; }
        private bool LitJson.IJsonWrapper.IsInt { get; }
        private bool LitJson.IJsonWrapper.IsLong { get; }
        private bool LitJson.IJsonWrapper.IsObject { get; }
        private bool LitJson.IJsonWrapper.IsString { get; }
        private bool System.Collections.IList.IsFixedSize { get; }
        private bool System.Collections.IList.IsReadOnly { get; }
        private object System.Collections.IDictionary.Item { get; set; }
        private object System.Collections.Specialized.IOrderedDictionary.Item { get; set; }
        private object System.Collections.IList.Item { get; set; }
        public LitJson.JsonData Item { get; set; }
        public LitJson.JsonData Item { get; set; }
        
        // Methods
        public int get_Count()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureCollection().Count;
        }
        public bool get_IsArray()
        {
            return (bool)(this.type == 2) ? 1 : 0;
        }
        public bool get_IsBoolean()
        {
            return (bool)(this.type == 7) ? 1 : 0;
        }
        public bool get_IsDouble()
        {
            return (bool)(this.type == 6) ? 1 : 0;
        }
        public bool get_IsInt()
        {
            return (bool)(this.type == 4) ? 1 : 0;
        }
        public bool get_IsLong()
        {
            return (bool)(this.type == 5) ? 1 : 0;
        }
        public bool get_IsObject()
        {
            return (bool)(this.type == 1) ? 1 : 0;
        }
        public bool get_IsString()
        {
            return (bool)(this.type == 3) ? 1 : 0;
        }
        private int System.Collections.ICollection.get_Count()
        {
            return this.Count;
        }
        private bool System.Collections.ICollection.get_IsSynchronized()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureCollection().IsSynchronized;
        }
        private object System.Collections.ICollection.get_SyncRoot()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureCollection().SyncRoot;
        }
        private bool System.Collections.IDictionary.get_IsFixedSize()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureDictionary().IsFixedSize;
        }
        private bool System.Collections.IDictionary.get_IsReadOnly()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureDictionary().IsReadOnly;
        }
        private System.Collections.ICollection System.Collections.IDictionary.get_Keys()
        {
            System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>> val_8;
            var val_9;
            var val_15;
            System.Collections.IDictionary val_1 = this.EnsureDictionary();
            System.Collections.Generic.List<System.String> val_2 = new System.Collections.Generic.List<System.String>();
            val_8 = this.object_list;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_9 = 0;
            val_8 = val_8.GetEnumerator();
            label_21:
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_9 = 0;
            if(val_8.MoveNext() == false)
            {
                goto label_11;
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_9 = 0;
            T val_8 = val_8.Current;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_14 = 0;
            val_14 = val_14 + 1;
            val_9 = 2;
            val_2.Add(item:  ???);
            goto label_21;
            label_11:
            if(val_8 != null)
            {
                    var val_15 = 0;
                val_15 = val_15 + 1;
                val_8.Dispose();
            }
            
            if(0 != 0)
            {
                    throw X21;
            }
            
            if(val_2 != null)
            {
                    if(X0 == true)
            {
                    return (System.Collections.ICollection)val_15;
            }
            
            }
            
            val_15 = 0;
            return (System.Collections.ICollection)val_15;
        }
        private System.Collections.ICollection System.Collections.IDictionary.get_Values()
        {
            System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>> val_8;
            var val_9;
            var val_15;
            System.Collections.IDictionary val_1 = this.EnsureDictionary();
            System.Collections.Generic.List<LitJson.JsonData> val_2 = new System.Collections.Generic.List<LitJson.JsonData>();
            val_8 = this.object_list;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_9 = 0;
            val_8 = val_8.GetEnumerator();
            label_21:
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_9 = 0;
            if(val_8.MoveNext() == false)
            {
                goto label_11;
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_9 = 0;
            T val_8 = val_8.Current;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_14 = 0;
            val_14 = val_14 + 1;
            val_9 = 2;
            val_2.Add(item:  ???);
            goto label_21;
            label_11:
            if(val_8 != null)
            {
                    var val_15 = 0;
                val_15 = val_15 + 1;
                val_8.Dispose();
            }
            
            if(0 != 0)
            {
                    throw X21;
            }
            
            if(val_2 != null)
            {
                    if(X0 == true)
            {
                    return (System.Collections.ICollection)val_15;
            }
            
            }
            
            val_15 = 0;
            return (System.Collections.ICollection)val_15;
        }
        private bool LitJson.IJsonWrapper.get_IsArray()
        {
            return (bool)(this.type == 2) ? 1 : 0;
        }
        private bool LitJson.IJsonWrapper.get_IsBoolean()
        {
            return (bool)(this.type == 7) ? 1 : 0;
        }
        private bool LitJson.IJsonWrapper.get_IsDouble()
        {
            return (bool)(this.type == 6) ? 1 : 0;
        }
        private bool LitJson.IJsonWrapper.get_IsInt()
        {
            return (bool)(this.type == 4) ? 1 : 0;
        }
        private bool LitJson.IJsonWrapper.get_IsLong()
        {
            return (bool)(this.type == 5) ? 1 : 0;
        }
        private bool LitJson.IJsonWrapper.get_IsObject()
        {
            return (bool)(this.type == 1) ? 1 : 0;
        }
        private bool LitJson.IJsonWrapper.get_IsString()
        {
            return (bool)(this.type == 3) ? 1 : 0;
        }
        private bool System.Collections.IList.get_IsFixedSize()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureList().IsFixedSize;
        }
        private bool System.Collections.IList.get_IsReadOnly()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureList().IsReadOnly;
        }
        private object System.Collections.IDictionary.get_Item(object key)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureDictionary().Item[key];
        }
        private void System.Collections.IDictionary.set_Item(object key, object value)
        {
            object val_3 = key;
            if((val_3 == null) || (null != null))
            {
                goto label_2;
            }
            
            if(null != null)
            {
                goto label_3;
            }
            
            this.set_Item(prop_name:  val_3 = key, value:  this.ToJsonData(obj:  value));
            return;
            label_2:
            System.ArgumentException val_2 = null;
            val_3 = val_2;
            val_2 = new System.ArgumentException(message:  "The key has to be a string");
            throw val_3;
            label_3:
        }
        private object System.Collections.Specialized.IOrderedDictionary.get_Item(int idx)
        {
            System.Collections.IDictionary val_1 = this.EnsureDictionary();
            var val_4 = 0;
            val_4 = val_4 + 1;
            T val_3 = this.object_list.Item[idx];
            return (object)idx;
        }
        private void System.Collections.Specialized.IOrderedDictionary.set_Item(int idx, object value)
        {
            var val_8 = 0;
            val_8 = val_8 + 1;
            var val_9 = 0;
            val_9 = val_9 + 1;
            this.inst_object.set_Item(key:  0, value:  0);
            System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData> val_6 = new System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>(key:  this.object_list.Item[idx], value:  this.EnsureDictionary().ToJsonData(obj:  value));
            var val_10 = 0;
            val_10 = val_10 + 1;
            this.object_list.set_Item(index:  idx, value:  val_6.Value);
        }
        private object System.Collections.IList.get_Item(int index)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureList().Item[index];
        }
        private void System.Collections.IList.set_Item(int index, object value)
        {
            this.set_Item(index:  index, value:  this.EnsureList().ToJsonData(obj:  value));
        }
        public LitJson.JsonData get_Item(string prop_name)
        {
            System.Collections.IDictionary val_1 = this.EnsureDictionary();
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.inst_object.Item[null];
        }
        public void set_Item(string prop_name, LitJson.JsonData value)
        {
            LitJson.JsonData val_10;
            var val_11;
            var val_13;
            System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>> val_14;
            System.Collections.IDictionary val_1 = this.EnsureDictionary();
            System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData> val_2;
            val_10 = value;
            val_11 = public System.Void System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>::.ctor(System.String key, LitJson.JsonData value);
            val_2 = new System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>(key:  prop_name, value:  val_10);
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_10 = 4;
            val_13 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::ContainsKey(TKey key);
            val_14 = this.object_list;
            if((this.inst_object.ContainsKey(key:  val_2.Value)) == false)
            {
                goto label_6;
            }
            
            var val_16 = 0;
            label_19:
            var val_14 = 0;
            val_14 = val_14 + 1;
            val_13 = 0;
            if(val_16 >= val_14.Count)
            {
                goto label_31;
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            val_13 = 0;
            if((System.String.op_Equality(a:  this.object_list.Item[0], b:  prop_name)) == true)
            {
                goto label_18;
            }
            
            val_16 = val_16 + 1;
            if(this.object_list != null)
            {
                goto label_19;
            }
            
            label_6:
            var val_17 = 0;
            val_17 = val_17 + 1;
            goto label_25;
            label_18:
            val_14 = this.object_list;
            var val_18 = 0;
            val_18 = val_18 + 1;
            goto label_30;
            label_25:
            val_11 = public System.Void System.Collections.Generic.ICollection<T>::Add(T item);
            val_14.Add(item:  val_2.Value);
            goto label_31;
            label_30:
            val_11 = 0;
            val_14.set_Item(index:  0, value:  val_2.Value);
            label_31:
            var val_19 = 0;
            val_19 = val_19 + 1;
            this.inst_object.set_Item(key:  val_2.Value, value:  0);
            this.json = 0;
        }
        public LitJson.JsonData get_Item(int index)
        {
            int val_9;
            var val_11;
            System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>> val_13;
            var val_14;
            val_9 = index;
            System.Collections.ICollection val_1 = this.EnsureCollection();
            if(this.type != 2)
            {
                goto label_1;
            }
            
            var val_4 = 0;
            val_11 = 1152921504687501320;
            val_4 = val_4 + 1;
            val_11 = 1152921504687501336;
            goto label_6;
            label_1:
            val_13 = this.object_list;
            var val_5 = 0;
            val_11 = 1152921504687501320;
            val_5 = val_5 + 1;
            val_14 = 0;
            goto label_11;
            label_6:
            val_14 = public T System.Collections.Generic.IList<T>::get_Item(int index);
            val_13 = ???;
            val_9 = ???;
            return this.inst_array.Item[val_9];
            label_11:
            T val_3 = val_13.Item[val_9];
            return (LitJson.JsonData)val_9;
        }
        public void set_Item(int index, LitJson.JsonData value)
        {
            int val_7 = index;
            System.Collections.ICollection val_1 = this.EnsureCollection();
            if(this.type != 2)
            {
                goto label_1;
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            goto label_6;
            label_1:
            var val_9 = 0;
            val_9 = val_9 + 1;
            goto label_11;
            label_6:
            this.inst_array.set_Item(index:  val_7 = index, value:  0);
            goto label_12;
            label_11:
            System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData> val_5 = new System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>(key:  this.object_list.Item[val_7], value:  value);
            var val_10 = 0;
            val_10 = val_10 + 1;
            this.object_list.set_Item(index:  val_7, value:  val_5.Value);
            val_7 = this.inst_object;
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_7.set_Item(key:  val_5.Value, value:  0);
            label_12:
            this.json = 0;
        }
        public JsonData()
        {
        
        }
        public JsonData(bool boolean)
        {
            this.type = 7;
            this.inst_boolean = boolean;
        }
        public JsonData(double number)
        {
            this.type = 6;
            this.inst_double = number;
        }
        public JsonData(int number)
        {
            this.type = 4;
            this.inst_int = number;
        }
        public JsonData(long number)
        {
            this.type = 5;
            this.inst_long = number;
        }
        public JsonData(object obj)
        {
            var val_2;
            if(obj == null)
            {
                goto label_6;
            }
            
            val_2 = null;
            if(null == val_2)
            {
                goto label_2;
            }
            
            if(null == null)
            {
                goto label_3;
            }
            
            if(null == null)
            {
                goto label_4;
            }
            
            if(null == null)
            {
                goto label_5;
            }
            
            if(null != null)
            {
                goto label_6;
            }
            
            this.type = 3;
            if(null != null)
            {
                goto label_15;
            }
            
            this.inst_string = obj;
            return;
            label_2:
            this.type = 7;
            this.inst_boolean = null;
            return;
            label_3:
            this.type = 6;
            this.inst_double = null;
            return;
            label_4:
            this.type = 4;
            this.inst_int = null;
            return;
            label_5:
            this.type = 5;
            this.inst_long = null;
            return;
            label_6:
            val_2 = 1152921513326522848;
            throw new System.ArgumentException(message:  "Unable to wrap the given object with JsonData");
            label_15:
        }
        public JsonData(string str)
        {
            this.type = 3;
            this.inst_string = str;
        }
        public static LitJson.JsonData op_Implicit(bool data)
        {
            .type = 7;
            .inst_boolean = data;
            return (LitJson.JsonData)new LitJson.JsonData();
        }
        public static LitJson.JsonData op_Implicit(double data)
        {
            .type = 6;
            .inst_double = data;
            return (LitJson.JsonData)new LitJson.JsonData();
        }
        public static LitJson.JsonData op_Implicit(int data)
        {
            .type = 4;
            .inst_int = data;
            return (LitJson.JsonData)new LitJson.JsonData();
        }
        public static LitJson.JsonData op_Implicit(long data)
        {
            .type = 5;
            .inst_long = data;
            return (LitJson.JsonData)new LitJson.JsonData();
        }
        public static LitJson.JsonData op_Implicit(string data)
        {
            .type = 3;
            .inst_string = data;
            return (LitJson.JsonData)new LitJson.JsonData();
        }
        public static bool op_Explicit(LitJson.JsonData data)
        {
            if(data.type != 7)
            {
                    throw new System.InvalidCastException(message:  "Instance of JsonData doesn\'t hold a double");
            }
            
            return (bool)data.inst_boolean;
        }
        public static double op_Explicit(LitJson.JsonData data)
        {
            if(data.type != 6)
            {
                    throw new System.InvalidCastException(message:  "Instance of JsonData doesn\'t hold a double");
            }
            
            return (double)data.inst_double;
        }
        public static int op_Explicit(LitJson.JsonData data)
        {
            if(data.type != 4)
            {
                    throw new System.InvalidCastException(message:  "Instance of JsonData doesn\'t hold an int");
            }
            
            return (int)data.inst_int;
        }
        public static long op_Explicit(LitJson.JsonData data)
        {
            if(data.type != 5)
            {
                    throw new System.InvalidCastException(message:  "Instance of JsonData doesn\'t hold an int");
            }
            
            return (long)data.inst_long;
        }
        public static string op_Explicit(LitJson.JsonData data)
        {
            if(data.type != 3)
            {
                    throw new System.InvalidCastException(message:  "Instance of JsonData doesn\'t hold a string");
            }
            
            return (string)data.inst_string;
        }
        private void System.Collections.ICollection.CopyTo(System.Array array, int index)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            this.EnsureCollection().CopyTo(array:  array, index:  index);
        }
        private void System.Collections.IDictionary.Add(object key, object value)
        {
            LitJson.JsonData val_1 = this.ToJsonData(obj:  value);
            var val_6 = 0;
            val_6 = val_6 + 1;
            this.EnsureDictionary().Add(key:  key, value:  val_1);
            if(key != null)
            {
                    if(null != null)
            {
                goto label_7;
            }
            
            }
            
            System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData> val_4 = new System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>(key:  key, value:  val_1);
            var val_7 = 0;
            val_7 = val_7 + 1;
            this.object_list.Add(item:  val_4.Value);
            this.json = 0;
            return;
            label_7:
        }
        private void System.Collections.IDictionary.Clear()
        {
            var val_4 = 0;
            val_4 = val_4 + 1;
            this.EnsureDictionary().Clear();
            var val_5 = 0;
            val_5 = val_5 + 1;
            this.object_list.Clear();
            this.json = 0;
        }
        private bool System.Collections.IDictionary.Contains(object key)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureDictionary().Contains(key:  key);
        }
        private System.Collections.IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator()
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            return this.GetEnumerator();
        }
        private void System.Collections.IDictionary.Remove(object key)
        {
            var val_8;
            int val_9;
            var val_12;
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_8 = public System.Void System.Collections.IDictionary::Remove(object key);
            this.EnsureDictionary().Remove(key:  key);
            val_9 = 0;
            label_20:
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_8 = 0;
            if(val_9 >= this.object_list.Count)
            {
                goto label_11;
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_8 = 0;
            if(key != null)
            {
                    if(null != null)
            {
                goto label_18;
            }
            
            }
            
            val_12 = 0;
            if((System.String.op_Equality(a:  this.object_list.Item[0], b:  key)) == true)
            {
                goto label_19;
            }
            
            val_9 = val_9 + 1;
            if(this.object_list != null)
            {
                goto label_20;
            }
            
            throw new NullReferenceException();
            label_19:
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_12 = 4;
            this.object_list.RemoveAt(index:  val_9);
            label_11:
            this.json = 0;
            return;
            label_18:
        }
        private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureCollection().GetEnumerator();
        }
        private bool LitJson.IJsonWrapper.GetBoolean()
        {
            if(this.type != 7)
            {
                    throw new System.InvalidOperationException(message:  "JsonData instance doesn\'t hold a boolean");
            }
            
            return (bool)this.inst_boolean;
        }
        private double LitJson.IJsonWrapper.GetDouble()
        {
            if(this.type != 6)
            {
                    throw new System.InvalidOperationException(message:  "JsonData instance doesn\'t hold a double");
            }
            
            return (double)this.inst_double;
        }
        private int LitJson.IJsonWrapper.GetInt()
        {
            if(this.type != 4)
            {
                    throw new System.InvalidOperationException(message:  "JsonData instance doesn\'t hold an int");
            }
            
            return (int)this.inst_int;
        }
        private long LitJson.IJsonWrapper.GetLong()
        {
            if(this.type != 5)
            {
                    throw new System.InvalidOperationException(message:  "JsonData instance doesn\'t hold a long");
            }
            
            return (long)this.inst_long;
        }
        private string LitJson.IJsonWrapper.GetString()
        {
            if(this.type != 3)
            {
                    throw new System.InvalidOperationException(message:  "JsonData instance doesn\'t hold a string");
            }
            
            return (string)this.inst_string;
        }
        private void LitJson.IJsonWrapper.SetBoolean(bool val)
        {
            this.type = 7;
            this.inst_boolean = val;
            this.json = 0;
        }
        private void LitJson.IJsonWrapper.SetDouble(double val)
        {
            this.inst_double = val;
            this.type = 6;
            this.json = 0;
        }
        private void LitJson.IJsonWrapper.SetInt(int val)
        {
            this.inst_int = val;
            this.type = 4;
            this.json = 0;
        }
        private void LitJson.IJsonWrapper.SetLong(long val)
        {
            this.inst_long = val;
            this.type = 5;
            this.json = 0;
        }
        private void LitJson.IJsonWrapper.SetString(string val)
        {
            this.type = 3;
            this.inst_string = val;
            this.json = 0;
        }
        private string LitJson.IJsonWrapper.ToJson()
        {
            return this.ToJson();
        }
        private void LitJson.IJsonWrapper.ToJson(LitJson.JsonWriter writer)
        {
            this.ToJson(writer:  writer);
        }
        private int System.Collections.IList.Add(object value)
        {
            return this.Add(value:  value);
        }
        private void System.Collections.IList.Clear()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            this.EnsureList().Clear();
            this.json = 0;
        }
        private bool System.Collections.IList.Contains(object value)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureList().Contains(value:  value);
        }
        private int System.Collections.IList.IndexOf(object value)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this.EnsureList().IndexOf(value:  value);
        }
        private void System.Collections.IList.Insert(int index, object value)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            this.EnsureList().Insert(index:  index, value:  value);
            this.json = 0;
        }
        private void System.Collections.IList.Remove(object value)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            this.EnsureList().Remove(value:  value);
            this.json = 0;
        }
        private void System.Collections.IList.RemoveAt(int index)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            this.EnsureList().RemoveAt(index:  index);
            this.json = 0;
        }
        private System.Collections.IDictionaryEnumerator System.Collections.Specialized.IOrderedDictionary.GetEnumerator()
        {
            System.Collections.IDictionary val_1 = this.EnsureDictionary();
            var val_5 = 0;
            val_5 = val_5 + 1;
            return (System.Collections.IDictionaryEnumerator)new LitJson.OrderedDictionaryEnumerator(enumerator:  this.object_list.GetEnumerator());
        }
        private void System.Collections.Specialized.IOrderedDictionary.Insert(int idx, object key, object value)
        {
            if(key != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            LitJson.JsonData val_1 = this.ToJsonData(obj:  value);
            this.set_Item(prop_name:  key, value:  val_1);
            System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData> val_2 = new System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>(key:  key, value:  val_1);
            var val_4 = 0;
            val_4 = val_4 + 1;
            this.object_list.Insert(index:  idx, item:  val_2.Value);
            return;
            label_2:
        }
        private void System.Collections.Specialized.IOrderedDictionary.RemoveAt(int idx)
        {
            var val_6;
            var val_8;
            System.Collections.IDictionary val_1 = this.EnsureDictionary();
            var val_7 = 0;
            val_7 = val_7 + 1;
            val_6 = public T System.Collections.Generic.IList<T>::get_Item(int index);
            T val_3 = this.object_list.Item[idx];
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_6 = 6;
            val_8 = public System.Boolean System.Collections.Generic.IDictionary<TKey, TValue>::Remove(TKey key);
            bool val_5 = this.inst_object.Remove(key:  ???);
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_8 = 4;
            this.object_list.RemoveAt(index:  idx);
        }
        private System.Collections.ICollection EnsureCollection()
        {
            var val_2;
            System.Collections.Generic.IList<LitJson.JsonData> val_3;
            var val_4;
            val_2 = this;
            if(this.type == 1)
            {
                goto label_1;
            }
            
            if(this.type != 2)
            {
                    throw new System.InvalidOperationException(message:  "The JsonData instance has to be initialized first");
            }
            
            val_3 = this.inst_array;
            if(val_3 == null)
            {
                goto label_3;
            }
            
            label_5:
            if(X0 == true)
            {
                    return (System.Collections.ICollection)val_4;
            }
            
            label_1:
            if(val_3 != null)
            {
                goto label_5;
            }
            
            label_3:
            val_4 = 0;
            return (System.Collections.ICollection)val_4;
        }
        private System.Collections.IDictionary EnsureDictionary()
        {
            System.Collections.Generic.IDictionary<System.String, LitJson.JsonData> val_4;
            var val_5;
            val_4 = this;
            if(this.type == 0)
            {
                goto label_1;
            }
            
            if(this.type != 1)
            {
                    throw new System.InvalidOperationException(message:  "Instance of JsonData is not a dictionary");
            }
            
            val_4 = this.inst_object;
            if(val_4 == null)
            {
                goto label_5;
            }
            
            if(X0 == true)
            {
                    return (System.Collections.IDictionary)val_5;
            }
            
            label_1:
            mem2[0] = 1;
            System.Collections.Generic.Dictionary<System.String, LitJson.JsonData> val_1 = new System.Collections.Generic.Dictionary<System.String, LitJson.JsonData>();
            mem2[0] = val_1;
            mem2[0] = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String, LitJson.JsonData>>();
            if(val_1 != null)
            {
                    val_4 = null;
                if(X0 == true)
            {
                    return (System.Collections.IDictionary)val_5;
            }
            
            }
            
            label_5:
            val_5 = 0;
            return (System.Collections.IDictionary)val_5;
        }
        private System.Collections.IList EnsureList()
        {
            System.Collections.Generic.IList<LitJson.JsonData> val_3;
            var val_4;
            val_3 = this;
            if(this.type == 0)
            {
                goto label_1;
            }
            
            if(this.type != 2)
            {
                    throw new System.InvalidOperationException(message:  "Instance of JsonData is not a list");
            }
            
            val_3 = this.inst_array;
            if(val_3 == null)
            {
                goto label_5;
            }
            
            if(X0 == true)
            {
                    return (System.Collections.IList)val_4;
            }
            
            label_1:
            mem2[0] = 2;
            System.Collections.Generic.List<LitJson.JsonData> val_1 = new System.Collections.Generic.List<LitJson.JsonData>();
            mem2[0] = val_1;
            if(val_1 != null)
            {
                    val_3 = null;
                if(X0 == true)
            {
                    return (System.Collections.IList)val_4;
            }
            
            }
            
            label_5:
            val_4 = 0;
            return (System.Collections.IList)val_4;
        }
        private LitJson.JsonData ToJsonData(object obj)
        {
            var val_2;
            if(obj != null)
            {
                    LitJson.JsonData val_1 = null;
                val_2 = val_1;
                val_1 = new LitJson.JsonData(obj:  obj);
                return (LitJson.JsonData);
            }
            
            val_2 = 0;
            return (LitJson.JsonData);
        }
        private static void WriteJson(LitJson.IJsonWrapper obj, LitJson.JsonWriter writer)
        {
            var val_23;
            string val_25;
            var val_28;
            var val_29;
            var val_41;
            var val_42;
            var val_43;
            var val_46;
            var val_49;
            if(obj == null)
            {
                goto label_1;
            }
            
            val_23 = 1152921504870051840;
            var val_38 = 0;
            val_38 = val_38 + 1;
            goto label_5;
            label_1:
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            val_25 = 0;
            goto label_7;
            label_5:
            if(obj.IsString == false)
            {
                goto label_8;
            }
            
            var val_39 = 0;
            val_39 = val_39 + 1;
            goto label_12;
            label_8:
            var val_40 = 0;
            val_40 = val_40 + 1;
            goto label_16;
            label_12:
            val_28 = public System.String LitJson.IJsonWrapper::GetString();
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            val_25 = obj.GetString();
            label_7:
            writer.Write(str:  val_25);
            return;
            label_16:
            if(obj.IsBoolean == false)
            {
                goto label_18;
            }
            
            var val_41 = 0;
            val_41 = val_41 + 1;
            goto label_22;
            label_18:
            var val_42 = 0;
            val_42 = val_42 + 1;
            goto label_26;
            label_22:
            val_28 = public System.Boolean LitJson.IJsonWrapper::GetBoolean();
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            writer.Write(boolean:  obj.GetBoolean());
            return;
            label_26:
            if(obj.IsDouble == false)
            {
                goto label_28;
            }
            
            var val_43 = 0;
            val_43 = val_43 + 1;
            goto label_32;
            label_28:
            var val_44 = 0;
            val_44 = val_44 + 1;
            goto label_36;
            label_32:
            val_28 = public System.Double LitJson.IJsonWrapper::GetDouble();
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            writer.Write(number:  obj.GetDouble());
            return;
            label_36:
            if(obj.IsInt == false)
            {
                goto label_38;
            }
            
            var val_45 = 0;
            val_45 = val_45 + 1;
            goto label_42;
            label_38:
            var val_46 = 0;
            val_46 = val_46 + 1;
            goto label_46;
            label_42:
            val_28 = public System.Int32 LitJson.IJsonWrapper::GetInt();
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            writer.Write(number:  obj.GetInt());
            return;
            label_46:
            if(obj.IsLong == false)
            {
                goto label_48;
            }
            
            var val_47 = 0;
            val_47 = val_47 + 1;
            goto label_52;
            label_48:
            var val_48 = 0;
            val_48 = val_48 + 1;
            goto label_56;
            label_52:
            val_28 = public System.Int64 LitJson.IJsonWrapper::GetLong();
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            writer.Write(number:  obj.GetLong());
            return;
            label_56:
            val_28 = public System.Boolean LitJson.IJsonWrapper::get_IsArray();
            if(obj.IsArray == false)
            {
                goto label_58;
            }
            
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            writer.WriteArrayStart();
            var val_49 = 0;
            val_49 = val_49 + 1;
            goto label_63;
            label_58:
            var val_50 = 0;
            val_50 = val_50 + 1;
            val_28 = public System.Boolean LitJson.IJsonWrapper::get_IsObject();
            if(obj.IsObject == false)
            {
                    return;
            }
            
            if(writer == null)
            {
                    throw new NullReferenceException();
            }
            
            writer.WriteObjectStart();
            var val_51 = 0;
            val_51 = val_51 + 1;
            goto label_73;
            label_63:
            val_41 = public System.Collections.IEnumerator System.Collections.IEnumerable::GetEnumerator();
            val_42 = obj;
            System.Collections.IEnumerator val_27 = val_42.GetEnumerator();
            if(val_27 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_43 = 1152921504683417600;
            label_88:
            var val_52 = 0;
            val_52 = val_52 + 1;
            if(val_27.MoveNext() == false)
            {
                goto label_79;
            }
            
            var val_53 = 0;
            val_53 = val_53 + 1;
            if(val_27.Current == null)
            {
                goto label_88;
            }
            
            val_28 = null;
            val_29 = (System.Object.__il2cppRuntimeField_typeHierarchy + (LitJson.JsonData.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8;
            if(val_29 != val_28)
            {
                    throw new NullReferenceException();
            }
            
            goto label_88;
            label_79:
            val_43 = 0;
            if(X0 == false)
            {
                goto label_89;
            }
            
            var val_56 = X0;
            if((X0 + 294) == 0)
            {
                goto label_93;
            }
            
            var val_54 = X0 + 176;
            var val_55 = 0;
            val_54 = val_54 + 8;
            label_92:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_91;
            }
            
            val_55 = val_55 + 1;
            val_54 = val_54 + 16;
            if(val_55 < (X0 + 294))
            {
                goto label_92;
            }
            
            goto label_93;
            label_91:
            val_56 = val_56 + (((X0 + 176 + 8)) << 4);
            val_46 = val_56 + 304;
            label_93:
            X0.Dispose();
            label_89:
            if(val_43 != 0)
            {
                goto label_119;
            }
            
            writer.WriteArrayEnd();
            return;
            label_73:
            System.Collections.IDictionaryEnumerator val_33 = obj.GetEnumerator();
            label_113:
            var val_57 = 0;
            val_57 = val_57 + 1;
            if(val_33.MoveNext() == false)
            {
                goto label_100;
            }
            
            var val_58 = 0;
            val_58 = val_58 + 1;
            val_28 = public System.Object System.Collections.IEnumerator::get_Current();
            if(val_33.Current == null)
            {
                    throw new NullReferenceException();
            }
            
            val_28 = null;
            if(null == null)
            {
                goto label_107;
            }
            
            val_29 = null;
            if(null != val_29)
            {
                goto label_108;
            }
            
            label_107:
            writer.WritePropertyName(property_name:  null);
            if(null == 0)
            {
                goto label_113;
            }
            
            val_29 = null;
            val_28 = null;
            val_29 = (LitJson.IJsonWrapper.__il2cppRuntimeField_typeHierarchy + (LitJson.JsonData.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8;
            if(val_29 != val_28)
            {
                    throw new NullReferenceException();
            }
            
            goto label_113;
            label_100:
            val_43 = 0;
            if(X0 == false)
            {
                goto label_114;
            }
            
            var val_61 = X0;
            if((X0 + 294) == 0)
            {
                goto label_118;
            }
            
            var val_59 = X0 + 176;
            var val_60 = 0;
            val_59 = val_59 + 8;
            label_117:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_116;
            }
            
            val_60 = val_60 + 1;
            val_59 = val_59 + 16;
            if(val_60 < (X0 + 294))
            {
                goto label_117;
            }
            
            goto label_118;
            label_116:
            val_61 = val_61 + (((X0 + 176 + 8)) << 4);
            val_49 = val_61 + 304;
            label_118:
            X0.Dispose();
            label_114:
            if(val_43 != 0)
            {
                goto label_119;
            }
            
            writer.WriteObjectEnd();
            return;
            label_108:
            label_119:
            val_42 = 41979904;
            val_41 = 0;
            throw val_42;
        }
        public int Add(object value)
        {
            this.json = 0;
            var val_4 = 0;
            val_4 = val_4 + 1;
            return this.EnsureList().Add(value:  this.ToJsonData(obj:  value));
        }
        public void Clear()
        {
            var val_3;
            var val_4;
            if(this.type != 2)
            {
                    if(this.type != 1)
            {
                    return;
            }
            
                val_3 = null;
                var val_2 = 0;
                val_2 = val_2 + 1;
                val_4 = 6;
            }
            else
            {
                    val_3 = null;
                var val_3 = 0;
                val_3 = val_3 + 1;
                val_4 = 4;
            }
            
            this.Clear();
        }
        public bool Equals(LitJson.JsonData x)
        {
            var val_1;
            if(((x != null) && (x.type == this.type)) && (x.type <= 7))
            {
                    var val_1 = 32562836 + (x.type) << 2;
                val_1 = val_1 + 32562836;
            }
            else
            {
                    val_1 = 0;
                return (bool)val_1;
            }
        
        }
        public LitJson.JsonType GetJsonType()
        {
            return (LitJson.JsonType)this.type;
        }
        public void SetJsonType(LitJson.JsonType type)
        {
            if(this.type == type)
            {
                    return;
            }
            
            if((type - 1) <= 6)
            {
                    var val_5 = 32562868 + ((type - 1)) << 2;
                val_5 = val_5 + 32562868;
            }
            else
            {
                    this.type = type;
            }
        
        }
        public string ToJson()
        {
            string val_3 = this.json;
            if(val_3 != null)
            {
                    return val_3;
            }
            
            System.IO.StringWriter val_1 = new System.IO.StringWriter();
            .validate = false;
            LitJson.JsonData.WriteJson(obj:  this, writer:  new LitJson.JsonWriter(writer:  val_1));
            val_3 = val_1;
            this.json = val_3;
            return val_3;
        }
        public void ToJson(LitJson.JsonWriter writer)
        {
            writer.validate = false;
            LitJson.JsonData.WriteJson(obj:  this, writer:  writer);
            writer.validate = writer.validate;
        }
        public override string ToString()
        {
            var val_1;
            LitJson.JsonType val_1 = this.type;
            val_1 = val_1 - 1;
            if(val_1 <= 6)
            {
                    var val_2 = 32562896 + ((this.type - 1)) << 2;
                val_2 = val_2 + 32562896;
            }
            else
            {
                    val_1 = "Uninitialized JsonData";
                return (string);
            }
        
        }
    
    }

}
