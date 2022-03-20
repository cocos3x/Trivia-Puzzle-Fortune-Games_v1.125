using UnityEngine;
public class AnalyticsEvent
{
    // Fields
    private string eventName;
    private double timestamp;
    private System.Collections.Generic.List<string> parameters;
    
    // Methods
    public AnalyticsEvent(string eventName, System.Collections.Generic.List<string> parameters)
    {
        val_1 = new System.Object();
        this.eventName = eventName;
        this.parameters = val_1;
        System.DateTime val_2 = System.DateTime.UtcNow;
        System.DateTime val_3 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
        System.TimeSpan val_4 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = val_3.dateData});
        this.timestamp = val_4._ticks.TotalSeconds;
    }
    public System.Collections.Generic.Dictionary<string, object> ToDictionary()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "eventName", value:  this.eventName);
        val_1.Add(key:  "timestamp", value:  this.timestamp);
        if(this.parameters == null)
        {
                return val_1;
        }
        
        val_1.set_Item(key:  "parameters", value:  this.parameters);
        return val_1;
    }

}
