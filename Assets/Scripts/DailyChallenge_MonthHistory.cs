using UnityEngine;
public class DailyChallenge_MonthHistory
{
    // Fields
    public int stars;
    public string tile;
    public System.Collections.Generic.Dictionary<string, DailyChallenge_DayProgress> progress;
    
    // Methods
    public DailyChallenge_MonthHistory()
    {
        this.tile = "";
        this.progress = new System.Collections.Generic.Dictionary<System.String, DailyChallenge_DayProgress>();
    }

}
