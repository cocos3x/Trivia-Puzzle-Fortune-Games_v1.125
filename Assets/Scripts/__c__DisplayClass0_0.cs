using UnityEngine;
private sealed class WADGiftRewardManager.<>c__DisplayClass0_0
{
    // Fields
    public GiftReward reward;
    public System.Predicate<GiftReward> <>9__1;
    
    // Methods
    public WADGiftRewardManager.<>c__DisplayClass0_0()
    {
    
    }
    internal bool <MakeRewards>b__1(GiftReward x)
    {
        return (bool)(x.SubType_PetCard.Info.Name == this.reward.SubType_PetCard.Info.Name) ? 1 : 0;
    }

}
