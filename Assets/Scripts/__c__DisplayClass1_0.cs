using UnityEngine;
private sealed class WADGiftRewardManager.<>c__DisplayClass1_0
{
    // Fields
    public GiftReward reward;
    
    // Methods
    public WADGiftRewardManager.<>c__DisplayClass1_0()
    {
    
    }
    internal bool <GetRewards>b__3(GiftReward x)
    {
        return (bool)(x.SubType_PetCard == this.reward.SubType_PetCard) ? 1 : 0;
    }

}
