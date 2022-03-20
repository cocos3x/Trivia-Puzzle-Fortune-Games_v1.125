using UnityEngine;
public class LogStash
{
    // Fields
    private const int MaxPerStash = 20;
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<TrackedEvent>> stashes;
    private static System.Collections.Generic.Dictionary<string, int> indexes;
    
    // Methods
    public static void Stash(string stash, string eventToTrack, System.Collections.Generic.Dictionary<string, string> properties)
    {
        var val_4;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String> val_6;
        System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.Object> val_8;
        val_4 = null;
        val_4 = null;
        val_6 = LogStash.<>c.<>9__3_0;
        if(val_6 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String>(object:  LogStash.<>c.__il2cppRuntimeField_static_fields, method:  System.String LogStash.<>c::<Stash>b__3_0(System.Collections.Generic.KeyValuePair<string, string> item));
            val_4 = null;
            LogStash.<>c.<>9__3_0 = val_6;
        }
        
        val_4 = null;
        val_8 = LogStash.<>c.<>9__3_1;
        if(val_8 == null)
        {
                System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.Object> val_2 = null;
            val_8 = val_2;
            val_2 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.Object>(object:  LogStash.<>c.__il2cppRuntimeField_static_fields, method:  System.Object LogStash.<>c::<Stash>b__3_1(System.Collections.Generic.KeyValuePair<string, string> item));
            LogStash.<>c.<>9__3_1 = val_8;
        }
        
        LogStash.Stash(stash:  stash, eventToTrack:  eventToTrack, properties:  System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String, System.Object>(source:  properties, keySelector:  val_1, elementSelector:  val_2));
    }
    public static void Stash(string stash, string eventToTrack, System.Collections.Generic.Dictionary<string, object> properties)
    {
        var val_11;
        var val_12;
        var val_13;
        var val_14;
        val_11 = null;
        val_11 = null;
        if((LogStash.stashes.ContainsKey(key:  stash)) != true)
        {
                val_12 = null;
            val_12 = null;
            LogStash.stashes.Add(key:  stash, value:  new System.Collections.Generic.List<TrackedEvent>());
            LogStash.indexes.Add(key:  stash, value:  0);
        }
        
        val_13 = null;
        val_13 = null;
        int val_5 = LogStash.indexes.Item[stash] + 1;
        LogStash.indexes.set_Item(key:  stash, value:  val_5);
        LogStash.stashes.Item[stash].Insert(index:  0, item:  new TrackedEvent(eventName:  eventToTrack, properties:  properties, index:  val_5));
        System.Collections.Generic.List<TrackedEvent> val_7 = LogStash.stashes.Item[stash];
        val_14 = null;
        val_14 = null;
        System.Collections.Generic.List<TrackedEvent> val_9 = LogStash.stashes.Item[stash];
        LogStash.stashes.Item[stash].RemoveAt(index:  LogStash.stashes - 1);
    }
    public static System.Collections.Generic.List<TrackedEvent> GetStash(string stashKey)
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = null;
        val_3 = null;
        if((LogStash.stashes.ContainsKey(key:  stashKey)) != false)
        {
                val_4 = null;
            val_4 = null;
            System.Collections.Generic.List<TrackedEvent> val_2 = LogStash.stashes.Item[stashKey];
            return (System.Collections.Generic.List<TrackedEvent>)val_5;
        }
        
        val_5 = 0;
        return (System.Collections.Generic.List<TrackedEvent>)val_5;
    }
    public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<TrackedEvent>> GetEverything()
    {
        null = null;
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<TrackedEvent>>)LogStash.stashes;
    }
    public LogStash()
    {
    
    }
    private static LogStash()
    {
        LogStash.stashes = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<TrackedEvent>>();
        LogStash.indexes = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
    }

}
