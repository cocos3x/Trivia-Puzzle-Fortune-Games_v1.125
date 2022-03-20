using UnityEngine;

namespace com.adjust.sdk
{
    public class JSONArray : JSONNode, IEnumerable
    {
        // Fields
        private System.Collections.Generic.List<com.adjust.sdk.JSONNode> m_List;
        
        // Properties
        public override com.adjust.sdk.JSONNode Item { get; set; }
        public override com.adjust.sdk.JSONNode Item { get; set; }
        public override int Count { get; }
        public override System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode> Childs { get; }
        
        // Methods
        public override com.adjust.sdk.JSONNode get_Item(int aIndex)
        {
            var val_2;
            bool val_2 = true;
            if(((aIndex & 2147483648) == 0) && (val_2 > aIndex))
            {
                    if(val_2 <= aIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_2 = val_2 + (aIndex << 3);
                val_2 = mem[(true + (aIndex) << 3) + 32];
                val_2 = (true + (aIndex) << 3) + 32;
                return (com.adjust.sdk.JSONNode)val_2;
            }
            
            com.adjust.sdk.JSONLazyCreator val_1 = null;
            val_2 = val_1;
            val_1 = new com.adjust.sdk.JSONLazyCreator();
            .m_Node = this;
            .m_Key = 0;
            return (com.adjust.sdk.JSONNode)val_2;
        }
        public override void set_Item(int aIndex, com.adjust.sdk.JSONNode value)
        {
            if((aIndex & 2147483648) != 0)
            {
                goto label_1;
            }
            
            if(true <= aIndex)
            {
                goto label_3;
            }
            
            this.m_List.set_Item(index:  aIndex, value:  value);
            return;
            label_1:
            label_3:
            this.m_List.Add(item:  value);
        }
        public override com.adjust.sdk.JSONNode get_Item(string aKey)
        {
            .m_Node = this;
            .m_Key = 0;
            return (com.adjust.sdk.JSONNode)new com.adjust.sdk.JSONLazyCreator();
        }
        public override void set_Item(string aKey, com.adjust.sdk.JSONNode value)
        {
            this.m_List.Add(item:  value);
        }
        public override int get_Count()
        {
            return 15136;
        }
        public override void Add(string aKey, com.adjust.sdk.JSONNode aItem)
        {
            this.m_List.Add(item:  aItem);
        }
        public override com.adjust.sdk.JSONNode Remove(int aIndex)
        {
            var val_1;
            bool val_1 = true;
            if(((aIndex & 2147483648) == 0) && (val_1 > aIndex))
            {
                    if(val_1 <= aIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + (aIndex << 3);
                val_1 = mem[(true + (aIndex) << 3) + 32];
                val_1 = (true + (aIndex) << 3) + 32;
                this.m_List.RemoveAt(index:  aIndex);
                return (com.adjust.sdk.JSONNode)val_1;
            }
            
            val_1 = 0;
            return (com.adjust.sdk.JSONNode)val_1;
        }
        public override com.adjust.sdk.JSONNode Remove(com.adjust.sdk.JSONNode aNode)
        {
            bool val_1 = this.m_List.Remove(item:  aNode);
            return (com.adjust.sdk.JSONNode)aNode;
        }
        public override System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode> get_Childs()
        {
            .<>1__state = -2;
            .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
            .<>4__this = this;
            return (System.Collections.Generic.IEnumerable<com.adjust.sdk.JSONNode>)new JSONArray.<get_Childs>d__13();
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new JSONArray.<GetEnumerator>d__14();
        }
        public override string ToString()
        {
            string val_6;
            string val_7;
            List.Enumerator<T> val_1 = this.m_List.GetEnumerator();
            label_8:
            val_7 = public System.Boolean List.Enumerator<com.adjust.sdk.JSONNode>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_6 = "[ ";
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_4 =  + 0;
            goto label_8;
            label_2:
            0.Dispose();
            return (string)"[ " + " ]";
        }
        public override string ToString(string aPrefix)
        {
            string val_8;
            string val_9 = "[ ";
            List.Enumerator<T> val_1 = this.m_List.GetEnumerator();
            label_6:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_9 = val_9 + ", ";
            val_8 = val_9 + "\n" + aPrefix + "   ";
            string val_5 = aPrefix + "   ";
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            string val_6 = val_8 + 0;
            goto label_6;
            label_2:
            0.Dispose();
            return (string)val_9 + "\n" + aPrefix + "]";
        }
        public override void Serialize(System.IO.BinaryWriter aWriter)
        {
            var val_2 = 0;
            do
            {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_2 = val_2 + 1;
            }
            while(this.m_List != null);
            
            throw new NullReferenceException();
        }
        public JSONArray()
        {
            this.m_List = new System.Collections.Generic.List<com.adjust.sdk.JSONNode>();
            this = new System.Object();
        }
    
    }

}
