using UnityEngine;

namespace SimpleJSON
{
    public class JSONData : JSONNode
    {
        // Fields
        private string m_Data;
        
        // Properties
        public override string Value { get; set; }
        
        // Methods
        public override string get_Value()
        {
            return (string)this.m_Data;
        }
        public override void set_Value(string value)
        {
            this.m_Data = value;
        }
        public JSONData(string aData)
        {
            val_1 = new System.Object();
            this.m_Data = aData;
        }
        public JSONData(float aData)
        {
            val_1 = new System.Object();
            val_1.AsFloat = aData;
        }
        public JSONData(double aData)
        {
            val_1 = new System.Object();
            val_1.AsDouble = aData;
        }
        public JSONData(bool aData)
        {
            val_1 = new System.Object();
            val_1.AsBool = aData;
        }
        public JSONData(int aData)
        {
            val_1 = new System.Object();
            val_1.AsInt = aData;
        }
        public override string ToString()
        {
            return "\"" + SimpleJSON.JSONNode.Escape(aText:  this.m_Data)(SimpleJSON.JSONNode.Escape(aText:  this.m_Data)) + "\"";
        }
        public override string ToString(string aPrefix)
        {
            return "\"" + SimpleJSON.JSONNode.Escape(aText:  this.m_Data)(SimpleJSON.JSONNode.Escape(aText:  this.m_Data)) + "\"";
        }
        public override void Serialize(System.IO.BinaryWriter aWriter)
        {
            var val_7;
            var val_8;
            var val_9;
            var val_11;
            var val_14;
            var val_15;
            var val_16;
            var val_18;
            var val_28;
            var val_29;
            var val_30;
            var val_31;
            val_28 = aWriter;
            val_29 = this;
            SimpleJSON.JSONData val_1 = null;
            val_30 = val_1;
            val_1 = new SimpleJSON.JSONData();
            .m_Data = "";
            val_1.AsInt = this.AsInt;
            if((System.String.op_Equality(a:  (SimpleJSON.JSONData)[1152921520100555184].m_Data, b:  this.m_Data)) == false)
            {
                goto label_2;
            }
            
            int val_4 = this.AsInt;
            label_10:
            val_31 = ???;
            val_29 = ???;
            val_28 = ???;
            val_30 = ???;
            goto typeof(System.IO.BinaryWriter).__il2cppRuntimeField_230;
            label_2:
            if((System.String.op_Equality(a:  val_30 + 16, b:  val_29 + 16)) == false)
            {
                goto label_4;
            }
            
            val_31 = val_7;
            val_29 = val_8;
            val_28 = val_9;
            val_30 = val_11;
            goto val_28 + 624;
            label_4:
            if((System.String.op_Equality(a:  val_11 + 16, b:  val_8 + 16)) == false)
            {
                goto label_6;
            }
            
            val_31 = val_14;
            val_29 = val_15;
            val_28 = val_16;
            val_30 = val_18;
            goto val_9 + 512;
            label_6:
            var val_19 = val_29 & 1;
            if((System.String.op_Equality(a:  val_18 + 16, b:  val_15 + 16)) == false)
            {
                goto val_16 + 640;
            }
            
            var val_21 = val_29 & 1;
            goto label_10;
        }
    
    }

}
