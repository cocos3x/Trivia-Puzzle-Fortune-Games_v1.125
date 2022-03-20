using UnityEngine;

namespace twelvegigs.sweepstakes
{
    public class Distribution
    {
        // Fields
        private string <Type>k__BackingField;
        private System.Nullable<double> value;
        private int <Frequency>k__BackingField;
        
        // Properties
        public string Type { get; set; }
        public double Value { get; }
        public int Frequency { get; set; }
        
        // Methods
        public string get_Type()
        {
            return (string)this.<Type>k__BackingField;
        }
        protected void set_Type(string value)
        {
            this.<Type>k__BackingField = value;
        }
        public double get_Value()
        {
            if(true == 0)
            {
                    return 0;
            }
            
            return this.value.Value;
        }
        public int get_Frequency()
        {
            return (int)this.<Frequency>k__BackingField;
        }
        protected void set_Frequency(int value)
        {
            this.<Frequency>k__BackingField = value;
        }
        public Distribution(System.Collections.Generic.Dictionary<string, object> distribution)
        {
            string val_11;
            object val_1 = distribution.Item["type"];
            this.<Type>k__BackingField = val_1;
            if((System.String.op_Equality(a:  val_1, b:  "cash")) != false)
            {
                    System.Nullable<System.Double> val_6 = new System.Nullable<System.Double>(value:  System.Math.Round(value:  System.Convert.ToDouble(value:  distribution.Item["value"]), digits:  2));
                this.value = val_6.HasValue;
            }
            
            if((distribution.ContainsKey(key:  "frequency")) != false)
            {
                    val_11 = distribution.Item["frequency"];
                int val_9 = System.Convert.ToInt32(value:  val_11);
            }
            else
            {
                    val_11 = 1;
            }
            
            this.<Frequency>k__BackingField = val_11;
        }
    
    }

}
