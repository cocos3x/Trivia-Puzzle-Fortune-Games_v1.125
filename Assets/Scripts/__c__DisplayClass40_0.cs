using UnityEngine;
private sealed class LeaguesDataController.<>c__DisplayClass40_0
{
    // Fields
    public int points;
    public SLC.Social.Leagues.LeaguesDataController <>4__this;
    
    // Methods
    public LeaguesDataController.<>c__DisplayClass40_0()
    {
    
    }
    internal void <ContributePoints>b__0(System.Collections.Generic.Dictionary<string, object> responseObject)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = responseObject;
        SLC.Social.Leagues.LeaguesTracker.AddLeaguePointsContributionFromSlots(leaguePoints:  this.points);
        SLC.Social.Leagues.LeaguesManager.RemoveCachedGC();
        if((val_4.ContainsKey(key:  "reward")) == false)
        {
                return;
        }
        
        val_4 = val_4.Item["reward"];
        decimal val_3 = System.Decimal.Parse(s:  val_4);
        this.<>4__this.DailyRewardAmount = val_3;
        mem2[0] = val_3.lo;
        mem[4] = val_3.mid;
    }

}
