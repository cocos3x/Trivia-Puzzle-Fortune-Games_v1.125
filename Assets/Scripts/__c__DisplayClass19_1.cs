using UnityEngine;
private sealed class CategoryPackCompletionRewardPopup.<>c__DisplayClass19_1
{
    // Fields
    public decimal preCreditedValueCoins;
    public CategoryPackCompletionRewardPopup <>4__this;
    
    // Methods
    public CategoryPackCompletionRewardPopup.<>c__DisplayClass19_1()
    {
    
    }
    internal float <Initialize>b__3()
    {
        Player val_1 = App.Player;
        this.<>4__this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = this.preCreditedValueCoins, hi = this.preCreditedValueCoins, lo = -1372744736, mid = 268435458}, toValue:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
        return 2f;
    }

}
