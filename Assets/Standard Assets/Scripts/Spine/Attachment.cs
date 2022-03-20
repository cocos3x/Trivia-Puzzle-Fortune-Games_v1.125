using UnityEngine;

namespace Spine
{
    public abstract class Attachment
    {
        // Fields
        private string <Name>k__BackingField;
        
        // Properties
        public string Name { get; set; }
        
        // Methods
        public string get_Name()
        {
            return (string)this.<Name>k__BackingField;
        }
        private void set_Name(string value)
        {
            this.<Name>k__BackingField = value;
        }
        public Attachment(string name)
        {
            if(name == null)
            {
                    throw new System.ArgumentNullException(paramName:  "name", message:  "name cannot be null");
            }
            
            this.<Name>k__BackingField = name;
        }
        public override string ToString()
        {
            return (string)this.<Name>k__BackingField;
        }
    
    }

}
