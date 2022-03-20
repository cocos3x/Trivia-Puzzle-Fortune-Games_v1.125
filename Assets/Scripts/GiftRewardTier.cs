using UnityEngine;
public class GiftRewardTier : DailyBonusTier
{
    // Fields
    public string threshold;
    public System.Collections.Generic.List<object> rewards;
    
    // Methods
    public GiftRewardTier()
    {
    
    }
    public GiftRewardTier(string threshold, System.Collections.Generic.List<object> rewards)
    {
        this.threshold = threshold;
        this.rewards = rewards;
    }
    public override string ToString()
    {
        return System.String.Format(format:  "threshold {0} rewards {1}", arg0:  this.threshold, arg1:  PrettyPrint.printJSON(obj:  this.rewards, types:  false, singleLineOutput:  false));
    }

}
