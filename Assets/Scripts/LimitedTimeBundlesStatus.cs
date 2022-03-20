using UnityEngine;
public class LimitedTimeBundlesStatus : EventProgression
{
    // Fields
    private const string PREF_STATUS = "ltb_status";
    private const string PREF_LEGACY_POPUP_LVL = "ltb_popup_lvl";
    private const string KEY_CURRENT_OFFER_END_TIME = "end";
    private const string KEY_POPUP_LVL = "lvl";
    private const string KEY_SHOWN_TIMES = "shown";
    public System.DateTime CurrentOfferEndTime;
    public int LevelsSincePopupShown;
    public int TimesPopupShown;
    
    // Methods
    public override void LoadFromJSON()
    {
        string val_19;
        string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "ltb_status", defaultValue:  "");
        if((System.String.IsNullOrEmpty(value:  val_1)) != false)
        {
                if((UnityEngine.PlayerPrefs.HasKey(key:  "ltb_popup_lvl")) != false)
        {
                this.LevelsSincePopupShown = UnityEngine.PlayerPrefs.GetInt(key:  "ltb_popup_lvl", defaultValue:  0);
        }
        
            UnityEngine.PlayerPrefs.DeleteKey(key:  "ltb_popup_lvl");
            return;
        }
        
        object val_5 = MiniJSON.Json.Deserialize(json:  val_1);
        if((val_5.ContainsKey(key:  "end")) != false)
        {
                val_19 = val_5.Item["end"];
            bool val_8 = System.DateTime.TryParse(s:  val_19, result: out  new System.DateTime() {dateData = this.CurrentOfferEndTime});
            System.DateTime val_9 = DateTimeCheat.Now;
            if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_9.dateData}, t2:  new System.DateTime() {dateData = this.CurrentOfferEndTime})) == true)
        {
                return;
        }
        
        }
        
        if((val_5.ContainsKey(key:  "lvl")) != false)
        {
                bool val_14 = System.Int32.TryParse(s:  val_5.Item["lvl"], result: out  this.LevelsSincePopupShown);
        }
        
        val_19 = "shown";
        if((val_5.ContainsKey(key:  "shown")) == false)
        {
                return;
        }
        
        bool val_18 = System.Int32.TryParse(s:  val_5.Item["shown"], result: out  this.TimesPopupShown);
    }
    public override void SaveToJSON()
    {
        System.DateTime val_9;
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<LimitedTimeBundlesManager>.Instance)) != false)
        {
                System.DateTime val_5 = MonoSingleton<LimitedTimeBundlesManager>.Instance.GetCurrentOfferEndTime();
        }
        else
        {
                val_9 = this.CurrentOfferEndTime;
        }
        
        val_1.Add(key:  "end", value:  val_9.ToString());
        val_1.Add(key:  "lvl", value:  this.LevelsSincePopupShown);
        val_1.Add(key:  "shown", value:  this.TimesPopupShown);
        UnityEngine.PlayerPrefs.SetString(key:  "ltb_status", value:  MiniJSON.Json.Serialize(obj:  val_1));
        bool val_8 = PrefsSerializationManager.SavePlayerPrefs();
    }
    public LimitedTimeBundlesStatus()
    {
    
    }

}
