using UnityEngine;

namespace SRDebugger
{
    public sealed class InfoEntry
    {
        // Fields
        private string <Title>k__BackingField;
        private bool <IsPrivate>k__BackingField;
        private System.Func<object> _valueGetter;
        
        // Properties
        public string Title { get; set; }
        public object Value { get; }
        public bool IsPrivate { get; set; }
        
        // Methods
        public string get_Title()
        {
            return (string)this.<Title>k__BackingField;
        }
        public void set_Title(string value)
        {
            this.<Title>k__BackingField = value;
        }
        public object get_Value()
        {
            if(this._valueGetter == null)
            {
                    throw new NullReferenceException();
            }
            
            return (object)this._valueGetter.Invoke();
        }
        public bool get_IsPrivate()
        {
            return (bool)this.<IsPrivate>k__BackingField;
        }
        private void set_IsPrivate(bool value)
        {
            this.<IsPrivate>k__BackingField = value;
        }
        public static SRDebugger.InfoEntry Create(string name, System.Func<object> getter, bool isPrivate = False)
        {
            .<Title>k__BackingField = name;
            ._valueGetter = getter;
            .<IsPrivate>k__BackingField = isPrivate;
            return (SRDebugger.InfoEntry)new SRDebugger.InfoEntry();
        }
        public static SRDebugger.InfoEntry Create(string name, object value, bool isPrivate = False)
        {
            .value = value;
            .<Title>k__BackingField = name;
            ._valueGetter = new System.Func<System.Object>(object:  new InfoEntry.<>c__DisplayClass12_0(), method:  System.Object InfoEntry.<>c__DisplayClass12_0::<Create>b__0());
            .<IsPrivate>k__BackingField = isPrivate;
            return (SRDebugger.InfoEntry)new SRDebugger.InfoEntry();
        }
        public InfoEntry()
        {
        
        }
    
    }

}
