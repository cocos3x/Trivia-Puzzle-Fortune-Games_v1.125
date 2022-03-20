using UnityEngine;
public class TrackedEvent
{
    // Fields
    private string eventName;
    private System.Collections.Generic.Dictionary<string, object> properties;
    private int index;
    
    // Methods
    public TrackedEvent(string eventName, System.Collections.Generic.Dictionary<string, object> properties, int index)
    {
        this.eventName = "";
        val_1 = new System.Object();
        this.eventName = eventName;
        this.properties = val_1;
        this.index = index;
    }
    public override string ToString()
    {
        static_value_02806577 = true;
        return System.String.Format(format:  "{0}) {1} with: {2}", arg0:  this.index.ToString(), arg1:  this.eventName, arg2:  MiniJSON.Json.Serialize(obj:  this.properties).Replace(oldValue:  "\",", newValue:  "\", "));
    }

}
