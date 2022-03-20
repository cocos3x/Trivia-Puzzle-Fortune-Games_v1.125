using UnityEngine;
public class FPHStarsManager : GoldenApplesManager
{
    // Methods
    public override void CreditBalance(int earnedAmount, string source, bool ignoreSubscriptionBonus = False, string subSource, bool skipTrack = False, System.Collections.Generic.Dictionary<string, object> additionalParam)
    {
        System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        if(additionalParam == null)
        {
            goto label_18;
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_3 = additionalParam.Keys.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_1.Add(key:  0, value:  additionalParam.Item[0]);
        goto label_5;
        label_3:
        0.Dispose();
        label_18:
        App.Player.stars = earnedAmount + val_6._stars;
        if(((System.String.IsNullOrEmpty(value:  source)) != true) && (skipTrack != true))
        {
                App.Player.TrackNonCoinReward(source:  source, subSource:  subSource, rewardType:  "Stars", rewardAmount:  earnedAmount.ToString(), additionalParams:  val_1);
        }
        
        GoldenApplesManager.OnAppleAwarded.Invoke(obj:  earnedAmount);
    }
    public FPHStarsManager()
    {
    
    }

}
