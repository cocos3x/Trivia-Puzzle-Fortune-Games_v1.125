using UnityEngine;
private sealed class WGDailyChallengeManager.<>c__DisplayClass139_0
{
    // Fields
    public int todayOnCalendar;
    
    // Methods
    public WGDailyChallengeManager.<>c__DisplayClass139_0()
    {
    
    }
    internal bool <GetMatchingDayDistance>b__0(System.Collections.Generic.KeyValuePair<string, DailyChallenge_DayProgress> x)
    {
        return (bool)((System.Int32.Parse(s:  x.Value)) < this.todayOnCalendar) ? 1 : 0;
    }

}
