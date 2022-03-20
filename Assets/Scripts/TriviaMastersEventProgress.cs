using UnityEngine;
public class TriviaMastersEventProgress : TRVEventProgression
{
    // Fields
    private const string KEY_TOKENS = "tokens";
    private const string KEY_NEXT_LEVEL = "nextTMLevel";
    public int Tokens;
    public int NextTMLevel;
    public string SelectedCategory;
    public bool IsPlayingTMQuiz;
    
    // Properties
    protected override string PREF_EVENT_PROG { get; }
    
    // Methods
    protected override string get_PREF_EVENT_PROG()
    {
        return "trv_masters_evt_prg";
    }
    public override void LoadFromJSON()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  this)) == false)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  this));
        if((val_3.ContainsKey(key:  "timestamp")) != false)
        {
                bool val_7 = System.Int32.TryParse(s:  val_3.Item["timestamp"], result: out  1152921517415846128);
        }
        
        if((val_3.ContainsKey(key:  "last_prog_timestamp")) != false)
        {
                bool val_11 = System.Int32.TryParse(s:  val_3.Item["last_prog_timestamp"], result: out  1152921517415846132);
        }
        
        if((val_3.ContainsKey(key:  "tokens")) != false)
        {
                bool val_15 = System.Int32.TryParse(s:  val_3.Item["tokens"], result: out  this.Tokens);
        }
        
        if((val_3.ContainsKey(key:  "nextTMLevel")) != false)
        {
                bool val_19 = System.Int32.TryParse(s:  val_3.Item["nextTMLevel"], result: out  this.NextTMLevel);
        }
        
        if((val_3.ContainsKey(key:  "isEventShown")) == false)
        {
                return;
        }
        
        bool val_23 = System.Boolean.TryParse(value:  val_3.Item["isEventShown"], result: out  1152921517415846136);
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "timestamp", value:  1152921510196879024);
        val_1.Add(key:  "last_prog_timestamp", value:  "timestamp");
        val_1.Add(key:  "tokens", value:  this.Tokens);
        val_1.Add(key:  "nextTMLevel", value:  this.NextTMLevel);
        val_1.Add(key:  "isEventShown", value:  "nextTMLevel");
        UnityEngine.PlayerPrefs.SetString(key:  this, value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        UnityEngine.PlayerPrefs.DeleteKey(key:  this);
    }
    public TriviaMastersEventProgress()
    {
        this.NextTMLevel = App.Player;
    }

}
