using UnityEngine;
public class DailyChallenge_WeekHistory
{
    // Fields
    public int stars;
    public System.Collections.Generic.Dictionary<string, DailyChallenge_DayProgress> progress;
    
    // Methods
    public DailyChallenge_WeekHistory()
    {
        this.progress = new System.Collections.Generic.Dictionary<System.String, DailyChallenge_DayProgress>();
    }

}
