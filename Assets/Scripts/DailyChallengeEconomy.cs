using UnityEngine;
public class DailyChallengeEconomy
{
    // Fields
    public int RequiredMonthlyStars;
    public int RequiredWeeklyStars;
    public DailyChallenge_RetryCosts RetryCosts;
    public DailyChallengeDefinition ChallengeDefinition;
    public StarTiers StarTiers;
    public DailyChallengeV5_ZooTiles ZooTiles;
    
    // Methods
    public DailyChallengeEconomy(System.Collections.Generic.Dictionary<string, object> sourceData)
    {
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        this.RetryCosts = new DailyChallenge_RetryCosts();
        this.ZooTiles = new DailyChallengeV5_ZooTiles();
        if((sourceData.ContainsKey(key:  "retry_costs")) != false)
        {
                object val_4 = sourceData.Item["retry_costs"];
            val_17 = 0;
            this.RetryCosts.Decode(jasonObject:  null, sourceModel:  0);
        }
        
        if((sourceData.ContainsKey(key:  "required_monthly_stars")) != false)
        {
                this.RequiredMonthlyStars = System.Int32.Parse(s:  sourceData.Item["required_monthly_stars"]);
        }
        
        if((sourceData.ContainsKey(key:  "required_weekly_stars")) != false)
        {
                this.RequiredWeeklyStars = System.Int32.Parse(s:  sourceData.Item["required_weekly_stars"]);
        }
        
        if((sourceData.ContainsKey(key:  "challenge_definition")) != false)
        {
                object val_12 = sourceData.Item["challenge_definition"];
            val_18 = 0;
            new DailyChallengeDefinition() = new DailyChallengeDefinition(sourceData:  null);
            this.ChallengeDefinition = new DailyChallengeDefinition();
        }
        
        val_19 = "star_tiers";
        if((sourceData.ContainsKey(key:  "star_tiers")) == false)
        {
                return;
        }
        
        val_19 = sourceData.Item["star_tiers"];
        val_20 = 0;
        new StarTiers() = new StarTiers(sourceData:  null);
        this.StarTiers = new StarTiers();
    }

}
