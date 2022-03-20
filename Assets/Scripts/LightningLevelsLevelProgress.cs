using UnityEngine;
public class LightningLevelsLevelProgress : LightningLevelProgress
{
    // Properties
    protected override string pref_lvl_prg { get; }
    
    // Methods
    protected override string get_pref_lvl_prg()
    {
        return "ll_evt_lvl_prg";
    }
    public override void LoadFromJSON()
    {
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  this, defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
        if((val_3.ContainsKey(key:  "game_mode")) != false)
        {
                object val_7 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_3.Item["game_mode"]);
            mem[1152921516503751024] = null;
        }
        
        if((val_3.ContainsKey(key:  "countdown_sec")) != false)
        {
                mem[1152921516503751036] = System.Int32.Parse(s:  val_3.Item["countdown_sec"]);
        }
        
        if((val_3.ContainsKey(key:  "lightning_striken")) != false)
        {
                mem[1152921516503751048] = System.Boolean.Parse(value:  val_3.Item["lightning_striken"]);
        }
        
        if((val_3.ContainsKey(key:  "lightning_tooltip")) != false)
        {
                bool val_18 = System.Boolean.TryParse(value:  val_3.Item["lightning_tooltip"], result: out  1152921516503751049);
        }
        
        if((val_3.ContainsKey(key:  "category_level")) == false)
        {
                return;
        }
        
        mem[1152921516503751032] = System.Int32.Parse(s:  val_3.Item["category_level"]);
    }
    public override void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        mem[1152921516503930608] = null;
        val_1.Add(key:  "game_mode", value:  ToString());
        val_1.Add(key:  "countdown_sec", value:  "game_mode");
        val_1.Add(key:  "lightning_striken", value:  "countdown_sec");
        val_1.Add(key:  "lightning_tooltip", value:  "lightning_striken");
        val_1.Add(key:  "category_level", value:  "lightning_tooltip");
        UnityEngine.PlayerPrefs.SetString(key:  this, value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public override void Delete()
    {
        this.DeleteKey(key:  this);
    }
    public LightningLevelsLevelProgress()
    {
        mem[1152921516504185328] = 1;
        mem[1152921516504185340] = 0;
        val_1 = new EventProgression();
    }

}
