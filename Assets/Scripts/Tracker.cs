using UnityEngine;
public abstract class Tracker
{
    // Fields
    protected System.Collections.Generic.List<string> events;
    protected System.Collections.Generic.List<System.Text.RegularExpressions.Regex> regexEvents;
    protected System.Collections.Generic.Dictionary<string, string> eventProperties;
    protected System.Collections.Generic.Dictionary<System.Text.RegularExpressions.Regex, string> regexProperties;
    private System.Collections.Generic.Dictionary<string, int> eventCounter;
    public bool logging;
    public string tag;
    private bool isEventTrackingWorking;
    
    // Properties
    public bool IsEventTrackingWorking { get; set; }
    public System.Collections.Generic.List<string> StaticEvents { get; }
    public System.Collections.Generic.List<System.Text.RegularExpressions.Regex> DynamicEvents { get; }
    public System.Collections.Generic.Dictionary<string, int> EventCounter { get; }
    
    // Methods
    public void set_IsEventTrackingWorking(bool value)
    {
        this.isEventTrackingWorking = value;
    }
    public bool get_IsEventTrackingWorking()
    {
        return (bool)this.isEventTrackingWorking;
    }
    public System.Collections.Generic.List<string> get_StaticEvents()
    {
        return (System.Collections.Generic.List<System.String>)this.events;
    }
    public System.Collections.Generic.List<System.Text.RegularExpressions.Regex> get_DynamicEvents()
    {
        return (System.Collections.Generic.List<System.Text.RegularExpressions.Regex>)this.regexEvents;
    }
    public System.Collections.Generic.Dictionary<string, int> get_EventCounter()
    {
        return (System.Collections.Generic.Dictionary<System.String, System.Int32>)this.eventCounter;
    }
    public Tracker()
    {
        this.tag = "Tracker [info]: ";
        this.events = new System.Collections.Generic.List<System.String>();
        this.regexEvents = new System.Collections.Generic.List<System.Text.RegularExpressions.Regex>();
        this.eventProperties = new System.Collections.Generic.Dictionary<System.String, System.String>();
        this.regexProperties = new System.Collections.Generic.Dictionary<System.Text.RegularExpressions.Regex, System.String>();
        this.eventCounter = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
    }
    public void AddEvent(string eventName, string propertyName)
    {
        if((this.events.Contains(item:  eventName)) == true)
        {
                return;
        }
        
        this.events.Add(item:  eventName);
        this.eventCounter.Add(key:  eventName, value:  0);
        if(propertyName == null)
        {
                return;
        }
        
        this.eventProperties.Add(key:  eventName, value:  propertyName);
    }
    public void AddEvent(System.Text.RegularExpressions.Regex regex, string propertyName)
    {
        if((this.regexEvents.Contains(item:  regex)) == true)
        {
                return;
        }
        
        this.regexEvents.Add(item:  regex);
        this.eventCounter.Add(key:  regex, value:  0);
        if(propertyName == null)
        {
                return;
        }
        
        this.regexProperties.Add(key:  regex, value:  propertyName);
    }
    private bool listens(string eventName)
    {
        var val_5;
        if((this.events.Contains(item:  eventName)) != false)
        {
                val_5 = 1;
            return (bool)val_5;
        }
        
        List.Enumerator<T> val_2 = this.regexEvents.GetEnumerator();
        label_7:
        if(0.MoveNext() == false)
        {
            goto label_5;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((0.IsMatch(input:  eventName)) == false)
        {
            goto label_7;
        }
        
        val_5 = 1;
        goto label_8;
        label_5:
        val_5 = 0;
        label_8:
        0.Dispose();
        return (bool)val_5;
    }
    public void stash(string trackerName, string eventName, System.Collections.Generic.Dictionary<string, object> data)
    {
        if((this.listens(eventName:  eventName)) == false)
        {
                return;
        }
        
        LogStash.Stash(stash:  trackerName, eventToTrack:  eventName, properties:  data);
    }
    public void track(string eventName, System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_12;
        string val_13;
        val_12 = data;
        if((this.listens(eventName:  eventName)) == false)
        {
                return;
        }
        
        if((this.eventProperties.ContainsKey(key:  eventName)) == false)
        {
            goto label_3;
        }
        
        val_12 = val_12.Item[this.eventProperties.Item[eventName]];
        string val_5 = this.eventProperties.Item[eventName];
        goto label_8;
        label_3:
        System.Text.RegularExpressions.Regex val_6 = this.getRegex(eventName:  eventName);
        if(val_6 == null)
        {
            goto label_9;
        }
        
        if((val_12.ContainsKey(key:  this.regexProperties.Item[val_6])) == false)
        {
                return;
        }
        
        val_12 = val_12.Item[this.regexProperties.Item[val_6]];
        string val_11 = this.regexProperties.Item[val_6];
        val_13 = val_6;
        goto label_16;
        label_9:
        label_8:
        val_13 = eventName;
        label_16:
        this.CountEvent(eventToCount:  val_13);
    }
    private System.Text.RegularExpressions.Regex getRegex(string eventName)
    {
        string val_4;
        var val_5;
        val_4 = eventName;
        List.Enumerator<T> val_1 = this.regexEvents.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_5 = 0;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_5.IsMatch(input:  val_4)) == false)
        {
            goto label_4;
        }
        
        goto label_5;
        label_2:
        val_5 = 0;
        label_5:
        0.Dispose();
        return (System.Text.RegularExpressions.Regex)val_5;
    }
    protected void Log(string message)
    {
        if(this.logging == false)
        {
                return;
        }
        
        UnityEngine.Debug.Log(message:  this.tag + message);
    }
    public void ClearCounters()
    {
        List.Enumerator<T> val_3 = new System.Collections.Generic.List<System.String>(collection:  this.eventCounter.Keys).GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(this.eventCounter == null)
        {
                throw new NullReferenceException();
        }
        
        this.eventCounter.set_Item(key:  0, value:  0);
        goto label_5;
        label_3:
        0.Dispose();
    }
    private void CountEvent(string eventToCount)
    {
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
                return;
        }
        
        this.eventCounter.set_Item(key:  eventToCount, value:  this.eventCounter.Item[eventToCount] + 1);
    }
    public abstract void identify(string id); // 0
    public abstract void trackEvent(string eventName, System.Collections.Generic.Dictionary<string, object> data); // 0
    public abstract void trackEvent(string eventName, string propertyName, string propertyValue); // 0
    public abstract void increment(string eventName, string eventValue); // 0
    public abstract void peopleIncrement(string eventName, string eventValue); // 0
    public abstract void peopleProperty(string propertyName, string propertyValue); // 0
    public abstract void superProperty(string propertyName, string propertyValue); // 0
    public abstract void trackCharge(string quantity, System.Collections.Generic.Dictionary<string, object> data); // 0

}
