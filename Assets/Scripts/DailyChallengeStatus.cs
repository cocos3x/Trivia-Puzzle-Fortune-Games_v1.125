using UnityEngine;
public class DailyChallengeStatus : Progression
{
    // Fields
    private const string pref_oa_date = "DailyChallengeOADate";
    public int playingMonth;
    public int playingDay;
    public bool playingDayMorning;
    public bool playingPersistentLevel;
    public int todayOnCalendar;
    public DailyChallengeLastPlayedLevel lastPlayedLevel;
    public double oa_date;
    private int today;
    private int thisMonth;
    
    // Methods
    public DailyChallengeStatus(bool isMorning)
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        this.today = val_1.dateData.Day;
        System.DateTime val_3 = DateTimeCheat.Now;
        this.thisMonth = val_3.dateData.Month;
        this.playingDayMorning = true;
        this.playingPersistentLevel = false;
        this.todayOnCalendar = this.today;
        this.playingMonth = this.thisMonth;
        this.playingDay = this.today;
        this.lastPlayedLevel = new DailyChallengeLastPlayedLevel(isMorning:  isMorning);
        this.oa_date = 0;
    }
    public override void Load()
    {
        if(this.playingDay != this.today)
        {
                return;
        }
        
        this.oa_date = System.Convert.ToDouble(value:  UnityEngine.PlayerPrefs.GetString(key:  "DailyChallengeOADate", defaultValue:  ""));
    }
    public override void Save()
    {
        if(this.playingDay != this.today)
        {
                return;
        }
        
        UnityEngine.PlayerPrefs.SetString(key:  "DailyChallengeOADate", value:  this.oa_date.ToString());
        bool val_2 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
