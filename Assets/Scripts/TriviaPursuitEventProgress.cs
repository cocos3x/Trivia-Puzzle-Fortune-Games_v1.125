using UnityEngine;
public class TriviaPursuitEventProgress : TRVEventProgression
{
    // Fields
    private const string KEY_SELECTED_CATEGORIES = "categories";
    private const string KEY_NEXT_TP_LEVEL = "nextTPLevel";
    public System.Collections.Generic.List<TriviaPursuitCategory> SelectedCategories;
    public int NextTPLevel;
    
    // Properties
    protected override string PREF_EVENT_PROG { get; }
    
    // Methods
    protected override string get_PREF_EVENT_PROG()
    {
        return "trv_pursuit_evt_prg";
    }
    public override void LoadFromJSON()
    {
        string val_26;
        var val_27;
        var val_31;
        string val_32;
        string val_33;
        if((UnityEngine.PlayerPrefs.HasKey(key:  this)) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this));
        val_31 = 1152921510222861648;
        if((val_3.ContainsKey(key:  "timestamp")) != false)
        {
                bool val_7 = System.Int32.TryParse(s:  val_3.Item["timestamp"], result: out  1152921517408566112);
        }
        
        if((val_3.ContainsKey(key:  "last_prog_timestamp")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_3.Item["last_prog_timestamp"], result: out  1152921517408566116);
        }
        
        if((val_3.ContainsKey(key:  "isEventShown")) != false)
        {
                bool val_15 = System.Boolean.TryParse(value:  val_3.Item["isEventShown"], result: out  1152921517408566120);
        }
        
        if((val_3.ContainsKey(key:  "nextTPLevel")) != false)
        {
                bool val_19 = System.Int32.TryParse(s:  val_3.Item["nextTPLevel"], result: out  this.NextTPLevel);
        }
        
        if((val_3.ContainsKey(key:  "categories")) == false)
        {
                return;
        }
        
        val_31 = 1152921510214912464;
        if(val_3.Item["categories"] == null)
        {
                return;
        }
        
        System.Collections.Generic.List<TriviaPursuitCategory> val_22 = new System.Collections.Generic.List<TriviaPursuitCategory>();
        List.Enumerator<T> val_25 = MiniJSON.Json.Deserialize(json:  val_3.Item["categories"]).GetEnumerator();
        val_31 = 1152921510211410768;
        label_25:
        if(val_27.MoveNext() == false)
        {
            goto label_21;
        }
        
        TriviaPursuitCategory val_29 = null;
        val_33 = 0;
        val_29 = new TriviaPursuitCategory();
        if(val_26 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_32 = val_26;
        val_33 = val_32;
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_32 = val_29;
        val_29.Parse(data:  val_33);
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22.Add(item:  val_29);
        goto label_25;
        label_21:
        val_27.Dispose();
        this.SelectedCategories = val_22;
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "timestamp", value:  1152921510196879024);
        val_1.Add(key:  "last_prog_timestamp", value:  "timestamp");
        val_1.Add(key:  "isEventShown", value:  "last_prog_timestamp");
        val_1.Add(key:  "nextTPLevel", value:  this.NextTPLevel);
        val_1.Add(key:  "categories", value:  MiniJSON.Json.Serialize(obj:  this.SelectedCategories));
        UnityEngine.PlayerPrefs.SetString(key:  this, value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public TriviaPursuitEventProgress()
    {
        this.NextTPLevel = App.Player;
    }

}
