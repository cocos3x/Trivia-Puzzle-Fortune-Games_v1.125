using UnityEngine;

namespace SimpleJSON
{
    public class JSONClass : JSONNode, IEnumerable
    {
        // Fields
        private System.Collections.Generic.Dictionary<string, SimpleJSON.JSONNode> m_Dict;
        
        // Properties
        public override SimpleJSON.JSONNode Item { get; set; }
        public override SimpleJSON.JSONNode Item { get; set; }
        public override int Count { get; }
        public override System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode> Childs { get; }
        
        // Methods
        public override SimpleJSON.JSONNode get_Item(string aKey)
        {
            if((this.m_Dict.ContainsKey(key:  aKey)) != false)
            {
                    return this.m_Dict.Item[aKey];
            }
            
            .m_Node = this;
            .m_Key = aKey;
            return (SimpleJSON.JSONNode)new SimpleJSON.JSONLazyCreator();
        }
        public override void set_Item(string aKey, SimpleJSON.JSONNode value)
        {
            if((this.m_Dict.ContainsKey(key:  aKey)) != false)
            {
                    this.m_Dict.set_Item(key:  aKey, value:  value);
                return;
            }
            
            this.m_Dict.Add(key:  aKey, value:  value);
        }
        public override SimpleJSON.JSONNode get_Item(int aIndex)
        {
            var val_3;
            if((aIndex & 2147483648) == 0)
            {
                    if(this.m_Dict.Count > aIndex)
            {
                    System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode> val_2 = System.Linq.Enumerable.ElementAt<System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode>>(source:  this.m_Dict, index:  aIndex);
                val_3 = aIndex;
                return (SimpleJSON.JSONNode)val_3;
            }
            
            }
            
            val_3 = 0;
            return (SimpleJSON.JSONNode)val_3;
        }
        public override void set_Item(int aIndex, SimpleJSON.JSONNode value)
        {
            if((aIndex & 2147483648) != 0)
            {
                    return;
            }
            
            if(this.m_Dict.Count <= aIndex)
            {
                    return;
            }
            
            System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode> val_2 = System.Linq.Enumerable.ElementAt<System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode>>(source:  this.m_Dict, index:  aIndex);
            this.m_Dict.set_Item(key:  val_2.Value, value:  value);
        }
        public override int get_Count()
        {
            return this.m_Dict.Count;
        }
        public override void Add(string aKey, SimpleJSON.JSONNode aItem)
        {
            string val_5;
            var val_6;
            if((System.String.IsNullOrEmpty(value:  aKey)) != false)
            {
                    System.Guid val_2 = System.Guid.NewGuid();
                val_5 = val_2._a.ToString();
                val_6 = public System.Void System.Collections.Generic.Dictionary<System.String, SimpleJSON.JSONNode>::Add(System.String key, SimpleJSON.JSONNode value);
            }
            else
            {
                    if((this.m_Dict.ContainsKey(key:  aKey)) != false)
            {
                    this.m_Dict.set_Item(key:  aKey, value:  aItem);
                return;
            }
            
                val_5 = aKey;
                val_6 = public System.Void System.Collections.Generic.Dictionary<System.String, SimpleJSON.JSONNode>::Add(System.String key, SimpleJSON.JSONNode value);
            }
            
            this.m_Dict.Add(key:  val_5, value:  aItem);
        }
        public override SimpleJSON.JSONNode Remove(string aKey)
        {
            var val_4;
            if((this.m_Dict.ContainsKey(key:  aKey)) != false)
            {
                    val_4 = this.m_Dict.Item[aKey];
                bool val_3 = this.m_Dict.Remove(key:  aKey);
                return (SimpleJSON.JSONNode)val_4;
            }
            
            val_4 = 0;
            return (SimpleJSON.JSONNode)val_4;
        }
        public override SimpleJSON.JSONNode Remove(int aIndex)
        {
            var val_4;
            if((aIndex & 2147483648) == 0)
            {
                    if(this.m_Dict.Count > aIndex)
            {
                    System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode> val_2 = System.Linq.Enumerable.ElementAt<System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode>>(source:  this.m_Dict, index:  aIndex);
                val_4 = aIndex;
                bool val_3 = this.m_Dict.Remove(key:  val_2.Value);
                return (SimpleJSON.JSONNode)val_4;
            }
            
            }
            
            val_4 = 0;
            return (SimpleJSON.JSONNode)val_4;
        }
        public override SimpleJSON.JSONNode Remove(SimpleJSON.JSONNode aNode)
        {
            JSONClass.<>c__DisplayClass12_0 val_1 = new JSONClass.<>c__DisplayClass12_0();
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            .aNode = aNode;
            System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode> val_4 = System.Linq.Enumerable.First<System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode>>(source:  System.Linq.Enumerable.Where<System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode>>(source:  this.m_Dict, predicate:  new System.Func<System.Collections.Generic.KeyValuePair<System.String, SimpleJSON.JSONNode>, System.Boolean>(object:  val_1, method:  System.Boolean JSONClass.<>c__DisplayClass12_0::<Remove>b__0(System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode> k))));
            bool val_5 = this.m_Dict.Remove(key:  val_4.Value);
            return (SimpleJSON.JSONNode)(JSONClass.<>c__DisplayClass12_0)[1152921520096314624].aNode;
        }
        public override System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode> get_Childs()
        {
            .<>1__state = -2;
            .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
            .<>4__this = this;
            return (System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode>)new JSONClass.<get_Childs>d__14();
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new JSONClass.<GetEnumerator>d__15();
        }
        public override string ToString()
        {
            string val_3;
            var val_4;
            string val_11;
            string val_12;
            var val_13;
            int val_14;
            int val_15;
            Dictionary.Enumerator<TKey, TValue> val_1 = this.m_Dict.GetEnumerator();
            label_23:
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_12 = "{";
            val_13 = 5;
            string[] val_7 = new string[5];
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = val_7.Length;
            if(val_14 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_7[0] = ;
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_14 = val_7.Length;
            val_7[1] = "\"";
            string val_8 = SimpleJSON.JSONNode.Escape(aText:  val_3);
            if(val_8 != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_15 = val_7.Length;
            if(val_15 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_7[2] = val_8;
            val_11 = "\":";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_15 = val_7.Length;
            if(val_15 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_7[3] = "\":";
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_11 = val_3;
            if(val_11 != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            if(val_7.Length <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_7[4] = val_11;
            string val_9 = +val_7;
            goto label_23;
            label_2:
            val_4.Dispose();
            return (string)"{" + "}";
        }
        public override string ToString(string aPrefix)
        {
            string val_3;
            var val_4;
            string val_13;
            string val_14;
            int val_15;
            int val_16;
            val_13 = "{ ";
            Dictionary.Enumerator<TKey, TValue> val_1 = this.m_Dict.GetEnumerator();
            label_22:
            if(val_4.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_13 = val_13 + ", ";
            string[] val_8 = new string[5];
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_15 = val_8.Length;
            if(val_15 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[0] = val_13 + "\n" + aPrefix + "   ";
            val_14 = "\"";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_15 = val_8.Length;
            if(val_15 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[1] = "\"";
            string val_9 = SimpleJSON.JSONNode.Escape(aText:  val_3);
            if(val_9 != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_16 = val_8.Length;
            if(val_16 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[2] = val_9;
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_16 = val_8.Length;
            val_8[3] = "\" : ";
            string val_10 = aPrefix + "   ";
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_14 = val_3;
            if(val_14 != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            if(val_8.Length <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_8[4] = val_14;
            string val_11 = +val_8;
            goto label_22;
            label_2:
            val_4.Dispose();
            return (string)val_13 + "\n" + aPrefix + "}";
        }
        public override void Serialize(System.IO.BinaryWriter aWriter)
        {
            string val_6;
            System.Collections.Generic.Dictionary<System.String, SimpleJSON.JSONNode> val_7;
            int val_1 = this.m_Dict.Count;
            Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = this.m_Dict.Keys.GetEnumerator();
            label_8:
            if(0.MoveNext() == false)
            {
                goto label_5;
            }
            
            val_6 = 0;
            val_7 = this.m_Dict;
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_6 = 0;
            if(val_7.Item[val_6] == null)
            {
                    throw new NullReferenceException();
            }
            
            goto label_8;
            label_5:
            0.Dispose();
        }
        public JSONClass()
        {
            this.m_Dict = new System.Collections.Generic.Dictionary<System.String, SimpleJSON.JSONNode>();
            this = new System.Object();
        }
    
    }

}
