using UnityEngine;

namespace com.adjust.sdk
{
    internal class JSONLazyCreator : JSONNode
    {
        // Fields
        private com.adjust.sdk.JSONNode m_Node;
        private string m_Key;
        
        // Properties
        public override com.adjust.sdk.JSONNode Item { get; set; }
        public override com.adjust.sdk.JSONNode Item { get; set; }
        public override int AsInt { get; set; }
        public override float AsFloat { get; set; }
        public override double AsDouble { get; set; }
        public override bool AsBool { get; set; }
        public override com.adjust.sdk.JSONArray AsArray { get; }
        public override com.adjust.sdk.JSONClass AsObject { get; }
        
        // Methods
        public JSONLazyCreator(com.adjust.sdk.JSONNode aNode)
        {
            val_1 = new System.Object();
            this.m_Node = aNode;
            this.m_Key = 0;
        }
        public JSONLazyCreator(com.adjust.sdk.JSONNode aNode, string aKey)
        {
            val_1 = new System.Object();
            this.m_Node = aNode;
            this.m_Key = val_1;
        }
        private void Set(com.adjust.sdk.JSONNode aVal)
        {
            if(this.m_Key != null)
            {
                
            }
            
            this.m_Node = 0;
        }
        public override com.adjust.sdk.JSONNode get_Item(int aIndex)
        {
            .m_Node = this;
            .m_Key = 0;
            return (com.adjust.sdk.JSONNode)new com.adjust.sdk.JSONLazyCreator();
        }
        public override void set_Item(int aIndex, com.adjust.sdk.JSONNode value)
        {
            com.adjust.sdk.JSONArray val_1 = new com.adjust.sdk.JSONArray();
            val_1.Add(aItem:  value);
            this.Set(aVal:  val_1);
        }
        public override com.adjust.sdk.JSONNode get_Item(string aKey)
        {
            .m_Node = this;
            .m_Key = aKey;
            return (com.adjust.sdk.JSONNode)new com.adjust.sdk.JSONLazyCreator();
        }
        public override void set_Item(string aKey, com.adjust.sdk.JSONNode value)
        {
            this.Set(aVal:  new com.adjust.sdk.JSONClass());
        }
        public override void Add(com.adjust.sdk.JSONNode aItem)
        {
            com.adjust.sdk.JSONArray val_1 = new com.adjust.sdk.JSONArray();
            val_1.Add(aItem:  aItem);
            this.Set(aVal:  val_1);
        }
        public override void Add(string aKey, com.adjust.sdk.JSONNode aItem)
        {
            this.Set(aVal:  new com.adjust.sdk.JSONClass());
        }
        public static bool op_Equality(com.adjust.sdk.JSONLazyCreator a, object b)
        {
            a = ((b == 0) ? 1 : 0) | ((a == b) ? 1 : 0);
            return (bool)a;
        }
        public static bool op_Inequality(com.adjust.sdk.JSONLazyCreator a, object b)
        {
            a = ((a != b) ? 1 : 0) & ((b != 0) ? 1 : 0);
            return (bool)a;
        }
        public override bool Equals(object obj)
        {
            this = ((obj == 0) ? 1 : 0) | ((this == obj) ? 1 : 0);
            return (bool)this;
        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        public override string ToString()
        {
            return "";
        }
        public override string ToString(string aPrefix)
        {
            return "";
        }
        public override int get_AsInt()
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsInt = 0;
            this.Set(aVal:  val_1);
            return 0;
        }
        public override void set_AsInt(int value)
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsInt = value;
            this.Set(aVal:  val_1);
        }
        public override float get_AsFloat()
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsFloat = 0f;
            this.Set(aVal:  val_1);
            return 0f;
        }
        public override void set_AsFloat(float value)
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsFloat = value;
            this.Set(aVal:  val_1);
        }
        public override double get_AsDouble()
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsDouble = 0;
            this.Set(aVal:  val_1);
            return 0;
        }
        public override void set_AsDouble(double value)
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsDouble = value;
            this.Set(aVal:  val_1);
        }
        public override bool get_AsBool()
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsBool = false;
            this.Set(aVal:  val_1);
            return false;
        }
        public override void set_AsBool(bool value)
        {
            com.adjust.sdk.JSONData val_1 = new com.adjust.sdk.JSONData();
            val_1.AsBool = value;
            this.Set(aVal:  val_1);
        }
        public override com.adjust.sdk.JSONArray get_AsArray()
        {
            com.adjust.sdk.JSONArray val_1 = new com.adjust.sdk.JSONArray();
            this.Set(aVal:  val_1);
            return val_1;
        }
        public override com.adjust.sdk.JSONClass get_AsObject()
        {
            com.adjust.sdk.JSONClass val_1 = new com.adjust.sdk.JSONClass();
            this.Set(aVal:  val_1);
            return val_1;
        }
    
    }

}
