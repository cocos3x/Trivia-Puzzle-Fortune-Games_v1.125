using UnityEngine;
public class TRVQotdEcon
{
    // Fields
    public int unlockLevel;
    public TRVReward normalReward;
    public TRVReward bonusReward;
    
    // Methods
    public TRVQotdEcon()
    {
        this.unlockLevel = 6;
        this.normalReward = new TRVReward(rewardType:  0, rewardAmount:  40);
        this.bonusReward = new TRVReward(rewardType:  1, rewardAmount:  20);
    }

}
