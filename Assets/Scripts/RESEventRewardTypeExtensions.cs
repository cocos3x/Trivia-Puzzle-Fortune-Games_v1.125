using UnityEngine;
public static class RESEventRewardTypeExtensions
{
    // Methods
    public static GameEventRewardType ToGameEventRewardType(RESEventRewardType rewardType)
    {
        if((rewardType - 1) > 3)
        {
                return 0;
        }
        
        return (GameEventRewardType)32556688 + ((rewardType - 1)) << 2;
    }

}
