using UnityEngine;
private sealed class WFOMysteryChestDisplay.<>c__DisplayClass86_0
{
    // Fields
    public WordForest.WFOMysteryChestDisplay <>4__this;
    public int completedItemSeq;
    public DG.Tweening.TweenCallback <>9__8;
    public DG.Tweening.TweenCallback <>9__9;
    public System.Func<bool> <>9__10;
    
    // Methods
    public WFOMysteryChestDisplay.<>c__DisplayClass86_0()
    {
    
    }
    internal void <DoOpenChestAnimationSequence>b__8()
    {
        if((this.<>4__this) != null)
        {
                this.<>4__this.ToggleTapToOpenLabel(isVisible:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    internal void <DoOpenChestAnimationSequence>b__9()
    {
        int val_1 = this.completedItemSeq;
        val_1 = val_1 + 1;
        this.completedItemSeq = val_1;
    }
    internal bool <DoOpenChestAnimationSequence>b__10()
    {
        if((this.<>4__this) != null)
        {
                return (bool)((this.<>4__this.isAwaitingPlayerInputForItems) == false) ? 1 : 0;
        }
        
        throw new NullReferenceException();
    }
    internal bool <DoOpenChestAnimationSequence>b__0()
    {
        return (bool)(this.completedItemSeq >= (this.<>4__this.rewardItems)) ? 1 : 0;
    }

}
