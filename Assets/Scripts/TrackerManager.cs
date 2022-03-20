using UnityEngine;
public class TrackerManager
{
    // Fields
    private static TrackerManager instance;
    private System.Collections.Generic.List<Tracker> trackers;
    private System.Collections.Generic.Queue<System.Collections.Generic.Dictionary<string, object>> cachedEvents;
    public bool logging;
    public bool queueing;
    private System.Collections.Generic.List<string> trackOnceEventsFired;
    
    // Properties
    public static TrackerManager Instance { get; }
    public System.Collections.Generic.List<Tracker> Trackers { get; }
    
    // Methods
    private TrackerManager()
    {
        this.trackOnceEventsFired = new System.Collections.Generic.List<System.String>();
        this.trackers = new System.Collections.Generic.List<Tracker>();
        this.cachedEvents = new System.Collections.Generic.Queue<System.Collections.Generic.Dictionary<System.String, System.Object>>();
    }
    public static TrackerManager get_Instance()
    {
        TrackerManager val_2;
        TrackerManager val_3 = TrackerManager.instance;
        if(val_3 != null)
        {
                return val_3;
        }
        
        TrackerManager val_1 = null;
        val_2 = val_1;
        val_1 = new TrackerManager();
        TrackerManager.instance = val_2;
        val_3 = TrackerManager.instance;
        return val_3;
    }
    public System.Collections.Generic.List<Tracker> get_Trackers()
    {
        return (System.Collections.Generic.List<Tracker>)this.trackers;
    }
    public void addTracker(Tracker t)
    {
        if((this.trackers.Contains(item:  t)) != false)
        {
                return;
        }
        
        this.trackers.Add(item:  t);
    }
    public void removeTracker(Tracker t)
    {
        if((this.trackers.Contains(item:  t)) == false)
        {
                return;
        }
        
        bool val_2 = this.trackers.Remove(item:  t);
    }
    public void flush()
    {
    
    }
    public void clearCache()
    {
        this.cachedEvents.Clear();
    }
    public void identify(string id)
    {
        List.Enumerator<T> val_1 = this.trackers.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_4;
        label_2:
        0.Dispose();
    }
    public bool find(string id)
    {
        string val_5;
        var val_6;
        var val_7;
        List.Enumerator<T> val_1 = this.trackers.GetEnumerator();
        label_7:
        val_5 = public System.Boolean List.Enumerator<Tracker>::MoveNext();
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_6 = 0;
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_5 = id;
        if((val_6.ContainsKey(key:  val_5)) == false)
        {
            goto label_7;
        }
        
        val_6 = 0;
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_6.Item[id] < 1)
        {
            goto label_7;
        }
        
