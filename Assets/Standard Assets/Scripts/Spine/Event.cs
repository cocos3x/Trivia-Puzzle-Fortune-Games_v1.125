using UnityEngine;

namespace Spine
{
    public class Event
    {
        // Fields
        internal readonly Spine.EventData data;
        internal readonly float time;
        internal int intValue;
        internal float floatValue;
        internal string stringValue;
        
        // Properties
        public Spine.EventData Data { get; }
        public float Time { get; }
        public int Int { get; set; }
        public float Float { get; set; }
        public string String { get; set; }
        
        // Methods
        public Spine.EventData get_Data()
        {
            return (Spine.EventData)this.data;
        }
        public float get_Time()
        {
            return (float)this.time;
        }
        public int get_Int()
        {
            return (int)this.intValue;
        }
        public void set_Int(int value)
        {
            this.intValue = value;
        }
        public float get_Float()
        {
            return (float)this.floatValue;
        }
        public void set_Float(float value)
        {
            this.floatValue = value;
        }
        public string get_String()
        {
            return (string)this.stringValue;
        }
        public void set_String(string value)
        {
            this.stringValue = value;
        }
        public Event(float time, Spine.EventData data)
        {
            if(data == null)
            {
                    throw new System.ArgumentNullException(paramName:  "data", message:  "data cannot be null.");
            }
            
            this.time = time;
            this.data = data;
        }
        public override string ToString()
        {
            if(this.data != null)
            {
                    return (string)this.data.name;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
