using UnityEngine;

namespace Spine
{
    public class EventData
    {
        // Fields
        internal string name;
        private int <Int>k__BackingField;
        private float <Float>k__BackingField;
        private string <String>k__BackingField;
        
        // Properties
        public string Name { get; }
        public int Int { get; set; }
        public float Float { get; set; }
        public string String { get; set; }
        
        // Methods
        public string get_Name()
        {
            return (string)this.name;
        }
        public int get_Int()
        {
            return (int)this.<Int>k__BackingField;
        }
        public void set_Int(int value)
        {
            this.<Int>k__BackingField = value;
        }
        public float get_Float()
        {
            return (float)this.<Float>k__BackingField;
        }
        public void set_Float(float value)
        {
            this.<Float>k__BackingField = value;
        }
        public string get_String()
        {
            return (string)this.<String>k__BackingField;
        }
        public void set_String(string value)
        {
            this.<String>k__BackingField = value;
        }
        public EventData(string name)
        {
            if(name == null)
            {
                    throw new System.ArgumentNullException(paramName:  "name", message:  "name cannot be null.");
            }
            
            this.name = name;
        }
        public override string ToString()
        {
            return (string)this.name;
        }
    
    }

}