        val_7 = 1;
        goto label_8;
        label_2:
        val_7 = 0;
        label_8:
        0.Dispose();
        return (bool)val_7;
    }
    public void track(string eventName)
    {
        this.track(eventName:  eventName, data:  new System.Collections.Generic.Dictionary<System.String, System.Object>());
    }
    public void track(string eventName, System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_11;
        var val_12;
        var val_18;
        UnityEngine.Object val_19;
        var val_20;
        var val_21;
        var val_22;
        var val_23;
        var val_24;
        var val_25;
        .<>4__this = this;
        .eventName = eventName;
        .data = data;
        val_18 = 1152921515554681584;
        val_19 = DefaultHandler<ServerHandler>.Instance;
        val_20 = 0;
        if(val_19 != 0)
        {
                ServerHandler val_4 = DefaultHandler<ServerHandler>.Instance;
            if(val_4._allowServerConnect == false)
        {
                return;
        }
        
        }
        
        val_19 = 1152921504884535296;
        if(CompanyDevices.Instance.CompanyDevice() == false)
        {
            goto label_14;
        }
        
        val_21 = null;
        val_21 = null;
        if(CompanyDevices.TrackingAllowed == false)
        {
            goto label_17;
        }
        
        label_14:
        val_18 = 1152921504885227520;
        val_22 = null;
        val_22 = null;
        if(TrackingComponent.hasFinishedInitializing != true)
        {
                object[] val_7 = new object[1];
            val_7[0] = (TrackerManager.<>c__DisplayClass17_0)[1152921515554805376].eventName;
            UnityEngine.Debug.LogWarningFormat(format:  "{0} Attempted to be Tracked before TrackingComponent Init!", args:  val_7);
            val_23 = null;
            val_23 = null;
            val_19 = TrackingComponent.finishedInitializingCallback;
            val_20 = 0;
            System.Delegate val_9 = System.Delegate.Combine(a:  val_19, b:  new System.Action(object:  new TrackerManager.<>c__DisplayClass17_0(), method:  System.Void TrackerManager.<>c__DisplayClass17_0::<track>b__0()));
            if(val_9 != null)
        {
                val_25 = null;
            if(null != val_25)
        {
            goto label_53;
        }
        
        }
        
            TrackingComponent.finishedInitializingCallback = val_9;
        }
        
        List.Enumerator<T> val_10 = this.trackers.GetEnumerator();
        label_37:
        if(val_12.MoveNext() == false)
        {
            goto label_39;
        }
        
        val_24 = val_11;
        if(val_24 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_24.track(eventName:  (TrackerManager.<>c__DisplayClass17_0)[1152921515554805376].eventName, data:  (TrackerManager.<>c__DisplayClass17_0)[1152921515554805376].data);
        goto label_37;
        label_17:
        List.Enumerator<T> val_14 = this.trackers.GetEnumerator();
        val_18 = 1152921504883789824;
        label_44:
        if(val_12.MoveNext() == false)
        {
            goto label_39;
        }
        
        System.Type val_16 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_11 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_11.stash(trackerName:  val_16, eventName:  (TrackerManager.<>c__DisplayClass17_0)[1152921515554805376].eventName, data:  (TrackerManager.<>c__DisplayClass17_0)[1152921515554805376].data);
        goto label_44;
        label_39:
        val_12.Dispose();
        return;
        label_53:
        if( == 1)
        {
                val_12.Dispose();
            if(new ArrayTypeMismatchException() == 0)
        {
                return;
        }
        
            throw new ArrayTypeMismatchException();
        }
    
    }
    private void trackEvent(object[] _params)
    {
        if(true == 0)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = this.cachedEvents.Dequeue();
        object val_2 = val_1.Item["eventName"];
        List.Enumerator<T> val_3 = this.trackers.GetEnumerator();
        label_10:
        if(0.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Debug.Log(message:  "GB: tracker: "("GB: tracker: ") + 0);
        UnityEngine.Debug.Log(message:  "GB: eventName: "("GB: eventName: ") + val_2);
        0.track(eventName:  val_2, data:  val_1);
        goto label_10;
        label_6:
        0.Dispose();
        this.flush();
    }
    public void track(string eventName, string propertyName, object propertyValue)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  propertyName, value:  propertyValue);
        this.track(eventName:  eventName, data:  val_1);
    }
    public void trackOnce(string eventName)
    {
        if((this.trackOnceEventsFired.Contains(item:  eventName)) != false)
        {
                return;
        }
        
        this.track(eventName:  eventName);
        this.trackOnceEventsFired.Add(item:  eventName);
    }
    public void trackOnce(string eventName, string propertyName, object propertyValue)
    {
        if((this.trackOnceEventsFired.Contains(item:  eventName)) != false)
        {
                return;
        }
        
        this.track(eventName:  eventName, propertyName:  propertyName, propertyValue:  propertyValue);
        this.trackOnceEventsFired.Add(item:  eventName);
    }
    public void peopleProperty(string propertyName, string propertyValue)
    {
        string val_1 = "TrackerManager: People Property "("TrackerManager: People Property ") + propertyName;
        List.Enumerator<T> val_2 = this.trackers.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_4;
        label_2:
        0.Dispose();
    }
    public void superProperty(string propertyName, string propertyValue)
    {
        string val_1 = "TrackerManager: Super Property "("TrackerManager: Super Property ") + propertyName;
        List.Enumerator<T> val_2 = this.trackers.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_4;
        label_2:
        0.Dispose();
    }
    public void increment(string eventName, string eventValue)
    {
        string val_1 = "TrackerManager: Increment "("TrackerManager: Increment ") + eventName;
        List.Enumerator<T> val_2 = this.trackers.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_4;
        label_2:
        0.Dispose();
    }
    public void peopleIncrement(string eventName, string eventValue)
    {
        string val_1 = "TrackerManager: People Increment "("TrackerManager: People Increment ") + eventName;
        List.Enumerator<T> val_2 = this.trackers.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_4;
        label_2:
        0.Dispose();
    }
    public void trackCharge(string quantity, System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_6;
        var val_7;
        val_6 = this;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_7 = null;
            val_7 = null;
            if(CompanyDevices.TrackingAllowed == false)
        {
                return;
        }
        
        }
        
        string val_3 = "TrackerManager: TrackCharge "("TrackerManager: TrackCharge ") + quantity;
        List.Enumerator<T> val_4 = this.trackers.GetEnumerator();
        val_6 = 1152921515554290288;
        label_11:
        if(0.MoveNext() == false)
        {
            goto label_9;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_11;
        label_9:
        0.Dispose();
    }
    private void Log(string message)
    {
    
    }

}
