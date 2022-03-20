using UnityEngine;
public class TRVStarsManager : MonoSingleton<TRVStarsManager>
{
    // Fields
    public static System.Action<int> OnStarAwarded;
    
    // Methods
    public void AwardStar(int earnedAmount, string source, string subSource, System.Collections.Generic.Dictionary<string, object> additionalParam)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_12 = additionalParam;
        if(val_12 == null)
        {
                System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_12 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        
        val_1.Add(key:  "Base Award", value:  earnedAmount);
        if((DefaultHandler<WGBonusRewardsHandler>.Instance) != 0)
        {
                decimal val_5 = DefaultHandler<WGBonusRewardsHandler>.Instance.GetBonusStars(starsBeingRewarded:  earnedAmount);
            int val_6 = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid});
            if(val_6 != 0)
        {
                val_1.Add(key:  "Bonus Level Bonus", value:  val_6);
            int val_12 = earnedAmount;
            val_12 = val_12 + val_6;
        }
        
        }
        
        App.Player.stars = val_12 + val_7._stars;
        TRVStarsManager.OnStarAwarded.Invoke(obj:  val_12);
        if((System.String.IsNullOrEmpty(value:  source)) == true)
        {
                return;
        }
        
        App.Player.TrackNonCoinReward(source:  source, subSource:  subSource, rewardType:  "Stars", rewardAmount:  val_12.ToString(), additionalParams:  val_1);
    }
    public TRVStarsManager()
    {
    
    }

}
