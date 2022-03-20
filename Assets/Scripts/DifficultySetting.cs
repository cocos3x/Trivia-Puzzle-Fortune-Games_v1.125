using UnityEngine;
public class DifficultySetting
{
    // Fields
    private const string PREF_DIFFICULTY_SETTING = "difficulty_setting";
    private const string KEY_MODE = "mode";
    private const string KEY_STARTING_LEVEL = "starting_level";
    private const string KEY_FEATURE_STATUS = "feature_status";
    public DifficultyMode Mode;
    public int StartingLevel;
    public DifficultySettingFeatureStatus FeatureStatus;
    
    // Methods
    public DifficultySetting()
    {
        this.Mode = 0;
        .Prompted = false;
        .IsFtuxSeen = false;
        .IsFtuxLevel = false;
        this.FeatureStatus = new DifficultySettingFeatureStatus();
    }
    public void LoadFromJSON()
    {
        DifficultySettingFeatureStatus val_19;
        DifficultySettingFeatureStatus val_20;
        string val_21;
        val_19 = this;
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "difficulty_setting", defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) == true)
        {
                return;
        }
        
        object val_3 = MiniJSON.Json.Deserialize(json:  val_1);
        val_20 = 1152921504685600768;
        if((val_3.ContainsKey(key:  "mode")) != false)
        {
                object val_7 = System.Enum.Parse(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  val_3.Item["mode"]);
            this.Mode = null;
        }
        
        if((val_3.ContainsKey(key:  "starting_level")) != false)
        {
                this.StartingLevel = System.Int32.Parse(s:  val_3.Item["starting_level"]);
        }
        
        val_21 = "feature_status";
        if((val_3.ContainsKey(key:  "feature_status")) == false)
        {
                return;
        }
        
        object val_12 = val_3.Item["feature_status"];
        val_20 = this.FeatureStatus;
        val_21 = val_12.Item["feature_prompted"];
        this.FeatureStatus.Prompted = System.Boolean.Parse(value:  val_21);
        val_19 = this.FeatureStatus;
        this.FeatureStatus.IsFtuxSeen = System.Boolean.Parse(value:  val_12.Item["feature_isFtuxSeen"]);
    }
    public void SaveToJSON()
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        mem2[0] = this.Mode;
        val_1.Add(key:  "mode", value:  this.Mode.ToString());
        val_1.Add(key:  "starting_level", value:  this.StartingLevel);
        System.Collections.Generic.Dictionary<System.String, System.Object> val_3 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_3.Add(key:  "feature_prompted", value:  this.FeatureStatus.Prompted);
        val_3.Add(key:  "feature_isFtuxSeen", value:  this.FeatureStatus.IsFtuxSeen);
        val_1.Add(key:  "feature_status", value:  val_3);
        UnityEngine.PlayerPrefs.SetString(key:  "difficulty_setting", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_5 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public void Update(DifficultyMode mode, int startingLevel)
    {
        this.Mode = mode;
        this.StartingLevel = startingLevel;
        this.SaveToJSON();
    }

}
