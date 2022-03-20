using UnityEngine;
private sealed class CategoryPackCompletionRewardPopup.<>c__DisplayClass19_2
{
    // Fields
    public int preCreditedValueGolden;
    public CategoryPackCompletionRewardPopup <>4__this;
    
    // Methods
    public CategoryPackCompletionRewardPopup.<>c__DisplayClass19_2()
    {
    
    }
    internal float <Initialize>b__4()
    {
        Player val_1 = App.Player;
        decimal val_2 = System.Decimal.op_Implicit(value:  val_1._stars);
        this.<>4__this.goldenAnimControl.Play(fromValue:  this.preCreditedValueGolden, toValue:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
        return 2f;
    }

}
