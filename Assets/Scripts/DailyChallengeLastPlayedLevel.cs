using UnityEngine;
public class DailyChallengeLastPlayedLevel : DailyChallengeBasicLevel
{
    // Fields
    private const string pref_last_played_lvl = "DC_last_played_lvl";
    public int day;
    public string levelId;
    public float progress;
    public bool done;
    public bool isPersistentLevel;
    
    // Methods
    public DailyChallengeLastPlayedLevel(bool isMorning)
    {
        this = new Progression();
        System.DateTime val_2 = DateTimeCheat.Now;
        this.day = val_2.dateData.Day;
        mem[1152921517467236644] = isMorning;
        mem[1152921517467236640] = 0;
        this.progress = 0f;
        this.levelId = "1";
        this.done = true;
        this.isPersistentLevel = true;
    }
    public DailyChallengeLastPlayedLevel(int day, bool isMorning, string levelId, int stars, float progress, bool done, bool isPersistentLevel)
    {
        val_1 = new Progression();
        this.day = day;
        this.levelId = levelId;
        mem[1152921517467352736] = stars;
        this.progress = progress;
        mem[1152921517467352740] = isMorning;
        this.done = done;
        this.isPersistentLevel = isPersistentLevel;
    }
    public override void Save()
    {
        if(this.isPersistentLevel == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_1.Add(key:  "day", value:  this.day);
        val_1.Add(key:  "isMorning", value:  "day");
        val_1.Add(key:  "levelId", value:  this.levelId);
        val_1.Add(key:  "stars", value:  "levelId");
        val_1.Add(key:  "progress", value:  this.progress.ToString());
        val_1.Add(key:  "done", value:  this.done.ToString());
        UnityEngine.PlayerPrefs.SetString(key:  "DC_last_played_lvl", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_5 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Load()
    {
        var val_24;
        if(this.isPersistentLevel == false)
        {
                return;
        }
        
        val_24 = "";
        if((System.String.IsNullOrEmpty(value:  UnityEngine.PlayerPrefs.GetString(key:  "DC_last_played_lvl", defaultValue:  ""))) == true)
        {
                return;
        }
        
        object val_4 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "DC_last_played_lvl", defaultValue:  ""));
        if((val_4.ContainsKey(key:  "day")) != false)
        {
                this.day = System.Int32.Parse(s:  val_4.Item["day"]);
        }
        
        if((val_4.ContainsKey(key:  "isMorning")) != false)
        {
                mem[1152921517467685668] = System.Boolean.Parse(value:  val_4.Item["isMorning"]);
        }
        
        if((val_4.ContainsKey(key:  "levelId")) != false)
        {
                this.levelId = val_4.Item["levelId"];
        }
        
        if((val_4.ContainsKey(key:  "stars")) != false)
        {
                mem[1152921517467685664] = System.Int32.Parse(s:  val_4.Item["stars"]);
        }
        
        if((val_4.ContainsKey(key:  "progress")) != false)
        {
                this.progress = System.Single.Parse(s:  val_4.Item["progress"]);
        }
        
        val_24 = "done";
        if((val_4.ContainsKey(key:  "done")) == false)
        {
                return;
        }
        
        this.done = System.Boolean.Parse(value:  val_4.Item["done"]);
    }

}
