using UnityEngine;

namespace PrizeBalloon
{
    public class Progress : EventProgression
    {
        // Fields
        private const string pref_prize_balloon = "prize_balloon";
        private const string key_levels_completed = "lvls_completed";
        private const string key_last_balloon_shown_time = "last_time";
        private const string key_daily_shown_times = "daily_shown_times";
        private const string key_track_balloon_appearance_in_level = "appearance_in_lvl";
        public int levelsCompletedThisSession;
        public System.DateTime lastBalloonShownTime;
        public int dailyShownTimes;
        public int balloonAppearedWithinLevel;
        
        // Methods
        public Progress()
        {
            this.levelsCompletedThisSession = 0;
            this.lastBalloonShownTime = 0;
            this.dailyShownTimes = 0;
            this.balloonAppearedWithinLevel = 0;
        }
        public override void LoadFromJSON()
        {
            if((UnityEngine.PlayerPrefs.HasKey(key:  "prize_balloon")) == false)
            {
                    return;
            }
            
            object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "prize_balloon"));
            if((val_3.ContainsKey(key:  "lvls_completed")) != false)
            {
                    bool val_7 = System.Int32.TryParse(s:  val_3.Item["lvls_completed"], result: out  this.levelsCompletedThisSession);
            }
            
            if((val_3.ContainsKey(key:  "last_time")) != false)
            {
                    bool val_10 = System.DateTime.TryParse(s:  val_3.Item["last_time"], result: out  new System.DateTime() {dateData = this.lastBalloonShownTime});
            }
            
            if((val_3.ContainsKey(key:  "daily_shown_times")) != false)
            {
                    bool val_14 = System.Int32.TryParse(s:  val_3.Item["daily_shown_times"], result: out  this.dailyShownTimes);
            }
            
            if((val_3.ContainsKey(key:  "appearance_in_lvl")) == false)
            {
                    return;
            }
            
            bool val_18 = System.Int32.TryParse(s:  val_3.Item["appearance_in_lvl"], result: out  this.balloonAppearedWithinLevel);
        }
        public override void SaveToJSON()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "lvls_completed", value:  this.levelsCompletedThisSession);
            val_1.Add(key:  "last_time", value:  this.lastBalloonShownTime.ToString());
            val_1.Add(key:  "daily_shown_times", value:  this.dailyShownTimes);
            val_1.Add(key:  "appearance_in_lvl", value:  this.balloonAppearedWithinLevel);
            UnityEngine.PlayerPrefs.SetString(key:  "prize_balloon", value:  MiniJSON.Json.Serialize(obj:  val_1));
            bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        }
    
    }

}
