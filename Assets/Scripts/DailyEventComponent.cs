using UnityEngine;
public class DailyEventComponent
{
    // Fields
    private System.DateTime updatedAt;
    public string name;
    
    // Properties
    private System.Collections.Generic.Dictionary<string, object> JSONDictionary { get; }
    
    // Methods
    private System.Collections.Generic.Dictionary<string, object> get_JSONDictionary()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "name", value:  this.name);
        val_1.Add(key:  "updatedAt", value:  this.updatedAt);
        return val_1;
    }
    public DailyEventComponent(string name)
    {
        string val_1 = "daily_event_component_" + name;
        this.name = val_1;
        if((UnityEngine.PlayerPrefs.HasKey(key:  val_1)) != false)
        {
                this.Load();
            return;
        }
        
        this.Reset();
    }
    private void Load()
    {
        var val_8;
        object val_2 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this.name));
        val_8 = 0;
        new twelvegigs.storage.JsonDictionary() = new twelvegigs.storage.JsonDictionary(parsedDictionary:  null);
        System.DateTime val_6 = System.DateTime.UtcNow;
        System.DateTime val_7 = SLCDateTime.Parse(dateTime:  new twelvegigs.storage.JsonDictionary().getString(key:  "updatedAt", defaultValue:  ""), defaultValue:  new System.DateTime() {dateData = val_6.dateData});
        this.updatedAt = val_7;
    }
    public bool IsTracked()
    {
        var val_6;
        var val_7;
        val_6 = null;
        val_6 = null;
        if((System.DateTime.op_Equality(d1:  new System.DateTime() {dateData = this.updatedAt}, d2:  new System.DateTime() {dateData = System.DateTime.MinValue})) != false)
        {
                val_7 = 0;
            return (bool)(val_3._ticks.TotalDays < 0) ? 1 : 0;
        }
        
        System.DateTime val_2 = System.DateTime.UtcNow;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_2.dateData}, d2:  new System.DateTime() {dateData = this.updatedAt});
        return (bool)(val_3._ticks.TotalDays < 0) ? 1 : 0;
    }
    public void Reset()
    {
        System.DateTime val_1 = System.DateTime.UtcNow;
        this.updatedAt = val_1;
        UnityEngine.PlayerPrefs.SetString(key:  this.name, value:  this);
    }
    public override string ToString()
    {
        return MiniJSON.Json.Serialize(obj:  this.JSONDictionary);
    }

}
